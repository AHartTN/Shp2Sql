#region Copyright Header
// <copyright file="NumericsHelper.cs" company="AH Operations">
// 	Copyright (c) 1985 - 2014 AH Operations All Rights Reserved
// 
// 	This source is created and maintained by AH Operations and is not available for public, private, or commercial use by any entity other than AH Operations.
// 
// 	Redistribution of this file in any part or entirety is strictly forbidden.
// </copyright>
// <author>Anthony Hart</author>
// <email>anthony@anthonyhart.info</email>
// <date>2014-07-22 6:57 PM</date>
// <summary>
// 	Solution: Shp2Sql
// 	Project: Shp2Sql
// 	File: NumericsHelper.cs
// 	Created: 2014-07-22 6:57 PM
// 
// 	Purpose: WRITE A DESCRIPTION FOR THIS FILE!
// </summary>
#endregion

namespace Shp2Sql.Classes.Helpers
{
    #region Using Directives
    using System;
    #endregion

    /// <summary>A class designed for aiding with common funtions regarding numerical values.</summary>
    public class NumericsHelper
    {
        /// <summary>Convert an integer's byte order</summary>
        /// <param name="source">The integer to reverse</param>
        /// <returns>The reversed integer (Small if source was big and visa-versa)</returns>
        public static int ReverseInt(int source)
        {
            byte[] fileCodeBytes = BitConverter.GetBytes(source);
            Array.Reverse(fileCodeBytes);
            string fileCodeByteString = fileCodeBytes.ToString();
            return BitConverter.ToInt32(fileCodeBytes, 0);
        }
    }
}