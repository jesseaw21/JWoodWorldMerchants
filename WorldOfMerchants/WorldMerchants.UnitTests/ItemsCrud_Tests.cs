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
        const string RARE = "Rare";
        const string MERCHANT = "Underhill";
        const string TYPE = "Metal";

        [TestMethod]
        public void ItemsCrud_Index_Test()
        {
            // arrange
            List<Item> items = new List<Item>();
            Item item = new Item { Name = ITEM1_NAME };
            items.Add(item);

            FakeUnitOfWork fakeUnit = new FakeUnitOfWork(null, items);
            ItemsCrudController target = new ItemsCrudController(fakeUnit);

            // act
            var view = (ViewResult)target.Index();

            // assert
            var model = (List<Item>)view.Model;
            Assert.AreEqual(ITEM1_NAME, model[0].Name);
        }

        [TestMethod]
        public void ItemsCrud_Create_Test()
        {
            // arrange
            List<Item> items = new List<Item>();
            ItemCreateViewModel item = new ItemCreateViewModel { Name = ITEM1_NAME, Value = 12, Points = 4 };
            List<Merchant> merchants = new List<Merchant>();
            merchants.Add(new Merchant { Name = MERCHANT });

            FakeUnitOfWork fakeUnit = new FakeUnitOfWork(merchants, items);
            ItemsCrudController target = new ItemsCrudController(fakeUnit);

            // act
            target.Create(item, RARE, MERCHANT, TYPE);

            // assert
            Assert.AreEqual(ITEM1_NAME, items[0].Name);
        }

    }
}
