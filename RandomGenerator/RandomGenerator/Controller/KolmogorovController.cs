using System;
using System.Collections.Generic;
using System.Text;
using RandomGenerator.Controller.Containers;
using RandomGenerator.Model;
using RandomGenerator.Model.Criteria;
using RandomGenerator.Model.Functions;
using RandomGenerator.View;
using ZedGraph;

namespace RandomGenerator.Controller
{
    //контроллер критерия колмогорова
    public class KolmogorovController
    {
        private AnswerContainer Answer = null;//контейнер для результатов
        private Sampling sampling = null;//выборка
        private int FuncType; //id функции (0 - кусочно-линейная, 1 - аналитическая, 2 - дискретная)
        private ZedGraphControl DrawPanel = null; //полотно

        //конструктор
        public KolmogorovController(ZedGraphControl panel, Sampling sample, AnswerContainer answer, int type)
        {
            //сохрание входных даных в локальные переменные
            FuncType = type;
            DrawPanel = panel;
            lock (sample)
            {
                sampling = sample;
            }
            lock (answer)
            {
                Answer = answer;
            }
        }

        public void Calculate()
        {
            Drawer drawer = new Drawer();//художник рисующий вывески
            KolmogorovCriterion Kolmogorov = new KolmogorovCriterion();//критерий колмогорова
            lock(Answer)
            {
                Answer.Kolmogorov = Kolmogorov.Calculate(sampling, FuncType);//вычисление критерия
                Answer.progress += sampling.GetVolume();//прогресс +25%
            }
            drawer.DrawGraph2(DrawPanel, new PracticalDistributionFunction(sampling), FuncType);
            lock (Answer)
            {
                Answer.KolmogorovFinished = true;//вычисления закончены
            }
         }

    }
}
