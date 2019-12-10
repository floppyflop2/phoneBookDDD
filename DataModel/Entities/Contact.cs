using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Xml;

namespace DataModel.Entities
{
    public class Contact
    {
        [Key]
        public int ContactId;
        public string FirstName;
        public string LastName;
        public string PhoneNumber;

    }
}
