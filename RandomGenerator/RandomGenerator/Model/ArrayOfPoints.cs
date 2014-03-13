using System;
using System.Collections.Generic;
using System.Text;

namespace RandomGenerator.Model
{
    //класс-контейнер границ карманов
    public class ArrayOfPoints
    {
        private List<double> Points = new List<double>(); //массив точек

        //метод получения границы по её номеру 
        public double GetPoint(int number) 
        {
            return Points[number];
        }
      
        //добавляет границу в массив
        public void SetPoint(double value)
        {
            Points.Add(value);
        }

        //возвращает общее количество точек
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
