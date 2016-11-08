using System.Collections.Generic;
using System.Linq;

namespace Shp2Sql.Models.Binding
{
	#region Imports

	

	#endregion
	public class Part
	{
		public Part()
		{
			Points = new HashSet<Point>();
		}

		public long Id { get; set; }

		public long ShapeId { get; set; }

		public long PartTypeId { get; set; }

		public int SortIndex { get; set; }

		public int NumberOfPoints { get; set; }

		public int StartIndex { get; set; }

		public int EndIndex { get; set; }

		public Shape Shape { get; set; }

		public ICollection<Point> Points { get; set; }

		public IReadOnlyCollection<string> CoordinateStrings
		{
			get
			{
				return Points.OrderBy(o => o.SortIndex).Select(s => s.Coordinates).ToArray();
			}
		}

		public string Coordinates => string.Join(", ", CoordinateStrings);

		public string CoordinateString => $"({Coordinates})";
	}
}