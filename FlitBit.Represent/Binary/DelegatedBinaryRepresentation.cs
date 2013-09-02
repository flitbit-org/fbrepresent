#region COPYRIGHT© 2009-2013 Phillip Clark. All rights reserved.

// For licensing information see License.txt (MIT style licensing).

#endregion

namespace FlitBit.Represent.Binary
{
	/// <summary>
	///   Delegated binary representation transform.
	/// </summary>
	/// <typeparam name="T">delegated target type T</typeparam>
	/// <typeparam name="TConcrete">target type C</typeparam>
	public class DelegatedBinaryRepresentation<T, TConcrete> : DelegatedRepresentation<T, TConcrete, byte[]>,
		IBinaryRepresentation<T>
		where TConcrete : class, T
	{
		/// <summary>
		///   Creates a new instance.
		/// </summary>
		public DelegatedBinaryRepresentation()
			: base(new BinaryRepresentation<TConcrete>())
		{
		}
	}
}