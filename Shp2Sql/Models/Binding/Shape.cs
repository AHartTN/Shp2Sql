using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using Microsoft.SqlServer.Types;
using Shp2Sql.Enumerators;
using Shp2Sql.Helpers;

namespace Shp2Sql.Models.Binding
{
	#region Imports

	

	#endregion
	#region Imports

	#endregion
	[Table("Shape")]
	public class Shape
	{
		public static LogHelper LH = new LogHelper();

		public Shape()
		{
		}

		// TODO: STOP USING WORLDWIDE SRID! Passs the relevant SRID to the constructor for use in Geometry creation!
		public Shape(long shapefileID, ShapeType shapeType, BinaryReader br)
		{
			ShapeFileId = shapefileID;
			ImportFromBinaryReader(shapeType, br);
		}

		public long Id { get; set; }

		public long ShapeFileId { get; set; }

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

		public ShapeFile ShapeFile { get; set; }

		public ShapeType ShapeType { get; set; }

		public DbGeometry Geometry { get; set; }

		public SqlGeometry DTGeometry
			=> SqlGeometry.STGeomFromWKB(new SqlBytes(Geometry.AsBinary()), Geometry.CoordinateSystemId);

		public void ImportFromBinaryReader(ShapeType shapeType, BinaryReader br)
		{
			try
			{
				long streamLength = br.BaseStream.Length;
				RecordNumber = NumericsHelper.ReverseInt(br.ReadInt32()); // Big, Reverse for actual value
				ContentLength = NumericsHelper.ReverseInt(br.ReadInt32()); // Big, Reverse for actual value
				ShapeType = (ShapeType) br.ReadInt32();

				if (ShapeType == ShapeType.Null
					|| shapeType == ShapeType.Null)
					return;

				if (ShapeType != shapeType)
					// Shape Type doesn't match type specified in file header. According to specs, this is invalid. Throw exception
					throw new Exception(
						$"Unable to process shape! File shape of {shapeType} does not match record shape of {ShapeType} which violates ESRI specifications for shape files!");

				ShapeClass shapeClass = ShapeClass.Coordinate;
				bool hasMultiplePoints = true;
				bool hasParts = true;
				bool hasPartTypes = false;

				switch (shapeType)
				{
					case ShapeType.MultiPatch:
						shapeClass = ShapeClass.Depth;
						hasPartTypes = true;
						break;
					case ShapeType.MultiPoint:
						hasParts = false;
						break;
					case ShapeType.MultiPointM:
						shapeClass = ShapeClass.Measurement;
						hasParts = false;
						break;
					case ShapeType.MultiPointZ:
						shapeClass = ShapeClass.Depth;
						hasParts = false;
						break;
					case ShapeType.Null:
						throw new Exception(
							"The application should have never gotten to this point.\r\nSomething is wrong with the code!\r\nLYNCH THE DEVELOPER!");
					case ShapeType.Point:
						hasMultiplePoints = false;
						hasParts = false;
						break;
					case ShapeType.PointM:
						shapeClass = ShapeClass.Measurement;
						hasMultiplePoints = false;
						hasParts = false;
						break;
					case ShapeType.PointZ:
						shapeClass = ShapeClass.Depth;
						hasMultiplePoints = false;
						hasParts = false;
						break;
					case ShapeType.Polygon:
					case ShapeType.Polyline:
						break;
					case ShapeType.PolygonM:
						shapeClass = ShapeClass.Measurement;
						break;
					case ShapeType.PolygonZ:
						shapeClass = ShapeClass.Depth;
						break;
					case ShapeType.PolylineM:
						shapeClass = ShapeClass.Measurement;
						break;
					case ShapeType.PolylineZ:
						shapeClass = ShapeClass.Depth;
						break;
					default:
						throw new Exception($"Unable to process shape! Record Shape of {ShapeType} is unknown!");
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

				LH.Write(StringHelper.GetProgressString(br.BaseStream.Position, streamLength, "Shape"));

				List<Part> parts = new List<Part>();

				for (int i = 0; i < NumberOfParts; i++) // Grab the parts
				{
					Part part = new Part
					{
						ShapeId = Id,
						SortIndex = i,
						PartTypeId = -1, // TODO: Find out what the appropriate part types are (if necessary)
						StartIndex = hasParts ? br.ReadInt32() : 0 // Get the start index
					};

					parts.Add(part);

					if (i > 0) // If this isn't the first element
						parts[i - 1].EndIndex = parts[i].StartIndex - 1;
					// Set the last element's end index to this element's start index minus one

					if (i + 1 == NumberOfParts) // If this is the last element
						parts[i].EndIndex = NumberOfPoints - 1;
					// Set the ending index to the number of points minus one (to account for 0 based index)

					LH.Write(StringHelper.GetProgressString(br.BaseStream.Position, streamLength, $"Part {i}"));
				}

				for (int i = 0; i < NumberOfParts; i++)
					// Set the number of points. This is done after initial grab to account for first/last elements
				{
					if (hasParts && hasPartTypes)
						parts[i].PartTypeId = br.ReadInt32();

					parts[i].NumberOfPoints = parts[i].EndIndex - parts[i].StartIndex + 1;

					LH.Write(StringHelper.GetProgressString(br.BaseStream.Position, streamLength, $"Part {i}"));
				}

				for (int i = 0; i < NumberOfParts; i++) // For each part
					for (int j = 0; j < parts[i].NumberOfPoints; j++) // For each point in each part
					{
						parts[i].Points.Add(new Point
						{
							SortIndex = j,
							X = br.ReadDouble(),
							Y = br.ReadDouble()
						}); // Grab the point
						LH.Write(StringHelper.GetProgressString(br.BaseStream.Position, streamLength, $"Part {i} | Point {j}"));
					}

				if (shapeClass == ShapeClass.Depth)
				{
					if (hasMultiplePoints)
					{
						ZMin = br.ReadDouble();
						ZMax = br.ReadDouble();
					}

					for (int i = 0; i < NumberOfParts; i++)
						for (int j = 0; j < parts[i].NumberOfPoints; j++)
						{
							LH.Write(StringHelper.GetProgressString(br.BaseStream.Position,
								streamLength,
								$"Part {i} | Point {j} | Setting Z Value"));
							parts[i].Points.ToArray()[j].Z = br.ReadDouble();
						}
				}

				if (shapeClass == ShapeClass.Depth
					||
					shapeClass == ShapeClass.Measurement)
				{
					if (hasMultiplePoints)
					{
						MMin = br.ReadDouble();
						MMax = br.ReadDouble();
					}

					for (int i = 0; i < NumberOfParts; i++)
						for (int j = 0; j < parts[i].NumberOfPoints; j++)
						{
							LH.Write(StringHelper.GetProgressString(br.BaseStream.Position,
								streamLength,
								$"Part {i} | Point {j} | Setting M Value"));
							parts[i].Points.ToArray()[j].M = br.ReadDouble();
						}
				}

				try
				{
					string wktTemplate = "{0}({1})";
					string shapeTypeName = ShapeType.ToString().ToUpperInvariant().Replace("POLYLINE", "MULTILINESTRING");
					IReadOnlyCollection<string> coordinateStrings = parts.Select(s => s.CoordinateString).ToArray();

					if (ShapeType == ShapeType.Point
						|| ShapeType == ShapeType.PointZ
						|| ShapeType == ShapeType.PointM)
						coordinateStrings = coordinateStrings.Select(s => s.Trim('(').Trim(')').Trim()).ToArray();

					string coordinateString = string.Join(",", coordinateStrings);
					string wktString = string.Format(wktTemplate, shapeTypeName, coordinateString);
					//Debug.WriteLine(wktString);
					Geometry = DbGeometry.FromText(wktString, 4326);
				}
				catch (Exception e)
				{
					LH.Error($"\r\n{e.Message}\r\n{e}");
					throw;
				}
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}
	}
}