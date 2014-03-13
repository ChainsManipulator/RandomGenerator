using System;
using System.Collections.Generic;
using System.Text;

namespace RandomGenerator.Model.Functions
{
    //практическая функция распределения
    public class PracticalDistributionFunction
    {
        private List<Point> Values = new List<Point>();

        //конструктор
        public PracticalDistributionFunction(Sampling sampling)
        {
            Sampling Ranged = sampling.RangedSampling(); //упорядоченная выборка
            double P = (double)1 / Ranged.GetVolume();//частота одной точки 
            Values.Add(new Point(Ranged.GetValue(0), P)); //добавляем первую точку к функции
            Ranged.DeletValue(Ranged.GetValue(0)); //удаляем её из выборки
            while (Ranged.GetVolume() != 0) //пока в выборке есть точки
            {
                double TemproraryProbability = Values[Values.Count - 1].GetP + P;
                if (Values[Values.Count - 1].GetX == Ranged.GetValue(0))
                    //если точка имеет то же значение что и последняя в функции
                {
                    Values[Values.Count - 1] = new Point(Ranged.GetValue(0), TemproraryProbability);
                    //увеличиваем значение функции в данной точке
                }
                else
                {
                    Values.Add(new Point(Ranged.GetValue(0), TemproraryProbability));
                    //иначе добавляем к функции новую точку
                }
                Ranged.DeletValue(Ranged.GetValue(0)); //удаляем текущую точку из выборки
            }
        }

        //возвращает значение "кусочно-линейной" функции в точке
        public double GetFunctionValue(double x)
        {
            if(x <= Values[0].GetX)
            {
                return 0;
            }
            if(x >= Values[Values.Count-1].GetX)
            {
                return 1;
            }
            double y=0;
            for (int i = 1; i < Values.Count; i++)
            {
                double val = Values[i].GetX;
                if (x <= val)
                {
                    double x1 = Values[i - 1].GetX;
                    double x2 = Values[i].GetX;
                    double y1 = Values[i - 1].GetP;
                    double y2 = Values[i].GetP;
                    y = y1 + ((x - x1)*(y2 - y1))/(x2 - x1);
                    break;
                }
            }
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

        //возвращает значение "ступенчатой" функции в точке
        public double GetDiscreteFunctionValue(double x)
        {
            if (x <= Values[0].GetX)
            {
                return 0;
            }
            if (x >= Values[Values.Count - 1].GetX)
            {
                return 1;
            }
            double val = Values[0].GetX;
            double probability = 0;
            double y = 0;
            for (int i = 1; i < Values.Count; i++)
            {
                if (x < val)
                {
                    y = probability;
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
                val = Values[i].GetX;
                probability = Values[i - 1].GetP;
            }
            return probability;
        }

        public double MeanSquareDeviation(double AverageValue)
        {
            double D = 0;
            for (int i = 0; i < Values.Count; i++)
            {
                double j ;
                if(i==0)
                {
                    j = 0;
                }
                else
                {
                    j = Values[i - 1].GetP;
                }
                D += (Values[i].GetP - j) * Math.Pow((Values[i].GetX - AverageValue), 2);
            }
            return Math.Sqrt(D);
        }
    }
}