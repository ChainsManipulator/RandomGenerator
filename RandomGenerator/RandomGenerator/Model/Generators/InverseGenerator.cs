using System;
using System.Collections.Generic;
using System.Text;
using RandomGenerator.Model.Functions;

namespace RandomGenerator.Model.Generators
{
    public class InverseGenerator:IGenerator
    {
        private InverseDistributionFunction Function = null;
        Random BaseGenerator = new Random();//генератор базовой случайной величины

        //конструктор
        public InverseGenerator()
        {
            Function = InverseDistributionFunction.Create();//получаем экземпляр функции распределения
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