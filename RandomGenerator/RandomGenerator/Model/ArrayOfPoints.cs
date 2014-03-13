using System;
using System.Collections.Generic;
using System.Text;

namespace RandomGenerator.Model
{
    //�����-��������� ������ ��������
    public class ArrayOfPoints
    {
        private List<double> Points = new List<double>(); //������ �����

        //����� ��������� ������� �� � ������ 
        public double GetPoint(int number) 
        {
            return Points[number];
        }
      
        //��������� ������� � ������
        public void SetPoint(double value)
        {
            Points.Add(value);
        }

        //���������� ����� ���������� �����
        public int GetNumberOfPoints()
        {
            return Points.Count;
        }

        public List<double> GetArray()
        {
            return Points;
        }
    }
}
