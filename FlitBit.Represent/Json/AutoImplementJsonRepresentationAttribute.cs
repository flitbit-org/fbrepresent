using System;
using FlitBit.Core.Factory;
using FlitBit.Core.Meta;

namespace FlitBit.Represent.Json
{
	/// <summary>
	///   Automatically creates implementations of IJsonRepresentations.
	/// </summary>
	public sealed class AutoImplementJsonRepresentationAttribute : AutoImplementedAttribute
	{
		/// <summary>
		///   Constructs a new instance.
		/// </summary>
		public AutoImplementJsonRepresentationAttribute()
			: base(InstanceScopeKind.ContainerScope)
		{
		}

		/// <summary>
		///   Gets the implementation for type
		/// </summary>
		/// <param name="factory">the factory from which the type was requested.</param>
		/// <param name="type">the target types</param>
		/// <param name="complete">callback invoked when the implementation is available</param>
		/// <returns>
		///   <em>true</em> if implemented; otherwise <em>false</em>.
		/// </returns>
		/// <exception cref="T:System.ArgumentException">thrown if <paramref name="type" /> is not eligible for implementation</exception>
		/// <remarks>
		///   If the <paramref name="complete" /> callback is invoked, it must be given either an implementation type
		///   assignable to type T, or a factory function that creates implementations of type T.
		/// </remarks>
		public override bool GetImplementation(IFactory factory, Type type, Action<Type, Func<object>> complete)
		{
			if (type.GetGenericTypeDefinition() == typeof (IJsonRepresentation<>))
			{
				Type[] args = type.GetGenericArguments();
				Type source = args[0];
				if (!source.IsValueType)
				{
					Type impl = factory.GetImplementationType(source);

					// Can deserialize if the implementation type has a default constructor...
					if (impl != null && impl.GetConstructor(Type.EmptyTypes) != null)
					{
						impl = (impl == source)
							? typeof (JsonRepresentationLoose<>).MakeGenericType(source)
							: typeof (DelegatedJsonRepresentationLoose<,>).MakeGenericType(source, impl);
						complete(impl, null);
						return true;
					}
				}
			}
			return false;
		}
	}
}