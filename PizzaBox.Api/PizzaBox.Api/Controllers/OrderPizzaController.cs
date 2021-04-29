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
    public class OrderPizzaController : ControllerBase
    {
        private readonly OrderPizzaRepository repository;

        public OrderPizzaController(OrderPizzaRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("{OrderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<OrderPizza> GetByOrderId(int OrderId)
        {
            return Ok(repository.GetAllItemsByOrderId(OrderId));
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(OrderPizza orderpizza)
        {
            if (orderpizza != null)
            {
                repository.Add(orderpizza);
                return NoContent();
            }
            else
                return BadRequest("Invalid pizza order");
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            repository.DeleteByOrderPizzaId(id);
            return NoContent();
        }
    }
}
