using System;
using System.Linq;
using Advantage.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Advantage.API.Controllers 
{
    [Route("api/[controller]")]
    public class ServersController : Controller 
    {
        private readonly ApiContext _context;
        public ServersController (ApiContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = _context.Servers.OrderBy(s => s.Id).ToList();
            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetServer")]
        public IActionResult Get(int id) => Ok(_context.Servers.Find(id));


        [HttpPut("{id}")]
        public IActionResult Message (int id, [FromBody] ServerMessage msg)
        {
            var server = _context.Servers.Find(id);
            if(server == null) return NotFound();
            
            if(msg.Payload == "activate") server.IsOnline = true; 
            if(msg.Payload == "deactivate") server.IsOnline = false; 

            _context.SaveChanges();
            return new NoContentResult();
        }



    }

}