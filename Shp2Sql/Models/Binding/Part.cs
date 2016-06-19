namespace Shp2Sql.Models.Binding
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.SqlTypes;
    using System.Linq;
    using Microsoft.SqlServer.Types;

    [Table("Part")]
    public partial class Part
    {
        public Part()
        {
            Points = new List<Point>();
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

        public List<Point> Points { get; set; }

        public string[] CoordinateStrings
        {
            get
            {
                return Points.OrderBy(o => o.SortIndex).Select(s => s.Coordinates).ToArray();
            }
        }

        public string Coordinates
        {
            get
            {
                return string.Join(",", CoordinateStrings);
            }
        }

        public string CoordinateString
        {
            get
            {
                return string.Format("({0})", Coordinates);
            }
        }

        public string MultiPointString
        {
            get
            {
                return string.Format("MULTIPOINT({0})", Coordinates);
            }
        }

        public char[] MultiPointCharArray
        {
            get
            {
                return MultiPointString.ToCharArray();
            }
        }

        public SqlChars MultiPointSqlChars
        {
            get
            {
                return new SqlChars(MultiPointCharArray);
            }
        }

        public SqlString MultiPointSqlString
        {
            get
            {
                return new SqlString(MultiPointString);
            }
        }

        public SqlGeography MultiPointGeog
        {
            get
            {
                return SqlGeography.Parse(MultiPointSqlString);
            }
        }

        public string LineStringString
        {
            get
            {
                return string.Format("LINESTRING({0})", Coordinates);
            }
        }

        public char[] LineStringCharArray
        {
            get
            {
                return LineStringString.ToCharArray();
            }
        }

        public SqlChars LineStringSqlChars
        {
            get
            {
                return new SqlChars(LineStringCharArray);
            }
        }

        public SqlString LineStringSqlString
        {
            get
            {
                return new SqlString(LineStringString);
            }
        }

        public SqlGeography LineStringGeog
        {
            get
            {
                return SqlGeography.Parse(LineStringSqlString);
            }
        }

        public string PolygonString
        {
            get
            {
                return string.Format("POLYGON({0})", CoordinateString);
            }
        }

        public char[] PolygonCharArray
        {
            get
            {
                return PolygonString.ToCharArray();
            }
        }

        public SqlChars PolygonSqlChars
        {
            get
            {
                return new SqlChars(PolygonCharArray);
            }
        }

        public SqlString PolygonSqlString
        {
            get
            {
                return new SqlString(PolygonString);
            }
        }

        public SqlGeography PolygonGeog
        {
            get
            {
                return SqlGeography.Parse(PolygonSqlString);
            }
        }
    }
}
