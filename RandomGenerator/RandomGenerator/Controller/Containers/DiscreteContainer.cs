namespace RandomGenerator.Controller.Containers
{
    using System.Collections.Generic;

    using RandomGenerator.Model;

    /// <summary>
    /// контейнер с данными для третьего генератора
    /// </summary>
    public class DiscreteContainer : Container
    {
        /// <summary>
        /// массив точек дискретной функции плотности
        /// </summary>
        public List<Point> Values = new List<Point>();
    }
}
