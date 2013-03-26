﻿#region COPYRIGHT© 2009-2013 Phillip Clark. All rights reserved.

// For licensing information see License.txt (MIT style licensing).

#endregion

namespace FlitBit.Represent
{
	/// <summary>
	///   Abstract implementation.
	/// </summary>
	/// <typeparam name="T">item type T</typeparam>
	/// <typeparam name="TRepresentation">representation type R</typeparam>
	public abstract class RepresentationBase<T, TRepresentation> : IRepresentation<T, TRepresentation>
	{
		#region IRepresentation<T,R> Members

		/// <summary>
		///   Produces representation type R from an item.
		/// </summary>
		/// <param name="item">the item</param>
		/// <returns>a representation of the item</returns>
		public abstract TRepresentation TransformItem(T item);

		/// <summary>
		///   Restores an item from a representation
		/// </summary>
		/// <param name="representation">the representation</param>
		/// <returns>the restored item</returns>
		public abstract T RestoreItem(TRepresentation representation);

		#endregion
	}
}