using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarInsuranceProject;
using CarInsuranceProject.Controllers;
using CarInsuranceProject.Models;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace CarInsuranceProject.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void CalculateUnderAge()
        {
            InsuranceCalculator test = new InsuranceCalculator(DateTime.Parse("2005-5-13"),1000,true,0);
            double result = test.CalculateInsurance();
            Assert.AreEqual(result, -1);
        }
        [TestMethod]
        public void CalculateThirdPartyCover()
        {
            InsuranceCalculator test = new InsuranceCalculator(DateTime.Parse("1990-5-13"), 1000, false, 0);
            double result = test.CalculateInsurance();
            Assert.AreEqual(result, 25);
        }
        [TestMethod]
        public void CalculateComprehensiveCover()
        {
            InsuranceCalculator test = new InsuranceCalculator(DateTime.Parse("1990-5-13"), 1000, true, 0);
            double result = test.CalculateInsurance();
            Assert.AreEqual(result, 40);
        }
        [TestMethod]
        public void CalculateYoungsterAdding()
        {
            InsuranceCalculator test = new InsuranceCalculator(DateTime.Parse("2000-5-13"), 1000, false, 0);
            double result = test.CalculateInsurance();
            Assert.AreEqual(result, 27,5);
        }

        [TestCase(0, 25)]
        [TestCase(1, 125)]
        [TestCase(5, 225)]
        [TestCase(8, 325)]
        [TestCase(11, 425)]
        [TestCase(13, -1)]
        public void CalculateExtraCharge(int penaltyPoints,int expected)
        {
            InsuranceCalculator test = new InsuranceCalculator(DateTime.Parse("1990-5-13"), 1000, false, penaltyPoints);
            Assert.AreEqual(test.CalculateInsurance(), expected);
        }
    }
}
