namespace RandomGenerator.Controller.Containers
{
    /// <summary>
    /// абстрактный класс контейнер
    /// </summary>
    public abstract class Container
    {
        /// <summary>
        /// объем выборки
        /// </summary>
        public int SamplingVolume;

        /// <summary>
        /// полотна для вывода графиков
        /// </summary>
        public ZedGraph.ZedGraphControl Controll1 = null;
        public ZedGraph.ZedGraphControl Controll2 = null;
        public ZedGraph.ZedGraphControl Controll3 = null;
    }
}
