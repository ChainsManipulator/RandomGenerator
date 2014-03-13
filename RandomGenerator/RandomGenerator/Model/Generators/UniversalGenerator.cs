using System;
using System.Collections.Generic;
using System.Text;
using RandomGenerator.Model.Functions;

namespace RandomGenerator.Model.Generators
{
    public class UniversalGenerator : IGenerator
    {
        private UniversalDistributionFunction Function = null;
        private IntervalFinder Finder = new IntervalFinder();//класс выполняющий разбиение интервала 
        private Random BaseGenerator = new Random();//генератор базовой случайной величины
        private int Intervals;

        //конструктор заполняет внутренние поля
        public UniversalGenerator(int NumIntervals, List<Inflection> Values)
        {
            Function = UniversalDistributionFunction.Create(Values);//получаем экземпляр функции распределения
            Finder.Find(NumIntervals);//находим границы карманов
            Intervals = NumIntervals;
        }

        //сгенерировать очередное значение
        public double GenerateValue()
        {
            double x1 = BaseGenerator.NextDouble();// генерация очередного значения базовой случайной величины
            double result;
            //ищем номер интервала в который попало значение
            for (int i = 1; i < Finder.Borders.GetNumberOfPoints(); i++)
            {
                if (x1 <= ((double)i/Intervals))
                {
                    double x2 = BaseGenerator.NextDouble();//получаем ещё одно значение из генератора БСВ
                    //растяжение второго значения БСВ в пределах интервала
                    result = x2*(Finder.Borders.GetPoint(i) - Finder.Borders.GetPoint(i - 1)) + Finder.Borders.GetPoint(i - 1);
                    return result;
                }
            }
            throw new Exception("Значение БСВ за пределами допустимого интервала!\n");
        }

        public List<double> GetIntervals()
        {
            return Finder.GetIntervals();
        }
    }
}