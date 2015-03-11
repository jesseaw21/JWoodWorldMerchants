using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldOfMerchants.Models;
using System.Collections.Generic;
using WorldOfMerchants.DAL;
using WorldOfMerchants.Controllers;
using System.Web.Mvc;

namespace WorldMerchants.UnitTests
{
    [TestClass]
    public class MerchantsCrud_Tests
    {        
        const string MERCHANT1 = "Dubious";

        [TestMethod]
        public void MerchantsCrud_Index_Test()
        {
            // arrange
            List<Merchant> merchants = new List<Merchant>();

            merchants.Add(new Merchant { Name = MERCHANT1 });

            FakeUnitOfWork fakeUnit = new FakeUnitOfWork(merchants);
            MerchantsCrudController target = new MerchantsCrudController(fakeUnit);

            //// act
            var view = (ViewResult)target.Index();

            //// assert
            var model = (List<Merchant>)view.Model;
            Assert.AreEqual(MERCHANT1, model[0].Name);
        }

        [TestMethod]
        public void MerchantsCrud_Create_Test()
        {
            // arrange
            List<Merchant> merchants = new List<Merchant>();
            Merchant merch = new Merchant { Name = MERCHANT1 };

            FakeUnitOfWork fakeUnit = new FakeUnitOfWork(merchants);
            MerchantsCrudController target = new MerchantsCrudController(fakeUnit);

            // act
            target.Create(merch);

            // assert
            Assert.AreEqual(MERCHANT1, merchants[0].Name);
        }
    }
}
