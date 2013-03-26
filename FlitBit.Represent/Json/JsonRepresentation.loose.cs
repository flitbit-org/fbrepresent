#region COPYRIGHT© 2009-2013 Phillip Clark. All rights reserved.

// For licensing information see License.txt (MIT style licensing).

#endregion

namespace FlitBit.Represent.Json
{
	/// <summary>
	///   Transforms an items into a JSON representation, ignoring missing members.
	/// </summary>
	/// <typeparam name="T">item type T</typeparam>
	public class JsonRepresentationLoose<T> : JsonRepresentation<T>
		where T : class
	{
		/// <summary>
		///   Creates a new instance.
		/// </summary>
		public JsonRepresentationLoose()
			: base(StaticJsonSettings.Loose) { }
	}
}