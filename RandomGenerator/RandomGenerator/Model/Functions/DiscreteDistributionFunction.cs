namespace RandomGenerator.Model.Functions
{
    using System;
    using System.Collections.Generic;


    /// <summary>
    /// дискретная функция распределения
    /// </summary>
    public class DiscreteDistributionFunction : IDistributionFunction, IDensityFunction
    {
        private static DiscreteDistributionFunction func = null;//экземпляр самой функции
        private List<Point> Values = new List<Point>();//массив точек(точки вида: значение, вероятность)

        //метод создания
        public static DiscreteDistributionFunction Create()
        {
            return func;//возвращаем существующий объект
        }

        //метод создания
        public static DiscreteDistributionFunction Create(List<Point> values)
        {
            func = new DiscreteDistributionFunction(values);//создаем экземпляр функции
            return func;//возвращаем созданный объект
        }

        //конструктор
        private DiscreteDistributionFunction(List<Point> values)
        {
            func = this;//сохраняем в func адрес создаваемого объекта
            Values = values;//сохраняем пришедшие точки
            double control = 0;// проверяем чтобы суммарная вероятность была равна 1
            for (int i = 0; i < Values.Count; i++)
            {
                control += Values[i].GetP;
            }
            int tochnost = 10000;//настройка точности проверки 10000-до 4 знака, 1000 - до 3 знака включительно и т.д.
            if ((Math.Round(control * tochnost) / tochnost) != 1)
            {
                //Проверка на то, что суммарная вероятность около 1
                throw new Exception("Суммарная вероятность должна быть равна 1\n");
            }
        }

        //приватный конструктор
        private DiscreteDistributionFunction()
        {
            func = this;//запрещает создание через конструктор напрямую
        }

        //возвращает значение "ступенчатой" функции в точке
        public double GetFunctionValue(double x)
        {
            //Возвращает значение дискретной функции распредения
            if (x <= Values[0].GetX)
            {
                return 0;//если меньше минимального
            }
            if (x >= Values[Values.Count - 1].GetX)
            {
                return 1;//если больше максимального
            }
            double val = Values[0].GetX;//извлекаем первое значение
            double probability = 0;//вероятность
            double y = 0;
            for (int i = 1; i < Values.Count; i++)// для всех точек СВ
            {
                if (x < val)//если х < текущей точки
                {
                    y = probability;
                    if (y < 0)//округление y
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
                val = Values[i].GetX;//переход к следущей точке
                probability += Values[i - 1].GetP;// увеличиваем вероятность
            }
            return probability;
        }

        //возвращает значение обратной функции в точке
        public double GetInverseFunctionValue(double y)
        {
            //Возвращает значение обратной дискретной функции распределения
            if (y < 0 || y > 1)
            {
                throw new Exception("Обратная функция существует только в интервале от 0 до 1");
            }
            double probability = 0;
            for (int i = 0; i < Values.Count; i++)//для всех точек
            {
                probability += Values[i].GetP;//увеличиваем вероятность
                if (y <= probability)//если y <= текущей вероятности
                {
                    return Values[i].GetX;// возвращаем х текущей точки
                }
            }
            return Values[Values.Count - 1].GetX;
        }

        //возвращает i-ю точку дискретной СВ
        public Point GetPoint(int number)
        {
            return Values[number];
        }

        //возвращает количество точек в дискретной СВ
        public int GetNumberOfPoints()
        {
            return Values.Count;
        }

        //возвращает значение дискретной функции плотности в точке
        public double GetDensityFunctionValue(double x)
        {
            if (x < Values[0].GetX)//если меньше минимального
            {
                return 0;
            }
            if (x > Values[Values.Count - 1].GetX)//если больше максимального
            {
                return 0;
            }
            double y = 0;
            for (int i = 1; i < Values.Count; i++)//для всех элементов
            {
                double val = Values[i].GetX;
                if (x <= val)// находим между какими двумя точками находится х
                {
                    double x1 = Values[i - 1].GetX;
                    double x2 = Values[i].GetX;
                    double y1 = Values[i - 1].GetP;
                    double y2 = Values[i].GetP;
                    y = y1 + ((x - x1) * (y2 - y1)) / (x2 - x1);//линейно интерполируем
                    break;//прерываем цикл
                }
            }
            return y;
        }

        //возвращает мат ожидание СВ
        public double GetExpectation()
        {
            double M = 0;//мат.ожидание
            for (int i = 0; i < this.GetNumberOfPoints(); i++)// для всех точек дискретной функции
            {
                //прибавляем к М произведение х на вероятность в текущей точке
                M += this.GetPoint(i).GetP * this.GetPoint(i).GetX;
            }
            return M;
        }

        //возвращает СКО СВ
        public double GetMeanSquareDeviation()
        {

            return Math.Sqrt(GetDispersion());
        }

        //возвращает дисперсию
        public double GetDispersion()
        {
            double M = this.GetExpectation();//получаем мат.ожидание
            double D = 0;
            for (int i = 0; i < this.GetNumberOfPoints(); i++)//для всех точек
            {
                //прибавляем к дисперсии очередное значение
                D += this.GetPoint(i).GetP * Math.Pow((this.GetPoint(i).GetX - M), 2);
            }
            return D;
        }

        //возвращает минимальное значение СВ
        public double Xmin()
        {
            return this.GetInverseFunctionValue(0);
        }

        //возвращает масимальное значение СВ
        public double Xmax()
        {
            return this.GetInverseFunctionValue(1);
        }
    }
}
