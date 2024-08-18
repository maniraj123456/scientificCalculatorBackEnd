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

        [HttpGet(Name = "Get")]
        public  List<string> GetConvertion(/* Calculator calculator */)
        {
            Calculator calculator = this.dbContext.Calculators.Find(4);

            List<string> result = new();

            char[] expression = calculator.Expression.ToCharArray();
            
            int prev = -1;
            int count = 0;
            for (int index = 0; index <= expression.Length; index++)
            {
                /* when charactor is number */
                if (index < expression.Length  && expression[index] - '0' >= 0 && expression[index] - '0' <= 9)
                {
                    count++;
                }
                /* when charactoris not string and non-trignometric, ........ */
                else
                {
                    if (count != 0)
                    {
                        result.Add(calculator.Expression.Substring(prev + 1, count));
                        if(index < expression.Length) 
                            result.Add(calculator.Expression.Substring(index, 1));
                    }
                    else
                    {
                        result.Add("error");
                        return result;
                    }
                    prev = index;
                    count = 0;
                }
            }
            return result;
        }

        /*
        public static Calculator Evaluation(List<string> expression)
        {
            Stack<int> stack = new Stack<int>();

            for(var index = 0; index < expression.Count; index++)
            {
                if (expression[index] == "+" || expression[index] == "-" || expression[index] == "*" || expression[index] == "/")
                {
                    
                }
            }
        }

        */
    }
}
