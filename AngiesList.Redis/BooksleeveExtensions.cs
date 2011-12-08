using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookSleeve;

namespace AngiesList.Redis
{
	internal static class BooksleeveExtensions
	{
		public static bool NeedsReset(this RedisConnectionBase connection)
		{
			return connection == null ||
				 (connection.State != RedisConnectionBase.ConnectionState.Open &&
				  connection.State != RedisConnectionBase.ConnectionState.Opening);
		}

		public static IDictionary<string, byte[]> ToEvenOddPairsDictionary(this byte[][] target)
		{
			Dictionary<string, byte[]> retVal = new Dictionary<string, byte[]>();
			for (var i = 0; i < target.Length; i++) {
				var key = Encoding.ASCII.GetString(target[i]);
				retVal.Add(key, target[++i]);
			}
			return retVal;
		}
	}
}
