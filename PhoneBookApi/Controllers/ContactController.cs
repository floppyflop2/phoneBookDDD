using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DataModel.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PhoneBookApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetAll()
        {
            var contacts = await _contactService.ListContacts();
            return Ok(contacts);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> Get(Guid id)
        {
            var contact = await _contactService.SearchContactById(id);
            return Ok(contact);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Contact contact)
        {
            var createdContact = await _contactService.CreateContact(contact);
            return CreatedAtRoute("Contact", createdContact);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Contact contact)
        {
            var createdContact =  _contactService.UpdateContact(contact);
            return CreatedAtRoute("Contact", createdContact);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody] Contact contact)
        {
            var createdContact = _contactService.DeleteContact(contact);
            return CreatedAtRoute("Contact", createdContact);
        }
    }
}
