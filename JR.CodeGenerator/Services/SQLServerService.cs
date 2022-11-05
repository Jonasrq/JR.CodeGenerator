﻿using JR.CodeGenerator.Extensions;
using JR.CodeGenerator.Models;

using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Text;

/// <summary>
/// 
/// </summary>
/// <autogeneratedoc />
namespace JR.CodeGenerator.Services;

/// <summary>
/// SQL Server Service
/// </summary>
/// <seealso cref="JR.CodeGenerator.Services.ISQLServerService" />
public class SQLServerService : ISQLServerService
{
    /// <summary>
    /// The data connection
    /// </summary>
    public DataConnection _dataConnection;
    public DataGeneral _dataGeneral;
    /// <summary>
    /// Gets the connection string.
    /// </summary>
    /// <returns></returns>
    private string GetConnectionString
    {
        get
        {
            string conexionString = $"Data Source={_dataConnection.ServerName};Initial Catalog={_dataConnection.DataBase};TrustServerCertificate=True;";

            if (_dataConnection.IsIntegrateSecurity)
                conexionString += "Integrated Security=True;";
            else
                conexionString += $"User ID={_dataConnection.UserName}; Password={_dataConnection.Password};";

            return conexionString;
        }
    }


    /// <summary>
    /// Gets the data basese2 async.
    /// </summary>
    /// <param name="dataConnection">The data connection.</param>
    /// <returns>
    /// A Task.
    /// </returns>
    public async Task<List<DataBase>> GetDataBaseseAsync(DataConnection dataConnection)
    {
        _dataConnection = dataConnection;

        return await GetDataBases();
    }

    /// <summary>
    /// Gets the datbles vistas.
    /// </summary>
    /// <param name="treeViewDataBases">The tree view data bases.</param>
    /// <autogeneratedoc />
    public async Task<List<TableView>> GetDatblesVistasAsync(DataConnection dataConnection)
    {
        _dataConnection = dataConnection;

        List<TableView> list = new List<TableView>()
        {
           new TableView(){Name = "Tablas", ImageUri = "/Images/folder.png"},
           new TableView(){Name = "Vistas", ImageUri = "/Images/folder.png"}
        };

        using (var db = new SqlConnection(GetConnectionString))
        {
            await db.OpenAsync();
            var dataTables = await db.GetSchemaAsync("Tables");

            foreach (DataRow dataTable in dataTables.Rows)
            {
                string squema = "Tablas";
                string imageUri = "/Images/table.png";
                if (dataTable["TABLE_TYPE"].ToString() == "VIEW")
                {
                    squema = "Vistas";
                    imageUri = "/Images/view.png";
                }

                TableView children = new TableView()
                {
                    Schema = dataTable["TABLE_SCHEMA"].ToString(),
                    Name = dataTable["TABLE_NAME"].ToString(),
                    ImageUri = imageUri,
                };

                list.Where(x => x.Name == squema).First().Children.Add(children);
            }
        }

        var list2 = new List<TableView>();

        foreach (var item in list)
        {
            list2.Add(new TableView()
            {
                Name = item.Name,
                ImageUri = item.ImageUri,
                Schema = item.Schema,
                Children = item.Children.OrderBy(x => x.Schema).OrderBy(x => x.Name).ToList()
            });
        }

        return list2;
    }

    /// <summary>
    /// Generates the code.
    /// </summary>
    /// <param name="dataConnection">The data connection.</param>
    /// <param name="dataGeneral">The data general.</param>
    /// <autogeneratedoc />
    public async Task GenerateCode(DataConnection conct, DataGeneral general)
    {
        _dataConnection = conct;
        _dataGeneral = general;
        var createClass = new ClaseMetodos(GetConnectionString);
        string _tableNameClass = general.TableName.ToLower().ToTitleCase();



        string queryCampoosTabla = await ReadFile("InfoCamposTablas.txt");
        queryCampoosTabla = queryCampoosTabla.Replace("$TableName$", _tableNameClass);

        string camposClessTemp = await createClass.GetFields(queryCampoosTabla, general.ToTitleCase);

        string entityTemp = await ReadFile("ClaseEntidad.txt");
        entityTemp = entityTemp.Replace("$TablaVista$", general.TableVista)
                               .Replace("$TableName$", _tableNameClass)
                               .Replace("$EspacioNombre$", general.NameSpace);
        entityTemp = entityTemp.Replace("#Propiedades#", camposClessTemp)
                               .Replace("#Empresa#", general.Empresa)
                               .Replace("#Autor#", general.Autor)
                               .Replace("#Fecha#", DateTime.Now.ToString("dd/MM/yyyy"));

        string pathCless = System.IO.Path.Combine(general.FullPath, _tableNameClass + ".cs");
        await WriteFile(pathCless, entityTemp);


        if (_dataGeneral.IsDapper)
        {
            string _templete = string.Empty;
            string _templete2 = string.Empty;
            _dataGeneral.TableVista = "Services";
            _templete = await ReadFile("DapperServiceEntities.txt");
            _templete = _templete.Replace("$EspacioNombre$", general.NameSpace)
                                 .Replace("$TableName$", _tableNameClass);

           
            _templete2 = await createClass.GetFieldsInsert(queryCampoosTabla);         
            _templete = _templete.Replace("$FieldssInsert$", _templete2);


            _templete2 = await createClass.GetFieldsUpdate(queryCampoosTabla);
            _templete = _templete.Replace("$FieldsUpdate$", _templete2);


            _templete2 = await createClass.GetFieldsPrimaryKey(queryCampoosTabla);
            _templete = _templete.Replace("$Clave_Primaria$", _templete2);


            pathCless = System.IO.Path.Combine(general.FullPath, $"{_tableNameClass}Service.cs");

            await WriteFile(pathCless, _templete);
        }


    }

    /// <summary>
    /// Generates the code base.
    /// </summary>
    /// <param name="general">The general.</param>
    public async Task GenerateCodeBase(DataGeneral general)
    {
        string _templete = string.Empty;
        string _pathCless = string.Empty;
        _dataGeneral = general;

        if (_dataGeneral.IsDapper)
        {
            _dataGeneral.TableVista = "Repositories";
            _templete = await ReadFile("DapperRepositoryBase.txt");
            _templete = _templete.Replace("$EspacioNombre$", general.NameSpace);
            _pathCless = System.IO.Path.Combine(general.FullPath, "RepositoryBase.cs");
            await WriteFile(_pathCless, _templete);

            _templete = await ReadFile("DapperRepository.txt");
            _templete = _templete.Replace("$EspacioNombre$", general.NameSpace);
            _pathCless = System.IO.Path.Combine(general.FullPath, "Repository.cs");
            await WriteFile(_pathCless, _templete);


            _templete = await ReadFile("DapperRepositoryCustomer.txt");
            _templete = _templete.Replace("$EspacioNombre$", general.NameSpace);
            _pathCless = System.IO.Path.Combine(general.FullPath, "RepositoryCustomer.cs");
            await WriteFile(_pathCless, _templete);
        }
        else
        {
            _dataGeneral.TableVista = "";
            _templete = await ReadFile("ExtensionsDataTable.txt");
            _templete = _templete.Replace("$EspacioNombre$", general.NameSpace);
            _pathCless = System.IO.Path.Combine(general.FullPath, "ExtensionsDataTable.cs");
            await WriteFile(_pathCless, _templete);
        }

        _dataGeneral.TableVista = "";
        _templete = await ReadFile("ExtensionsConvert.txt");
        _templete = _templete.Replace("$EspacioNombre$", general.NameSpace);
        _pathCless = System.IO.Path.Combine(general.FullPath, "ExtensionsConvert.cs");
        await WriteFile(_pathCless, _templete);

    }

    /// <summary>
    /// Gets the data bases2.
    /// </summary>
    /// <returns></returns>
    private async Task<List<DataBase>> GetDataBases()
    {
        List<DataBase> list = new List<DataBase>();
        list.Add(new DataBase(0, "--Base de Datos--"));
        using (var db = new SqlConnection(GetConnectionString))
        {
            await db.OpenAsync();
            var dataBases = await db.GetSchemaAsync("DataBases");

            foreach (DataRow dataBase in dataBases.Rows)
            {
                if ((Int16)dataBase["dbid"] > 4)
                {
                    list.Add(new DataBase((Int16)dataBase["dbid"], dataBase["database_name"].ToString()));
                }
            }
        }

        return list.OrderBy(x => x.Name).ToList();
    }

    /// <summary>
    /// Geras the entidad.
    /// </summary>
    private async Task GeraEntidad()
    {
        await Task.Delay(100);
    }

    /// <summary>
    /// Reads the file.
    /// </summary>
    /// <param name="file">The file.</param>
    /// <returns></returns>
    /// <autogeneratedoc />
    private async Task<string> ReadFile(string file)
    {
        string result = string.Empty;
        string path = System.IO.Path.Combine(Environment.CurrentDirectory, "Template", file);
        result = await File.ReadAllTextAsync(path, Encoding.UTF8);
        return result;
    }

    /// <summary>
    /// Writes the file.
    /// </summary>
    /// <param name="pathDocuName">Name of the path docu.</param>
    /// <param name="document">The document.</param>
    /// <autogeneratedoc />
    private async Task WriteFile(string pathDocuName, string document)
    {
        if (!Directory.Exists(_dataGeneral.FullPath))
            Directory.CreateDirectory(_dataGeneral.FullPath);

        await File.WriteAllTextAsync(pathDocuName, document, Encoding.UTF8);
    }

}


