namespace RandomGenerator.Controller
{

    using System.Threading;

    using RandomGenerator.Controller.Containers;
    using RandomGenerator.Model;
    using RandomGenerator.Model.Generators;
    using RandomGenerator.View;

    /// <summary>
    /// контроллер генератора с дискретной функцией
    /// </summary>
    public class DiscreteInverseController
    {
        private Sampling sampling = new Sampling();//выборка
        private DiscreteInverseGenerator generator = null;//генератор
        private DiscreteContainer data = null;//контейнер с входными данными
        private AnswerContainer Answer = null;//контейнер для результатов

        //конструктор
        public DiscreteInverseController(DiscreteContainer InputData, AnswerContainer result)
        {
            data = InputData;
            lock (result)
            {
                Answer = result;
            }
        }

        //основной метод
        public void Generate()
        {
            Drawer drawer = new Drawer();//художник рисующий вывески
            drawer.Clear(data.Controll1);//очистка полотен
            drawer.Clear(data.Controll2);
            drawer.Clear(data.Controll3);
            //создание экземпляра генератора
            generator = new DiscreteInverseGenerator(data.Values);
            for (int i = 0; i < data.SamplingVolume; i++)//генерация выборки
            {
                lock (Answer)//синхронизация по контейнеру с результатами
                {
                    Answer.progress = 2 * (i + 1);//задание текущего прогресса
                }
                sampling.AddValue(generator.GenerateValue());//добавление сгенерированного значения к выборке
            }
            //создаём экземпляр контроллера критерия пирсона
            PirsonController PirsonControl = new PirsonController(data.Controll3, sampling, Answer, 2, data.Values.Count, null);
            Thread PirsonThread = new Thread(PirsonControl.Calculate);//помещаем конроллер в нить
            PirsonThread.Start();//запускаем нить
            //создаём экземпляр контроллера критерия колмогорова
            KolmogorovController KolmogorovControl = new KolmogorovController(data.Controll2, sampling, Answer, 2);
            Thread KolmogorovThread = new Thread(KolmogorovControl.Calculate);//помещаем контроллер в нить
            KolmogorovThread.Start();// запускаем нить
            drawer.DrawGraph1(data.Controll1, sampling, 2);
            lock (Answer)
            {
                Answer.sampling = sampling;//ложим выборку в контейнер результов
                Answer.GenerationFinished = true;//вычисления завершены
            }
        }
    }
}
