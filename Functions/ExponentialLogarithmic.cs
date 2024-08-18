namespace scientificCalculatorBackEnd.Functions
{
    public static class ExponentialLogarithmic
    {
        public static double Log(double value) => Math.Log10(value);
        public static double Ln(double value) => Math.Log(value);
        public static double Exp(double value) => Math.Exp(value);
        public static double Power(double baseValue, double exponent) => Math.Pow(baseValue, exponent);
    }

}
