#region Copyright Header
// <copyright file="ShapeTypeEnum.cs" company="AH Operations">
// 	Copyright (c) 1985 - 2014 AH Operations All Rights Reserved
// 
// 	This source is created and maintained by AH Operations and is not available for public, private, or commercial use by any entity other than AH Operations.
// 
// 	Redistribution of this file in any part or entirety is strictly forbidden.
// </copyright>
// <author>Anthony Hart</author>
// <email>anthony@anthonyhart.info</email>
// <date>2014-07-22 6:49 AM</date>
// <summary>
// 	Solution: Shp2Sql
// 	Project: Shp2Sql
// 	File: ShapeTypeEnum.cs
// 	Created: 2014-07-22 6:49 AM
// 
// 	Purpose: WRITE A DESCRIPTION FOR THIS FILE!
// </summary>
#endregion

namespace Shp2Sql.Enumerators
{
    public enum ShapeTypeEnum
    {
        Null = 0,
        Point = 1,
        Polyline = 3,
        Polygon = 5,
        MultiPoint = 8,
        PointZ = 11,
        PolylineZ = 13,
        PolygonZ = 15,
        MultiPointZ = 18,
        PointM = 21,
        PolylineM = 23,
        PolygonM = 25,
        MultiPointM = 28,
        MultiPatch = 31,
    }
}