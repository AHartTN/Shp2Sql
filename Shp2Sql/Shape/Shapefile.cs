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

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using Shp2Sql.Classes.Helpers;
using Shp2Sql.Enumerators;
using Shp2Sql.Models.Binding;

namespace Shp2Sql.Classes.Shape
{
	#region Using Directives

	

	#endregion

	public class ShapeFile : ImportFile
	{
		public ShapeFile()
		{
			Initialize();
		}

		public ShapeFile(BinaryReader br)
		{
			Initialize();

			FileCode = NumericsHelper.ReverseInt(br.ReadInt32()); // Big, Reverse for actual value

			for (var i = 0; i < 5; i++)
				br.ReadInt32(); // Skip 5 empty Integer (4-byte) slots

			FileLength = NumericsHelper.ReverseInt(br.ReadInt32()); // Big, Reverse for actual value
			Version = br.ReadInt32();
			ShapeType = (ShapeTypeEnum) br.ReadInt32();
			BoundingBox = new BoundingBoxZ(br);
		}

		private void Initialize()
		{
			MultiPatches = new HashSet<MultiPatch>();
			MultiPoints = new HashSet<MultiPoint>();
			Nulls = new HashSet<Null>();
			Points = new HashSet<Point>();
			Polygons = new HashSet<Polygon>();
			Polylines = new HashSet<Polyline>();
		}
		
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

		public long BoundingBoxId { get; set; }

		[ForeignKey("BoundingBoxId")]
		public BoundingBox BoundingBox { get; set; }

		public ICollection<MultiPatch> MultiPatches { get; set; }
		public ICollection<MultiPoint> MultiPoints { get; set; }
		public ICollection<Null> Nulls { get; set; }
		public ICollection<Point> Points { get; set; }
		public ICollection<Polygon> Polygons { get; set; }
		public ICollection<Polyline> Polylines { get; set; }
	}
}