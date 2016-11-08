using System;
using System.Collections.Generic;
using System.Linq;

namespace Shp2Sql.Helpers
{
	#region Imports

	

	#endregion
	public static class MathHelper
	{
		public static double? Median<TColl, TValue>(this IEnumerable<TColl> source, Func<TColl, TValue> selector)
		{
			return source.Select(selector).Median();
		}

		public static double? Median<T>(this IEnumerable<T> source)
		{
			if (Nullable.GetUnderlyingType(typeof (T)) != null)
				source = source.Where(x => x != null);

			int count = source.Count();
			if (count == 0)
				return null;

			source = source.OrderBy(n => n);

			int midpoint = count/2;
			return count%2 == 0
				? (Convert.ToDouble(source.ElementAt(midpoint - 1)) + Convert.ToDouble(source.ElementAt(midpoint)))/2.0
				: Convert.ToDouble(source.ElementAt(midpoint));
		}
	}
}