using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using realapi.Data;
using realapi.models;

namespace realapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class contactsController : Controller
    {
        private readonly realapiDbContext dbcontext;
        public contactsController(realapiDbContext dbContext)
        {
            this.dbcontext = dbContext;
            
        }
        [HttpGet]
        public async Task< IActionResult> Getcontacts()
        {
            return Ok( await dbcontext.contacts.ToListAsync());
        }
        [HttpGet]
        [Route("{id:guid}")]

        public async Task<IActionResult> Getcontact([FromRoute]Guid id)
        {
            var contact = await dbcontext.contacts.FindAsync(id);
            if(contact==null)
            {
                return NotFound();
            }
            return Ok(contact);

        }
        
            [HttpPost]
        public async Task< IActionResult> Addcontact(Addcontactrequest addcontactrequest)
        {
            var contact = new Contact()
            {
                id = Guid.NewGuid(),
                address = addcontactrequest.address,
                email = addcontactrequest.email,
                name = addcontactrequest.name,
                phone = addcontactrequest.phone
            };

            await dbcontext.contacts.AddAsync(contact);
            await dbcontext.SaveChangesAsync();
            return Ok(contact);
        }
      

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> updatecontact([FromRoute] Guid id,updatecontact updatecontact)
        {
            var contact = await dbcontext.contacts.FindAsync(id);

            if(contact!=null)
            {
                contact.name = updatecontact.name;
                contact.email = updatecontact.email;
                contact.phone = updatecontact.phone;
                contact.address = updatecontact.address;

                await dbcontext.SaveChangesAsync();
                return Ok(contact);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> deletecontact([FromRoute] Guid id)
        {
            var contact = await dbcontext.contacts.FindAsync(id);

            if(contact!=null)
            {
                dbcontext.Remove(contact);
                await dbcontext.SaveChangesAsync();
                return Ok(contact);
            }
            return NotFound();
        }

    }
}
