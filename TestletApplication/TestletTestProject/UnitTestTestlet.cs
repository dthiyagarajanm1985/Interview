using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestletLibrary;
using System.Collections.Generic;
namespace TestletTestProject
{
    [TestClass]
    public class UnitTestTestlet
    {
        Testlet testlet = new Testlet();
        DataAccess dataAccess = new DataAccess("TestletItems.xml");
        DataAccess defaultData = new DataAccess();

        [TestMethod]        
        public void MinimumTestletItemCount()
        {
            Assert.AreEqual(10, dataAccess.GetData().Count);
        }
        [TestMethod]
        public void MaximumTestletItemCount()
        {
            Assert.AreEqual(10, dataAccess.GetData().Count);
        }
        [TestMethod]
        public void MinimumAnswerCount()
        {
            List<ItemsItem> allitems = dataAccess.GetData();
            foreach (ItemsItem item in allitems)
            {
                Assert.AreEqual(4, item.Answers.Length);
            }
        }
        [TestMethod]
        public void MaximumAnswerCount()
        {
            List<ItemsItem> allitems = dataAccess.GetData();
            foreach (ItemsItem item in allitems)
            {
                Assert.AreEqual(4, item.Answers.Length);
            }
        }

        [TestMethod]
        public void NullCheckItem()
        {
            Assert.AreSame(null, defaultData.GetData());
        }
        [TestMethod]
        public void MinimumOperationalCount()
        {
            List<ItemsItem> allitems = dataAccess.GetData().FindAll(a=>a.ItemType.ToString()=="Operational");
            Assert.AreEqual(6, allitems.Count);
            
        }
        [TestMethod]
        public void MaximumOperationalCount()
        {
            List<ItemsItem> allitems = dataAccess.GetData().FindAll(a => a.ItemType.ToString() == "Operational");
            Assert.AreEqual(6, allitems.Count);
        }
        [TestMethod]
        public void MaximumPreTestCount()
        {
            List<ItemsItem> allitems = dataAccess.GetData().FindAll(a => a.ItemType.ToString() == "Pretest");
            Assert.AreEqual(4, allitems.Count);
        }
        [TestMethod]
        public void MinimumPreTestCount()
        {
            List<ItemsItem> allitems = dataAccess.GetData().FindAll(a => a.ItemType.ToString() == "Pretest");
            Assert.AreEqual(4, allitems.Count);
        }

        [TestMethod]
        public void FirstTwoPreTestItemCheck()
        {
            var preTestCount = 0;
            List<ItemsItem> allitems = testlet.Randomize();
            do
            {
                if (allitems[0].ItemType.ToString() == "Pretest")                
                    preTestCount++;
            }
            while (preTestCount < 2);
            Assert.AreEqual(2, preTestCount);
        }

        [TestMethod]
        public void MixItemCheck()
        {
            List<ItemsItem> allitems = testlet.Randomize();
            allitems.RemoveAt(0);
            allitems.RemoveAt(1);
            Assert.AreEqual(8, allitems.Count);
        }

    }
}

