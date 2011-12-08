using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.Text;
using System.IO;

namespace AngiesList.Redis
{
	public class SSJsonSerializer : IValueSerializer
	{
		public byte[] Serialize(object value)
		{
			var memStream = new MemoryStream(4);
			JsonSerializer.SerializeToStream(value, memStream);
			var bytes = memStream.ToArray();
			memStream.Close();
			return bytes;
		}

		public object Deserialize(byte[] bytes)
		{
			throw new NotImplementedException();
		}

		public object Deserialize(Type type, byte[] bytes)
		{
			var memStream = new MemoryStream(bytes);
			object value = ServiceStack.Text.JsonSerializer.DeserializeFromStream(type, memStream);
			memStream.Close();
			return value;
		}

	}
}
