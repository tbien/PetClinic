﻿namespace PetClinic.Entities
{
    public class Owner
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Telephone { get; set; }
        public string Pets { get; set; }
        public string Name => $"{FirstName} {LastName}";
    }
}