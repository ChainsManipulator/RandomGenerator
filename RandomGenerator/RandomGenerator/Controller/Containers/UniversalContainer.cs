namespace RandomGenerator.Controller.Containers
{
    using System.Collections.Generic;

    using RandomGenerator.Model;

    /// <summary>
    /// контейнер с данными для первого генератора
    /// </summary>
    public class UniversalContainer : Container
    {
        public int Intervals;

        /// <summary>
        /// количество интервалов в критерии пирсона
        /// </summary>
        public int PirsonIntervals;

        /// <summary>
        /// массив точек перегиба кусочно-линейной функции
        /// </summary>
        public List<Inflection> Values = new List<Inflection>();
    }
}
