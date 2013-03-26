#region COPYRIGHT© 2009-2013 Phillip Clark. All rights reserved.

// For licensing information see License.txt (MIT style licensing).

#endregion

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FlitBit.Represent.Binary
{
	/// <summary>
	///   Transforms source item into a it's binary representation
	/// </summary>
	/// <typeparam name="T">item type T</typeparam>
	public class BinaryRepresentation<T> : RepresentationBase<T, byte[]>, IBinaryRepresentation<T>
	{
		#region IBinaryRepresentation<T> Members

		/// <summary>
		///   Produces a binary representation from an item.
		/// </summary>
		/// <param name="item">the item</param>
		/// <returns>binary representation of the item</returns>
		public override byte[] TransformItem(T item)
		{
			using (var stream = new MemoryStream())
			{
				var formatter = new BinaryFormatter();
				formatter.Serialize(stream, item);
				return stream.ToArray();
			}
		}

		/// <summary>
		///   Restores an item from it's binary representation
		/// </summary>
		/// <param name="bytes">the item's binary representation</param>
		/// <returns>the restored item</returns>
		public override T RestoreItem(byte[] bytes)
		{
			using (var stream = new MemoryStream(bytes))
			{
				var formatter = new BinaryFormatter();
				return (T) formatter.Deserialize(stream);
			}
		}

		#endregion
	}
}