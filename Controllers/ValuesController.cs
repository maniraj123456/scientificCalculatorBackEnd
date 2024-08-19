using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using scientificCalculatorBackEnd.Functions;
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
            /* when no.of records greater than 50 */
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
                    List<string> strings = Evaluation.GetConvertion(calculator);

                    /* when expression ends or starts with operator */
                    if (!double.TryParse(strings[0], out double number) || !double.TryParse(strings[strings.Count - 1], out double number1))
                    {
                         return false;
                    }
                    /* when two operators are side by side */
                    for(int i = 1; i < strings.Count - 1; i++)
                    {
                        if ( (! double.TryParse(strings[i], out double number4))  && 
                             ( ! double.TryParse(strings[i - 1], out double number2) || ! double.TryParse(strings[i + 1], out double number3))
                           )
                        {
                            return false;
                        }
                    }
                    /* evaluating the result */
                    calculator.Result = (decimal?)Evaluation.EvaluateExpression(strings);
                    /* stiring the result */
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
