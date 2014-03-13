namespace RandomGenerator.Model.Functions
{
    //интерфейс функции плотности
    public interface IDensityFunction
    {
        double GetDensityFunctionValue(double x);
        double GetExpectation();
        double GetMeanSquareDeviation();
        double GetDispersion();
    }
}