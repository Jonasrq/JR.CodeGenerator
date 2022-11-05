﻿using System.Security.Policy;

namespace JR.CodeGenerator.Models;

/// <summary>
/// 
/// </summary>
public class DataGeneral
{
    /// <summary>
    /// Gets or sets the empresa.
    /// </summary>
    /// <value>
    /// The empresa.
    /// </value>
    /// <autogeneratedoc />
    public string Empresa { get; set; }
    /// <summary>
    /// Gets or sets the autor.
    /// </summary>
    /// <value>
    /// The autor.
    /// </value>
    /// <autogeneratedoc />
    public string Autor { get; set; }
    /// <summary>
    /// Gets or sets the name space.
    /// </summary>
    /// <value>
    /// The name space.
    /// </value>
    /// <autogeneratedoc />
    public string NameSpace { get; set; }

    /// <summary>
    /// Gets or sets the path.
    /// </summary>
    /// <value>
    /// The path.
    /// </value>
    /// <autogeneratedoc />
    public string Path { get; set; }
    

    /// <summary>
    /// Converts to titlecase.
    /// </summary>
    /// <value>
    ///   <c>true</c> if [to title case]; otherwise, <c>false</c>.
    /// </value>
    /// <autogeneratedoc />
    public bool ToTitleCase { get; set; }

    /// <summary>
    /// Gets or sets the name of the table.
    /// </summary>
    /// <value>
    /// The name of the table.
    /// </value>
    /// <autogeneratedoc />
    public string TableName { get; set; }

    /// <summary>
    /// Gets or sets the table vista.
    /// </summary>
    /// <value>
    /// The table vista.
    /// </value>
    /// TODO Edit XML Comment Template for TableVista
    public string TableVista { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is dapper.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is dapper; otherwise, <c>false</c>.
    /// </value>
    public bool IsDapper { get; set; }

    /// <summary>
    /// Gets the full path.
    /// </summary>
    /// <value>
    /// The full path.
    /// </value>
    /// TODO Edit XML Comment Template for FullPath
    public string FullPath { get => $@"{Path}\{TableVista}"; }
}
