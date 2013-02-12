#region COPYRIGHT© 2009-2013 Phillip Clark. All rights reserved.
// For licensing information see License.txt (MIT style licensing).
#endregion

using System;
using System.Diagnostics.Contracts;

namespace FlitBit.Represent.Bson
{	
	/// <summary>
	/// Delegated BSON representation transform.
	/// </summary>
	/// <typeparam name="T">delegated target type T</typeparam>
	/// <typeparam name="C">target type C</typeparam>
	public class DelegatedBsonRepresentation<T, C> : DelegatedRepresentation<T, C, byte[]>, IBsonRepresentation<T>
		where C : class, T
	{
		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="strict">Inidcates whether the JSON transorm should be strict</param>
		public DelegatedBsonRepresentation(bool strict)
			: base((strict) ? (IRepresentation<C, byte[]>)new BsonRepresentationStrict<C>() : (IRepresentation<C, byte[]>)new BsonRepresentationLoose<C>())
		{ 
		}
	}

	/// <summary>
	/// Delegated loose BSON representation transform.
	/// </summary>
	/// <typeparam name="T">delegated target type T</typeparam>
	/// <typeparam name="C">target type C</typeparam>
	public class DelegatedBsonRepresentationLoose<T, C> : DelegatedBsonRepresentation<T, C>
		where C : class, T
	{
		/// <summary>
		/// Creates a new instance.
		/// </summary>
		public DelegatedBsonRepresentationLoose()
			: base(false)
		{
		}
	}
	/// <summary>
	/// Delegated  strict BSON representation transform.
	/// </summary>
	/// <typeparam name="T">delegated target type T</typeparam>
	/// <typeparam name="C">target type C</typeparam>
	public class DelegatedBsonRepresentationStrict<T, C> : DelegatedBsonRepresentation<T, C>
		where C : class, T
	{
		/// <summary>
		/// Creates a new instance.
		/// </summary>
		public DelegatedBsonRepresentationStrict()
			: base(true)
		{
		}
	}
}
