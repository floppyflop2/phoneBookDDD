﻿using System;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
using DataModel.Entities;
using DbContext;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class ContactRepository: IContactRepository

    {
        private readonly PhoneBookDbContext _phoneBookDbContext;

        public ContactRepository(PhoneBookDbContext phoneBookDbContext)
        {
            _phoneBookDbContext = phoneBookDbContext;
        }

        public async Task<Contact> GetContact(int id)
        {
            var foundedContact = await _phoneBookDbContext.Contacts.FirstOrDefaultAsync(contact => contact.ContactId == id);
            return foundedContact;
        }

        public async Task<Contact> CreateContact(Contact contact)
        {
            var createdContact = await _phoneBookDbContext.Contacts.AddAsync(contact);
            return createdContact.Entity;
        }

        public Contact DeleteContact(Contact contact)
        {
            var removedContact =  _phoneBookDbContext.Contacts.Remove(contact);
            _phoneBookDbContext.SaveChangesAsync();
            return removedContact.Entity;
        }

        public Contact UpdateContact(Contact contact)
        {
            var createdContact = _phoneBookDbContext.Contacts.Update(contact);
            return createdContact.Entity;
        }
    }
}
