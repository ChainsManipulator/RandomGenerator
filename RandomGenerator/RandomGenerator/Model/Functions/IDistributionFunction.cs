namespace RandomGenerator.Model.Functions
{
    /// <summary>
    /// ��������� ������� �������������
    /// </summary>
    public interface IDistributionFunction
    {
        double GetFunctionValue(double x);
        double GetInverseFunctionValue(double y);
        double Xmin();
        double Xmax();
    }
}
