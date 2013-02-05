using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlitBit.Dto;
using FlitBit.Core;
using FlitBit.Wireup;
using FlitBit.Represent.Json;
using FlitBit.Represent.Tests.Models;

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
			var factory = FactoryFactory.Instance;
			var rep = factory.CreateInstance<IJsonRepresentation<IMyModel>>();
			Assert.IsNotNull(rep);

			for (int i = 0; i < 10000; i++)
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
