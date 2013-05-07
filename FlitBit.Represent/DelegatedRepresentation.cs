#region COPYRIGHT© 2009-2013 Phillip Clark. All rights reserved.

// For licensing information see License.txt (MIT style licensing).

#endregion

using System;
using System.Diagnostics.Contracts;

namespace FlitBit.Represent
{
	/// <summary>
	///   Delegated representation transform. Transforms target type T into representation R, and upon
	///   restore, restores type C.
	/// </summary>
	/// <typeparam name="T">delegated target type T</typeparam>
	/// <typeparam name="TConcrete">target type C</typeparam>
	/// <typeparam name="TRepresentation">representation type R</typeparam>
	public class DelegatedRepresentation<T, TConcrete, TRepresentation> : IRepresentation<T, TRepresentation>
		where TConcrete : class, T
	{
		readonly IRepresentation<TConcrete, TRepresentation> _transform;

		/// <summary>
		///   Creates a new instance.
		/// </summary>
		/// <param name="transform">delegate target transform for type C to R</param>
		public DelegatedRepresentation(IRepresentation<TConcrete, TRepresentation> transform)
		{
			Contract.Requires<ArgumentNullException>(transform != null);

			_transform = transform;
		}

		#region IRepresentation<T,TRepresentation> Members

		/// <summary>
		///   Produces representation type R from an item.
		/// </summary>
		/// <param name="item">the item</param>
		/// <returns>a representation of the item</returns>
		public TRepresentation TransformItem(T item)
		{
			return _transform.TransformItem(item as TConcrete);
		}

		/// <summary>
		///   Restores an item from a representation
		/// </summary>
		/// <param name="representation">the representation</param>
		/// <returns>the restored item</returns>
		public T RestoreItem(TRepresentation representation)
		{
			return _transform.RestoreItem(representation);
		}

		/// <summary>
		///   Restores an item from a representation
		/// </summary>
		/// <param name="representation">the representation</param>
		/// <returns>the restored item</returns>
		public object UntypedRestoreItem(TRepresentation representation)
		{
			return RestoreItem(representation);
		}

		/// <summary>
		///   Produces representation type R from an item.
		/// </summary>
		/// <param name="item">the item</param>
		/// <returns>a representation of the item</returns>
		public TRepresentation UntypedTransformItem(object item)
		{
			return TransformItem((TConcrete) item);
		}

		#endregion
	}
}