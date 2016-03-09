namespace RandomGenerator.Model.Criteria
{
    using System;

    using RandomGenerator.Controller.Containers;
    using RandomGenerator.Model.Functions;

    /// <summary>
    /// критерий колмогрова
    /// </summary>
    public class KolmogorovCriterion
    {
        TableKolmogorova table = new TableKolmogorova();//таблица критерия


        public KolmogorovContainer Calculate(Sampling sampling, int type)
        {
            //создаём эземпляр практической функции распределения
            PracticalDistributionFunction function1 = new PracticalDistributionFunction(sampling);
            double d = D(function1, type);
            double λ =  d * Math.Sqrt(sampling.GetVolume());//вычисляем λ
            double P = table.GetP(λ);//ищем по таблице результат
            KolmogorovContainer result = new KolmogorovContainer();
            result.P = P;
            result.λ = λ;
            result.D = d;
            result.MeanSquareDeviation = function1.MeanSquareDeviation(sampling.AvеrageValue());
            return result;
        }

        //возвращает максимальное расхождение между теорертической и практической функциями распределения
        private double D(PracticalDistributionFunction function1, int type)
        {
            double d = 0;
            IDistributionFunction function2 = null;
            switch (type)
            {
                case 0:
                    function2 = UniversalDistributionFunction.Create();
                    break;
                
                case 1:
                    function2 = InverseDistributionFunction.Create();
                    break;

                case 2:
                    function2 = DiscreteDistributionFunction.Create();
                    break;

                default:
                    throw new Exception("Неизвестная функция");
            }
            double min = function2.Xmin();
            double max = function2.Xmax();
            //проверка расхождения между функциями с определённым шагом
            for (double i = min; i <= max; i += (max-min)/100000)
            {
                double temp;
                if(type==2)//если функция дискретная
                {
                    temp = Math.Abs(function1.GetDiscreteFunctionValue(i) - function2.GetFunctionValue(i));
                }
                else//если функция неприрывная
                {
                    temp = Math.Abs(function1.GetFunctionValue(i) - function2.GetFunctionValue(i));
                }
                if(temp>d)
                {
                    d = temp;
                }
            }
            return d;
        }
    }
}
