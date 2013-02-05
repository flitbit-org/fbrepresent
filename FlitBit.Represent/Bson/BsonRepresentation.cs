#region COPYRIGHT© 2009-2013 Phillip Clark. All rights reserved.
// For licensing information see License.txt (MIT style licensing).
#endregion

using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace FlitBit.Represent.Json
{
	
	/// <summary>
	/// Transforms source item into a it's JSON representation
	/// </summary>
	/// <typeparam name="T">item type T</typeparam>
	public class BsonRepresentation<T> : RepresentationBase<T, byte[]>, IBsonRepresentation<T>
	{
		readonly JsonSerializerSettings _settings;
		
		/// <summary>
		/// Creates a new instance with serializer settings given.
		/// </summary>
		/// <param name="settings">serializer settings</param>
		public BsonRepresentation(JsonSerializerSettings settings)
		{
			Contract.Requires<ArgumentNullException>(settings != null);
			_settings = settings;
		}

		/// <summary>
		/// Produces a BSON representation from an item.
		/// </summary>
		/// <param name="item">the item</param>
		/// <returns>BSON representation of the item</returns>
		public override byte[] TransformItem(T item)
		{
			using(var stream = new MemoryStream())
			using (var writer = new BsonWriter(stream))
			{
				JsonSerializer serializer = JsonSerializer.Create(_settings);
				serializer.Serialize(writer, item);
				return stream.ToArray();				
			}
		}

		/// <summary>
		/// Restores an item from it's BSON representation
		/// </summary>
		/// <param name="bson">the item's BSON representation</param>
		/// <returns>the restored item</returns>
		public override T RestoreItem(byte[] bson)
		{
			// convert string to stream
			using (var stream = new MemoryStream(bson))
			using (var reader = new BsonReader(stream))
			{
				var jsonSerializer = JsonSerializer.Create(_settings);
				return (T)jsonSerializer.Deserialize(reader, typeof(T));
			}
		}
	}
}
