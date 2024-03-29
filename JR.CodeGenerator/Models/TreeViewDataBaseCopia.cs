﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JR.CodeGenerator.Models;



/// <summary>
/// 
/// </summary>
/// <autogeneratedoc />
public class TablesVistas
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TablesVistas"/> class.
    /// </summary>
    /// <autogeneratedoc />
    public TablesVistas()
    {
        Tables = new List<TablesVistas>();
    }
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    /// <autogeneratedoc />
    public string Name { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="TablesVistas"/> is selected.
    /// </summary>
    /// <value>
    ///   <c>true</c> if selected; otherwise, <c>false</c>.
    /// </value>
    /// <autogeneratedoc />
    public bool Selected { get; set; }
    /// <summary>
    /// Gets or sets the tables.
    /// </summary>
    /// <value>
    /// The tables.
    /// </value>
    /// <autogeneratedoc />
    public List<TablesVistas> Tables { get; set; }
}

/// <summary>
/// 
/// </summary>
/// <seealso cref="JR.CodeGenerator.Models.MyItem" />
/// <autogeneratedoc />
public class DataBase
{
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    /// <autogeneratedoc />
    public string Name { get; set; }
    /// <summary>
    /// Initializes a new instance of the <see cref="MyDirectoryItem"/> class.
    /// </summary>
    /// <autogeneratedoc />
    public DataBase()
    {
        Items = new List<TablesVistas>();
    }

    /// <summary>
    /// Gets or sets the items.
    /// </summary>
    /// <value>
    /// The items.
    /// </value>
    /// <autogeneratedoc />
    public List<TablesVistas> Items { get; set; }

    /// <summary>
    /// Adds the dir item.
    /// </summary>
    /// <param name="directoryItem">The directory item.</param>
    /// <autogeneratedoc />
    public void AddDirItem(TablesVistas directoryItem)
    {
        Items.Add(directoryItem);
    }
}


///// <summary>
///// 
///// </summary>
///// <autogeneratedoc />
//public class MyItem
//{
//    /// <summary>
//    /// Gets or sets the name.
//    /// </summary>
//    /// <value>
//    /// The name.
//    /// </value>
//    /// <autogeneratedoc />
//    public string Name { get; set; }
//}

///// <summary>
///// 
///// </summary>
///// <seealso cref="JR.CodeGenerator.Models.MyItem" />
///// <autogeneratedoc />
//public class MyDirectoryItem : MyItem
//{
//    /// <summary>
//    /// Initializes a new instance of the <see cref="MyDirectoryItem"/> class.
//    /// </summary>
//    /// <autogeneratedoc />
//    public MyDirectoryItem()
//    {
//        Items = new List<MyDirectoryItem>();
//    }

//    /// <summary>
//    /// Gets or sets the items.
//    /// </summary>
//    /// <value>
//    /// The items.
//    /// </value>
//    /// <autogeneratedoc />
//    public List<MyDirectoryItem> Items { get; set; }

//    /// <summary>
//    /// Adds the dir item.
//    /// </summary>
//    /// <param name="directoryItem">The directory item.</param>
//    /// <autogeneratedoc />
//    public void AddDirItem(MyDirectoryItem directoryItem)
//    {
//        Items.Add(directoryItem);
//    }

//    /// <summary>
//    /// Traverses the specified it.
//    /// </summary>
//    /// <param name="it">It.</param>
//    /// <returns></returns>
//    /// <autogeneratedoc />
//    public List<MyItem> Traverse(MyDirectoryItem it)
//    {
//        var items = new List<MyItem>();

//        foreach (var itm in it.Items)
//        {
//            Traverse(itm);
//            items.Add(itm);
//        }

//        return items;
//    }
//}