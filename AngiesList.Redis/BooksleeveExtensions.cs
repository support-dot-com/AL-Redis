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

	}
}
