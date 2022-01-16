using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.IServices;
using System;

namespace RestWithASPNETUdemy.Controllers
{
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

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (_personSerevice.IsNumeric(firstNumber) && _personSerevice.IsNumeric(secondNumber))
            {
                var sum = _personSerevice.ConvertToDecimal(firstNumber) + _personSerevice.ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid input");
        }
    }
}
