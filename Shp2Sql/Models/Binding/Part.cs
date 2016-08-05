using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using Microsoft.SqlServer.Types;

namespace Shp2Sql.Models.Binding
{
	[Table("Part")]
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

		public PartType PartType { get; set; }

		public Shape Shape { get; set; }

		public ICollection<Point> Points { get; set; }

		public IEnumerable<string> CoordinateStrings
		{
			get { return Points.OrderBy(o => o.SortIndex).Select(s => s.Coordinates); }
		}

		public string Coordinates => string.Join(",", CoordinateStrings);

		public string CoordinateString => $"({Coordinates})";

		public string MultiPointString => $"MULTIPOINT({Coordinates})";

		public char[] MultiPointCharArray => MultiPointString.ToCharArray();

		public SqlChars MultiPointSqlChars => new SqlChars(MultiPointCharArray);

		public SqlString MultiPointSqlString => new SqlString(MultiPointString);

		public SqlGeography MultiPointGeog => SqlGeography.Parse(MultiPointSqlString);

		public string LineStringString => $"LINESTRING({Coordinates})";

		public char[] LineStringCharArray => LineStringString.ToCharArray();

		public SqlChars LineStringSqlChars => new SqlChars(LineStringCharArray);

		public SqlString LineStringSqlString => new SqlString(LineStringString);

		public SqlGeography LineStringGeog => SqlGeography.Parse(LineStringSqlString);

		public string PolygonString => $"POLYGON({CoordinateString})";

		public char[] PolygonCharArray => PolygonString.ToCharArray();

		public SqlChars PolygonSqlChars => new SqlChars(PolygonCharArray);

		public SqlString PolygonSqlString => new SqlString(PolygonString);

		public SqlGeography PolygonGeog => SqlGeography.Parse(PolygonSqlString);
	}
}