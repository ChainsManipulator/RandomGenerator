namespace RandomGenerator.Model.Functions
{
    //интерфейс функции распределения
    public interface IDistributionFunction
    {
        double GetFunctionValue(double x);
        double GetInverseFunctionValue(double y);
        double Xmin();
        double Xmax();
    }
}