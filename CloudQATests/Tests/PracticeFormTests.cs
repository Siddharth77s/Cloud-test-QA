using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CloudQATests.Pages;
using System;
using System.IO;

namespace CloudQATests.Tests
{
    [TestFixture]
    public class PracticeFormTests
    {
        private IWebDriver driver;
        private PracticeFormPage form;

        [SetUp]
        public void Setup()
        {
            // Path: CloudQATests/Drivers/chromedriver.exe
            string driverPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Drivers");
            driverPath = Path.GetFullPath(driverPath);

            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            driver = new ChromeDriver(driverPath, options);

            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            form = new PracticeFormPage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        // -------------------------------------------------------------
        // TEST 1 – Verify First Name field
        // -------------------------------------------------------------
        [Test]
        public void Test_FirstNameField()
        {
            string firstName = "Siddharth";
            form.EnterFirstName(firstName);

            string value = driver.FindElement(By.Id("firstName")).GetAttribute("value");
            Assert.AreEqual(firstName, value, "First Name was not entered correctly.");
        }

        // -------------------------------------------------------------
        // TEST 2 – Verify Gender Selection (Male)
        // -------------------------------------------------------------
        [Test]
        public void Test_GenderMaleSelection()
        {
            form.SelectGenderMale();
            bool selected = driver.FindElement(By.Id("gender-radio-1")).Selected;

            Assert.IsTrue(selected, "Male gender was not selected.");
        }

        // -------------------------------------------------------------
        // TEST 3 – Verify Mobile Number field
        // -------------------------------------------------------------
        [Test]
        public void Test_MobileNumberField()
        {
            string mobile = "9876543210";
            form.EnterMobileNumber(mobile);

            string value = driver.FindElement(By.Id("userNumber")).GetAttribute("value");
            Assert.AreEqual(mobile, value, "Mobile number was not entered correctly.");
        }
    }
}
