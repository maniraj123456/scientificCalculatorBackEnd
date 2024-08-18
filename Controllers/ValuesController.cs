using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using scientificCalculatorBackEnd.Models;

namespace scientificCalculatorBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController(ILogger<ValuesController> logger, PremadeInnovationsContext dbContext) : ControllerBase
    {
        private readonly PremadeInnovationsContext dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        [HttpGet]
        public List<Calculator> GetValues()
        {

            if (this.dbContext.Calculators.ToList().Count > 50)
            {
                return this.dbContext.Calculators.ToList().Slice(this.dbContext.Calculators.ToList().Count - 50, this.dbContext.Calculators.ToList().Count);
            }
            return this.dbContext.Calculators.ToList();
        }

        [HttpPost]
        public bool PostValue(Calculator calculator)
        {
            try
            {
                if (calculator != null)
                {
                    this.dbContext.Calculators.Add(calculator);
                    this.dbContext.SaveChanges();

                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
