namespace RandomGenerator.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// �����-��������� ������ ��������
    /// </summary>
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
