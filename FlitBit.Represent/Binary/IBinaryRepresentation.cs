#region COPYRIGHT© 2009-2013 Phillip Clark. All rights reserved.
// For licensing information see License.txt (MIT style licensing).
#endregion

namespace FlitBit.Represent.Binary
{
	/// <summary>
	/// Transforms source item into a it's binary serialized representation.
	/// </summary>
	/// <typeparam name="T">item type T</typeparam>
	[AutoImplementBinaryRepresentation]
	public interface IBinaryRepresentation<T> : IRepresentation<T, byte[]>
	{
	}
}
