#region Copyright Header

// <copyright file="RecordHeader.cs" company="AH Operations">
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
// 	File: RecordHeader.cs
// 	Created: 2014-07-22 8:18 AM
// 
// 	Purpose: WRITE A DESCRIPTION FOR THIS FILE!
// </summary>

#endregion

using System.IO;
using Shp2Sql.Classes.Helpers;

namespace Shp2Sql.Classes.Shape
{
	#region Using Directives

	

	#endregion

	public class RecordHeader
	{
		public RecordHeader()
		{
		}

		public RecordHeader(BinaryReader br)
		{
			RecordNumber = NumericsHelper.ReverseInt(br.ReadInt32()); // Big, Reverse for actual value
			ContentLength = NumericsHelper.ReverseInt(br.ReadInt32()); // Big, Reverse for actual value
		}

		public long Id { get; set; }
		public int RecordNumber { get; set; }
		public int ContentLength { get; set; }
	}
}