namespace Shp2Sql.Models.Binding
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.SqlTypes;
    using System.Linq;
    using Microsoft.SqlServer.Types;
    using Shp2Sql.Enumerators;

    [Table("Shape")]
    public partial class Shape
    {
        public Shape()
        {
            Parts = new List<Part>();
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

        public List<Part> Parts { get; set; }

        public ShapeFile ShapeFile { get; set; }

        public ShapeType ShapeType { get; set; }

        public string Coordinates
        {
            get
            {
                return string.Join(",", Parts.Select(s => s.CoordinateString));
            }
        }

        public string CoordinateString
        {
            get
            {
                return string.Format("({0})", Coordinates);
            }
        }

        public string MultiLineStringString
        {
            get
            {
                return string.Format("MULTILINESTRING({0})", Coordinates);
            }
        }

        public char[] MultiLineStringCharArray
        {
            get
            {
                return MultiLineStringString.ToCharArray();
            }
        }

        public SqlChars MultiLineStringSqlChars
        {
            get
            {
                return new SqlChars(MultiLineStringCharArray);
            }
        }

        public SqlGeography MultiLineStringGeog
        {
            get
            {
                return SqlGeography.STPolyFromText(MultiLineStringSqlChars, 4326);
            }
        }
    }
}