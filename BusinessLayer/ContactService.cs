using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataModel.Entities;

namespace BusinessLayer
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public bool IsPhoneNumberValid(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Contact>> ListContacts()
        {
            var contacts = await _contactRepository.GetAllContacts();
            return contacts;
        }

        public async Task<Contact> SearchContactById(Guid id)
        {
            var foundedContact = await _contactRepository.GetContact(id);
            return foundedContact;
        }

        public async Task<Contact> CreateContact(Contact contact)
        {
            var createdContact = await _contactRepository.CreateContact(contact);
            return createdContact;
        }

        public Contact DeleteContact(Contact contact)
        {
            var removedContact = _contactRepository.DeleteContact(contact);
            return removedContact;
        }

        public Contact UpdateContact(Contact contact)
        {
            var createdContact = _contactRepository.UpdateContact(contact);
            return createdContact;
        }
    }
}
