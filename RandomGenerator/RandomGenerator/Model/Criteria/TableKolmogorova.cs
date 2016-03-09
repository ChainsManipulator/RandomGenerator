namespace RandomGenerator.Model.Criteria
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// таблица для критерия колмогорова
    /// </summary>
    public class TableKolmogorova
    {
        private List<Point> Table = new List<Point>();

        //конструктор
        public TableKolmogorova()
        {
            Table.Add(new Point(0.0, 1.000));//лямда,вероятность
            Table.Add(new Point(0.1, 1.000));
            Table.Add(new Point(0.2, 1.000));
            Table.Add(new Point(0.3, 1.000));
            Table.Add(new Point(0.4, 0.997));
            Table.Add(new Point(0.5, 0.964));
            Table.Add(new Point(0.6, 0.864));
            Table.Add(new Point(0.7, 0.711));
            Table.Add(new Point(0.8, 0.544));
            Table.Add(new Point(0.9, 0.393));
            Table.Add(new Point(1.0, 0.270));
            Table.Add(new Point(1.1, 0.178));
            Table.Add(new Point(1.2, 0.112));
            Table.Add(new Point(1.3, 0.068));
            Table.Add(new Point(1.4, 0.04));
            Table.Add(new Point(1.5, 0.022));
            Table.Add(new Point(1.6, 0.012));
            Table.Add(new Point(1.7, 0.006));
            Table.Add(new Point(1.8, 0.003));
            Table.Add(new Point(1.9, 0.002));
            Table.Add(new Point(2.0, 0.001));
        }

        public double GetP(double λ)
        {
            if (λ > 2)//если λ слишком большая
            {
                return 0;
            }
            for (int i = 0; i < Table.Count - 1; i++)//поиск значения в таблице
            {
                if ((λ >= Table[i].GetX) && (λ <= Table[i + 1].GetX))
                {
                    return Table[i].GetP + (λ - Table[i].GetX) * (Table[i + 1].GetP - Table[i].GetP) / (Table[i + 1].GetX - Table[i].GetX);
                }
            }
            throw new Exception("Значение не найдено\n");
        }
    }
}
