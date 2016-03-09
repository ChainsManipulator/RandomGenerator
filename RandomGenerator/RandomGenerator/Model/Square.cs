namespace RandomGenerator.Model
{
    using System;

    using RandomGenerator.Model.Functions;

    /// <summary>
    /// ����� ��� ���������� ������� ��� �������� ��������� � ������ ���������
    /// </summary>
    public class Square
    {
        private UniversalDistributionFunction Function;

        public double GetSquare(double x1, double x2)
        {
            Function = UniversalDistributionFunction.Create();
            if (x2 < x1)
            {
                throw new Exception("������� ������� ��������� �� ����� ���� ������ ������ ������� ���������");
            }

            double s = Function.GetFunctionValue(x2) - Function.GetFunctionValue(x1);
            return s;
        }
    }
}
