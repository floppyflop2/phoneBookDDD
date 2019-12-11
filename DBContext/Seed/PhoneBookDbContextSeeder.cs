using System;
using DataModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace DbContext.Seed
{
    public static class PhoneBookDbContextSeeder
    {
        public static void SeedDataBase(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    FirstName = "Florian",
                    Id = new Guid("60172c4e-cfa2-4875-b1aa-3a1c883f1d4e"),
                    LastName = "Morel",
                    PhoneNumber = "0441254512"
                },
                new Contact
                {
                    FirstName = "Gabi",
                    Id = new Guid("44fc8a2e-e335-4dca-86b7-07faa964a18a"),
                    LastName = "King of Brazil",
                    PhoneNumber = "0036214551"
                },
                new Contact
                {
                    FirstName = "Super Gabi",
                    Id = new Guid("7f3b0a44-44d5-456c-8c55-bf09688fa71c"),
                    LastName = "Monseigneur of Brazil",
                    PhoneNumber = "0033214541"
                },
                new Contact
                {
                    FirstName = "Omega Gabi",
                    Id = new Guid("763866bf-6bfd-4071-ad80-9509eac09852"),
                    LastName = "Ruler of Brazil",
                    PhoneNumber = "00323246"
                },
                new Contact
                {
                    FirstName = "Lord Floppy",
                    Id = new Guid("9d6821f6-e013-4912-8cf1-90ab19fc7eff"),
                    LastName = "Supreme leader of the universe",
                    PhoneNumber = "0025362356"
                }
            );
        }
    }
}