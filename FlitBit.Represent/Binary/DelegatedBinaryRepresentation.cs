#region COPYRIGHT© 2009-2013 Phillip Clark. All rights reserved.
// For licensing information see License.txt (MIT style licensing).
#endregion

using System;
using System.Diagnostics.Contracts;

namespace FlitBit.Represent.Binary
{	
	/// <summary>
	/// Delegated binary representation transform.
	/// </summary>
	/// <typeparam name="T">delegated target type T</typeparam>
	/// <typeparam name="C">target type C</typeparam>
	public class DelegatedBinaryRepresentation<T, C> : DelegatedRepresentation<T, C, byte[]>, IBinaryRepresentation<T>
		where C : class, T
	{
		/// <summary>
		/// Creates a new instance.
		/// </summary>
		public DelegatedBinaryRepresentation() : base(new BinaryRepresentation<C>())
		{ 
		}
	}		 
	
}
