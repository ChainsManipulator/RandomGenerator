namespace RandomGenerator.Model.Generators
{
    using System;
    using System.Collections.Generic;

    using RandomGenerator.Model.Functions;

    public class DiscreteInverseGenerator:IGenerator
    {
        private DiscreteDistributionFunction Function = null;
        Random BaseGenerator = new Random();//генератор базовой случайной величины

        //конструктор
        public DiscreteInverseGenerator(List<Point> Values)
        {
            Function = DiscreteDistributionFunction.Create(Values);//получаем экземпляр функции распределения
        }

        //сгенерировать очередное значение
        public double GenerateValue()
        {
            double x1 = BaseGenerator.NextDouble();// генерация очередного значения базовой случайной величины
            double result = Function.GetInverseFunctionValue(x1);//получение значения обратной функции распределения
            return result;
        }
    }
}
