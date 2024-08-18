using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using scientificCalculatorBackEnd.Models;
using System;

namespace scientificCalculatorBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrignometricOperationsController : ControllerBase
    {
        [HttpGet(Name = "sine")]
        public ActionResult<double> GetSine(double angle)
        {
            return Trigonometric.Sin(angle);
        }

        [HttpGet(Name = "cos")]
        public ActionResult<double> GetCos(double angle)
        {
            return Trigonometric.Cos(angle);
        }

        [HttpGet(Name = "tan")]
        public ActionResult<double> GetTan(double angle)
        {
            return Trigonometric.Tan(angle);
        }
    }
}

