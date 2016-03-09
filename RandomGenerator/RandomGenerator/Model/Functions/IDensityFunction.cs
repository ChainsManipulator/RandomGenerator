namespace RandomGenerator.Model.Functions
{
    /// <summary>
    /// интерфейс функции плотности
    /// </summary>
    public interface IDensityFunction
    {
        double GetDensityFunctionValue(double x);
        double GetExpectation();
        double GetMeanSquareDeviation();
        double GetDispersion();
    }
}
