﻿#region COPYRIGHT© 2009-2014 Phillip Clark. All rights reserved.
// For licensing information see License.txt (MIT style licensing).
#endregion

namespace FlitBit.Represent.Json
{
	/// <summary>
	///   Delegated loose JSON representation transform.
	/// </summary>
	/// <typeparam name="T">delegated target type T</typeparam>
	/// <typeparam name="TRepresentation">target type C</typeparam>
	public class DelegatedJsonRepresentationLoose<T, TRepresentation> : DelegatedJsonRepresentation<T, TRepresentation>
		where TRepresentation : class, T
	{
		/// <summary>
		///   Creates a new instance.
		/// </summary>
		public DelegatedJsonRepresentationLoose()
			: base(false) { }
	}
}