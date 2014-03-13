using System;
using System.Collections.Generic;
using System.Text;
using RandomGenerator.Model.Functions;

namespace RandomGenerator.Model.Generators
{
    public class UniversalGenerator : IGenerator
    {
        private UniversalDistributionFunction Function = null;
        private IntervalFinder Finder = new IntervalFinder();//����� ����������� ��������� ��������� 
        private Random BaseGenerator = new Random();//��������� ������� ��������� ��������
        private int Intervals;

        //����������� ��������� ���������� ����
        public UniversalGenerator(int NumIntervals, List<Inflection> Values)
        {
            Function = UniversalDistributionFunction.Create(Values);//�������� ��������� ������� �������������
            Finder.Find(NumIntervals);//������� ������� ��������
            Intervals = NumIntervals;
        }

        //������������� ��������� ��������
        public double GenerateValue()
        {
            double x1 = BaseGenerator.NextDouble();// ��������� ���������� �������� ������� ��������� ��������
            double result;
            //���� ����� ��������� � ������� ������ ��������
            for (int i = 1; i < Finder.Borders.GetNumberOfPoints(); i++)
            {
                if (x1 <= ((double)i/Intervals))
                {
                    double x2 = BaseGenerator.NextDouble();//�������� ��� ���� �������� �� ���������� ���
                    //���������� ������� �������� ��� � �������� ���������
                    result = x2*(Finder.Borders.GetPoint(i) - Finder.Borders.GetPoint(i - 1)) + Finder.Borders.GetPoint(i - 1);
                    return result;
                }
            }
            throw new Exception("�������� ��� �� ��������� ����������� ���������!\n");
        }

        public List<double> GetIntervals()
        {
            return Finder.GetIntervals();
        }
    }
}