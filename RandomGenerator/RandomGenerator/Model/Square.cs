using System;
using System.Collections.Generic;
using System.Text;
using RandomGenerator.Model.Functions;

namespace RandomGenerator.Model
{

    //����� ��� ���������� ������� ��� �������� ��������� � ������ ���������
    public class Square
    {
        private UniversalDistributionFunction Function = null;

        public double GetSquare(double x1, double x2)
        {
            Function = UniversalDistributionFunction.Create();
            if (x2<x1)
            {
                throw new Exception("������� ������� ��������� �� ����� ���� ������ ������ ������� ���������");
            }
            double s = Function.GetFunctionValue(x2) - Function.GetFunctionValue(x1);
            return s;
        }
    }
}
