using System;
using System.Collections.Generic;
using System.Text;
using RandomGenerator.Model;

namespace RandomGenerator.Controller.Containers
{
    //контейнер с данными для первого генератора
    public class UniversalContainer:Container
    {
        public int Intervals;
        public int PirsonIntervals;//количество интервалов в критерии пирсона
        public List<Inflection> Values = new List<Inflection>();//массив точек перегиба кусочно-линейной функции
    }
}