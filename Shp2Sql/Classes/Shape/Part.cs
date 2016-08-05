#region Copyright Header

// <copyright file="Part.cs" company="AH Operations">
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
// 	File: Part.cs
// 	Created: 2014-07-22 8:18 AM
// 
// 	Purpose: WRITE A DESCRIPTION FOR THIS FILE!
// </summary>

#endregion

using System.Collections.Generic;
using System.IO;
using Shp2Sql.Enumerators;

namespace Shp2Sql.Classes.Shape
{
	#region Using Directives

	

	#endregion

	public class Part
	{
		public Part()
		{
			Points = new HashSet<Point>();
		}

		public Part(BinaryReader br)
		{
			Points = new HashSet<Point>();
			StartIndex = br.ReadInt32();
		}

		public long Id { get; set; }
		public int StartIndex { get; set; }
		public int EndIndex { get; set; }
		public int NumberOfPoints { get; set; }
		public SurfacePatchTypeEnum PartType { get; set; }
		public ICollection<Point> Points { get; set; }
	}
}