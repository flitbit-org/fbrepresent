using FlitBit.Represent;
using FlitBit.Wireup;
using FlitBit.Wireup.Meta;

[assembly: Wireup(typeof(WireupThisAssembly))]

namespace FlitBit.Represent
{
	/// <summary>
	///   Wires up this assembly.
	/// </summary>
	public sealed class WireupThisAssembly : IWireupCommand
	{
		#region IWireupCommand Members

		/// <summary>
		///   Wires up this assembly.
		/// </summary>
		/// <param name="coordinator"></param>
		public void Execute(IWireupCoordinator coordinator) { }

		#endregion
	}
}