namespace RandomGenerator.Model
{
    using System;
    using System.Collections.Generic;

    using RandomGenerator.Model.Functions;

    /// <summary>
    /// находит границы интервалов для универсального метода
    /// </summary>
    public class IntervalFinder
    {
        public ArrayOfPoints Borders = new ArrayOfPoints();//массив границ интервалов
        private Square integral = new Square();//экземпляр класса вычисляющего площадь

        public void Find(int intervals)
        {
            //получаем экземпляр функции распределения
            UniversalDistributionFunction function2 = UniversalDistributionFunction.Create();
            double square=(double)1/intervals;//искомая площадь интервала
            double step = (function2.Xmax() - function2.Xmin())/1000000;//точность нахождения границы
            double prevpoint = function2.Xmin();//начальная точка кармана
            double secondpoint = prevpoint + step;//конечная точка кармана
            Borders.SetPoint(function2.Xmin());//заносим в массив первую точку
            while (Borders.GetNumberOfPoints()<(intervals))
            {
                //пока площадь кармана меньше искомой
                while (square > integral.GetSquare(prevpoint, secondpoint))
                {
                    //увеличиваем карман
                    secondpoint += step;
                }
                Borders.SetPoint(secondpoint);// добавление точки в массив
                prevpoint = secondpoint;//начальная точка кармана равна конечной точке предыдущего шага
            }
            Borders.SetPoint(function2.Xmax());//добавляем последнюю границу
            if(intervals!=(Borders.GetNumberOfPoints()-1))
            {
                throw new Exception("ошибка при разбиении на интервалы\n");
            }
        }

        public List<double> GetIntervals()
        {
            return Borders.GetArray();
        }
    }
}
