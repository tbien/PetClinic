using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using PetClinic.Entities;
using PetClinic.Extensions;
using PetClinic.Helpers;

namespace PetClinic.PageObjects
{
    public class OwnersPage : ProjectPageObject
    {
        //locators
        private readonly ElementLocator _owners = new ElementLocator(Locator.CssSelector, "table.table tr:nth-of-type({0})>td");
        private readonly ElementLocator _numberOfRows = new ElementLocator(Locator.CssSelector, "table.table>tbody>tr");

        public OwnersPage(IWebDriver driver) : base(driver)
        {
        }

        public List<Owner> Owners
        {
            get
            {
                var ownerList = new List<Owner>();

                var count = Driver.FindElements(_numberOfRows).Count;
                for (var i = 1; i <= count; i++)
                {
                    var list = Driver.FindElements(_owners, i).Select(x => x.Text).ToList();
                    ownerList.Add(new Owner
                    {
                        FirstName = list[0].Split()[0],
                        LastName = list[0].Split()[1],
                        Address = list[1],
                        City = list[2],
                        Telephone = list[3]
                    });
                }
                return ownerList;
            }
        }
    }
}
