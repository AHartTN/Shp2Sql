#region Copyright Header
// <copyright file="BoundingBox.cs" company="AH Operations">
// 	Copyright (c) 1985 - 2014 AH Operations All Rights Reserved
// 
// 	This source is created and maintained by AH Operations and is not available for public, private, or commercial use by any entity other than AH Operations.
// 
// 	Redistribution of this file in any part or entirety is strictly forbidden.
// </copyright>
// <author>Anthony Hart</author>
// <email>anthony@anthonyhart.info</email>
// <date>2014-07-22 8:58 PM</date>
// <summary>
// 	Solution: Shp2Sql
// 	Project: Shp2Sql
// 	File: BoundingBox.cs
// 	Created: 2014-07-22 8:58 PM
// 
// 	Purpose: WRITE A DESCRIPTION FOR THIS FILE!
// </summary>
#endregion

namespace Shp2Sql.Classes.Shape
{
    #region Using Directives
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.IO;
    #endregion

    public class BoundingBox
    {
        public BoundingBox()
        {
        }

        public BoundingBox(BinaryReader br)
        {
            XMin = br.ReadDouble();
            YMin = br.ReadDouble();
            XMax = br.ReadDouble();
            YMax = br.ReadDouble();
        }

        [Key]
        public long Id { get; set; }

        public double XMin { get; set; }
        public double YMin { get; set; }
        public double XMax { get; set; }
        public double YMax { get; set; }
        public double? ZMin { get; set; }
        public double? ZMax { get; set; }
        public double? MMin { get; set; }
        public double? MMax { get; set; }

        public static BoundingBox Import(BinaryReader br)
        {
            using (ShapeEntities db = new ShapeEntities())
            {
                BoundingBox newObj = new BoundingBox(br);
                newObj = db.BoundingBoxes.Add(newObj);
                db.Entry(newObj).State = EntityState.Added;
                return db.SaveChanges() > 0
                           ? newObj
                           : null;
            }
        }
    }
}