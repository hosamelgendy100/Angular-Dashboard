using System;
using System.Linq;
using Advantage.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Advantage.API.Controllers 
{
    [Route("api/[controller]")]
    public class OrdersController : Controller 
    {
        private readonly ApiContext _context;
        public OrdersController (ApiContext context) 
        {
            _context = context;
        }


        [HttpGet("{pageIndex:int}/{pageSize:int}")]
        public IActionResult GetOrders(int pageIndex, int pageSize)
        {
            var data = _context.Orders.Include(o => o.Customer).OrderByDescending(o => o.Placed).AsQueryable();
            var page = new PaginatedResponse<Order>(data, pageIndex, pageSize);
            
            var totalCount = data.Count();
            var totalPages = Math.Ceiling((double)totalCount/pageSize);
            var response = new { Page = page, TotalPages = totalPages };
            
            return Ok(response);
        }

        [HttpGet("bystate")]
        public IActionResult ByState()
        {
            var orders = _context.Orders.Include(o => o.Customer).ToList();
            var groupResult = orders.GroupBy(o => o.Customer.State).ToList()
                .Select(grp => new {
                    State = grp.Key,
                    Total = grp.Sum(x => x.OrderTotal)
                }).OrderByDescending(res => res.Total).ToList();

            return Ok(groupResult);
        }



        [HttpGet("bycustomer/{n}")]
        public IActionResult ByCustomer(int n)
        {
            var orders = _context.Orders.Include(o => o.Customer).ToList();
            var groupedResult = orders.GroupBy(o => o.Customer.Id).ToList()
                .Select(grp => new {
                    Name = _context.Customers.Find(grp.Key).Name,
                    Total = grp.Sum(x => x.OrderTotal)
                }).OrderByDescending(res => res.Total).Take(n).ToList();

            return Ok(groupedResult);
        }


        [HttpGet("getorder/{id}", Name = "GetOrder")]
        public IActionResult GetOrder (int id)
        {
            var order = _context.Orders.Include(o => o.Customer).FirstOrDefault(o => o.Id == id);
            return Ok(order);
        }

    }
}