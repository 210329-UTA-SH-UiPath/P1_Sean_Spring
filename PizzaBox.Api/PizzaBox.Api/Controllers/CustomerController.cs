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
    public class CustomerController : ControllerBase
    {
        private readonly CustomerRepository repository;

        public CustomerController(CustomerRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Customer> Get()
        {
            return Ok(repository.GetAllItems());
        }


        [HttpGet("id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Customer> GetById(int id)
        {
            var customer = repository.GetById(id);
            if (customer == null)
            {
                NotFound($"The customer with id {id} is not in the database");
            }
            return Ok(customer);
        }

        [HttpGet("name/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Customer> GetByName(string name)
        {
            var customer = repository.GetByName(name);
            if (customer == null)
            {
                NotFound($"The customer with name {name} is not in the database");
            }
            return Ok(customer);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(Customer customer)
        {
            if (customer != null)
            {
                repository.Add(customer);
                return NoContent();
            }
            else
                return BadRequest("Customer data is invalid");
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(Customer customer)
        {
            if (customer != null)
            {
                repository.Update(customer);
                return NoContent();
            }
            else
                return BadRequest("Customer data is invalid");
        }
    }
}
