using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using scientificCalculatorBackEnd.Functions;
using scientificCalculatorBackEnd.Models;
using System;
using System.Linq.Expressions;

namespace scientificCalculatorBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationController(PremadeInnovationsContext dbContext) : ControllerBase
    {
        private readonly PremadeInnovationsContext dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));   
    }
}
