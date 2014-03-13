using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RandomGenerator.Controller.Containers
{
    //абстрактный класс контейнер
    public abstract class Container
    {
        public int SamplingVolume;//объем выборки
        public ZedGraph.ZedGraphControl Controll1 = null;//полотна для вывода графиков
        public ZedGraph.ZedGraphControl Controll2 = null;
        public ZedGraph.ZedGraphControl Controll3 = null;
    }
}