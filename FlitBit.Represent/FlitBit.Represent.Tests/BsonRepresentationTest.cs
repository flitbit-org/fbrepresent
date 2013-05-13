using System;
using FlitBit.Core;
using FlitBit.Emit;
using FlitBit.Represent.Bson;
using FlitBit.Represent.Tests.Models;
using FlitBit.Wireup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlitBit.Represent.Tests
{
	[TestClass]
	public class BsonRepresentationTest
	{
		public TestContext TestContext { get; set; }

		[TestInitialize]
		public void Init()
		{
			RuntimeAssemblies.WriteDynamicAssemblyOnExit = true;
			WireupCoordinator.SelfConfigure();
		}

		[TestCleanup]
		public void Cleanup()
		{
			var report = WireupCoordinator.Instance.ReportWireupHistory();
			TestContext.WriteLine("---------- Wireup Report ----------");
			TestContext.WriteLine(report);
		}

		[TestMethod]
		public void BsonRepresentation_CanRoundTripGeneratedType()
		{
			var rand = new Random();
			var factory = FactoryProvider.Factory;
			var rep = factory.CreateInstance<IBsonRepresentation<IMyModel>>();
			Assert.IsNotNull(rep);

			for (var i = 0; i < 10000; i++)
			{
				var my = factory.CreateInstance<IMyModel>();
				my.Created = DateTime.Now;
				my.ID = rand.Next();
				my.Name = String.Concat("MyIdentityIs", my.ID);

				var ser = rep.TransformItem(my);
				var nother = rep.RestoreItem(ser);
				Assert.AreEqual(my.ID, nother.ID);
				Assert.AreEqual(my.Name, nother.Name);
				// Some date bits get dropped in the round-trip...
				Assert.AreEqual(my.Created.ToLongDateString(), nother.Created.ToLongDateString());
			}
		}
	}
}