#region Copyright Header
// <copyright file="Polygon.cs" company="AH Operations">
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
// 	File: Polygon.cs
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

    public class Polygon : BaseShape
    {
        public Polygon()
        {
            Parts = new List<Part>();
        }

        public Polygon(ShapeFile shp, BinaryReader br, bool readHeader = true) : base(shp, br, readHeader)
        {
            if (!readHeader)
                ShapeType = ShapeTypeEnum.Polygon;
            if (shp.ShapeType != ShapeType)
                throw new Exception(string.Format("Unable to process shape! Shape types do not match! (Shapefile: {0} | Record: {1}", shp.ShapeType, ShapeType));
            BoundingBox = new BoundingBox(br);
            BoundingBoxId = BoundingBox.Id;
            NumberOfParts = br.ReadInt32();
            NumberOfPoints = br.ReadInt32();
            Parts = new List<Part>(NumberOfParts);
            for (int i = 0; i < NumberOfParts; i++)
            {
                Parts.Add(new Part(br));
                if (i > 0)
                    Parts[i - 1].EndIndex = Parts[i].StartIndex - 1;
                if (i + 1 == NumberOfParts)
                    Parts[i].EndIndex = NumberOfPoints - 1;
            }
            for (int i = 0; i < NumberOfParts; i++)
            {
                Parts[i].NumberOfPoints = (Parts[i].EndIndex - Parts[i].StartIndex) + 1;
                Parts[i].Points = new List<Point>(Parts[i].NumberOfPoints);
            }
            for (int i = 0; i < NumberOfParts; i++)
            {
                for (int j = 0; j < Parts[i].NumberOfPoints; j++)
                    Parts[i].Points.Add(new Point(shp, br, false));
            }
        }

        public double XMin { get; set; }
        public double YMin { get; set; }
        public double XMax { get; set; }
        public double YMax { get; set; }
        public double? ZMin { get; set; }
        public double? ZMax { get; set; }
        public double? MMin { get; set; }
        public double? MMax { get; set; }
        public int NumberOfParts { get; set; }
        public int NumberOfPoints { get; set; }
        public List<Part> Parts { get; set; }
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
                Polygon newObj = new Polygon(shp, br, readHeader);
                db.Polygons.Add(newObj);
                db.Entry(newObj).State = EntityState.Added;
                return db.SaveChanges() > 0;
            }
        }
    }
}