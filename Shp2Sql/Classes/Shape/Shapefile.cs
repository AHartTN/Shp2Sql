#region Copyright Header
// <copyright file="Shapefile.cs" company="AH Operations">
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
// 	File: Shapefile.cs
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
    using System.IO;
    using Shp2Sql.Classes.Helpers;
    using Shp2Sql.Enumerators;
    #endregion

    public class ShapeFile
    {
        public ShapeFile()
        {
            MultiPatches = new List<MultiPatch>();
            MultiPoints = new List<MultiPoint>();
            Nulls = new List<Null>();
            Points = new List<Point>();
            Polygons = new List<Polygon>();
            Polylines = new List<Polyline>();
        }

        public ShapeFile(BinaryReader br)
        {
            MultiPatches = new List<MultiPatch>();
            MultiPoints = new List<MultiPoint>();
            Nulls = new List<Null>();
            Points = new List<Point>();
            Polygons = new List<Polygon>();
            Polylines = new List<Polyline>();
            FileCode = NumericsHelper.ReverseInt(br.ReadInt32()); // Big, Reverse for actual value
            for (int i = 0; i < 5; i++)
                br.ReadInt32(); // Skip 5 empty Integer (4-byte) slots
            FileLength = NumericsHelper.ReverseInt(br.ReadInt32()); // Big, Reverse for actual value
            Version = br.ReadInt32();
            ShapeType = (ShapeTypeEnum)br.ReadInt32();
            BoundingBox = new BoundingBoxZ(br);
        }

        public long Id { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime CreationTimeUtc { get; set; }
        public string DirectoryName { get; set; }
        public string Extension { get; set; }
        public string FullName { get; set; }
        public bool IsReadOnly { get; set; }
        public DateTime LastAccessTime { get; set; }
        public DateTime LastAccessTimeUtc { get; set; }
        public DateTime LastWriteTime { get; set; }
        public DateTime LastWriteTimeUtc { get; set; }
        public long Length { get; set; }
        public string Name { get; set; }
        public int FileCode { get; set; }
        public int FileLength { get; set; }
        public int Version { get; set; }
        public ShapeTypeEnum ShapeType { get; set; }
        public double XMin { get; set; }
        public double YMin { get; set; }
        public double XMax { get; set; }
        public double YMax { get; set; }
        public double? ZMin { get; set; }
        public double? ZMax { get; set; }
        public double? MMin { get; set; }
        public double? MMax { get; set; }

        public List<MultiPatch> MultiPatches { get; set; }
        public List<MultiPoint> MultiPoints { get; set; }
        public List<Null> Nulls { get; set; }
        public List<Point> Points { get; set; }
        public List<Polygon> Polygons { get; set; }
        public List<Polyline> Polylines { get; set; }
    }
}