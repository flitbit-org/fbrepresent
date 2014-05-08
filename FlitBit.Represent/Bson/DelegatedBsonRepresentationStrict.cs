#region COPYRIGHT© 2009-2014 Phillip Clark. All rights reserved.
// For licensing information see License.txt (MIT style licensing).
#endregion

namespace FlitBit.Represent.Bson
{
	/// <summary>
	///   Delegated  strict BSON representation transform.
	/// </summary>
	/// <typeparam name="T">delegated target type T</typeparam>
	/// <typeparam name="TConcrete">target type C</typeparam>
	public class DelegatedBsonRepresentationStrict<T, TConcrete> : DelegatedBsonRepresentation<T, TConcrete>
		where TConcrete : class, T
	{
		/// <summary>
		///   Creates a new instance.
		/// </summary>
		public DelegatedBsonRepresentationStrict()
			: base(true) { }
	}
}