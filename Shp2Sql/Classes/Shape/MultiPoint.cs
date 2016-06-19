#region Copyright Header
// <copyright file="MultiPoint.cs" company="AH Operations">
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
// 	File: MultiPoint.cs
// 	Created: 2014-07-22 8:18 AM
// 
// 	Purpose: WRITE A DESCRIPTION FOR THIS FILE!
// </summary>
#endregion

namespace Shp2Sql.Classes.Shape
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.IO;
    using Shp2Sql.Enumerators;
    #endregion

    public class MultiPoint : BaseShape
    {
        public MultiPoint()
        {
            Points = new List<Point>();
        }

        public MultiPoint(ShapeFile shp, BinaryReader br, bool readHeader = true) : base(shp, br, readHeader)
        {
            if (!readHeader)
                ShapeType = ShapeTypeEnum.MultiPoint;
            if (shp.ShapeType != ShapeType)
                throw new Exception(string.Format("Unable to process shape! Shape types do not match! (Shapefile: {0} | Record: {1}", shp.ShapeType, ShapeType));
            BoundingBox = new BoundingBox(br);
            BoundingBoxId = BoundingBox.Id;
            NumberOfPoints = br.ReadInt32();
            Points = new List<Point>(NumberOfPoints);
            for (int i = 0; i < NumberOfPoints; i++)
                Points.Add(new Point(shp, br, false));
        }

        public double XMin { get; set; }
        public double YMin { get; set; }
        public double XMax { get; set; }
        public double YMax { get; set; }
        public double? ZMin { get; set; }
        public double? ZMax { get; set; }
        public double? MMin { get; set; }
        public double? MMax { get; set; }
        public int NumberOfPoints { get; set; }
        public List<Point> Points { get; set; }
        public long? ZRangeId { get; set; }

        [ForeignKey("ZRangeId")]
        public ZRange ZRange { get; set; }

        public long? MeasurementRangeId { get; set; }

        [ForeignKey("MeasurementRangeId")]
        public MeasurementRange MeasurementRange { get; set; }

        public static bool Import(ShapeFile shp, BinaryReader br, bool readHeader = true)
        {
            using (ShapeEntities db = new ShapeEntities())
            {
                MultiPoint newObj = new MultiPoint(shp, br, readHeader);
                db.Entry(db.MultiPoints.Add(newObj)).State = EntityState.Added;
                return db.SaveChanges() > 0;
            }
        }
    }
}