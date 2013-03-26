using System;
using System.Reflection;
using FlitBit.Core.Factory;
using FlitBit.Core.Meta;
using FlitBit.Emit;

namespace FlitBit.Represent.Bson
{
	/// <summary>
	///   Automatically creates implementations of IBsonRepresentations.
	/// </summary>
	public sealed class AutoImplementBsonRepresentationAttribute : AutoImplementedAttribute
	{
		static readonly MethodInfo GetImplementationType = typeof(IFactory).MatchGenericMethod("GetImplementationType", 1, typeof(Type));

		/// <summary>
		///   Constructs a new instance.
		/// </summary>
		public AutoImplementBsonRepresentationAttribute()
			: base(InstanceScopeKind.ContainerScope) { }

		/// <summary>
		///   Automatically creates implementations of IBsonRepresentations.
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
				var source = args[0];
				if (!source.IsValueType)
				{
					var getImpl = GetImplementationType.MakeGenericMethod(source);
					var impl = (Type)getImpl.Invoke(factory, null);

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