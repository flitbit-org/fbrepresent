#region COPYRIGHT© 2009-2013 Phillip Clark. All rights reserved.
// For licensing information see License.txt (MIT style licensing).
#endregion

namespace FlitBit.Represent
{
	/// <summary>
	/// Abstract implementation.
	/// </summary>
	/// <typeparam name="T">item type T</typeparam>
	/// <typeparam name="R">representation type R</typeparam>
	public abstract class RepresentationBase<T, R> : IRepresentation<T, R>
	{
		/// <summary>
		/// Produces representation type R from an item.
		/// </summary>
		/// <param name="item">the item</param>
		/// <returns>a representation of the item</returns>
		public abstract R TransformItem(T item);
		/// <summary>
		/// Restores an item from a representation
		/// </summary>
		/// <param name="representation">the representation</param>
		/// <returns>the restored item</returns>
		public abstract T RestoreItem(R representation);
	}
}
