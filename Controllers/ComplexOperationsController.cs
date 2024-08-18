using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using scientificCalculatorBackEnd.Functions;
using scientificCalculatorBackEnd.Models;
using System.Numerics;

namespace scientificCalculatorBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplexOperationsController : ControllerBase
    {
        [HttpGet(Name = "Add")]
        public Complex GetComplexAdd(ComplexNumbers complexNumbers)
        {
            Complex result = ComplexOperations.Add(complexNumbers.num1, complexNumbers.num2);
            return result;
        }

        [HttpPost(Name = "Sub")]
        public Complex GetComplexSub(ComplexNumbers complexNumbers)
        {
            Complex result = ComplexOperations.Subtract(complexNumbers.num1, complexNumbers.num2);
            return result;
        }

        [HttpPut(Name = "Mul")]
        public Complex GetComplexMul(ComplexNumbers complexNumbers)
        { 
            Complex result = ComplexOperations.Multiply(complexNumbers.num1, complexNumbers.num2);
            return result;
        }

        [HttpDelete(Name = "Divide")]
        public Complex GetComplexDivide(ComplexNumbers complexNumbers)
        {
            Complex result = ComplexOperations.Divide(complexNumbers.num1, complexNumbers.num2);
            return result;
        }
    }
}
