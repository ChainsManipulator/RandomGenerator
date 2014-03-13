namespace RandomGenerator.Model.Functions
{
    //��������� ������� ���������
    public interface IDensityFunction
    {
        double GetDensityFunctionValue(double x);
        double GetExpectation();
        double GetMeanSquareDeviation();
        double GetDispersion();
    }
}