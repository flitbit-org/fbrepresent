#region COPYRIGHT© 2009-2014 Phillip Clark. All rights reserved.

// For licensing information see License.txt (MIT style licensing).

#endregion

namespace FlitBit.Represent.Bson
{
	/// <summary>
	///   Transforms source item into a it's BSON representation
	/// </summary>
	/// <typeparam name="T">item type T</typeparam>
	[AutoImplementBsonRepresentation]
	public interface IBsonRepresentation<T> : IRepresentation<T, byte[]>
	{}
}