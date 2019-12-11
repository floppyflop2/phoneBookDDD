using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAllContacts();
        Task<Contact> GetContact(Guid id);
        Task<Contact> CreateContact(Contact contact);
        Contact DeleteContact(Contact contact);
        Contact UpdateContact(Contact contact);
    }
}