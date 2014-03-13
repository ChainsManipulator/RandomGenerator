using System;
using System.Collections.Generic;
using System.Text;
using RandomGenerator.Model;

namespace RandomGenerator.Controller.Containers
{
    //контейнер с данными для третьего генератора
    public class DiscreteContainer:Container
    {
        public List<Point> Values = new List<Point>();//массив точек дискретной функции плотности
    }
}