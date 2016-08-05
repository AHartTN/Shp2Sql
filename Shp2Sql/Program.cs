#region Copyright Header

// <copyright file="Program.cs" company="AH Operations">
// 	Copyright (c) 1985 - 2014 AH Operations All Rights Reserved
// 
// 	This source is created and maintained by AH Operations and is not available for public, private, or commercial use by any entity other than AH Operations.
// 
// 	Redistribution of this file in any part or entirety is strictly forbidden.
// </copyright>
// <author>Anthony Hart</author>
// <email>anthony@anthonyhart.info</email>
// <date>2014-07-20 4:09 AM</date>
// <summary>
// 	Solution: Shp2Sql
// 	Project: Shp2Sql
// 	File: Program.cs
// 	Created: 2014-07-20 4:09 AM
// 
// 	Purpose: WRITE A DESCRIPTION FOR THIS FILE!
// </summary>

#endregion

using System;
using System.Configuration;

namespace Shp2Sql
{
	#region Using Directives

	

	#endregion

	public class Program
	{
		public static string SourcePath = ConfigurationManager.AppSettings["SourcePath"];

		private static void Main(string[] args)
		{
			ESRIHelper.ProcessDirectory(SourcePath);

			foreach (var arg in args)
				ESRIHelper.ProcessDirectory(arg);

			Console.ReadKey(true);
		}
	}
}