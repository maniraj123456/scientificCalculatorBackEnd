using System;
using System.Collections.Generic;

namespace scientificCalculatorBackEnd.Models;

public partial class Calculator
{
    public int Id { get; set; }

    public string Expression { get; set; } = null!;

    public decimal? Result { get; set; }

    public decimal? RealValue { get; set; }

    public decimal? ComplexValue { get; set; }
}
