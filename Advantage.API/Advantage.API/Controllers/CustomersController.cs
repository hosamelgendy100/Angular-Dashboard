using System.Threading.Tasks;
using Advantage.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Advantage.API.Controllers
{
    [Route("api/[Controller]")]
    public class CustomersController : Controller
    {
        private readonly ApiContext _context;
        public CustomersController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            if (customers == null) return BadRequest();
            
            return Ok(customers);
        }


        [HttpGet("{id}", Name = "GetCustomer")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return BadRequest();
            return Ok(customer);
        }


        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
        {
            if (customer == null) return BadRequest();

            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("GetCustomer", new Customer{Id = customer.Id}, customer );
        }



    }
}