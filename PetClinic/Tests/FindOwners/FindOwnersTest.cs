using System;
using NUnit.Framework;
using PetClinic.Entities;
using PetClinic.PageObjects;

namespace PetClinic.Tests.FindOwners
{
    public class FindOwnersTest : ProjectTestBase
    {
        private readonly Owner _owner = new Owner
        {
            FirstName = "Tomasz",
            LastName = Guid.NewGuid().ToString().Substring(0,6),
            City = "Wroclaw",
            Address = "Strzegomska",
            Telephone = "1123"
        };

        [Test, Order(1)]
        public void AddOwnerTest()
        {
            var ownerDetails = new FindOwnerPage(Driver)
                .Open()
                .ClickAddOwnerButton()
                .EnterOwnerDetails(_owner)
                .ClickAddOwnerButton();

            Assert.AreEqual($"{_owner.FirstName} {_owner.LastName}", ownerDetails.Name);
            Assert.AreEqual(_owner.Address, ownerDetails.Address);
            Assert.AreEqual(_owner.City, ownerDetails.City);
            Assert.AreEqual(_owner.Telephone, ownerDetails.Telephone);
        }

        [Test, Order(2)]
        public void ASearchOwnerTest()
        {
            var ownerDetails = new FindOwnerPage(Driver)
                .Open()
                .SearchForOwner(_owner.LastName);

            Assert.AreEqual($"{_owner.FirstName} {_owner.LastName}", ownerDetails.Name);
            Assert.AreEqual(_owner.Address, ownerDetails.Address);
            Assert.AreEqual(_owner.City, ownerDetails.City);
            Assert.AreEqual(_owner.Telephone, ownerDetails.Telephone);
        }

        [Test, Order(3)]
        public void SearchForDublicatesTest()
        {
            var ownerDetails = new FindOwnerPage(Driver).Open();

            for (var i = 0; i < 2; i++)
            {
                _owner.FirstName += i;

                ownerDetails
                    .ClickAddOwnerButton()
                    .EnterOwnerDetails(_owner)
                    .ClickAddOwnerButton()
                    .GoToFindOwnerPage();
            }

            ownerDetails.SearchForOwner(_owner.LastName);
        }
    }
}