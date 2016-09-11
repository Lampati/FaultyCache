using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FaultyCache.Entities;
using FaultyCache.Models;
using FaultyCache.Interfaces;

namespace FaultyCache.Tests.Models
{
    [TestClass]
    public class EventModelTest
    {
        Event ev = new Event() { Title = "1", Link = "2", StartDate = DateTime.Now.AddDays(1), Technology = "3" };

        [TestMethod]
        public void EntityToModelTest()
        {
            EventModel evModel = new EventModel(ev);

            Assert.AreEqual(ev.Title, evModel.Title);
            Assert.AreEqual(ev.Link, evModel.Link);
            Assert.AreEqual(ev.StartDate, evModel.StartDate);
            Assert.AreEqual(ev.Technology, evModel.Technology);

        }

        [TestMethod]
        public void ModelToDataTableStringArrayTest()
        {
            EventModel evModel = new EventModel(){ Title = "1", Link = "2", StartDate = DateTime.Now.AddDays(1), Technology = "3" };

            string[] stringArray = evModel.ToDataTableStringArray();

            Assert.AreEqual(stringArray[0], evModel.Title);
            Assert.AreEqual(stringArray[1], evModel.StartDate.ToString("yyyy/MM/dd"));
            Assert.AreEqual(stringArray[2], evModel.Link);
            Assert.AreEqual(stringArray[3], evModel.Technology);

        }
    }
}
