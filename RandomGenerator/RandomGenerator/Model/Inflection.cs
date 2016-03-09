namespace RandomGenerator.Model 
{
    using System;

    /// <summary>
    /// точка перегиба
    /// </summary>
    public class Inflection 
    {
        private double X;
        private double Y;

        //конструктор
        public Inflection(double val, double prob) 
        {
            if(Y<0)
            {
                throw new Exception("Y должен быть быть больше 0");
            }
            X = val;
            Y = prob;
        }

        public double GetY
        {
            get
            {
                return Y;
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
