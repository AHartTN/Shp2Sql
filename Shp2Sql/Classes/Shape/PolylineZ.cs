#region Copyright Header
// <copyright file="PolylineZ.cs" company="AH Operations">
// 	Copyright (c) 1985 - 2014 AH Operations All Rights Reserved
// 
// 	This source is created and maintained by AH Operations and is not available for public, private, or commercial use by any entity other than AH Operations.
// 
// 	Redistribution of this file in any part or entirety is strictly forbidden.
// </copyright>
// <author>Anthony Hart</author>
// <email>anthony@anthonyhart.info</email>
// <date>2014-07-22 9:41 PM</date>
// <summary>
// 	Solution: Shp2Sql
// 	Project: Shp2Sql
// 	File: PolylineZ.cs
// 	Created: 2014-07-22 9:41 PM
// 
// 	Purpose: WRITE A DESCRIPTION FOR THIS FILE!
// </summary>
#endregion

namespace Shp2Sql.Classes.Shape
{
    #region Using Directives
    using System;
    using System.Data.Entity;
    using System.IO;
    using Shp2Sql.Enumerators;
    #endregion

    public class PolylineZ : Polyline
    {
        public PolylineZ()
        {
        }

        public PolylineZ(ShapeFile shp, BinaryReader br, bool readHeader = true) : base(shp, br, readHeader)
        {
            if (!readHeader)
                ShapeType = ShapeTypeEnum.PolylineZ;
            if (shp.ShapeType != ShapeType)
                throw new Exception(string.Format("Unable to process shape! Shape types do not match! (Shapefile: {0} | Record: {1}", shp.ShapeType, ShapeType));
            ZRange = ZRange.Import(br);
            ZRangeId = ZRange.Id;
            for (int i = 0; i < NumberOfParts; i++)
            {
                for (int j = 0; j < Parts[i].NumberOfPoints; j++)
                {
                    Parts[i].Points[j].ShapeType = ShapeTypeEnum.PointZ;
                    Parts[i].Points[j].Z = br.ReadDouble();
                }
            }
            MeasurementRange = MeasurementRange.Import(br);
            MeasurementRangeId = MeasurementRange.Id;
            for (int i = 0; i < NumberOfParts; i++)
            {
                for (int j = 0; j < Parts[i].NumberOfPoints; j++)
                    Parts[i].Points[j].M = br.ReadDouble();
            }
        }

        public new static bool Import(ShapeFile shp, BinaryReader br, bool readHeader = true)
        {
            using (ShapeEntities db = new ShapeEntities())
            {
                PolylineZ newObj = new PolylineZ(shp, br, readHeader);
                db.Entry(db.Polylines.Add(newObj)).State = EntityState.Added;
                return db.SaveChanges() > 0;
            }
        }
    }
}