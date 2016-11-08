#region Copyright Header

// <copyright file="BoundingBoxM.cs" company="AH Operations">
// 	Copyright (c) 1985 - 2014 AH Operations All Rights Reserved
// 
// 	This source is created and maintained by AH Operations and is not available for public, private, or commercial use by any entity other than AH Operations.
// 
// 	Redistribution of this file in any part or entirety is strictly forbidden.
// </copyright>
// <author>Anthony Hart</author>
// <email>anthony@anthonyhart.info</email>
// <date>2014-07-22 10:05 PM</date>
// <summary>
// 	Solution: Shp2Sql
// 	Project: Shp2Sql
// 	File: BoundingBoxM.cs
// 	Created: 2014-07-22 10:05 PM
// 
// 	Purpose: WRITE A DESCRIPTION FOR THIS FILE!
// </summary>

#endregion

using System.IO;

namespace Shp2Sql.Classes.Shape
{
	#region Using Directives

	

	#endregion

	public class BoundingBoxM : BoundingBox
	{
		public BoundingBoxM()
		{
		}

		public BoundingBoxM(BinaryReader br) : base(br)
		{
			MMin = br.ReadDouble();
			MMax = br.ReadDouble();
		}
	}
}