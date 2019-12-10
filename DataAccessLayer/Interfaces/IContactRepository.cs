using System.Threading.Tasks;
using DataModel.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IContactRepository
    {
        Task<Contact> GetContact(int id);
        Task<Contact> CreateContact(Contact contact);
        Contact DeleteContact(Contact contact);
        Contact UpdateContact(Contact contact);
    }
}