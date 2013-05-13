using System;
using System.Collections.Generic;
using System.Linq;
using FlitBit.Core;
using FlitBit.Core.Factory;
using FlitBit.Emit;
using FlitBit.Represent.Json;
using FlitBit.Represent.Tests.Models;
using FlitBit.Wireup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlitBit.Represent.Tests
{
	[TestClass]
	public class JsonRepresentationTest
	{
		static Random _random = new Random(Environment.TickCount);

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
		public void JsonRepresentation_CanRoundTripComplexType()
		{
			var factory = FactoryProvider.Factory;
			var rep = factory.CreateInstance<IJsonRepresentation<IComplexModel>>();
			Assert.IsNotNull(rep);

			for (var i = 0; i < 10000; i++)
			{
				var dto = SetupComplexModel(factory);
				Assert.IsNotNull(dto);
				Assert.AreNotEqual(dto.Id, Guid.Empty);

				var serializedDto = rep.TransformItem(dto);
				Assert.IsFalse(string.IsNullOrEmpty(serializedDto));

				var restoredDto = rep.RestoreItem(serializedDto);
				Assert.IsNotNull(restoredDto);
				Assert.AreEqual(dto.Id, restoredDto.Id);
				Assert.AreEqual(dto.Name, restoredDto.Name);
				Assert.AreEqual(dto.Model, restoredDto.Model);
			}
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

		[TestMethod]
		public void JsonRepresentation_CanRoundTripModelWithInterfaceDrivenArray()
		{
			var factory = FactoryProvider.Factory;
			var rep = factory.CreateInstance<IJsonRepresentation<IArrayBasedModel>>();
			Assert.IsNotNull(rep);

			for (var i = 0; i < 1000; i++)
			{
				var dto = SetupArrayModel(factory);
				Assert.IsNotNull(dto);
				Assert.AreNotEqual(dto.Id, Guid.Empty);

				var serializedDto = rep.TransformItem(dto);
				Assert.IsFalse(string.IsNullOrEmpty(serializedDto));

				var restoredDto = rep.RestoreItem(serializedDto);
				Assert.IsNotNull(restoredDto);
				Assert.AreEqual(dto.Id, restoredDto.Id);
				Assert.AreEqual(dto.Name, restoredDto.Name);
				Assert.AreEqual(dto.Items.Count(), restoredDto.Items.Count());

				if (dto.Items.Any())
				{
					Assert.AreEqual(dto.Items.ElementAt(0)
														.Id, restoredDto.Items.ElementAt(0)
																						.Id);
					Assert.AreEqual(dto.Items.ElementAt(0)
														.Name, restoredDto.Items.ElementAt(0)
																							.Name);
					Assert.AreEqual(dto.Items.ElementAt(0)
														.CreatedAt, restoredDto.Items.ElementAt(0)
																									.CreatedAt);

					var lastIndex = dto.Items.Count() - 1;
					Assert.AreEqual(dto.Items.ElementAt(lastIndex)
														.Id, restoredDto.Items.ElementAt(lastIndex)
																						.Id);
					Assert.AreEqual(dto.Items.ElementAt(lastIndex)
														.Name, restoredDto.Items.ElementAt(lastIndex)
																							.Name);
					Assert.AreEqual(dto.Items.ElementAt(lastIndex)
														.CreatedAt, restoredDto.Items.ElementAt(lastIndex)
																									.CreatedAt);
				}
			}
		}

		IArrayBasedModel SetupArrayModel(IFactory factory)
		{
			var arrayModel = factory.CreateInstance<IArrayBasedModel>();
			arrayModel.Id = Guid.NewGuid();
			arrayModel.Name = String.Concat("Name{0}", arrayModel.Id);
			arrayModel.Items = factory.CreateInstance<List<IArrayItemModel>>();

			arrayModel.Items = SetupItems(factory)
				.ToList();

			Assert.IsNotNull(arrayModel);
			return arrayModel;
		}

		IComplexModel SetupComplexModel(IFactory factory)
		{
			var complex = factory.CreateInstance<IComplexModel>();
			complex.Id = Guid.NewGuid();
			complex.Name = String.Concat("Name{0}", complex.Id);

			var subModel = factory.CreateInstance<ISubModel>();
			subModel.Id = Guid.NewGuid();
			subModel.Name = String.Concat("Name{0}", subModel.Id);
			complex.Model = subModel;
			return complex;
		}

		IEnumerable<IArrayItemModel> SetupItems(IFactory factory)
		{
			for (var i = 0; i < _random.Next(0, 15); i++)
			{
				var item = factory.CreateInstance<IArrayItemModel>();
				item.Id = Guid.NewGuid();
				item.CreatedAt = DateTime.UtcNow;
				item.Name = String.Concat("Name{0}{1}", item.Id, item.CreatedAt);
				yield return item;
			}
		}
	}
}