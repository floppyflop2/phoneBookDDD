using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IContactService
    {
        bool IsPhoneNumberValid(string phoneNumber);
        Task<List<Contact>> ListContacts();
        Task<Contact> SearchContactById(Guid id);
        Task<Contact> CreateContact(Contact contact);
        Contact DeleteContact(Contact contact);
        Contact UpdateContact(Contact contact);
    }
}