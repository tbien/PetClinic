using OpenQA.Selenium;
using PetClinic.Entities;
using PetClinic.Extensions;
using PetClinic.Helpers;

namespace PetClinic.PageObjects
{
    public class AddOwnerPage
    {
        private readonly IWebDriver _driver;
        
        //locators
        private readonly ElementLocator _addOwnerButton = new ElementLocator(Locator.CssSelector, "button[type='submit']");
        private readonly ElementLocator _ownerAddress = new ElementLocator(Locator.Id, "address");
        private readonly ElementLocator _ownerCity = new ElementLocator(Locator.Id, "city");
        private readonly ElementLocator _ownerLastName = new ElementLocator(Locator.Id, "lastName");
        private readonly ElementLocator _ownerName = new ElementLocator(Locator.Id, "firstName");
        private readonly ElementLocator _ownerTelephone = new ElementLocator(Locator.Id, "telephone");

        public AddOwnerPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public AddOwnerPage EnterOwnerDetails(Owner owner)
        {
            this._driver.SendKeys(_ownerName, owner.FirstName);
            this._driver.SendKeys(_ownerLastName, owner.LastName);
            this._driver.SendKeys(_ownerAddress, owner.Address);
            this._driver.SendKeys(_ownerCity, owner.City);
            this._driver.SendKeys(_ownerTelephone, owner.Telephone);
            return this;
        }

        public OwnerInformationPage ClickAddOwnerButton()
        {
            this._driver.Click(_addOwnerButton);
            return new OwnerInformationPage(this._driver);
        }
    }
}