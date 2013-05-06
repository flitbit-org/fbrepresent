using System;
using System.Linq;
using System.Reflection;
using FlitBit.Copy;
using FlitBit.Core;
using FlitBit.Emit;
using FlitBit.Represent.Json;
using FlitBit.Represent.Tests.Models;
using FlitBit.Wireup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace FlitBit.Represent.Tests
{
	[TestClass]
	public class JsonRepresentationTest
	{	
		[TestInitialize]
		public void Init()
		{
			WireupCoordinator.SelfConfigure();
		}

		[TestMethod]
		public void JsonRepresentation_CanRoundTripGeneratedType()
		{
			var rand = new Random();
			var factory = FactoryProvider.Factory;
			var rep = factory.CreateInstance<IJsonRepresentation<IMyModel>>();
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
				Assert.AreEqual(my.Created, nother.Created);
			}
		}
	}
}