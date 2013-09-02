using FlitBit.Wireup;
using FlitBit.Wireup.Meta;

[assembly: WireupDependency(typeof (AssemblyWireup))]
[assembly: Wireup(typeof (FlitBit.Represent.AssemblyWireup))]

namespace FlitBit.Represent
{
	/// <summary>
	///   Wires up this assembly; target for dependent assemblies.
	/// </summary>
	public sealed class AssemblyWireup : IWireupCommand
	{
		/// <summary>
		///   Wires up this assembly.
		/// </summary>
		/// <param name="coordinator"></param>
		public void Execute(IWireupCoordinator coordinator)
		{
		}
	}
}