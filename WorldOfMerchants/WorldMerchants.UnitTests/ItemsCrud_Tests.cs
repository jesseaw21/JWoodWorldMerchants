using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldOfMerchants.Models;
using System.Collections.Generic;
using WorldOfMerchants.DAL;
using WorldOfMerchants.Controllers;
using System.Web.Mvc;
using WorldMerchants.Controllers;

namespace WorldMerchants.UnitTests
{
    [TestClass]
    public class ItemsCrud_Tests
    {
        const string ITEM1_NAME = "Goldenrod";
        const string ITEM2_NAME = "Scythe";
        const string RARE = "Rare";
        const string MERCHANT = "Underhill";
        const string TYPE = "Metal";

        [TestMethod]
        public void ItemsCrud_Index_Test()
        {
            // arrange
            List<Item> items = new List<Item>();
            Item item = new Item { Name = ITEM1_NAME };
            Item item2 = new Item { Name = ITEM2_NAME };
            items.Add(item);
            items.Add(item2);

            FakeUnitOfWork fakeUnit = new FakeUnitOfWork(null, items);
            ItemsCrudController target = new ItemsCrudController(fakeUnit);

            // act
            var view = (ViewResult)target.Index();

            // assert
            var model = (List<Item>)view.Model;
            Assert.AreEqual(ITEM1_NAME, model[0].Name);
            Assert.AreEqual(ITEM2_NAME, model[1].Name);
        }

        [TestMethod]
        public void ItemsCrud_Create_Test()
        {
            // arrange
            List<Item> items = new List<Item>();
            ItemCreateViewModel item = new ItemCreateViewModel { Name = ITEM1_NAME, Value = 12, Points = 4 };
            ItemCreateViewModel item2 = new ItemCreateViewModel { Name = ITEM2_NAME };
            List<Merchant> merchants = new List<Merchant>();
            merchants.Add(new Merchant { ID = 1, Name = MERCHANT });

            FakeUnitOfWork fakeUnit = new FakeUnitOfWork(merchants, items);
            ItemsCrudController target = new ItemsCrudController(fakeUnit);

            // act
            target.Create(item, RARE, MERCHANT, TYPE);
            target.Create(item2, RARE, MERCHANT, TYPE);

            // assert
            Assert.AreEqual(ITEM1_NAME, items[0].Name);
            Assert.AreEqual(ITEM2_NAME, items[1].Name);
            Assert.AreEqual(1, items[0].MerchantID);
        }

    }
}
