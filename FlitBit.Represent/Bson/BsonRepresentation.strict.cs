#region COPYRIGHT© 2009-2013 Phillip Clark. All rights reserved.
// For licensing information see License.txt (MIT style licensing).
#endregion

using Newtonsoft.Json;
using FlitBit.Represent.Json;

namespace FlitBit.Represent.Bson
{
	/// <summary>
	/// Transforms an items into a BSON representation, erroring on missing members.
	/// </summary>
	/// <typeparam name="T">item type T</typeparam>
	public class BsonRepresentationStrict<T> : BsonRepresentation<T>
		where T : class
	{
		/// <summary>
		/// Creates a new instance.
		/// </summary>
		public BsonRepresentationStrict() : base(StaticJsonSettings.Strict) { }
	}
}
