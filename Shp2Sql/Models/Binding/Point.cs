namespace Shp2Sql.Models.Binding
{
	#region Imports

	#endregion
	public class Point
	{
		public long Id { get; set; }

		public int SortIndex { get; set; }

		public double X { get; set; }

		public double Y { get; set; }

		public double? Z { get; set; }

		public double? M { get; set; }

		public string Coordinates => $"{X} {Y} {Z} {M}".Trim().Replace("  ", " ");
	}
}