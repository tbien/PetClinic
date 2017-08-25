using NUnit.Framework;
using PetClinic.Entities;
using PetClinic.PageObjects;

namespace PetClinic.Tests.FindOwners
{
    public class FindOwnersTest : ProjectTestBase
    {
        private readonly Owner _owner = new Owner {FirstName = "Tomasz", LastName = "Bien", City = "Wroclaw", Address = "Strzegomska", Telephone = "1123"};

        [Test]
        public void AddOwnerTest()
        {
            var ownerDetails = new FindOwnerPage(Driver)
                .Open()
                .ClickAddOwnerButton()
                .EnterOwnerDetails(_owner)
                .ClickAddOwnerButton();

            Assert.AreEqual($"{this._owner.FirstName} {this._owner.LastName}", ownerDetails.Name);
            Assert.AreEqual(this._owner.Address, ownerDetails.Address);
            Assert.AreEqual(this._owner.City, ownerDetails.City);
            Assert.AreEqual(this._owner.Telephone, ownerDetails.Telephone);
        }
    }
}
