using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using Shp2Sql.Classes.Helpers;
using Shp2Sql.Enumerators;

namespace Shp2Sql.Models.Binding
{
	[Table("ShapeFile")]
	public class ShapeFile : ImportFile
	{
		public ShapeFile() : base()
		{
			Shapes = new HashSet<Shape>();
		}

		public ShapeFile(FileInfo file) : base(file)
		{
			Shapes = new HashSet<Shape>();
			ReadFromFile(file);
		}

		public void ReadFromFile(FileInfo file)
		{
			// TODO: Delete all records that pertain to this file

			using (var br = new BinaryReader(file.OpenRead()))
			{
				FileCode = NumericsHelper.ReverseInt(br.ReadInt32());

				for (var i = 0; i < 5; i++)
					br.ReadInt32(); // Skip 5 empty Integer (4-byte) slots

				ContentLength = NumericsHelper.ReverseInt(br.ReadInt32()); // Big Endian, Reverse for actual value
				FileVersion = br.ReadInt32();
				ShapeTypeId = br.ReadInt32();
				XMin = br.ReadDouble();
				YMin = br.ReadDouble();
				XMax = br.ReadDouble();
				YMax = br.ReadDouble();
				ZMin = br.ReadDouble();
				ZMax = br.ReadDouble();
				MMin = br.ReadDouble();
				MMax = br.ReadDouble();

				while (br.PeekChar() > -1)
					Shapes.Add(new Shape((ShapeTypeEnum)ShapeTypeId, br));
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

		public ShapeType ShapeType { get; set; }

		public ICollection<Shape> Shapes { get; set; }
	}
}