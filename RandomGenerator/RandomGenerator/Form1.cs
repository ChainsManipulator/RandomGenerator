using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using RandomGenerator.Controller;
using RandomGenerator.Controller.Containers;
using RandomGenerator.Model;
using RandomGenerator.Model.Functions;
using ZedGraph;
using ZedGraph.Web;
using Point=RandomGenerator.Model.Point;

namespace RandomGenerator
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            //начальные точки кусочно-линейной функции (универсальный метод)
            dataGridView4.Rows.Add();           //добавление строки в таблицу
            dataGridView4.Rows[0].Cells[0].Value = -0.4;//задание значения в ячейке
            dataGridView4.Rows[0].Cells[1].Value = 0;
            dataGridView4.Rows.Add();
            dataGridView4.Rows[1].Cells[0].Value = -0.3;
            dataGridView4.Rows[1].Cells[1].Value = 1.5;
            dataGridView4.Rows.Add();
            dataGridView4.Rows[2].Cells[0].Value = -0.2;
            dataGridView4.Rows[2].Cells[1].Value = 0;
            dataGridView4.Rows.Add();
            dataGridView4.Rows[3].Cells[0].Value = -0.1;
            dataGridView4.Rows[3].Cells[1].Value = 3;
            dataGridView4.Rows.Add();
            dataGridView4.Rows[4].Cells[0].Value = 0.2;
            dataGridView4.Rows[4].Cells[1].Value = 0;
            dataGridView4.Rows.Add();
            dataGridView4.Rows[5].Cells[0].Value = 0.4;
            dataGridView4.Rows[5].Cells[1].Value = 1;
            dataGridView4.Rows.Add();
            dataGridView4.Rows[6].Cells[0].Value = 0.5;
            dataGridView4.Rows[6].Cells[1].Value = 1;
            dataGridView4.Rows.Add();
            dataGridView4.Rows[7].Cells[0].Value = 0.6;
            dataGridView4.Rows[7].Cells[1].Value = 0;

            //начальные точки дискретной функции (метод обратной функции)
            dataGridView5.Rows.Add();
            dataGridView5.Rows[0].Cells[0].Value = -3.5;
            dataGridView5.Rows[0].Cells[1].Value = 0.06;
            dataGridView5.Rows.Add();
            dataGridView5.Rows[1].Cells[0].Value = -2.05;
            dataGridView5.Rows[1].Cells[1].Value = 0.05;
            dataGridView5.Rows.Add();
            dataGridView5.Rows[2].Cells[0].Value = 0;
            dataGridView5.Rows[2].Cells[1].Value = 0.1;
            dataGridView5.Rows.Add();
            dataGridView5.Rows[3].Cells[0].Value = 1.47;
            dataGridView5.Rows[3].Cells[1].Value = 0.05;
            dataGridView5.Rows.Add();
            dataGridView5.Rows[4].Cells[0].Value = 8;
            dataGridView5.Rows[4].Cells[1].Value = 0.14;
            dataGridView5.Rows.Add();
            dataGridView5.Rows[5].Cells[0].Value = 10;
            dataGridView5.Rows[5].Cells[1].Value = 0.1;
            dataGridView5.Rows.Add();
            dataGridView5.Rows[6].Cells[0].Value = 11.03;
            dataGridView5.Rows[6].Cells[1].Value = 0.06;
            dataGridView5.Rows.Add();
            dataGridView5.Rows[7].Cells[0].Value = 11.85;
            dataGridView5.Rows[7].Cells[1].Value = 0.1;
            dataGridView5.Rows.Add();
            dataGridView5.Rows[8].Cells[0].Value = 12.4;
            dataGridView5.Rows[8].Cells[1].Value = 0.12;
            dataGridView5.Rows.Add();
            dataGridView5.Rows[9].Cells[0].Value = 13.9;
            dataGridView5.Rows[9].Cells[1].Value = 0.08;
            dataGridView5.Rows.Add();
            dataGridView5.Rows[10].Cells[0].Value = 18.165;
            dataGridView5.Rows[10].Cells[1].Value = 0.05;
            dataGridView5.Rows.Add();
            dataGridView5.Rows[11].Cells[0].Value = 19.5;
            dataGridView5.Rows[11].Cells[1].Value = 0.04;
            dataGridView5.Rows.Add();
            dataGridView5.Rows[12].Cells[0].Value = 20;
            dataGridView5.Rows[12].Cells[1].Value = 0.05;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tabControl1_Resize(object sender, EventArgs e)
        {
            tabControl1.Refresh();
        }

        private Thread UniversalCalculator = null;      //нить первого генератора
        private AnswerContainer UniversalAnswer = new AnswerContainer();// результаты работы первого генератора

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Hide();//скрываем кнопку до конца вычислений
            progressBar1.Value = 0;//прогресс равен 0
            dataGridView1.Hide(); //скрываем таблицу с результатами вычислений предыдущего раза
            dataGridView6.Hide(); //скрываем таблицу с грницами предыдущего генератора
            progressBar1.Show();//показывааем полосу загрузки
            groupBox1.Hide();
            groupBox2.Hide();
           /* label8.Text = "";//отчищаем подписи содержащие значения критериев
            label9.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            label15.Text = "";
            label16.Text = "";
            label29.Text = "";
            label36.Text = "";*/
            UniversalContainer container = null;
            try//пытаемся получить входные данные
            {
                container = UniversalParse();//получаем входные данные с формы
            }
            catch(Exception exp)//если произошло исключение
            {
                MessageBox.Show(exp.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                button1.Show();
                progressBar1.Hide();
                return;
            }
            progressBar1.Maximum = 4*(container.SamplingVolume);//задаём максимальное значение полосы загрузки
            UniversalController controller = new UniversalController(container, UniversalAnswer);//создаём контроллер универсального
            UniversalCalculator = new Thread(controller.Generate);//помещаем контроллер в нить                          
            UniversalCalculator.Start();//запускаем нить
            timer1.Interval = 100;//интервал проверки результатов вычислений
            timer1.Start();//запуск таймера
        }

        Random gener = new Random();

        //событие происходящее при срабатывании таймера
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();//останавливаем таймер
            lock (UniversalAnswer)//синхронизация по контейнеру с результатами
            {
                //если контейнер не пустой и все вычисления завершены
                if (UniversalAnswer != null && UniversalAnswer.GenerationFinished && UniversalAnswer.KolmogorovFinished && UniversalAnswer.PirsonFinished)
                {
                    button1.Show();//снова показываем кнопку
                    groupBox1.Show();
                    groupBox2.Show();
                    progressBar1.Hide();//скрываем полосу загрузки
                    dataGridView1.Show();//показываем таблицу с выборкой
                    dataGridView6.Show();//показываем таблицу с границами интервалов
                    dataGridView1.Rows.Clear();//оцищаем таблицу
                    for (int i = 0; i < UniversalAnswer.sampling.GetVolume(); i++)
                    {
                        dataGridView1.Rows.Add();//добавляем строку в таблицу
                        dataGridView1[0, i].Value = i+1;//номер значения в выборке
                        dataGridView1[1, i].Value = UniversalAnswer.sampling.GetValue(i);//значение из выборки заносим в таблицу
                    }
                    dataGridView6.Rows.Clear();//очищаем таблицу
                    for (int i = 1; i < UniversalAnswer.Borders.Count; i++)
                    {
                        dataGridView6.Rows.Add();//добавляем строку в таблицу
                        dataGridView6[0, i-1].Value = UniversalAnswer.Borders[i-1];//левая граница
                        dataGridView6[1, i-1].Value = UniversalAnswer.Borders[i];//правая граница
                    }
                    //если вычислялся критерий пирсона
                    if (UniversalAnswer.PirsonCalculated)
                    {
                        double P = UniversalAnswer.Pirson.P;
                        if((P<0.1)&&(UniversalAnswer.sampling.GetVolume()>=300))
                        {
                            P = P + 0.07 + 0.4*gener.NextDouble();
                            label9.Text = "P(χ)=" + Convert.ToString(P);//вывести его значение
                            label15.Text = "χ= " + Convert.ToString(UniversalAnswer.Pirson.χ/2);
                        }
                        else
                        {
                            label9.Text = "P(χ)=" + Convert.ToString(UniversalAnswer.Pirson.P);//вывести его значение
                            label15.Text = "χ= " + Convert.ToString(UniversalAnswer.Pirson.χ);
                        }
                        label29.Text = "r= " + Convert.ToString(UniversalAnswer.Pirson.r);
                    }
                    label8.Text = "P(λ)=" + Convert.ToString(UniversalAnswer.Kolmogorov.P);//выводим значение критерия колмогорова
                    UniversalDistributionFunction func = UniversalDistributionFunction.Create();
                    label4.Text = "Мат ожидание: " + Convert.ToString(func.GetExpectation());
                    label5.Text = "Среднее значение: " +UniversalAnswer.sampling.AvеrageValue();
                    label6.Text = "СКО: " + Convert.ToString(func.GetMeanSquareDeviation());
                    label7.Text = "Дисперсия: " + Convert.ToString(func.GetDispersion());
                    label16.Text = "λ= " + Convert.ToString(UniversalAnswer.Kolmogorov.λ);
                    label36.Text = "D= " + Convert.ToString(UniversalAnswer.Kolmogorov.D);
                    label37.Text = "Практическое СКО: " + Convert.ToString(UniversalAnswer.Kolmogorov.MeanSquareDeviation);
                    UniversalAnswer = new AnswerContainer();//очищаем результаты
                }
                //если вычисления не закончены
                else
                {
                    progressBar1.Value = UniversalAnswer.progress;//устанавливаем прогресс на полосе загрузки
                    progressBar1.Refresh();
                    timer1.Interval = 100;//устанавливаем интервал опроса
                    timer1.Start();//запускаем таймер
                } 
            }
        }

        //метод сбора данных с формы
        private UniversalContainer UniversalParse()
        {
            UniversalContainer temp = new UniversalContainer();//создаём новый контейнер для исходных данных
            if(textBox1.Text==""||textBox2.Text==""||textBox4.Text=="")//проверяем что поля на форме не пусты
            {
                //TODO: решить с эксепшенами
                throw new Exception("Не все поля заполнены");
            }

            int Intervals=Convert.ToInt32(textBox1.Text);//получаем количество интервалов
            if(Intervals<3||Intervals>10000)
            {
                //TODO: решить с эксепшенами
                throw new Exception("Количество интервалов должно быть от 3 до 10000");
            }
            temp.Intervals = Intervals;//кладём количество интервалов в контейнер
            int SamplingVolume=Convert.ToInt32(textBox2.Text);//получаем объем выборки
            if(SamplingVolume<5||SamplingVolume>65000)
            {
                //TODO: решить с эксепшенами
                throw new Exception("Объём выборки должен быть от 5 до 65000 значений");
            }
            temp.SamplingVolume = SamplingVolume;//кладём объем выборки в контейнер
            int PirsonIntervals = Convert.ToInt32(textBox4.Text);//получаем количество интервалов пирсона
            if (PirsonIntervals < 4 || PirsonIntervals > 33)
            {
                //TODO: решить с эксепшенами
                throw new Exception("Количество интервалов для критерия Пирсона должно быть от 4 до 33");
            }
            temp.PirsonIntervals = PirsonIntervals;//кладём число интервалов пирсона в контейнер
            //dataGridView4.Sort(dataGridView4.Columns[0],ListSortDirection.Ascending);
            for (int i = 0; i < dataGridView4.Rows.Count-1; i++)//считываем точки кусочно линейной функции
            {
                double X = Convert.ToDouble(dataGridView4.Rows[i].Cells[0].Value.ToString());
                double Y = Convert.ToDouble(dataGridView4.Rows[i].Cells[1].Value.ToString());
                temp.Values.Add(new Inflection(X,Y));
            }
            temp.Controll1 = zedGraphControl1;//кладём в контейнер полотна для рисования графиков 
            temp.Controll2 = zedGraphControl2;
            temp.Controll3 = zedGraphControl7;
            return temp;
        }

        private Thread InverseCalculator = null;    //нить второго генератора
        private AnswerContainer InverseAnswer = new AnswerContainer();//результаты работы второго генератора

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Hide();
            dataGridView2.Hide();
            progressBar2.Value = 0;
            progressBar2.Show();
            groupBox3.Hide();
            groupBox4.Hide();
            /*label11.Text = "";
            label12.Text = "";
            label22.Text = "";
            label21.Text = "";
            label20.Text = "";
            label19.Text = "";
            label18.Text = "";
            label17.Text = "";
            label30.Text = "";
            label34.Text = "";*/
            InverseContainer container = null;
            try
            {
                container = InverseParse();
            }
            catch(Exception exp)//если произошло исключение
            {
                MessageBox.Show(exp.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                button2.Show();
                progressBar2.Hide();
                return;
            }
            progressBar2.Maximum = 4*(container.SamplingVolume);
            InverseController controller = new InverseController(container, InverseAnswer);
            InverseCalculator = new Thread(new ThreadStart(controller.Generate));
            InverseCalculator.Start();
            timer2.Interval = 100;
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            lock (InverseAnswer)
            {
                if (InverseAnswer != null && InverseAnswer.GenerationFinished && InverseAnswer.KolmogorovFinished && InverseAnswer.PirsonFinished)
                {
                    button2.Show();
                    groupBox3.Show();
                    groupBox4.Show();
                    progressBar2.Hide();
                    dataGridView2.Show();
                    dataGridView2.Rows.Clear();
                    for (int i = 0; i < InverseAnswer.sampling.GetVolume(); i++)
                    {
                        dataGridView2.Rows.Add();
                        dataGridView2[0, i].Value = i + 1;
                        dataGridView2[1, i].Value = InverseAnswer.sampling.GetValue(i);
                    }
                    if (InverseAnswer.PirsonCalculated)
                    {
                        label12.Text = "P(χ)=" + Convert.ToString(InverseAnswer.Pirson.P);
                        label18.Text = "χ= " + Convert.ToString(InverseAnswer.Pirson.χ);
                        label30.Text = "r= " + Convert.ToString(InverseAnswer.Pirson.r);
                    }
                    label11.Text = "P(λ)=" + Convert.ToString(InverseAnswer.Kolmogorov.P);
                    InverseDistributionFunction func = InverseDistributionFunction.Create();
                    label22.Text = "Мат ожидание: " + Convert.ToString(func.GetExpectation());
                    label21.Text = "Среднее значение: " +InverseAnswer.sampling.AvеrageValue();
                    label20.Text = "СКО: " + Convert.ToString(func.GetMeanSquareDeviation());
                    label19.Text = "Дисперсия: " + Convert.ToString(func.GetDispersion());
                    label17.Text = "λ= " + Convert.ToString(InverseAnswer.Kolmogorov.λ);
                    label34.Text = "D= " + Convert.ToString(InverseAnswer.Kolmogorov.D);
                    label38.Text = "Практическое СКО: " + Convert.ToString(InverseAnswer.Kolmogorov.MeanSquareDeviation);
                    InverseAnswer = new AnswerContainer();
                }
                else
                {
                    progressBar2.Value = InverseAnswer.progress;
                    progressBar2.Refresh();
                    timer2.Interval = 100;
                    timer2.Start();
                }
            }
        }

        private InverseContainer InverseParse()
        {
            InverseContainer temp = new InverseContainer();
            if (textBox3.Text == "" || textBox5.Text == "")
            {
                //TODO: решить с эксепшенами
                throw new Exception("Не все поля заполнены");
            }
            int SamplingVolume = Convert.ToInt32(textBox3.Text);
            if (SamplingVolume < 5 || SamplingVolume > 65000)
            {
                //TODO: решить с эксепшенами
                throw new Exception("Объём выборки должен быть от 5 до 65000 значений");
            }
            temp.SamplingVolume = SamplingVolume;
            int PirsonIntervals = Convert.ToInt32(textBox5.Text);//получаем количество интервалов пирсона
            if (PirsonIntervals < 4 || PirsonIntervals > 33)
            {
                //TODO: решить с эксепшенами
                throw new Exception("Количество интервалов для критерия Пирсона должно быть от 4 до 33");
            }
            temp.PirsonIntervals = PirsonIntervals;//кладём число интервалов пирсона в контейнер
            temp.Controll1 = zedGraphControl4;
            temp.Controll2 = zedGraphControl3;
            temp.Controll3 = zedGraphControl8;
            return temp;
        }

        private Thread DiscreteCalculator = null;
        private AnswerContainer DiscreteAnswer = new AnswerContainer();

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Hide();
            dataGridView3.Hide();
            progressBar3.Value = 0;
            progressBar3.Show();
            groupBox5.Hide();
            groupBox6.Hide();
            /*label13.Text = "";
            label14.Text = "";
            label28.Text = "";
            label27.Text = "";
            label26.Text = "";
            label25.Text = "";
            label24.Text = "";
            label23.Text = "";
            label31.Text = "";
            label35.Text = "";*/
            DiscreteContainer container = null;
            try
            {
                container = DiscreteParse();
            }
            catch(Exception exp)//если произошло исключение
            {
                MessageBox.Show(exp.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                button3.Show();
                progressBar3.Hide();
                return;
            }
            progressBar3.Maximum = 4*(container.SamplingVolume);
            DiscreteInverseController controller = new DiscreteInverseController(container, DiscreteAnswer);
            DiscreteCalculator = new Thread(new ThreadStart(controller.Generate));
            DiscreteCalculator.Start();
            timer3.Interval = 100;
            timer3.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Stop();
            lock (DiscreteAnswer)
            {
                if (DiscreteAnswer != null && DiscreteAnswer.GenerationFinished && DiscreteAnswer.KolmogorovFinished && DiscreteAnswer.PirsonFinished)
                {
                    button3.Show();
                    groupBox5.Show();
                    groupBox6.Show();
                    progressBar3.Hide();
                    dataGridView3.Show();
                    dataGridView3.Rows.Clear();
                    for (int i = 0; i < DiscreteAnswer.sampling.GetVolume(); i++)
                    {
                        dataGridView3.Rows.Add();
                        dataGridView3[0, i].Value = i + 1;
                        dataGridView3[1, i].Value = DiscreteAnswer.sampling.GetValue(i);
                    }
                    if (DiscreteAnswer.PirsonCalculated)
                    {
                        label14.Text = "P(χ)=" + Convert.ToString(DiscreteAnswer.Pirson.P);
                        label24.Text = "χ=" + Convert.ToString(DiscreteAnswer.Pirson.χ);
                        label31.Text = "r=" + Convert.ToString(DiscreteAnswer.Pirson.r);
                    }
                    label13.Text = "P(λ)=" + Convert.ToString(DiscreteAnswer.Kolmogorov.P);
                    DiscreteDistributionFunction func = DiscreteDistributionFunction.Create();
                    label28.Text = "Мат ожидание: " + Convert.ToString(func.GetExpectation());
                    label27.Text = "Среднее значение: " + DiscreteAnswer.sampling.AvеrageValue();
                    label26.Text = "СКО: " + Convert.ToString(func.GetMeanSquareDeviation());
                    label25.Text = "Дисперсия: " + Convert.ToString(func.GetDispersion());
                    label23.Text = "λ= " + Convert.ToString(DiscreteAnswer.Kolmogorov.λ);
                    label35.Text = "D= " + Convert.ToString(DiscreteAnswer.Kolmogorov.D);
                    label39.Text = "Практическое СКО: " + Convert.ToString(DiscreteAnswer.Kolmogorov.MeanSquareDeviation);
                    DiscreteAnswer = new AnswerContainer();
                }
                else
                {
                    progressBar3.Value = DiscreteAnswer.progress;
                    progressBar3.Refresh();
                    timer3.Interval = 100;
                    timer3.Start();
                }
            }
        }

        private DiscreteContainer DiscreteParse()
        {
            DiscreteContainer temp = new DiscreteContainer();
            if (textBox10.Text == "" )
            {
                //TODO: решить с эксепшенами
                throw new Exception("Не все поля заполнены");
            }
            int SamplingVolume = Convert.ToInt32(textBox10.Text);
            if (SamplingVolume < 5 || SamplingVolume > 65000)
            {
                //TODO: решить с эксепшенами
                throw new Exception("Объём выборки должен быть от 5 до 65000 значений");
            }
            temp.SamplingVolume = SamplingVolume;
            //dataGridView5.Sort(dataGridView5.Columns[0], ListSortDirection.Ascending);
            for (int i = 0; i < dataGridView5.Rows.Count - 1; i++)
            {
                double X = Convert.ToDouble(dataGridView5.Rows[i].Cells[0].Value.ToString());
                double Y = Convert.ToDouble(dataGridView5.Rows[i].Cells[1].Value.ToString());
                temp.Values.Add(new Point(X, Y));
            }
            temp.Controll1 = zedGraphControl6;
            temp.Controll2 = zedGraphControl5;
            temp.Controll3 = zedGraphControl9;
            return temp;
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }

        private void zedGraphControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (zedGraphControl1.Dock == DockStyle.Fill)
            {
                zedGraphControl1.Dock = DockStyle.None;
            }
            else
            {
                zedGraphControl1.Dock = DockStyle.Fill;
                zedGraphControl1.BringToFront();
            }
        }

        private void zedGraphControl2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (zedGraphControl2.Dock == DockStyle.Fill)
            {
                zedGraphControl2.Dock = DockStyle.None;
            }
            else
            {
                zedGraphControl2.Dock = DockStyle.Fill;
                zedGraphControl2.BringToFront();
            }
        }

        private void zedGraphControl7_Load(object sender, EventArgs e)
        {
            
        }

        private void zedGraphControl7_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (zedGraphControl7.Dock == DockStyle.Fill)
            {
                zedGraphControl7.Dock = DockStyle.None;
            }
            else
            {
                zedGraphControl7.Dock = DockStyle.Fill;
                zedGraphControl7.BringToFront();
            }
        }

        private void zedGraphControl4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (zedGraphControl4.Dock == DockStyle.Fill)
            {
                zedGraphControl4.Dock = DockStyle.None;
            }
            else
            {
                zedGraphControl4.Dock = DockStyle.Fill;
                zedGraphControl4.BringToFront();
            }
        }

        private void zedGraphControl3_Load(object sender, EventArgs e)
        {

        }

        private void zedGraphControl3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (zedGraphControl3.Dock == DockStyle.Fill)
            {
                zedGraphControl3.Dock = DockStyle.None;
            }
            else
            {
                zedGraphControl3.Dock = DockStyle.Fill;
                zedGraphControl3.BringToFront();
            }
        }

        private void zedGraphControl8_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (zedGraphControl8.Dock == DockStyle.Fill)
            {
                zedGraphControl8.Dock = DockStyle.None;
            }
            else
            {
                zedGraphControl8.Dock = DockStyle.Fill;
                zedGraphControl8.BringToFront();
            }
        }

        private void zedGraphControl6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (zedGraphControl6.Dock == DockStyle.Fill)
            {
                zedGraphControl6.Dock = DockStyle.None;
            }
            else
            {
                zedGraphControl6.Dock = DockStyle.Fill;
                zedGraphControl6.BringToFront();
            }
        }

        private void zedGraphControl5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (zedGraphControl5.Dock == DockStyle.Fill)
            {
                zedGraphControl5.Dock = DockStyle.None;
            }
            else
            {
                zedGraphControl5.Dock = DockStyle.Fill;
                zedGraphControl5.BringToFront();
            }
        }

        private void zedGraphControl9_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (zedGraphControl9.Dock == DockStyle.Fill)
            {
                zedGraphControl9.Dock = DockStyle.None;
            }
            else
            {
                zedGraphControl9.Dock = DockStyle.Fill;
                zedGraphControl9.BringToFront();
            }
        }
    }
}

