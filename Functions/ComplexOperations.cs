using System.Numerics;

namespace scientificCalculatorBackEnd.Functions
{
    public static class ComplexOperations
    {
        public static Complex Add(Complex a, Complex b)
        {
            return (a + b);
        }
        public static Complex Subtract(Complex a, Complex b)
        {
            return (a - b);
        }
        public static Complex Multiply(Complex a, Complex b)
        {
            return (a * b);
        }
        public static Complex Divide(Complex a, Complex b)
        {
            return (a / b);
        }
    }

}
