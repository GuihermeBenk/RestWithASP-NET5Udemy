using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secoundNumber}")]
        public IActionResult Soma(string firstNumber, string secoundNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secoundNumber))
            {
                var ret = ConvertToDecimal(firstNumber) + ConvertToDecimal(secoundNumber);
                return Ok(ret.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("sub/{firstNumber}/{secoundNumber}")]
        public IActionResult Subtracao(string firstNumber, string secoundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secoundNumber))
            {
                var ret = ConvertToDecimal(firstNumber) - ConvertToDecimal(secoundNumber);
                return Ok(ret.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("multi/{firstNumber}/{secoundNumber}")]
        public IActionResult Multiplicacao(string firstNumber, string secoundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secoundNumber))
            {
                var ret = ConvertToDecimal(firstNumber) * ConvertToDecimal(secoundNumber);
                return Ok(ret.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("div/{firstNumber}/{secoundNumber}")]
        public IActionResult Divisao(string firstNumber, string secoundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secoundNumber) && ConvertToDecimal(secoundNumber) != 0)
            {
                var ret = ConvertToDecimal(firstNumber)/ConvertToDecimal(secoundNumber);
                return Ok(ret.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("med/{firstNumber}/{secoundNumber}")]
        public IActionResult Media(string firstNumber, string secoundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secoundNumber))
            {
                var ret = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secoundNumber)) / 2;
                return Ok(ret.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("raiz/{firstNumber}")]
        public IActionResult Raiz(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var ret = Math.Sqrt((double)ConvertToDecimal(firstNumber));

                return Ok(ret.ToString());
            }

            return BadRequest("Invalid input");
        }

        private bool IsNumeric(string strNumber)
        {
            bool isNumber = double.TryParse(strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out _);
            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }
    }
}
