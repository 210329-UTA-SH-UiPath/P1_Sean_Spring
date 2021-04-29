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
    public class PizzaController : ControllerBase
    {
        private readonly PizzaRepository repository;

        public PizzaController(PizzaRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Pizza> Get()
        {
            return Ok(repository.GetAllItems());
        }

        [HttpGet("GetRecent/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Pizza> GetRecentlyAdded()
        {
            return Ok(repository.GetRecentlyAdded());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = repository.GetByID(id);
            if (pizza == null)
            {
                NotFound($"The pizza with id {id} is not in the database");
            }
            return Ok(pizza);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(Pizza pizza)
        {

            if (pizza != null)
            {
                repository.Add(pizza);
                return NoContent();
            }
            else
                return BadRequest("Pizza data is invalid");
        }
    }
}
