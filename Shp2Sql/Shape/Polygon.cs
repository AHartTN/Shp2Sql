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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using Shp2Sql.Enumerators;

namespace Shp2Sql.Classes.Shape
{
	#region Using Directives

	

	#endregion

	public class Polygon : BaseShape
	{
		public Polygon()
		{
			Parts = new HashSet<Part>();
		}

		public Polygon(ShapeFile shp, BinaryReader br, bool readHeader = true) : base(shp, br, readHeader)
		{
			if (!readHeader)
				ShapeType = ShapeTypeEnum.Polygon;
			if (shp.ShapeType != ShapeType)
				throw new Exception(
					$"Unable to process shape! Shape types do not match! (Shapefile: {shp.ShapeType} | Record: {ShapeType}");
			BoundingBox = new BoundingBox(br);
			BoundingBoxId = BoundingBox.Id;
			NumberOfParts = br.ReadInt32();
			NumberOfPoints = br.ReadInt32();
			Parts = new HashSet<Part>();
			for (var i = 0; i < NumberOfParts; i++)
			{
				Parts.Add(new Part(br));
				if (i > 0)
					((List<Part>)Parts)[i - 1].EndIndex = ((List<Part>)Parts)[i].StartIndex - 1;
				if (i + 1 == NumberOfParts)
					((List<Part>)Parts)[i].EndIndex = NumberOfPoints - 1;
			}
			for (var i = 0; i < NumberOfParts; i++)
			{
				((List<Part>)Parts)[i].NumberOfPoints = ((List<Part>)Parts)[i].EndIndex - ((List<Part>)Parts)[i].StartIndex + 1;
				((List<Part>) Parts)[i].Points = new HashSet<Point>();
			}
			for (var i = 0; i < NumberOfParts; i++)
			{
				for (var j = 0; j < ((List<Part>)Parts)[i].NumberOfPoints; j++)
					((List<Part>)Parts)[i].Points.Add(new Point(shp, br, false));
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
		public ICollection<Part> Parts { get; set; }
		public long? ZRangeId { get; set; }

		[ForeignKey("ZRangeId")]
		public ZRange ZRange { get; set; }

		public long? MeasurementRangeId { get; set; }

		[ForeignKey("MeasurementRangeId")]
		public MeasurementRange MeasurementRange { get; set; }

		public long BoundingBoxId { get; set; }

		[ForeignKey("BoundingBoxId")]
		public BoundingBox BoundingBox { get; set; }
	}
}