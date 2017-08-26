using OpenQA.Selenium;
using PetClinic.Extensions;
using PetClinic.Helpers;

namespace PetClinic.PageObjects
{
    public class OwnerInformationPage
    {
        private readonly IWebDriver _driver;

        //locators
        private readonly ElementLocator _address = new ElementLocator(Locator.XPath, "//th[text()='Address']/following-sibling::td");
        private readonly ElementLocator _city = new ElementLocator(Locator.XPath, "//th[text()='City']/following-sibling::td");
        private readonly ElementLocator _name = new ElementLocator(Locator.XPath, "//th[text()='Name']/following-sibling::td/b");
        private readonly ElementLocator _telephone = new ElementLocator(Locator.XPath, "//th[text()='Telephone']/following-sibling::td");
        private readonly ElementLocator _findOwner = new ElementLocator(Locator.CssSelector, "a[href='/petclinic/owners/find.html']");

        public OwnerInformationPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public string Name => this._driver.GetText(_name);
        public string Address => this._driver.GetText(_address);
        public string City => this._driver.GetText(_city);
        public string Telephone => this._driver.GetText(_telephone);

        public FindOwnerPage GoToFindOwnerPage()
        {
            _driver.Click(_findOwner);
            return new FindOwnerPage(this._driver);
        }
    }
}