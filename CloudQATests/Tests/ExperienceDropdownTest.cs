using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using System;

namespace CloudQATests
{
    public class ExperienceDropdownTest
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
        public void SelectExperience()
        {
            driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");

            // Locate dropdown by label
            var dropdown = wait.Until(driver =>
                driver.FindElement(By.XPath("//label[contains(text(),'Experience')]/following::select[1]"))
            );

            var selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("2");

            Assert.AreEqual("2", selectElement.SelectedOption.Text);
        }

        [TearDown]
        public void Close()
        {
            driver.Quit();
        }
    }
}
