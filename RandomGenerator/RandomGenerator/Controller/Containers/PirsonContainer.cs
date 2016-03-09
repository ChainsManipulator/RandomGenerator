namespace RandomGenerator.Controller.Containers
{
    using System.Collections.Generic;

    using RandomGenerator.Model;

    /// <summary>
    /// контейнер с данными возвращаемыми критерием пирсона
    /// </summary>
    public class PirsonContainer
    {
        /// <summary>
        /// количество интервалов
        /// </summary>
        public int Intervals;

        /// <summary>
        /// массив границ
        /// </summary>
        public ArrayOfPoints Border = null;

        /// <summary>
        /// массив практических частот
        /// </summary>
        public List<int> Nj = null;

        /// <summary>
        /// размер выборки
        /// </summary>
        public int N;

        /// <summary>
        /// результат вычисления критерия пирсона
        /// </summary>
        public double P;

        /// <summary>
        /// массив теоретических частот
        /// </summary>
        public List<double> NP;

        /// <summary>
        /// Хи
        /// </summary>
        public double χ;

        /// <summary>
        /// число степеней свободы
        /// </summary>
        public int r;
    }
}
