namespace RandomGenerator.Model.Functions
{
    /// <summary>
    /// ��������� ������� ���������
    /// </summary>
    public interface IDensityFunction
    {
        double GetDensityFunctionValue(double x);
        double GetExpectation();
        double GetMeanSquareDeviation();
        double GetDispersion();
    }
}
