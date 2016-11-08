using System;
using System.Security.Cryptography;

namespace Shp2Sql.Helpers
{
	#region Imports

	

	#endregion
	public static class RandomHelper
	{
		private static readonly RNGCryptoServiceProvider _global = new RNGCryptoServiceProvider();

		[ThreadStatic]
		private static Random _local;

		public static int Next()
		{
			Random inst = _local;
			if (inst == null)
			{
				byte[] buffer = new byte[4];
				_global.GetBytes(buffer);
				_local = inst = new Random(
					BitConverter.ToInt32(buffer, 0));
			}
			return inst.Next();
		}

		public static int Next(int min, int max)
		{
			Random inst = _local;
			if (inst == null)
			{
				byte[] buffer = new byte[4];
				_global.GetBytes(buffer);
				_local = inst = new Random(
					BitConverter.ToInt32(buffer, 0));
			}
			return inst.Next(min, max);
		}
	}
}