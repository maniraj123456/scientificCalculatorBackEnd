namespace scientificCalculatorBackEnd.Functions
{
    public static class Statistics
    {
        public static double Mean(double[] values) => values.Average();
        public static double Median(double[] values)
        {
            var sortedValues = values.OrderBy(x => x).ToArray();
            int mid = sortedValues.Length / 2;
            return sortedValues.Length % 2 == 0 ? (sortedValues[mid] + sortedValues[mid - 1]) / 2 : sortedValues[mid];
        }
        public static double StandardDeviation(double[] values)
        {
            double mean = Mean(values);
            return Math.Sqrt(values.Average(v => Math.Pow(v - mean, 2)));
        }
    }

}
