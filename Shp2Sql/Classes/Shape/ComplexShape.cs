#region Copyright Header
// <copyright file="ComplexShape.cs" company="AH Operations">
// 	Copyright (c) 1985 - 2014 AH Operations All Rights Reserved
// 
// 	This source is created and maintained by AH Operations and is not available for public, private, or commercial use by any entity other than AH Operations.
// 
// 	Redistribution of this file in any part or entirety is strictly forbidden.
// </copyright>
// <author>Anthony Hart</author>
// <email>anthony@anthonyhart.info</email>
// <date>2014-07-25 3:41 AM</date>
// <summary>
// 	Solution: Shp2Sql
// 	Project: Shp2Sql
// 	File: ComplexShape.cs
// 	Created: 2014-07-25 3:41 AM
// 
// 	Purpose: WRITE A DESCRIPTION FOR THIS FILE!
// </summary>
#endregion

namespace Shp2Sql.Classes.Shape
{
    #region Using Directives
    using System.IO;
    #endregion

    public class ComplexShape : BaseShape
    {
        public ComplexShape()
        {
        }

        public ComplexShape(ShapeFile shp, BinaryReader br, bool readHeader) : base(shp, br, readHeader)
        {
        }

        public double XMin { get; set; }
        public double YMin { get; set; }
        public double XMax { get; set; }
        public double YMax { get; set; }
        public double? ZMin { get; set; }
        public double? ZMax { get; set; }
        public double? MMin { get; set; }
        public double? MMax { get; set; }
    }
}