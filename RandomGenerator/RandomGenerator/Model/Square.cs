namespace RandomGenerator.Model
{
    using System;

    using RandomGenerator.Model.Functions;

    /// <summary>
    /// класс дл€ вычислени€ площади под функцией плотности в нужном интервале
    /// </summary>
    public class Square
    {
        private UniversalDistributionFunction Function;

        public double GetSquare(double x1, double x2)
        {
            Function = UniversalDistributionFunction.Create();
            if (x2 < x1)
            {
                throw new Exception("¬ерхн€€ граница интеграла не может быть меньше нижней границы интеграла");
            }

            double s = Function.GetFunctionValue(x2) - Function.GetFunctionValue(x1);
            return s;
        }
    }
}
