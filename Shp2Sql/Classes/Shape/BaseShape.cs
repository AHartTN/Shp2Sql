#region Copyright Header
// <copyright file="BaseShape.cs" company="AH Operations">
// 	Copyright (c) 1985 - 2014 AH Operations All Rights Reserved
// 
// 	This source is created and maintained by AH Operations and is not available for public, private, or commercial use by any entity other than AH Operations.
// 
// 	Redistribution of this file in any part or entirety is strictly forbidden.
// </copyright>
// <author>Anthony Hart</author>
// <email>anthony@anthonyhart.info</email>
// <date>2014-07-22 7:54 PM</date>
// <summary>
// 	Solution: Shp2Sql
// 	Project: Shp2Sql
// 	File: BaseShape.cs
// 	Created: 2014-07-22 7:54 PM
// 
// 	Purpose: WRITE A DESCRIPTION FOR THIS FILE!
// </summary>
#endregion

namespace Shp2Sql.Classes.Shape
{
    #region Using Directives
    using System.ComponentModel.DataAnnotations.Schema;
    using System.IO;
    using Shp2Sql.Enumerators;
    #endregion

    public class BaseShape
    {
        public BaseShape()
        {
        }

        public BaseShape(ShapeFile shp, BinaryReader br, bool readHeader = true)
        {
            ShapeFile = shp;
            ShapeFileId = shp.Id;
            RecordHeader = readHeader
                               ? RecordHeader.Import(br)
                               : null;
            if (RecordHeader != null)
            {
                RecordHeaderId = RecordHeader.Id;
                ShapeType = (ShapeTypeEnum)br.ReadInt32();
            }
        }

        public long Id { get; set; }
        public long ShapeFileId { get; set; }
        public long? RecordHeaderId { get; set; }
        public ShapeTypeEnum ShapeType { get; set; }

        [ForeignKey("ShapeFileId")]
        public ShapeFile ShapeFile { get; set; }

        [ForeignKey("RecordHeaderId")]
        public RecordHeader RecordHeader { get; set; }
    }
}