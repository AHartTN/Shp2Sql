namespace Shp2Sql.Models.Binding
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.SqlTypes;
    using Microsoft.SqlServer.Types;

    [Table("Point")]
    public partial class Point
    {
        public long Id { get; set; }

        public long PartId { get; set; }

        public int SortIndex { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public double M { get; set; }

        public Part Part { get; set; }

        public string Coordinates
        {
            get
            {
                return string.Join(" ", new
                                        {
                                            X,
                                            Y,
                                            Z,
                                            M
                                        });
            }
        }

        public string PointString
        {
            get
            {
                return string.Format("Point({0})", Coordinates);
            }
        }

        public char[] PointCharArray
        {
            get
            {
                return PointString.ToCharArray();
            }
        }

        public SqlChars PointSqlChars
        {
            get
            {
                return new SqlChars(PointCharArray);
            }
        }

        public SqlString PointSqlString
        {
            get
            {
                return new SqlString(PointString);
            }
        }

        public SqlGeography PointGeog
        {
            get
            {
                return SqlGeography.Parse(PointSqlString);
            }
        }
    }
}
