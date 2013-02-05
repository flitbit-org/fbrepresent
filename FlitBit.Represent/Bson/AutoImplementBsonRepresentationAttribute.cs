using System;
using System.Reflection;
using FlitBit.Core.Factory;
using FlitBit.Emit;
using FlitBit.Emit.Meta;

namespace FlitBit.Represent.Json
{
	/// <summary>
	/// Automatically creates implementations of IJsonRepresentations.
	/// </summary>
	public sealed class AutoImplementBsonRepresentationAttribute: AutoImplementedAttribute
	{
		static readonly MethodInfo GetImplementationType = typeof(IFactory).GetGenericMethod("GetImplementationType", 0, 1);

		/// <summary>
		/// Automatically creates implementations of IJsonRepresentations.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="factory"></param>
		/// <param name="complete"></param>
		/// <returns></returns>
		public override bool GetImplementation<T>(IFactory factory, Action<Type, Func<T>> complete)
		{
			if (typeof(T).GetGenericTypeDefinition() == typeof(IBsonRepresentation<>))
			{
				var args = typeof(T).GetGenericArguments();
				Type source = args[0];
				if (!source.IsValueType)
				{
					Type impl = (Type)GetImplementationType.MakeGenericMethod(source).Invoke(factory, new object[0]);

					// Can deserialize if the implementation type has a default constructor...
					if (impl != null && impl.GetConstructor(Type.EmptyTypes) != null)
					{
						impl = (impl == source)
							? typeof(BsonRepresentationLoose<>).MakeGenericType(source)
							: typeof(DelegatedBsonRepresentationLoose<,>).MakeGenericType(source, impl);
						complete(impl, null);
						return true;
					}
				}
			}
			return false;
		}
	}
}
