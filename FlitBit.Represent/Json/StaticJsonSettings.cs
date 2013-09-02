using Newtonsoft.Json;

namespace FlitBit.Represent.Json
{
	internal static class StaticJsonSettings
	{
		internal static readonly JsonSerializerSettings Loose = new JsonSerializerSettings
		{
			MissingMemberHandling = MissingMemberHandling.Ignore,
			ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
			Converters = new[] {new FactorySupportedJsonConverter()}
		};

		internal static readonly JsonSerializerSettings Strict = new JsonSerializerSettings
		{
			MissingMemberHandling = MissingMemberHandling.Error,
			ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
			Converters = new[] {new FactorySupportedJsonConverter()}
		};
	}
}