namespace RandomGenerator.Model
{
    using System;

    /// <summary>
    /// точка дискретной СВ
    /// </summary>
    public class Point
    {
        private double X;
        private double P;

        //конструктор
        public Point(double val,double prob)
        {
            prob = Math.Floor(prob * 10000000000000) / 10000000000000;//округление вероятности
            if(prob>1||prob<0)
            {
                throw new Exception("Вероятность должна быть от 0 до 1");
            }
            X = val;
            P = prob;
        }

        public double GetP
        {
            get
            {
                return P;
            }
        }

        public double GetX
        {
            get
            {
                return X;
            }
        }
    }
}
