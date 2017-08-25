using OpenQA.Selenium;
using PetClinic.Extensions;
using PetClinic.Helpers;

namespace PetClinic.PageObjects
{
    public class OwnerInformationPage
    {
        private readonly IWebDriver _driver;

        //locators
        private readonly ElementLocator _name = new ElementLocator(Locator.XPath, "//th[text()='Name']/following-sibling::td/b");
        private readonly ElementLocator _address = new ElementLocator(Locator.XPath, "//th[text()='Address']/following-sibling::td");
        private readonly ElementLocator _city = new ElementLocator(Locator.XPath, "//th[text()='City']/following-sibling::td");
        private readonly ElementLocator _telephone = new ElementLocator(Locator.XPath, "//th[text()='Telephone']/following-sibling::td");

        public OwnerInformationPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string Name => _driver.GetText(this._name);
        public string Address => _driver.GetText(this._address);
        public string City => _driver.GetText(this._city);
        public string Telephone => _driver.GetText(this._telephone);
    }
}
