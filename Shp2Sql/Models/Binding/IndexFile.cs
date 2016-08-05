using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using Shp2Sql.Classes.Helpers;

namespace Shp2Sql.Models.Binding
{
	[Table("IndexFile")]
	public class IndexFile : ImportFile
	{
		public IndexFile() : base()
		{
			ShapeIndexes = new HashSet<ShapeIndex>();
		}
		public IndexFile(FileInfo file) : base(file)
		{
			ShapeIndexes = new HashSet<ShapeIndex>();
			ReadFromFile(file);
		}

		public void ReadFromFile(FileInfo file)
		{
			using (var br = new BinaryReader(file.OpenRead()))
			{
				var streamLength = br.BaseStream.Length;
				Console.Write(StringHelper.GetProgressString(br.BaseStream.Position, streamLength, file.Name));

				FileCode = NumericsHelper.ReverseInt(br.ReadInt32());

				Console.Write(StringHelper.GetProgressString(br.BaseStream.Position, streamLength, file.Name));

				for (var i = 0; i < 5; i++)
					br.ReadInt32(); // Skip 5 empty Integer (4-byte) slots

				Console.Write(StringHelper.GetProgressString(br.BaseStream.Position, streamLength, file.Name));

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

				Console.Write(StringHelper.GetProgressString(br.BaseStream.Position, streamLength, file.Name));

				var counter = 0;
				while (br.PeekChar() > -1)
				{
					ShapeIndexes.Add(new ShapeIndex
					{
						//IndexFileId = Id,
						RecordNumber = ++counter,
						Offset = NumericsHelper.ReverseInt(br.ReadInt32()),
						ContentLength = NumericsHelper.ReverseInt(br.ReadInt32())
					});

					Console.Write(StringHelper.GetProgressString(br.BaseStream.Position, streamLength, file.Name));
				}
			}
			Console.Write(StringHelper.GetProgressString(file.Length, file.Length, file.Name));
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

		public ICollection<ShapeIndex> ShapeIndexes { get; set; }
	}
}