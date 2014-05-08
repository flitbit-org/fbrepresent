#region COPYRIGHT© 2009-2014 Phillip Clark. All rights reserved.

// For licensing information see License.txt (MIT style licensing).

#endregion

namespace FlitBit.Represent.Json
{
	/// <summary>
	///   Delegated JSON representation transform.
	/// </summary>
	/// <typeparam name="T">delegated target type T</typeparam>
	/// <typeparam name="TRepresentation">target type C</typeparam>
	public class DelegatedJsonRepresentation<T, TRepresentation> : DelegatedRepresentation<T, TRepresentation, string>, IJsonRepresentation<T>
		where TRepresentation : class, T
	{
		/// <summary>
		///   Creates a new instance.
		/// </summary>
		/// <param name="strict">Inidcates whether the JSON transorm should be strict</param>
		public DelegatedJsonRepresentation(bool strict)
			: base(
				(strict)
					? new JsonRepresentationStrict<TRepresentation>()
					: (IRepresentation<TRepresentation, string>) new JsonRepresentationLoose<TRepresentation>()) { }
	}
}