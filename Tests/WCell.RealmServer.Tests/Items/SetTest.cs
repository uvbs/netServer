using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WCell.RealmServer.Tests.Misc;
using WCell.RealmServer.Entities;
using WCell.RealmServer.Items;

namespace WCell.RealmServer.Tests.Items
{
	/// <summary>
	/// Summary description for SetTest
	/// </summary>
	[TestClass]
	public class SetTest
	{
		static Character m_char;

		public SetTest()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		//
		// You can use the following additional attributes as you write your tests:
		//
		// Use ClassInitialize to run code before running the first test in the class
		// [ClassInitialize()]
		// public static void MyClassInitialize(TestContext testContext) { }
		//
		// Use ClassCleanup to run code after all tests in a class have run
		// [ClassCleanup()]
		// public static void MyClassCleanup() { }
		//
		// Use TestInitialize to run code before running each test 
		// [TestInitialize()]
		// public void MyTestInitialize() { }
		//
		// Use TestCleanup to run code after each test has run
		// [TestCleanup()]
		// public void MyTestCleanup() { }
		//
		#endregion

		[ClassInitialize()]
		public static void Initialize(TestContext testContext)
		{
			Setup.EnsureItemsInitialized();

			m_char = Setup.DefaultCharacter;
		}

		[TestMethod]
		public void TestAddSet()
		{
			uint setId = 1;
			var setBagSlot = 0;

			// make sure the first slot is empty so the set will be added to it
			m_char.Inventory.EquippedContainers.RemoveBag(setBagSlot);

			var set = ItemMgr.Sets[setId];
			Assert.IsNotNull(set);
			var result = ItemSet.CreateSet(m_char, setId);
			Assert.IsTrue(result);

			var bag = m_char.Inventory.EquippedContainers.GetBag(setBagSlot);
			Assert.IsNotNull(bag);

			Assert.AreEqual(set.Templates.Length, bag.BaseInventory.Count);
		}
	}
}