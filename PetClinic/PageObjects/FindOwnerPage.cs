using OpenQA.Selenium;
using PetClinic.Extensions;
using PetClinic.Helpers;

namespace PetClinic.PageObjects
{
    public class FindOwnerPage : ProjectPageObject
    {
        private readonly IWebDriver _driver;

        //locators
        private readonly ElementLocator _addOwnerButton = new ElementLocator(Locator.CssSelector, "a[href*='/petclinic/owners/new']");
        private readonly ElementLocator _searchField = new ElementLocator(Locator.Id, "lastName");
        private readonly ElementLocator _findOwner = new ElementLocator(Locator.CssSelector, "button");

        public FindOwnerPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public FindOwnerPage Open()
        {
            this._driver.Navigate().GoToUrl($"{Url}/owners/find.html");
            return this;
        }

        public AddOwnerPage ClickAddOwnerButton()
        {
            this._driver.Click(_addOwnerButton);
            return new AddOwnerPage(_driver);
        }

        public OwnerInformationPage SearchForOwner(string ownerLastName)
        {
            this._driver.SendKeys(_searchField, ownerLastName);
            this._driver.Click(_findOwner);
            return new OwnerInformationPage(this._driver);
        }
    }
}