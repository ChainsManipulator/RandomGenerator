using System;
using System.Collections.Generic;
using System.Text;
using RandomGenerator.Model;

namespace RandomGenerator.Controller.Containers
{
    //контейнер с данными возвращаемыми критерием пирсона
    public class PirsonContainer
    {
        public int Intervals;// количество интервалов
        public ArrayOfPoints Border = null ;//массив границ
        public List<int> Nj= null;//массив практических частот
        public int N;// размер выборки
        public double P;// результат вычисления критерия пирсона
        public List<double> NP;//массив теоретических частот
        public double χ;//Хи
        public int r; //число степеней свободы
    }
}
