﻿using Dapper;

using JR.CodeGenerator.Models;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Globalization;
using JR.CodeGenerator.Extensions;

namespace JR.CodeGenerator.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <autogeneratedoc />
    public class ClaseMetodos
    {
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClaseMetodos"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <autogeneratedoc />
        public ClaseMetodos(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Gets the campos.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        /// <autogeneratedoc />
        public async Task<string> GetCampos(string query, bool toTitleCase)
        {
            string result = string.Empty;
            DataTable dt = new DataTable();
            var into = Environment.NewLine;
            using (var db = new SqlConnection(_connectionString))
            {
                //await db.OpenAsync();

                var resultData = await db.QueryAsync<InfoCampo>(query);

                foreach (var item in resultData)
                {
                    result += "\t\t ///<summary> "; //+ into;
                    //result += "\t\t /// ";
                    string s = item.Column_Name;
                    string p = Regex.Replace(s, "([a-z](?=[A-Z0-9])|[A-Z](?=[A-Z][a-z]))", "$1 ").ToString();
                    result += "Gets or sets the " + p;

                    if (!string.IsNullOrEmpty( item.Campo_Descripcion))
                    {
                        result +=  into;
                        result += "\t\t /// ";
                        result += item.Campo_Descripcion.Trim().Replace("\r\n", "\r\n \t\t  ///");

                    }
                    //result += into;
                    // result += "\t\t ///</summary> " + into;
                    result += " </summary> " + into;

                    string campo = toTitleCase ? CultureInfo.CurrentCulture.TextInfo.ToTitleCase(item.Column_Name) : item.Column_Name.UpperFirstChar();

                    result += $"\t\tpublic {clsSQLToCsharp.SQLToCsharp(item.Data_Type)} {campo} ";
                    
                    result += "{get;set;}" + into;
                    //result += clsSQLToCsharp.DefaultValue(item.Data_Type);//TODO: Validar si colocarlo
                }

            }


            return result;
        }


    }
}
