using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using System;

namespace CloudQATests
{
    public class FirstNameTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void EnterFirstName()
        {
            driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");

            // Locate by label text and then go to input (position independent)
            var firstNameField = wait.Until(driver =>
                driver.FindElement(By.XPath("//label[contains(text(),'First Name')]/following::input[1]"))
            );

            firstNameField.Clear();
            firstNameField.SendKeys("Siddharth");

            Assert.AreEqual("Siddharth", firstNameField.GetAttribute("value"));
        }

        [TearDown]
        public void Close()
        {
            driver.Quit();
        }
    }
}
