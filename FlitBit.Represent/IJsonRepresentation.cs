#region COPYRIGHT© 2009-2013 Phillip Clark. All rights reserved.
// For licensing information see License.txt (MIT style licensing).
#endregion

namespace FlitBit.Represent
{
	/// <summary>
	/// Transforms source item into a it's JSON representation
	/// </summary>
	/// <typeparam name="T">item type T</typeparam>
	public interface IJsonRepresentation<T> : IRepresentation<T, string>
	{
	}
}
