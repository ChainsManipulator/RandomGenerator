namespace RandomGenerator.Model.Functions
{
    using System;
    using System.Collections.Generic;

    public class UniversalDistributionFunction : IDistributionFunction, IDensityFunction
    {
        private static UniversalDistributionFunction func = null;

        private List<Inflection> Values = null;//массив точек перегиба
        private List<double> square = new List<double>();

        //метод создания
        public static UniversalDistributionFunction Create()
        {
            return func;
        }

        public static UniversalDistributionFunction Create(List<Inflection> values)
        {
            func = new UniversalDistributionFunction(values);
            return func;
        }

        //конструктор
        private UniversalDistributionFunction()
        {
            func = this;
        }

        //конструктор
        private UniversalDistributionFunction(List<Inflection> values)
        {
            func = this;
            Values = values;
            double control = 0;
            for (int i = 1; i < Values.Count; i++)
            {
                square.Add((Values[i].GetX - Values[i - 1].GetX) * (Values[i].GetY + Values[i - 1].GetY) / 2);
                control += square[i - 1];
            }
            int tochnost = 10000;//настройка точности проверки 10000-до 4 знака, 1000 - до 3 знака включительно и т.д.
            if ((Math.Round(control * tochnost) / tochnost) != 1)
            {
                //Проверка на то, что суммарная вероятность около 1
                throw new Exception("Суммарная вероятность должна быть равна 1\n");
            }
        }

        //возвращает значение функции в точке
        public double GetFunctionValue(double x)
        {
            if (x < Values[0].GetX)
            {
                return 0;
            }
            if (x > Values[Values.Count - 1].GetX)
            {
                return 1;
            }
            double y = 0;
            for (int i = 1; i < Values.Count; i++)
            {
                if (x <= Values[i].GetX)
                {
                    y += (x - Values[i - 1].GetX) * (Values[i - 1].GetY + this.GetDensityFunctionValue(x)) / 2;
                    if (y < 0)
                    {
                        return 0;
                    }
                    else
                    {
                        if (y > 1)
                        {
                            return 1;
                        }
                        else
                        {
                            return y;
                        }
                    }
                }
                y += square[i - 1];
            }
            return y;
        }

        //возвращает значение обратной функции в точке
        public double GetInverseFunctionValue(double y)
        {
            //todo: InverseFunctionValue 
            if (y < 0 || y > 1)
            {
                throw new Exception("Обратная функция существует только в интервале от 0 до 1");
            }
            if (y == 0)
            {
                return Values[0].GetX;
            }
            if (y == 1)
            {
                return Values[Values.Count - 1].GetX;
            }
            double Prevx = 0;
            double x = -1;
            double FirstBorder = Values[0].GetX;
            double SecondBorder = Values[Values.Count - 1].GetX;
            do
            {
                Prevx = x;
                x = this.GetFunctionValue(FirstBorder + (SecondBorder - FirstBorder) / 2);
                if (y > x)
                {
                    FirstBorder += (SecondBorder - FirstBorder) / 2;
                }
                else
                {
                    SecondBorder = FirstBorder + (SecondBorder - FirstBorder) / 2;
                }
            }
            while (Math.Abs(Prevx - x) > 0.0000000001);

            return x;
        }

        //Возвращает значение функции плотности в точке
        public double GetDensityFunctionValue(double x)
        {
            if (x < Values[0].GetX)
            {
                return 0;
            }
            if (x > Values[Values.Count - 1].GetX)
            {
                return 0;
            }
            double y = 0;
            for (int i = 1; i < Values.Count; i++)
            {
                double val = Values[i].GetX;
                if (x <= val)
                {
                    double x1 = Values[i - 1].GetX;
                    double x2 = Values[i].GetX;
                    double y1 = Values[i - 1].GetY;
                    double y2 = Values[i].GetY;
                    y = y1 + ((x - x1) * (y2 - y1)) / (x2 - x1);
                    break;
                }
            }
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
                    current += step *
                               (Math.Pow((x + step - M), 2) * GetDensityFunctionValue(x + step) +
                                Math.Pow((x - M), 2) * GetDensityFunctionValue(x)) / 2;
                }
                D = current;
                step /= 2;
            }
            return D;
        }

        public double Xmin()
        {
            return Values[0].GetX;
        }

        public double Xmax()
        {
            return Values[Values.Count - 1].GetX;
        }
    }
}
