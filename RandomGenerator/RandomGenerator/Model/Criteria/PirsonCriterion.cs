namespace RandomGenerator.Model.Criteria
{
    using System;
    using System.Collections.Generic;

    using RandomGenerator.Controller.Containers;
    using RandomGenerator.Model.Functions;

    /// <summary>
    /// критерий пирсона
    /// </summary>
    public class PirsonCriterion
    {
        private Sampling ranged = null;//упорядоченная выборка
        private int Intervals;//количество интервалов
        private double Max;
        private double Min;
        private int Volume;//объём выборки
        private double step;
        private List<int> values = new List<int>();

        //конструктор
        public PirsonCriterion(Sampling sampling,int intervals)
        {
            Intervals = intervals;
            ranged = sampling.RangedSampling();//упорядоченная выборка
        }

        public PirsonContainer Calculate(int type)
        {
            PirsonTable table = new PirsonTable();// хранит таблицу для критерия Пирсона
            ArrayOfPoints borders = new ArrayOfPoints();//массив границ гистограмм
            List<int> m =new List<int>();//массив практических частот
            List<double> np= new List<double>();//массив теоретических частот
            int r = Intervals - 3;//количество степеней свободы (количество интервалов-количество ограничений)
            double χ = 0; //Хи
            Volume = ranged.GetVolume();
            PirsonContainer Result = new PirsonContainer();// создаём контейнер для результатов
            IDistributionFunction function1 = null;
            switch (type)
            {
                case 0:
                    function1 = UniversalDistributionFunction.Create();
                    break;

                case 1:
                    function1 = InverseDistributionFunction.Create();
                    break;

                case 2:
                    function1 = DiscreteDistributionFunction.Create();
                    break;

                default:
                    throw new Exception("Неизвестная функция");
            }
            if(type!=2)//вычисление Хи если функция непрерывная
            {
                Min = function1.Xmin();//минимальное значение СВ
                Max = function1.Xmax();//максимальное значение СВ
                step = (Max - Min) / Intervals;//длина интервала
                for (double i = Min; i < Max; i =/* Math.Floor(*/ i /* * 10000000000000) / 10000000000000 */+ step)
                {
                    borders.SetPoint(i);//добавляем границу
                    //вычисляем теоретическую частоту интервала
                    np.Add(Volume * (function1.GetFunctionValue(i + step) - function1.GetFunctionValue(i)));
                    //вычисляем практическую частоту интервала
                    m.Add(this.GetM(i));
                }
                borders.SetPoint(Max);
                for (int l = 0; l < Intervals; l++)
                {
                    if (np[l] != 0)
                    {
                        χ += Math.Pow((m[l] - np[l]), 2) / np[l];//вычисление Хи
                    }
                }
                Result.Border = borders;//сохраняем в контейнер с результатами
            }
            else//вычисление Хи если функция дискретная
            {
                //вычисление частот для каждой точки дискретной функции
                int n = 0;//номер значения в упорядоченной выборке
                Point p = null;//точка ряда распределения
                //для всех точек дискретной функции
                for (int j = 0; j < ((DiscreteDistributionFunction)function1).GetNumberOfPoints(); j++)
                {
                    m.Add(0);
                    p = ((DiscreteDistributionFunction)function1).GetPoint(j);//получаем очередную точку
                    np.Add(Volume * p.GetP);//вычисляем теоретическую частоту
                    //пока значения выборки совпадают с значением точки
                    while ((n < ranged.GetVolume()) && (p.GetX == ranged.GetValue(n)))
                    {
                        m[j]++;
                        n++;//переходим к следующей точке
                    }
                    χ += Math.Pow((m[j] - np[j]), 2) / np[j];//вычисление Хи
                }
            }
            
            double P = table.GetP(χ, r);//получение из таблицы значения критерия пирсона
            // сохраненение результатов в конетейнер
            Result.P = P;
            Result.Intervals = Intervals;
            Result.N = ranged.GetVolume();
            Result.Nj = m;
            Result.NP = np;
            Result.χ = χ;
            Result.r = r;
            return Result; 
        }

        //метод вычисляющий практическую частоту интервала
        private int GetM(double i)
        {
            int counter = 0;//счётчик
            for (int k = 0; k < Volume; k++)//для каждого значения выборки
            {
                //если значение на начальной границе и первый интервал
                if (i == Min && ranged.GetValue(k) == Min)
                {
                    counter++;
                }
                //если значение в текущем интервале
                if ((ranged.GetValue(k) > i) && (ranged.GetValue(k) <= i + step))
                {
                    counter++;
                }
                else
                {
                    //если значение на последней границе и последний интервал
                    if ((Math.Abs(i + step - Max) < 0.0000000000001) && (ranged.GetValue(k) == Max))
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }
    }
}
