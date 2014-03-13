using System;
using System.Collections.Generic;
using System.Text;
using RandomGenerator.Model;

namespace RandomGenerator.Controller.Containers
{
    //контейнер с данными, возвращаемыми генераторами
    public class AnswerContainer
    {
        public Sampling sampling;//выборка
        public KolmogorovContainer Kolmogorov; //критерий пирсона
        public PirsonContainer Pirson; //критерий колмогорова
        public int progress = 0;//прогресс
        public bool PirsonCalculated = false;//критерий пирсона вычислялся
        public bool GenerationFinished = false;//генерация значений закончена
        public bool PirsonFinished = false;//вычисление критерия пирсона закончено
        public bool KolmogorovFinished = false;//вычисление критерия колмогорова закончено
        public List<double> Borders;//границы интервалов (используется только в универсальном методе)
    }
}
