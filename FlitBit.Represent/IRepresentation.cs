#region COPYRIGHT© 2009-2013 Phillip Clark. All rights reserved.

// For licensing information see License.txt (MIT style licensing).

#endregion

namespace FlitBit.Represent
{
	/// <summary>
	///   Transforms source item into an alternate representation.
	/// </summary>
	/// <typeparam name="TRepresentation">representation type R</typeparam>
	public interface IRepresentation<TRepresentation>
	{
		/// <summary>
		///   Restores an item from a representation
		/// </summary>
		/// <param name="representation">the representation</param>
		/// <returns>the restored item</returns>
		object UntypedRestoreItem(TRepresentation representation);

		/// <summary>
		///   Produces representation type R from an item.
		/// </summary>
		/// <param name="item">the item</param>
		/// <returns>a representation of the item</returns>
		TRepresentation UntypedTransformItem(object item);
	}

	/// <summary>
	///   Transforms source item into an alternate representation.
	/// </summary>
	/// <typeparam name="T">item type T</typeparam>
	/// <typeparam name="TRepresentation">representation type R</typeparam>
	public interface IRepresentation<T, TRepresentation> : IRepresentation<TRepresentation>
	{
		/// <summary>
		///   Restores an item from a representation
		/// </summary>
		/// <param name="representation">the representation</param>
		/// <returns>the restored item</returns>
		T RestoreItem(TRepresentation representation);

		/// <summary>
		///   Produces representation type R from an item.
		/// </summary>
		/// <param name="item">the item</param>
		/// <returns>a representation of the item</returns>
		TRepresentation TransformItem(T item);
	}
}