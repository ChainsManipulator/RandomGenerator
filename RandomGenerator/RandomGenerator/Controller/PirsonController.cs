using System;
using System.Collections.Generic;
using System.Text;
using RandomGenerator.Controller.Containers;
using RandomGenerator.Model;
using RandomGenerator.Model.Criteria;
using RandomGenerator.View;
using ZedGraph;

namespace RandomGenerator.Controller
{
    //контроллер критрерия пирсона
    public class PirsonController
    {
        private AnswerContainer Answer = null;//контейнер для результатов
        private Sampling sampling = null;//выборка
        private int FuncType;  //id функции (0 - кусочно-линейная, 1 - аналитическая, 2 - дискретная)
        private ZedGraphControl DrawPanel = null;  //полотно
        private int Intervals;
        private List<double> UniversalBorders = null;//границы интервалов универсального метода 

        //конструктор
        public PirsonController(ZedGraphControl panel, Sampling sample, AnswerContainer answer, int type,int intervals, List<double> Borders)
        {
            //сохрание входных даных в локальные переменные
            FuncType = type;
            DrawPanel = panel;
            Intervals = intervals;
            UniversalBorders = Borders;
            lock(sample)
            {
                sampling = sample;
            }
            lock(answer)
            {
                Answer = answer;
            }
        }

        public void Calculate()
        {
            PirsonCriterion Criterion = new PirsonCriterion(sampling, Intervals);//критерий пирсона
            Drawer drawer = new Drawer();//художник рисующий вывески
            if (sampling.GetVolume() >= 100)//критерий не вычисляется если объём выборки <100
            {
                PirsonContainer PirsonAnswer = Criterion.Calculate(FuncType);//вычисление критерия
                lock (Answer)
                {
                    //сохраниение результатов
                    Answer.Pirson = PirsonAnswer;
                    Answer.PirsonCalculated = true;
                    Answer.progress += sampling.GetVolume();//прогресс +25%
                }
                if(FuncType==0)
                {
                    //отрисовка графика
                    drawer.DrawGraph3(DrawPanel, PirsonAnswer, FuncType, UniversalBorders);
                }
                else
                {
                    drawer.DrawGraph3(DrawPanel, PirsonAnswer, FuncType);//отрисовка графика
                }
                
            }
            //если критерий не вычисляется
            else
            {
                drawer.Clear(DrawPanel);//очистка полотна
            }
            lock(Answer)
            {
                Answer.PirsonFinished = true;//вычисления завершены
            } 
        }
    }
}
