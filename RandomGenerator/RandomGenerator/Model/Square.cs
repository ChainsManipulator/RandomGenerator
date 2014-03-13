using System;
using System.Collections.Generic;
using System.Text;
using RandomGenerator.Model.Functions;

namespace RandomGenerator.Model
{

    //класс дл€ вычислени€ площади под функцией плотности в нужном интервале
    public class Square
    {
        private UniversalDistributionFunction Function = null;

        public double GetSquare(double x1, double x2)
        {
            Function = UniversalDistributionFunction.Create();
            if (x2<x1)
            {
                throw new Exception("¬ерхн€€ граница интеграла не может быть меньше нижней границы интеграла");
            }
            double s = Function.GetFunctionValue(x2) - Function.GetFunctionValue(x1);
            return s;
        }
    }
}
