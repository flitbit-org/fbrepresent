#region COPYRIGHT© 2009-2013 Phillip Clark. All rights reserved.
// For licensing information see License.txt (MIT style licensing).
#endregion

using System;
using System.Diagnostics.Contracts;

namespace FlitBit.Represent.Json
{	
	/// <summary>
	/// Delegated JSON representation transform.
	/// </summary>
	/// <typeparam name="T">delegated target type T</typeparam>
	/// <typeparam name="C">target type C</typeparam>
	public class DelegatedJsonRepresentation<T, C> : DelegatedRepresentation<T, C, string>, IJsonRepresentation<T>
		where C : class, T
	{
		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="strict">Inidcates whether the JSON transorm should be strict</param>
		public DelegatedJsonRepresentation(bool strict)
			: base((strict) ? (IRepresentation<C, string>)new JsonRepresentationStrict<C>() : (IRepresentation<C, string>)new JsonRepresentationLoose<C>())
		{ 
		}
	}

	/// <summary>
	/// Delegated loose JSON representation transform.
	/// </summary>
	/// <typeparam name="T">delegated target type T</typeparam>
	/// <typeparam name="C">target type C</typeparam>
	public class DelegatedJsonRepresentationLoose<T, C> : DelegatedJsonRepresentation<T, C>
		where C : class, T
	{
		/// <summary>
		/// Creates a new instance.
		/// </summary>
		public DelegatedJsonRepresentationLoose()
			: base(false)
		{
		}
	}
	/// <summary>
	/// Delegated  strict JSON representation transform.
	/// </summary>
	/// <typeparam name="T">delegated target type T</typeparam>
	/// <typeparam name="C">target type C</typeparam>
	public class DelegatedJsonRepresentationStrict<T, C> : DelegatedJsonRepresentation<T, C>
		where C : class, T
	{
		/// <summary>
		/// Creates a new instance.
		/// </summary>
		public DelegatedJsonRepresentationStrict()
			: base(true)
		{
		}
	}
}
