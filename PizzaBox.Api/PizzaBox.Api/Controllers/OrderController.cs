using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaBox.Storing.Repositories;
using PizzaBox.Domain.Models;

namespace PizzaBox.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderRepository repository;

        public OrderController(OrderRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("Customerid/{CustomerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Order> GetOrderByCustomerId(int CustomerId)
        {
            return Ok(repository.GetAllOrdersByCustomerId(CustomerId));
        }

        [HttpGet("Storeid/{StoreId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Order> GetOrderByStoreId(int StoreId)
        {
            return Ok(repository.GetAllOrdersByStoreId(StoreId));
        }



        //[HttpGet({"id"})]
        //public ActionResult<Order> GetOrderByStoreId(int id)
        //{

        //}


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult Post(Order order)
        {
            if (order != null)
            {
                repository.Add(order);
                return NoContent();
            }
            else
            {
                return BadRequest("Order invalid");
            }
        }

    }
}
