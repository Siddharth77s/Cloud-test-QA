using OpenQA.Selenium;

namespace CloudQATests.Pages
{
    public class PracticeFormPage
    {
        private readonly IWebDriver driver;

        public PracticeFormPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement FirstNameInput =>
            driver.FindElement(By.XPath("//label[contains(., 'First Name')]/following::input[1]"));

        public IWebElement LastNameInput =>
            driver.FindElement(By.XPath("//label[contains(., 'Last Name')]/following::input[1]"));

        public IWebElement GenderMale =>
            driver.FindElement(By.XPath("//label[contains(., 'Male')]"));

        public IWebElement DobInput =>
            driver.FindElement(By.XPath("//label[contains(., 'Date of Birth')]/following::input[1]"));

        public IWebElement MobileInput =>
            driver.FindElement(By.XPath("//label[contains(., 'Mobile')]/following::input[1]"));

        public IWebElement EmailInput =>
            driver.FindElement(By.XPath("//label[contains(., 'Email')]/following::input[1]"));
    }
}
