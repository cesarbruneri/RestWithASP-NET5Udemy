using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.IServices;
using System;

namespace RestWithASPNETUdemy.Controllers
{
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;
        private readonly ICalculatorSerevice _calculatorSerevice;

        public CalculatorController(
            ILogger<CalculatorController> logger,
            ICalculatorSerevice calculatorSerevice)
        {
            _logger = logger;
            _calculatorSerevice = calculatorSerevice;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (_calculatorSerevice.IsNumeric(firstNumber) && _calculatorSerevice.IsNumeric(secondNumber))
            {
                var sum = _calculatorSerevice.ConvertToDecimal(firstNumber) + _calculatorSerevice.ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (_calculatorSerevice.IsNumeric(firstNumber) && _calculatorSerevice.IsNumeric(secondNumber))
            {
                var subtraction = _calculatorSerevice.ConvertToDecimal(firstNumber) - _calculatorSerevice.ConvertToDecimal(secondNumber);
                return Ok(subtraction.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("multiply/{firstNumber}/{secondNumber}")]
        public IActionResult Multiply(string firstNumber, string secondNumber)
        {
            if (_calculatorSerevice.IsNumeric(firstNumber) && _calculatorSerevice.IsNumeric(secondNumber))
            {
                var multiply = _calculatorSerevice.ConvertToDecimal(firstNumber) * _calculatorSerevice.ConvertToDecimal(secondNumber);
                return Ok(multiply.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (!_calculatorSerevice.IsNumeric(firstNumber) || !_calculatorSerevice.IsNumeric(secondNumber))
            {
                return BadRequest("Invalid input");
            }

            if (_calculatorSerevice.IsEqualZero(firstNumber) || _calculatorSerevice.IsEqualZero(secondNumber))
            {
                return BadRequest("Invalid division");
            }

            var division = _calculatorSerevice.ConvertToDecimal(firstNumber) / _calculatorSerevice.ConvertToDecimal(secondNumber);
            return Ok(division.ToString());
        }

        [HttpGet("average/{firstNumber}/{secondNumber}")]
        public IActionResult Average(string firstNumber, string secondNumber)
        {
            if (!_calculatorSerevice.IsNumeric(firstNumber) || !_calculatorSerevice.IsNumeric(secondNumber))
            {
                return BadRequest("Invalid input");
            }

            var average = (_calculatorSerevice.ConvertToDecimal(firstNumber) + _calculatorSerevice.ConvertToDecimal(secondNumber)) / 2;
            return Ok(average.ToString());
        }

        [HttpGet("square-root/{strNumber}")]
        public IActionResult SquareRoot(string strNumber)
        {
            if (!_calculatorSerevice.IsNumeric(strNumber))
            {
                return BadRequest("Invalid input");
            }
            var squareRoot = Math.Sqrt(_calculatorSerevice.ConvertToDouble(strNumber));
            return Ok(squareRoot.ToString());
        }
    }
}
