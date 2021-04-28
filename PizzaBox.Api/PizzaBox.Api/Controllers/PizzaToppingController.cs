using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaToppingController : ControllerBase
    {
        private readonly PizzaToppingRepository repository;

        PizzaToppingController( PizzaToppingRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("{PizzaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PizzaTopping> GetPizzaToppingsByPizzaId(int PizzaId)
        {
            return Ok(repository.GetAllItemsByPizzaId(PizzaId));
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(PizzaTopping pizzaTopping)
        {
            if (pizzaTopping != null)
            {
                repository.Add(pizzaTopping);
                return NoContent();
            }
            else
                return BadRequest("Invalid pizza topping");
        }
    }
}
