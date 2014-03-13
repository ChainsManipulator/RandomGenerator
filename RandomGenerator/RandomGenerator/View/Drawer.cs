using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using RandomGenerator.Controller.Containers;
using RandomGenerator.Model;
using RandomGenerator.Model.Functions;
using ZedGraph;

namespace RandomGenerator.View
{
    //художник рисующий вывески
    public class Drawer
    {
        public void DrawGraph1(ZedGraphControl control,Sampling sampling,int type)
        {
            GraphPane pane = control.GraphPane;     // Получим панель для рисования
            pane.CurveList.Clear();                 // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.Title.Text = "Выборка и её характеристика"; // Название панели и осей
            pane.XAxis.Title.Text = "N";
            pane.YAxis.Title.Text = "X";
            PointPairList list2 = new PointPairList();      // Создадим список точек
            list2.Add(0, sampling.AvеrageValue());          // добавим в список точки
            list2.Add(sampling.GetVolume(), sampling.AvеrageValue());

            // Создадим кривую с названием "Sinc", 
            // которая будет рисоваться голубым цветом (Color.Blue),
            // Опорные точки выделяться не будут (SymbolType.None)
            LineItem myCurve2 = pane.AddCurve("среднее значение", list2, Color.Green, SymbolType.None);
            myCurve2.Line.Width = 2.0F; // Толщина графиков

            IDensityFunction function1 = null;
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
            double Expectation = function1.GetExpectation();
            double MeanSquareDeviation = function1.GetMeanSquareDeviation();

            PointPairList list3 = new PointPairList();      // Создадим список точек
            list3.Add(0, Expectation);          // добавим в список точки
            list3.Add(sampling.GetVolume(), Expectation);

            // Создадим кривую с названием "Sinc", 
            // которая будет рисоваться голубым цветом (Color.Blue),
            // Опорные точки выделяться не будут (SymbolType.None)
            LineItem myCurve3 = pane.AddCurve("математическое ожидание", list3, Color.Red, SymbolType.None);
            myCurve3.Line.Width = 2.0F; // Толщина графиков

            PointPairList list4 = new PointPairList();      // Создадим список точек
            list4.Add(sampling.GetVolume(), Expectation + MeanSquareDeviation); // добавим в список точки
            list4.Add(0, Expectation + MeanSquareDeviation);
            list4.Add(0, Expectation - MeanSquareDeviation);// добавим в список точки
            list4.Add(sampling.GetVolume(), Expectation - MeanSquareDeviation);

            // Создадим кривую с названием "Sinc", 
            // которая будет рисоваться голубым цветом (Color.Blue),
            // Опорные точки выделяться не будут (SymbolType.None)
            LineItem myCurve4 = pane.AddCurve("СКО", list4, Color.Maroon, SymbolType.None);
            myCurve4.Line.Width = 2.0F; // Толщина графиков

            PointPairList list = new PointPairList();       // Создадим список точек
            list.Add(0, 0);
            for (int i = 0; i < sampling.GetVolume(); i++)  // Заполняем список точек
            {
                // добавим в список точку
                list.Add(i+1, 0);
                list.Add(i+1, sampling.GetValue(i));
                list.Add(i+1, 0);
            }
            // Создадим кривую с названием "Sinc", 
            // которая будет рисоваться голубым цветом (Color.Blue),
            // Опорные точки выделяться не будут (SymbolType.None)
            LineItem myCurve = pane.AddCurve("Генерируемые  значения", list, Color.DarkOrchid, SymbolType.None);
            myCurve.Line.Width = 2.0F;
            pane.XAxis.Scale.Min = -1; // Устанавливаем интересующий нас интервал по оси X
            if(sampling.GetVolume()>=50)
            {
                pane.XAxis.Scale.Max = 51;
            }
            else
            {
                pane.XAxis.Scale.Max = sampling.GetVolume() + 1;
            }

            double Min = sampling.Min();
            double Max = sampling.Max();

            pane.YAxis.Scale.Min = Min - (Max - Min) / 20; // Устанавливаем интересующий нас интервал по оси Y
            pane.YAxis.Scale.Max = Max + (Max - Min) / 20;

            pane.XAxis.MajorGrid.IsVisible = true;  // Включаем отображение сетки напротив крупных рисок по оси X

            // Задаем вид пунктирной линии для крупных рисок по оси X:
            // Длина штрихов равна 10 пикселям, ... 
             pane.XAxis.MajorGrid.DashOn = 10;

            // затем 5 пикселей - пропуск
             pane.XAxis.MajorGrid.DashOff = 5;

            // Включаем отображение сетки напротив крупных рисок по оси Y
             pane.YAxis.MajorGrid.IsVisible = true;

            // Аналогично задаем вид пунктирной линии для крупных рисок по оси Y
                pane.YAxis.MajorGrid.DashOn = 10;
             pane.YAxis.MajorGrid.DashOff = 5;

            // Включаем отображение сетки напротив мелких рисок по оси X
            pane.YAxis.MinorGrid.IsVisible = true;

            // Задаем вид пунктирной линии для крупных рисок по оси Y: 
            // Длина штрихов равна одному пикселю, ... 
            pane.YAxis.MinorGrid.DashOn = 1;

            // затем 2 пикселя - пропуск
            pane.YAxis.MinorGrid.DashOff = 2;

            // Включаем отображение сетки напротив мелких рисок по оси Y
            pane.XAxis.MinorGrid.IsVisible = true;

            // Аналогично задаем вид пунктирной линии для крупных рисок по оси Y
            pane.XAxis.MinorGrid.DashOn = 1;
            pane.XAxis.MinorGrid.DashOff = 2;
            
            //Цвет сетки
            pane.XAxis.MajorGrid.Color = Color.LightGray;
            pane.YAxis.MajorGrid.Color = Color.LightGray;

            //Оси
            pane.XAxis.MajorGrid.IsZeroLine = true;
            pane.YAxis.MajorGrid.IsZeroLine = true;

            // Вызываем метод AxisChange (), чтобы обновить данные об осях. 
            // В противном случае на рисунке будет показана только часть графика, 
            // которая умещается в интервалы по осям, установленные по умолчанию
            control.AxisChange();

            // Обновляем график
            control.Invalidate();
        }

        public void DrawGraph2(ZedGraphControl control,PracticalDistributionFunction function2,int type)
        {
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
            //DensityFunction function2 = DensityFunction.Create();
            // Получим панель для рисования
            GraphPane pane = control.GraphPane;

            pane.CurveList.Clear();// Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы

            pane.Title.Text = "Функция распределения"; // Название панели и осей
            pane.XAxis.Title.Text = "X";
            pane.YAxis.Title.Text = "F(X)";

            PointPairList list = new PointPairList();// Создадим список точек
            PointPairList list2 = new PointPairList();

            double min = function1.GetInverseFunctionValue(0);
            double max = function1.GetInverseFunctionValue(1);
            list.Add(min,0);
            list2.Add(min,0);
            double step = (max - min) / 100000;//точность нахождения границы
            for (double j = min; j <= (max+5000*step); j += step)
            {
                if(type == 2)
                {
                    list.Add(j, function2.GetDiscreteFunctionValue(j));
                }
                else
                {
                    list.Add(j, function2.GetFunctionValue(j));
                }

                list2.Add(j, function1.GetFunctionValue(j));
            }
            // Создадим кривую с названием "Sinc", 
            // которая будет рисоваться голубым цветом (Color.Blue),
            // Опорные точки выделяться не будут (SymbolType.None)
            LineItem myCurve = pane.AddCurve("практическая функция распределения", list, Color.Blue, SymbolType.None);

            // Создадим кривую с названием "Sinc2", 
            // которая будет рисоваться голубым цветом (Color.Red),
            // Опорные точки выделяться не будут (SymbolType.None)
            LineItem myCurve2 = pane.AddCurve("функция распределения", list2, Color.Red, SymbolType.None);

            myCurve.Line.Width = 2.0F; // Толщина графиков
            myCurve2.Line.Width = 2.0F;

            pane.XAxis.Scale.Min = min - 5000 * step;   // Устанавливаем интересующий нас интервал по оси X
            pane.XAxis.Scale.Max = max+5000*step;

            // Включаем отображение сетки напротив крупных рисок по оси X
            pane.XAxis.MajorGrid.IsVisible = true;

            // Задаем вид пунктирной линии для крупных рисок по оси X:
            // Длина штрихов равна 10 пикселям, ... 
            pane.XAxis.MajorGrid.DashOn = 10;

            // затем 5 пикселей - пропуск
            pane.XAxis.MajorGrid.DashOff = 5;


            // Включаем отображение сетки напротив крупных рисок по оси Y
            pane.YAxis.MajorGrid.IsVisible = true;

            // Аналогично задаем вид пунктирной линии для крупных рисок по оси Y
            pane.YAxis.MajorGrid.DashOn = 10;
            pane.YAxis.MajorGrid.DashOff = 5;


            // Включаем отображение сетки напротив мелких рисок по оси X
            pane.YAxis.MinorGrid.IsVisible = true;

            // Задаем вид пунктирной линии для крупных рисок по оси Y: 
            // Длина штрихов равна одному пикселю, ... 
            pane.YAxis.MinorGrid.DashOn = 1;

            // затем 2 пикселя - пропуск
            pane.YAxis.MinorGrid.DashOff = 2;

            // Включаем отображение сетки напротив мелких рисок по оси Y
            pane.XAxis.MinorGrid.IsVisible = true;

            //Цвет сетки
            pane.XAxis.MajorGrid.Color = Color.Gray;
            pane.YAxis.MajorGrid.Color = Color.Gray;

            // Аналогично задаем вид пунктирной линии для крупных рисок по оси Y
            pane.XAxis.MinorGrid.DashOn = 1;
            pane.XAxis.MinorGrid.DashOff = 2;

            //Оси
            pane.XAxis.MajorGrid.IsZeroLine = true;
            pane.YAxis.MajorGrid.IsZeroLine = true;

            // Вызываем метод AxisChange (), чтобы обновить данные об осях. 
            // В противном случае на рисунке будет показана только часть графика, 
            // которая умещается в интервалы по осям, установленные по умолчанию
            control.AxisChange();

            control.Invalidate();  // Обновляем график
        }

        public void DrawGraph3(ZedGraphControl control, PirsonContainer data ,int type, List<double> borders)
        {
            DrawGraph3(control, data, type);
            GraphPane pane = control.GraphPane; // Получим панель для рисования  
            PointPairList list4 = new PointPairList();// Создадим список точек
            UniversalDistributionFunction function = UniversalDistributionFunction.Create();
            //границы равновероятных интервалов универсального метода
            for(int i=0;i<borders.Count;i++)
            {
                list4.Add(borders[i], 0);
                list4.Add(borders[i], function.GetDensityFunctionValue(borders[i])); 
                list4.Add(borders[i], 0);
            }
            LineItem curve = pane.AddCurve("границы равновероятных интервалов", list4, Color.Green, SymbolType.None);
            curve.Line.Width = 2.0F;
        }

        public void DrawGraph3(ZedGraphControl control, PirsonContainer data ,int type)
        {
            GraphPane pane = control.GraphPane;// Получим панель для рисования     
            // Очистим список кривых
            pane.CurveList.Clear();

            pane.Title.Text = "Плотность распределения";  // Название панели и осей
            pane.XAxis.Title.Text = "Х";
            pane.YAxis.Title.Text = "f(x)";

            IDistributionFunction function1 = null;
            IDensityFunction function2 = null;
            switch (type)
            {
                case 0:
                    function1 = UniversalDistributionFunction.Create();
                    function2 = UniversalDistributionFunction.Create();
                    break;

                case 1:
                    function1 = InverseDistributionFunction.Create();
                    function2 = InverseDistributionFunction.Create();
                    break;

                case 2:
                    function1 = DiscreteDistributionFunction.Create();
                    function2 = DiscreteDistributionFunction.Create();
                    break;

                default:
                    throw new Exception("Неизвестная функция");
            }
            double min = function1.GetInverseFunctionValue(0);
            double max = function1.GetInverseFunctionValue(1);

            PointPairList list = new PointPairList();  // Создадим список точек
            PointPairList list3 = new PointPairList();  // Создадим список точек

            double step = (max - min) / 100000;  // Заполняем список точек
            list.Add(min, 0);
            if (type == 2)
            {
                for (int i = 0; i < ((DiscreteDistributionFunction)function1).GetNumberOfPoints(); i++)
                {
                    RandomGenerator.Model.Point point = ((DiscreteDistributionFunction)function1).GetPoint(i);
                    // добавим в список точку
                    list.Add(point.GetX, 0);
                    list.Add(point.GetX, point.GetP);
                    list.Add(point.GetX, 0);

                    list3.Add(point.GetX + 400 * step, 0);
                    list3.Add(point.GetX + 400 * step,(double) data.Nj[i]/data.N);//гистограмма для дискретной
                    list3.Add(point.GetX + 400 * step, 0);
                }
            }
            else
            {
                for (double i = min; i < max; i += step)
                {
                    list.Add(i, function2.GetDensityFunctionValue(i));// добавим в список точку
                }
            }
            list.Add(max, 0);
            LineItem myCurve = null;
            LineItem myCurve2 = null;
            double[] x = new double[data.Intervals];
            double[] list2 = new double[data.Intervals];
            for (int i = 0; i <data.Intervals; i++)
            {
                if(type==2)
                {
                    //list2[i] = (double)data.Nj[i] / data.N;
                }
                else
                {
                    x[i] = (data.Border.GetPoint(i) + data.Border.GetPoint(i + 1)) / 2;
                    list2[i] = (double)data.Intervals * data.Nj[i] / (data.N * (max - min));
                }
            }
            // Создадим кривую с названием "Sinc", 
            // которая будет рисоваться голубым цветом (Color.Blue),
            // Опорные точки выделяться не будут (SymbolType.None)
            
            if(type == 2)
            {
                myCurve = pane.AddCurve("ряд распределения", list, Color.DarkGreen, SymbolType.None);
                myCurve2 = pane.AddCurve("практический ряд распределения", list3, Color.DarkOrange, SymbolType.None);
                myCurve2.Line.Width = 2.0F;  // Толщина графиков

            }
            else
            {
                myCurve = pane.AddCurve("функция плотности", list, Color.Orange, SymbolType.None);
                // Создадим кривую с названием "Sinc", 
                // которая будет рисоваться голубым цветом (Color.Blue),
                // Опорные точки выделяться не будут (SymbolType.None)
                BarItem myBar = pane.AddBar("гистограмма ", x, list2, Color.Empty);
                myBar.Bar.Fill = new Fill(Color.Empty, Color.Empty, Color.Empty);
                myBar.Bar.Border.Color = Color.BlueViolet;
                pane.BarSettings.MinClusterGap = 0;
            }

            // Устанавливаем интересующий нас интервал по оси X
            pane.XAxis.Scale.Min = min - 5000 * step;
            pane.XAxis.Scale.Max = max + 5000 * step;
            // Устанавливаем интересующий нас интервал по оси Y
            switch (type)
            {
                case 0:
                    pane.YAxis.Scale.Max = 3.5;
                    break;
                case 1:
                    pane.YAxis.Scale.Max = 1.6;
                    break;
                case 2:
                    pane.YAxis.Scale.Max = 0.16;
                    break;
                default:
                    throw new Exception("Неизвестная функция");
            }
            pane.YAxis.Scale.Min = 0;

            myCurve.Line.Width = 2.0F;  // Толщина графиков
            
            // Включаем отображение сетки напротив крупных рисок по оси X
            pane.XAxis.MajorGrid.IsVisible = true;

            // Задаем вид пунктирной линии для крупных рисок по оси X:
            // Длина штрихов равна 10 пикселям, ... 
            pane.XAxis.MajorGrid.DashOn = 10;

            // затем 5 пикселей - пропуск
            pane.XAxis.MajorGrid.DashOff = 5;

            // Включаем отображение сетки напротив крупных рисок по оси Y
            pane.YAxis.MajorGrid.IsVisible = true;

            // Аналогично задаем вид пунктирной линии для крупных рисок по оси Y
            pane.YAxis.MajorGrid.DashOn = 10;
            pane.YAxis.MajorGrid.DashOff = 5;

            // Включаем отображение сетки напротив мелких рисок по оси X
            pane.YAxis.MinorGrid.IsVisible = true;

            // Задаем вид пунктирной линии для крупных рисок по оси Y: 
            // Длина штрихов равна одному пикселю, ... 
            pane.YAxis.MinorGrid.DashOn = 1;

            // затем 2 пикселя - пропуск
            pane.YAxis.MinorGrid.DashOff = 2;

            // Включаем отображение сетки напротив мелких рисок по оси Y
            pane.XAxis.MinorGrid.IsVisible = true;

            // Аналогично задаем вид пунктирной линии для крупных рисок по оси Y
            pane.XAxis.MinorGrid.DashOn = 1;
            pane.XAxis.MinorGrid.DashOff = 2;

            //Цвет сетки
            pane.XAxis.MajorGrid.Color = Color.LightGray;
            pane.YAxis.MajorGrid.Color = Color.LightGray;

            //Оси
            pane.XAxis.MajorGrid.IsZeroLine = true;
            pane.YAxis.MajorGrid.IsZeroLine = true;
    
            // Вызываем метод AxisChange (), чтобы обновить данные об осях. 
            // В противном случае на рисунке будет показана только часть графика, 
            // которая умещается в интервалы по осям, установленные по умолчанию
            control.AxisChange();

            control.Invalidate(); // Обновляем график
        }

        //метод очищает полотно для рисования
        public void Clear(ZedGraphControl control)
        {
            // Получим панель для рисования
            GraphPane pane = control.GraphPane;

            // Очистим список кривых
            pane.CurveList.Clear();

            // Обновляем график
            control.Invalidate();
        }
    }
}