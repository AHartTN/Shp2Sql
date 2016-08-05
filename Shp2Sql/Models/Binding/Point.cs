using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Types;

namespace Shp2Sql.Models.Binding
{
	[Table("Point")]
	public class Point
	{
		public long Id { get; set; }

		public long PartId { get; set; }

		public int SortIndex { get; set; }

		public double X { get; set; }

		public double Y { get; set; }

		public double Z { get; set; }

		public double M { get; set; }

		public Part Part { get; set; }

		public string Coordinates => string.Join(" ", new
		{
			X,
			Y,
			Z,
			M
		});

		public string PointString => $"Point({Coordinates})";

		public char[] PointCharArray => PointString.ToCharArray();

		public SqlChars PointSqlChars => new SqlChars(PointCharArray);

		public SqlString PointSqlString => new SqlString(PointString);

		public SqlGeography PointGeog => SqlGeography.Parse(PointSqlString);
	}
}