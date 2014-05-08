#region COPYRIGHT© 2009-2014 Phillip Clark. All rights reserved.
// For licensing information see License.txt (MIT style licensing).
#endregion

using FlitBit.Wireup;
using FlitBit.Wireup.Meta;

[assembly: Wireup(typeof(FlitBit.Represent.AssemblyWireup))]

namespace FlitBit.Represent
{
	/// <summary>
	///   Wires up this assembly.
	/// </summary>
	public sealed class AssemblyWireup : IWireupCommand
	{
		#region IWireupCommand Members

		/// <summary>
		///   Wires up this assembly.
		/// </summary>
		/// <param name="coordinator"></param>
		public void Execute(IWireupCoordinator coordinator)
		{}

		#endregion
	}
}