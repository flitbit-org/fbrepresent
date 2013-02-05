#region COPYRIGHT© 2009-2013 Phillip Clark. All rights reserved.
// For licensing information see License.txt (MIT style licensing).
#endregion

using Newtonsoft.Json;

namespace FlitBit.Represent.Json
{	
	/// <summary>
	/// Transforms an items into a BSON representation, ignoring missing members.
	/// </summary>
	/// <typeparam name="T">item type T</typeparam>
	public class BsonRepresentationLoose<T> : BsonRepresentation<T>
		where T : class
	{
		/// <summary>
		/// Creates a new instance.
		/// </summary>
		public BsonRepresentationLoose() : base(StaticJsonSettings.Loose) { }
	}
}
