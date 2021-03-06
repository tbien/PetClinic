﻿using System;
using System.Collections.Generic;
using FluentAssertions;
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
            City = "Wroclaw",
            Address = "Strzegomska",
            Telephone = "1123"
        };

        [Test]
        public void AddOwnerTest()
        {
            _owner.LastName = Guid.NewGuid().ToString().Substring(0, 8);

            var ownerDetails = AddOwner();

            Assert.AreEqual($"{_owner.FirstName} {_owner.LastName}", ownerDetails.Name);
            Assert.AreEqual(_owner.Address, ownerDetails.Address);
            Assert.AreEqual(_owner.City, ownerDetails.City);
            Assert.AreEqual(_owner.Telephone, ownerDetails.Telephone);
        }

        [Test]
        public void SearchOwnerTest()
        {
            _owner.LastName = Guid.NewGuid().ToString().Substring(0, 8);

            var ownerInfromationPage = AddOwner()
                .GoToFindOwnerPage()
                .SearchForOwner(_owner.LastName, driver => new OwnerInformationPage(driver));

            Assert.AreEqual($"{_owner.FirstName} {_owner.LastName}", ownerInfromationPage.Name);
            Assert.AreEqual(_owner.Address, ownerInfromationPage.Address);
            Assert.AreEqual(_owner.City, ownerInfromationPage.City);
            Assert.AreEqual(_owner.Telephone, ownerInfromationPage.Telephone);
        }

        [Test]
        public void SearchForDublicatesTest()
        {
            _owner.LastName = Guid.NewGuid().ToString().Substring(0, 8);
            var expectedOwners = new List<Owner>();
            var ownerInfromationPage = new OwnerInformationPage(Driver);

            for (var i = 0; i < 2; i++)
            {
                ownerInfromationPage = AddOwner();
                expectedOwners.Add(_owner);
            }

           var actualOwners = ownerInfromationPage
                .GoToFindOwnerPage()
                .SearchForOwner(_owner.LastName, driver => new OwnersPage(driver))
                .Owners;

            expectedOwners.ShouldBeEquivalentTo(actualOwners);
        }

        private OwnerInformationPage AddOwner()
        {
            return new FindOwnerPage(Driver)
                .Open()
                .ClickAddOwnerButton()
                .EnterOwnerDetails(_owner);
        }
    }
}