#region Copyright Header
// <copyright file="ZRange.cs" company="AH Operations">
// 	Copyright (c) 1985 - 2014 AH Operations All Rights Reserved
// 
// 	This source is created and maintained by AH Operations and is not available for public, private, or commercial use by any entity other than AH Operations.
// 
// 	Redistribution of this file in any part or entirety is strictly forbidden.
// </copyright>
// <author>Anthony Hart</author>
// <email>anthony@anthonyhart.info</email>
// <date>2014-07-22 8:18 AM</date>
// <summary>
// 	Solution: Shp2Sql
// 	Project: Shp2Sql
// 	File: ZRange.cs
// 	Created: 2014-07-22 8:18 AM
// 
// 	Purpose: WRITE A DESCRIPTION FOR THIS FILE!
// </summary>
#endregion

namespace Shp2Sql.Classes.Shape
{
    #region Using Directives
    using System.Data.Entity;
    using System.IO;
    #endregion

    public class ZRange
    {
        public ZRange()
        {
        }

        public ZRange(BinaryReader br)
        {
            Minimum = br.ReadDouble();
            Maximum = br.ReadDouble();
        }

        public long Id { get; set; }
        public double Minimum { get; set; }
        public double Maximum { get; set; }

        public static ZRange Import(BinaryReader br)
        {
            using (ShapeEntities db = new ShapeEntities())
            {
                ZRange zr = new ZRange(br);
                db.Entry(db.ZRanges.Add(zr)).State = EntityState.Added;
                return db.SaveChanges() > 0
                           ? zr
                           : null;
            }
        }
    }
}