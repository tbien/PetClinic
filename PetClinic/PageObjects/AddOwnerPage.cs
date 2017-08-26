using OpenQA.Selenium;
using PetClinic.Entities;
using PetClinic.Extensions;
using PetClinic.Helpers;

namespace PetClinic.PageObjects
{
    public class AddOwnerPage : ProjectPageObject
    {
       
        //locators
        private readonly ElementLocator _addOwnerButton = new ElementLocator(Locator.CssSelector, "button[type='submit']");
        private readonly ElementLocator _ownerAddress = new ElementLocator(Locator.Id, "address");
        private readonly ElementLocator _ownerCity = new ElementLocator(Locator.Id, "city");
        private readonly ElementLocator _ownerLastName = new ElementLocator(Locator.Id, "lastName");
        private readonly ElementLocator _ownerName = new ElementLocator(Locator.Id, "firstName");
        private readonly ElementLocator _ownerTelephone = new ElementLocator(Locator.Id, "telephone");

        public AddOwnerPage(IWebDriver driver) : base(driver)
        {
        }

        public AddOwnerPage EnterOwnerDetails(Owner owner)
        {
            Driver.SendKeys(_ownerName, owner.FirstName);
            Driver.SendKeys(_ownerLastName, owner.LastName);
            Driver.SendKeys(_ownerAddress, owner.Address);
            Driver.SendKeys(_ownerCity, owner.City);
            Driver.SendKeys(_ownerTelephone, owner.Telephone);
            return this;
        }

        public OwnerInformationPage ClickAddOwnerButton()
        {
            Driver.Click(_addOwnerButton);
            return new OwnerInformationPage(Driver);
        }
    }
}