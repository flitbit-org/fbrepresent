using System;
using System.Reflection;
using FlitBit.Core.Factory;
using FlitBit.Core.Meta;
using FlitBit.Emit;

namespace FlitBit.Represent.Json
{
	/// <summary>
	///   Automatically creates implementations of IJsonRepresentations.
	/// </summary>
	public sealed class AutoImplementJsonRepresentationAttribute : AutoImplementedAttribute
	{
		static readonly MethodInfo GetImplementationType = typeof(IFactory).MatchGenericMethod("GetImplementationType", 1, typeof(Type));
		
		/// <summary>
		///   Automatically creates implementations of IJsonRepresentations.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="factory"></param>
		/// <param name="complete"></param>
		/// <returns></returns>
		public override bool GetImplementation<T>(IFactory factory, Action<Type, Func<T>> complete)
		{
			if (typeof(T).GetGenericTypeDefinition() == typeof(IJsonRepresentation<>))
			{
				var args = typeof(T).GetGenericArguments();
				var source = args[0];
				if (!source.IsValueType)
				{
					var getImpl = GetImplementationType.MakeGenericMethod(source);
					var impl = (Type) getImpl.Invoke(factory, null);

					// Can deserialize if the implementation type has a default constructor...
					if (impl != null && impl.GetConstructor(Type.EmptyTypes) != null)
					{
						impl = (impl == source)
							? typeof(JsonRepresentationLoose<>).MakeGenericType(source)
							: typeof(DelegatedJsonRepresentationLoose<,>).MakeGenericType(source, impl);
						complete(impl, null);
						return true;
					}
				}
			}
			return false;
		}
	}
}