using System;
using System.Reflection;
using FlitBit.Core.Factory;
using FlitBit.Core.Meta;
using FlitBit.Emit;

namespace FlitBit.Represent.Binary
{
	/// <summary>
	/// Automatically creates implementations of IBsonRepresentations.
	/// </summary>
	public sealed class AutoImplementBinaryRepresentationAttribute : AutoImplementedAttribute
	{
		static readonly MethodInfo GetImplementationType = typeof(IFactory).GetGenericMethod("GetImplementationType", 0, 1);

		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public AutoImplementBinaryRepresentationAttribute()
			: base(InstanceScopeKind.ContainerScope)
		{		
		}
		/// <summary>
		/// Automatically creates implementations of IBsonRepresentations.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="factory"></param>
		/// <param name="complete"></param>
		/// <returns></returns>
		public override bool GetImplementation<T>(IFactory factory, Action<Type, Func<T>> complete)
		{
			if (typeof(T).GetGenericTypeDefinition() == typeof(IBinaryRepresentation<>))
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
							? typeof(BinaryRepresentation<>).MakeGenericType(source)
							: typeof(DelegatedBinaryRepresentation<,>).MakeGenericType(source, impl);
						complete(impl, null);
						return true;
					}
				}
			}
			return false;
		}
	}
}
