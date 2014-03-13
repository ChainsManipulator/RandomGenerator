using System;
using System.Collections.Generic;
using System.Text;

namespace RandomGenerator.Model.Functions
{
    //функция распределения обратного метода непрерывной СВ
    public class InverseDistributionFunction : IDistributionFunction, IDensityFunction
    {
        private static InverseDistributionFunction func = null;

        //метод создания
        public static InverseDistributionFunction Create()
        {
            func = new InverseDistributionFunction();
            return func;
        }

        //конструктор
        private InverseDistributionFunction()
        {
            func = this;
        }

        //возвращает значение функции в точке
        public double GetFunctionValue(double x)
        {
            if(x<Xmin())
            {
                return 0;
            }
            if(x>Xmax())
            {
                return 1;
            }
            double y = Math.Log(x,2);  //функция распределения
            if (y<0)
            {
                return 0;
            }
            else
            {
                if (y>1)
                {
                    return 1;
                }
                else
                {
                    return y;
                }
            }
        }

        //возвращает значение обратной функции в точке
        public double GetInverseFunctionValue(double y)
        {
            if (y < 0 || y > 1)
            {
                throw new Exception("Обратная функция существует только в интервале от 0 до 1");
            }
            double x = Math.Pow(2,y); //обратная функция распределения
            return x;
        }

        //Возвращает значение функции плотности в точке
        public double GetDensityFunctionValue(double x)
        {
            double y = (double)1/(x*Math.Log(2));//функция плотности

            return y;
        }
        //возвращает математическое ожидание СВ
        public double GetExpectation()
        {
            double step = (Xmax() - Xmin()) / 100;
            double prevM = 0;
            double M = 1;
            while (Math.Abs(M - prevM) > 0.000001)
            {
                prevM = M;
                double current = 0;
                for (double x = Xmin(); x < Xmax(); x += step)
                {
                    current += step * ((x + step) * GetDensityFunctionValue(x + step) + x * GetDensityFunctionValue(x)) / 2;
                }
                M = current;
                step /= 2;
            }
            return M;
        }

        //возвращает СКО
        public double GetMeanSquareDeviation()
        {
        
            return Math.Sqrt(GetDispersion());
        }

        //возвращает дисперсию
        public double GetDispersion()
        {
            double step = (Xmax() - Xmin()) / 100;
            double prevD = 0;
            double D = 1;
            double M = this.GetExpectation();
            while (Math.Abs(D - prevD) > 0.000001)
            {
                prevD = D;
                double current = 0;
                for (double x = Xmin(); x < Xmax(); x += step)
                {
                    current += step * (Math.Pow((x + step - M), 2) * GetDensityFunctionValue(x + step) + Math.Pow((x - M), 2) * GetDensityFunctionValue(x)) / 2;
                }
                D = current;
                step /= 2;
            }
            return D;
        }

        public double Xmin()
        {
            return this.GetInverseFunctionValue(0);
        }

        public double Xmax()
        {
            return this.GetInverseFunctionValue(1);
        }
    }
}