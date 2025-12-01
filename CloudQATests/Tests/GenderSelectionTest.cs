using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using System;

namespace CloudQATests
{
    public class GenderSelectionTest
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
        public void SelectGenderMale()
        {
            driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");

            // Select gender by label text - future-proof
            var genderMale = wait.Until(driver =>
                driver.FindElement(By.XPath("//label[contains(text(),'Male')]"))
            );

            genderMale.Click();

            var input = genderMale.FindElement(By.XPath(".//preceding::input[1]"));

            Assert.IsTrue(input.Selected);
        }

        [TearDown]
        public void Close()
        {
            driver.Quit();
        }
    }
}
