#region COPYRIGHT© 2009-2014 Phillip Clark. All rights reserved.
// For licensing information see License.txt (MIT style licensing).
#endregion

using Newtonsoft.Json;

namespace FlitBit.Represent.Json
{
	internal static class StaticJsonSettings
	{
		internal static readonly JsonSerializerSettings Loose = new JsonSerializerSettings
		{
			MissingMemberHandling = MissingMemberHandling.Ignore,
			ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
			Converters = new[] { new FactorySupportedJsonConverter() }
		};

		internal static readonly JsonSerializerSettings Strict = new JsonSerializerSettings
		{
			MissingMemberHandling = MissingMemberHandling.Error,
			ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
			Converters = new[] { new FactorySupportedJsonConverter() }
		};
	}
}