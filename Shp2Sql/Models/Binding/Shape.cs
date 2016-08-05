using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using Microsoft.SqlServer.Types;
using Shp2Sql.Classes.Helpers;
using Shp2Sql.Enumerators;

namespace Shp2Sql.Models.Binding
{
	[Table("Shape")]
	public class Shape
	{
		public Shape()
		{
			Parts = new HashSet<Part>();
		}

		public Shape(ShapeTypeEnum shapeType, BinaryReader br)
		{
			Parts = new HashSet<Part>();
			ReadFromBinaryReader(shapeType, br);
		}

		public void ReadFromBinaryReader(ShapeTypeEnum shapeType, BinaryReader br)
		{
			//ShapeFileId = shapeFile.Id,
			RecordNumber = NumericsHelper.ReverseInt(br.ReadInt32()); // Big, Reverse for actual value
			ContentLength = NumericsHelper.ReverseInt(br.ReadInt32()); // Big, Reverse for actual value
			ShapeTypeId = br.ReadInt32();

			if (shapeType == ShapeTypeEnum.Null || (ShapeTypeEnum)ShapeTypeId == ShapeTypeEnum.Null)
				return;

			if (shapeType != (ShapeTypeEnum)ShapeTypeId)
				// Shape Type doesn't match type specified in file header. According to specs, this is invalid. Throw exception
				throw new Exception(
					$"Unable to process shape! File shape of {shapeType} does not match record shape of {(ShapeTypeEnum)ShapeTypeId} which violates ESRI specifications for shape files!");

			var shapeClass = ShapeClass.Coordinate;
			var hasMultiplePoints = true;
			var hasParts = true;
			var hasPartTypes = false;

			switch (shapeType)
			{
				case ShapeTypeEnum.MultiPatch:
					shapeClass = ShapeClass.Depth;
					hasPartTypes = true;
					break;
				case ShapeTypeEnum.MultiPoint:
					hasParts = false;
					break;
				case ShapeTypeEnum.MultiPointM:
					shapeClass = ShapeClass.Measurement;
					hasParts = false;
					break;
				case ShapeTypeEnum.MultiPointZ:
					shapeClass = ShapeClass.Depth;
					hasParts = false;
					break;
				case ShapeTypeEnum.Null:
					throw new Exception(
						"The application should have never gotten to this point.\r\nSomething is wrong with the code!\r\nLYNCH THE DEVELOPER!");
				case ShapeTypeEnum.Point:
					hasMultiplePoints = false;
					hasParts = false;
					break;
				case ShapeTypeEnum.PointM:
					shapeClass = ShapeClass.Measurement;
					hasMultiplePoints = false;
					hasParts = false;
					break;
				case ShapeTypeEnum.PointZ:
					shapeClass = ShapeClass.Depth;
					hasMultiplePoints = false;
					hasParts = false;
					break;
				case ShapeTypeEnum.Polygon:
				case ShapeTypeEnum.Polyline:
					break;
				case ShapeTypeEnum.PolygonM:
					shapeClass = ShapeClass.Measurement;
					break;
				case ShapeTypeEnum.PolygonZ:
					shapeClass = ShapeClass.Depth;
					break;
				case ShapeTypeEnum.PolylineM:
					shapeClass = ShapeClass.Measurement;
					break;
				case ShapeTypeEnum.PolylineZ:
					shapeClass = ShapeClass.Depth;
					break;
				default:
					throw new Exception($"Unable to process shape! Record Shape of {(ShapeTypeEnum)ShapeTypeId} is unknown!");
			}

			if (hasMultiplePoints)
			{
				XMin = br.ReadDouble();
				YMin = br.ReadDouble();
				XMax = br.ReadDouble();
				YMax = br.ReadDouble();
			}

			NumberOfParts = hasParts ? br.ReadInt32() : 1;
			NumberOfPoints = hasMultiplePoints ? br.ReadInt32() : 1;

			var parts = new List<Part>();

			for (var i = 0; i < NumberOfParts; i++) // Grab the parts
			{
				parts.Add(new Part
				{
					SortIndex = i,
					PartTypeId = -1,
					StartIndex = hasParts ? br.ReadInt32() : 0 // Get the start index
				});

				if (i > 0) // If this isn't the first element
					parts[i - 1].EndIndex = parts[i].StartIndex - 1;
				// Set the last element's end index to this element's start index minus one

				if (i + 1 == NumberOfParts) // If this is the last element
					parts[i].EndIndex = NumberOfPoints - 1;
				// Set the ending index to the number of points minus one (to account for 0 based index)
			}

			for (var i = 0; i < NumberOfParts; i++)
			// Set the number of points. This is done after initial grab to account for first/last elements
			{
				if (hasParts && hasPartTypes)
					parts[i].PartTypeId = br.ReadInt32();

				parts[i].NumberOfPoints = parts[i].EndIndex - parts[i].StartIndex + 1;
			}

			for (var i = 0; i < NumberOfParts; i++) // For each part
				for (var j = 0; j < parts[i].NumberOfPoints; j++) // For each point in each part
				{
					parts[i].Points.Add(new Point
					{
						SortIndex = j,
						X = br.ReadDouble(),
						Y = br.ReadDouble()
					}); // Grab the point
				}

			if (shapeClass == ShapeClass.Depth)
			{
				if (hasMultiplePoints)
				{
					ZMin = br.ReadDouble();
					ZMax = br.ReadDouble();
				}

				for (var i = 0; i < NumberOfParts; i++)
					for (var j = 0; j < parts[i].NumberOfPoints; j++)
						parts[i].Points.ToArray()[j].Z = br.ReadDouble();
			}

			if (shapeClass == ShapeClass.Depth ||
				shapeClass == ShapeClass.Measurement)
			{ 
				if (hasMultiplePoints)
				{
					MMin = br.ReadDouble();
					MMax = br.ReadDouble();
				}

				for (var i = 0; i < NumberOfParts; i++)
					for (var j = 0; j < parts[i].NumberOfPoints; j++)
						parts[i].Points.ToArray()[j].M = br.ReadDouble();
			}

			Parts = parts;
		}

		public long Id { get; set; }

		public long ShapeFileId { get; set; }

		public long ShapeTypeId { get; set; }

		public int RecordNumber { get; set; }

		public int ContentLength { get; set; }

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

		public ShapeFile ShapeFile { get; set; }

		public ShapeType ShapeType { get; set; }

		public string Coordinates
		{
			get { return string.Join(",", Parts.Select(s => s.CoordinateString)); }
		}

		public string CoordinateString => $"({Coordinates})";

		public string MultiLineStringString => $"MULTILINESTRING({Coordinates})";

		public char[] MultiLineStringCharArray => MultiLineStringString.ToCharArray();

		public SqlChars MultiLineStringSqlChars => new SqlChars(MultiLineStringCharArray);

		public SqlGeography MultiLineStringGeog => SqlGeography.STPolyFromText(MultiLineStringSqlChars, 4326);
	}
}