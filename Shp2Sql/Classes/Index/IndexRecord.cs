#region Copyright Header
// <copyright file="IndexRecord.cs" company="AH Operations">
// 	Copyright (c) 1985 - 2014 AH Operations All Rights Reserved
// 
// 	This source is created and maintained by AH Operations and is not available for public, private, or commercial use by any entity other than AH Operations.
// 
// 	Redistribution of this file in any part or entirety is strictly forbidden.
// </copyright>
// <author>Anthony Hart</author>
// <email>anthony@anthonyhart.info</email>
// <date>2014-07-22 7:03 PM</date>
// <summary>
// 	Solution: Shp2Sql
// 	Project: Shp2Sql
// 	File: IndexRecord.cs
// 	Created: 2014-07-22 7:03 PM
// 
// 	Purpose: WRITE A DESCRIPTION FOR THIS FILE!
// </summary>
#endregion

namespace Shp2Sql.Classes.Index
{
    #region Using Directives
    using System.IO;
    using Shp2Sql.Classes.Helpers;
    #endregion

    public class IndexRecord
    {
        public int Offset { get; set; }
        public int ContentLength { get; set; }

        public static IndexRecord Import(BinaryReader br)
        {
            return new IndexRecord
                   {
                       Offset = NumericsHelper.ReverseInt(br.ReadInt32()),
                       ContentLength = NumericsHelper.ReverseInt(br.ReadInt32())
                   };
        }
    }
}