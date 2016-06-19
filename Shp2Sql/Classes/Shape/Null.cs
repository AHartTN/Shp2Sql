#region Copyright Header
// <copyright file="Null.cs" company="AH Operations">
// 	Copyright (c) 1985 - 2014 AH Operations All Rights Reserved
// 
// 	This source is created and maintained by AH Operations and is not available for public, private, or commercial use by any entity other than AH Operations.
// 
// 	Redistribution of this file in any part or entirety is strictly forbidden.
// </copyright>
// <author>Anthony Hart</author>
// <email>anthony@anthonyhart.info</email>
// <date>2014-07-22 8:18 AM</date>
// <summary>
// 	Solution: Shp2Sql
// 	Project: Shp2Sql
// 	File: Null.cs
// 	Created: 2014-07-22 8:18 AM
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

    public class Null : BaseShape
    {
        public Null()
        {
        }

        public Null(ShapeFile shp, BinaryReader br, bool readHeader = true) : base(shp, br, readHeader)
        {
            if (!readHeader)
                ShapeType = ShapeTypeEnum.Null;
            if (shp.ShapeType != ShapeType &&
                ShapeType != ShapeTypeEnum.Null)
                throw new Exception(string.Format("Unable to process shape! Shape types do not match and isn't null! (Shapefile: {0} | Record: {1}", shp.ShapeType, ShapeType));
        }

        public static bool Import(ShapeFile shp, BinaryReader br, bool readHeader = true)
        {
            using (ShapeEntities db = new ShapeEntities())
            {
                Null newObj = new Null(shp, br, readHeader);
                db.Entry(db.Nulls.Add(newObj)).State = EntityState.Added;
                return db.SaveChanges() > 0;
            }
        }
    }
}