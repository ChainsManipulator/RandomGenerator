namespace RandomGenerator.Controller.Containers
{
    using System.Collections.Generic;

    using RandomGenerator.Model;

    /// <summary>
    /// контейнер с данными, возвращаемыми генераторами
    /// </summary>
    public class AnswerContainer
    {
        /// <summary>
        /// выборка
        /// </summary>
        public Sampling sampling;

        /// <summary>
        /// критерий пирсона
        /// </summary>
        public KolmogorovContainer Kolmogorov;

        /// <summary>
        /// критерий колмогорова
        /// </summary>
        public PirsonContainer Pirson;

        /// <summary>
        /// прогресс
        /// </summary>
        public int progress = 0;//

        /// <summary>
        /// критерий пирсона вычислялся
        /// </summary>
        public bool PirsonCalculated = false;

        /// <summary>
        /// генерация значений закончена
        /// </summary>
        public bool GenerationFinished = false;

        /// <summary>
        /// вычисление критерия пирсона закончено
        /// </summary>
        public bool PirsonFinished = false;

        /// <summary>
        /// вычисление критерия колмогорова закончено
        /// </summary>
        public bool KolmogorovFinished = false;

        /// <summary>
        /// границы интервалов (используется только в универсальном методе)
        /// </summary>
        public List<double> Borders;
    }
}
