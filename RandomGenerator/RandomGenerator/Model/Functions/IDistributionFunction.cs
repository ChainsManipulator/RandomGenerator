namespace RandomGenerator.Model.Functions
{
    //��������� ������� �������������
    public interface IDistributionFunction
    {
        double GetFunctionValue(double x);
        double GetInverseFunctionValue(double y);
        double Xmin();
        double Xmax();
    }
}