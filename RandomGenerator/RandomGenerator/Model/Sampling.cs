using System;
using System.Collections.Generic;
using System.Text;

namespace RandomGenerator.Model
{
    //хранит выборку
    public class Sampling
    {
        private List<double> Values = new List<double>();//выборка

        //возвращает значение по индексу
        public double GetValue(int Number)
        {
            return Values[Number];
        }

        //добавляет значение в выборку
        public void AddValue(double value)
        {
            Values.Add(value);
        }

        //возвращает объём выборки
        public int GetVolume()
        {
            return Values.Count;
        }

        ///возвращает среднее значение в выборке
        public double AvеrageValue()
        {
            double Sum = 0;
            for (int i = 0; i < GetVolume(); i++)
            {
                Sum += GetValue(i);
            }
            return Sum / GetVolume();
        }

        //возвращает упорядоченную по возрастанию выборку
        public Sampling RangedSampling()
        { 
            Sampling mass = this.Clone();
            for (int i = 0; i < GetVolume(); i++)
            {
                for (int j = i; j < GetVolume(); j++)
                {
                    double FirstValue = mass.GetValue(i);
                    double SecondValue = mass.GetValue(j);
                    if (FirstValue > SecondValue)
                    {
                        mass.SetValue(i, SecondValue);
                        mass.SetValue(j, FirstValue);
                    }
                }
            }
            return mass;
        }

        //удаляет значение из выборки
        public void DeletValue(double value)
        {
            Values.Remove(value);
        }

        //возвращает минимальное значение в выборке
        public double Min()
        {
            double min = Values[0];
            for (int i = 0; i < GetVolume(); i++)
            {
                if(GetValue(i)<min)
                {
                    min = GetValue(i);
                }
            }
            return min;
        }

        //возвращает максимальное значение в выборке
        public double Max()
        {
            double max = Values[0];
            for (int i = 0; i < GetVolume(); i++)
            {
                if (GetValue(i) > max)
                {
                    max = GetValue(i);
                }
            }
            return max;
        }

        //возвращает копию выборки
        public Sampling Clone()
        {
            Sampling Result = new Sampling();
            for(int i=0;i<GetVolume();i++)
            {
                Result.AddValue(GetValue(i));
            }
            return Result;
        }

        //устанавливает значение в i-ю позицию выборки
        public void SetValue(int position, double value)
        {
            Values[position] = value;
        }
    }
}
