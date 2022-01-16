using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.IServices;
using RestWithASPNETUdemy.Model;
using System;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonSerevice _personSerevice;

        public PersonController(
            ILogger<PersonController> logger,
            IPersonSerevice personSerevice)
        {
            _logger = logger;
            _personSerevice = personSerevice;
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            return Ok(_personSerevice.FindAll());   
        }

        [HttpGet("{id}")]
        public IActionResult FindById(long id)
        {
            var person = _personSerevice.FindById(id);
            if (person is null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Person person)
        {            
            if (person is null) return BadRequest();
            return Ok(_personSerevice.Create(person));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Person person)
        {
            if (person is null) return BadRequest();
            return Ok(_personSerevice.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personSerevice.Delete(id);            
            return NoContent();
        }
    }
}
