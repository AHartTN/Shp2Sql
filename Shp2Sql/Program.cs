#region Copyright Header
// <copyright file="Program.cs" company="AH Operations">
// 	Copyright (c) 1985 - 2014 AH Operations All Rights Reserved
// 
// 	This source is created and maintained by AH Operations and is not available for public, private, or commercial use by any entity other than AH Operations.
// 
// 	Redistribution of this file in any part or entirety is strictly forbidden.
// </copyright>
// <author>Anthony Hart</author>
// <email>anthony@anthonyhart.info</email>
// <date>2014-07-20 4:09 AM</date>
// <summary>
// 	Solution: Shp2Sql
// 	Project: Shp2Sql
// 	File: Program.cs
// 	Created: 2014-07-20 4:09 AM
// 
// 	Purpose: WRITE A DESCRIPTION FOR THIS FILE!
// </summary>
#endregion

namespace Shp2Sql
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Linq;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Shp2Sql.Classes.Comparers;
    using Shp2Sql.Classes.Helpers;
    using Shp2Sql.Enumerators;
    using Shp2Sql.Models.Binding;
    using Shp2Sql.Models.Entity;
    #endregion

    public class Program
    {
        private static string folderPath = @"F:\2014 Tiger\National";

        private static void Main(string[] args)
        {
            ESRIHelper.ProcessDirectory(folderPath);

            foreach (string arg in args)
                ESRIHelper.ProcessDirectory(arg);

            Console.ReadKey(true);
        }
    }
}