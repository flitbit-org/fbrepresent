#region COPYRIGHT© 2009-2013 Phillip Clark. All rights reserved.

// For licensing information see License.txt (MIT style licensing).

#endregion

namespace FlitBit.Represent.Bson
{
	/// <summary>
	///   Delegated BSON representation transform.
	/// </summary>
	/// <typeparam name="T">delegated target type T</typeparam>
	/// <typeparam name="TConcrete">target type C</typeparam>
	public class DelegatedBsonRepresentation<T, TConcrete> : DelegatedRepresentation<T, TConcrete, byte[]>,
		IBsonRepresentation<T>
		where TConcrete : class, T
	{
		/// <summary>
		///   Creates a new instance.
		/// </summary>
		/// <param name="strict">Inidcates whether the JSON transorm should be strict</param>
		public DelegatedBsonRepresentation(bool strict)
			: base(
				(strict)
					? new BsonRepresentationStrict<TConcrete>()
					: (IRepresentation<TConcrete, byte[]>) new BsonRepresentationLoose<TConcrete>())
		{
		}
	}
}