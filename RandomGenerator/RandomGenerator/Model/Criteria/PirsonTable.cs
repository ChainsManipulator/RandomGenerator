using System;
using System.Collections.Generic;
using System.Text;

namespace RandomGenerator.Model.Criteria
{
    //таблица для критерия пирсона
    public class PirsonTable
    {
        private List<Point> r1 = new List<Point>();
        private List<Point> r2 = new List<Point>();
        private List<Point> r3 = new List<Point>();
        private List<Point> r4 = new List<Point>();
        private List<Point> r5 = new List<Point>();
        private List<Point> r6 = new List<Point>();
        private List<Point> r7 = new List<Point>();
        private List<Point> r8 = new List<Point>();
        private List<Point> r9 = new List<Point>();
        private List<Point> r10 = new List<Point>();
        private List<Point> r11 = new List<Point>();
        private List<Point> r12 = new List<Point>();
        private List<Point> r13 = new List<Point>();
        private List<Point> r14 = new List<Point>();
        private List<Point> r15 = new List<Point>();
        private List<Point> r16 = new List<Point>();
        private List<Point> r17 = new List<Point>();
        private List<Point> r18 = new List<Point>();
        private List<Point> r19 = new List<Point>();
        private List<Point> r20 = new List<Point>();
        private List<Point> r21 = new List<Point>();
        private List<Point> r22 = new List<Point>();
        private List<Point> r23 = new List<Point>();
        private List<Point> r24 = new List<Point>();
        private List<Point> r25 = new List<Point>();
        private List<Point> r26 = new List<Point>();
        private List<Point> r27 = new List<Point>();
        private List<Point> r28 = new List<Point>();
        private List<Point> r29 = new List<Point>();
        private List<Point> r30 = new List<Point>();

        public PirsonTable()
        {
            r1.Add(new Point(0.00, 0.99));//Хи,вероятность
            r1.Add(new Point(0.001, 0.98));
            r1.Add(new Point(0.004, 0.95));
            r1.Add(new Point(0.016, 0.90));
            r1.Add(new Point(0.064, 0.80));
            r1.Add(new Point(0.148, 0.70));
            r1.Add(new Point(0.455, 0.50));
            r1.Add(new Point(1.074, 0.30));
            r1.Add(new Point(1.642, 0.20));
            r1.Add(new Point(2.71, 0.10));
            r1.Add(new Point(3.84, 0.05));
            r1.Add(new Point(5.41, 0.02));
            r1.Add(new Point(6.64, 0.01));
            r1.Add(new Point(10.83, 0.001));

            r2.Add(new Point(0.02, 0.99));//Хи,вероятность
            r2.Add(new Point(0.04, 0.98));
            r2.Add(new Point(0.103, 0.95));
            r2.Add(new Point(0.211, 0.90));
            r2.Add(new Point(0.446, 0.80));
            r2.Add(new Point(0.713, 0.70));
            r2.Add(new Point(1.386, 0.50));
            r2.Add(new Point(2.41, 0.30));
            r2.Add(new Point(3.22, 0.20));
            r2.Add(new Point(4.6, 0.10));
            r2.Add(new Point(5.99, 0.05));
            r2.Add(new Point(7.82, 0.02));
            r2.Add(new Point(9.21, 0.01));
            r2.Add(new Point(13.82, 0.001));

            r3.Add(new Point(0.115, 0.99));//Хи,вероятность
            r3.Add(new Point(0.185, 0.98));
            r3.Add(new Point(0.352, 0.95));
            r3.Add(new Point(0.584, 0.90));
            r3.Add(new Point(1.005, 0.80));
            r3.Add(new Point(1.424, 0.70));
            r3.Add(new Point(2.37, 0.50));
            r3.Add(new Point(3.66, 0.30));
            r3.Add(new Point(4.64, 0.20));
            r3.Add(new Point(6.25, 0.10));
            r3.Add(new Point(7.82, 0.05));
            r3.Add(new Point(9.84, 0.02));
            r3.Add(new Point(11.34, 0.01));
            r3.Add(new Point(16.27, 0.001));

            r4.Add(new Point(0.297, 0.99));//Хи,вероятность
            r4.Add(new Point(0.429, 0.98));
            r4.Add(new Point(0.711, 0.95));
            r4.Add(new Point(1.064, 0.90));
            r4.Add(new Point(1.649, 0.80));
            r4.Add(new Point(2.20, 0.70));
            r4.Add(new Point(3.36, 0.50));
            r4.Add(new Point(4.88, 0.30));
            r4.Add(new Point(5.99, 0.20));
            r4.Add(new Point(7.78, 0.10));
            r4.Add(new Point(9.49, 0.05));
            r4.Add(new Point(11.67, 0.02));
            r4.Add(new Point(13.28, 0.01));
            r4.Add(new Point(18.46, 0.001));

            r5.Add(new Point(0.554, 0.99));//Хи,вероятность
            r5.Add(new Point(0.752, 0.98));
            r5.Add(new Point(1.145, 0.95));
            r5.Add(new Point(1.610, 0.90));
            r5.Add(new Point(2.34, 0.80));
            r5.Add(new Point(3.00, 0.70));
            r5.Add(new Point(4.35, 0.50));
            r5.Add(new Point(6.06, 0.30));
            r5.Add(new Point(7.29, 0.20));
            r5.Add(new Point(9.24, 0.10));
            r5.Add(new Point(11.07, 0.05));
            r5.Add(new Point(13.39, 0.02));
            r5.Add(new Point(15.09, 0.01));
            r5.Add(new Point(20.5, 0.001));

            r6.Add(new Point(0.872, 0.99));//Хи,вероятность
            r6.Add(new Point(1.134, 0.98));
            r6.Add(new Point(1.635, 0.95));
            r6.Add(new Point(2.2, 0.90));
            r6.Add(new Point(3.07, 0.80));
            r6.Add(new Point(3.83, 0.70));
            r6.Add(new Point(5.35, 0.50));
            r6.Add(new Point(7.23, 0.30));
            r6.Add(new Point(8.56, 0.20));
            r6.Add(new Point(10.64, 0.10));
            r6.Add(new Point(12.59, 0.05));
            r6.Add(new Point(15.03, 0.02));
            r6.Add(new Point(16.81, 0.01));
            r6.Add(new Point(22.5, 0.001));

            r7.Add(new Point(1.239, 0.99));//Хи,вероятность
            r7.Add(new Point(1.564, 0.98));
            r7.Add(new Point(2.17, 0.95));
            r7.Add(new Point(2.83, 0.90));
            r7.Add(new Point(3.82, 0.80));
            r7.Add(new Point(4.67, 0.70));
            r7.Add(new Point(6.35, 0.50));
            r7.Add(new Point(8.38, 0.30));
            r7.Add(new Point(9.8, 0.20));
            r7.Add(new Point(12.02, 0.10));
            r7.Add(new Point(14.07, 0.05));
            r7.Add(new Point(16.62, 0.02));
            r7.Add(new Point(18.48, 0.01));
            r7.Add(new Point(24.3, 0.001));

            r8.Add(new Point(1.646, 0.99));//Хи,вероятность
            r8.Add(new Point(2.03, 0.98));
            r8.Add(new Point(2.73, 0.95));
            r8.Add(new Point(3.49, 0.90));
            r8.Add(new Point(4.59, 0.80));
            r8.Add(new Point(5.53, 0.70));
            r8.Add(new Point(7.34, 0.50));
            r8.Add(new Point(9.52, 0.30));
            r8.Add(new Point(11.03, 0.20));
            r8.Add(new Point(13.36, 0.10));
            r8.Add(new Point(15.51, 0.05));
            r8.Add(new Point(18.17, 0.02));
            r8.Add(new Point(20.1, 0.01));
            r8.Add(new Point(26.1, 0.001));

            r9.Add(new Point(2.09, 0.99));//Хи,вероятность
            r9.Add(new Point(2.53, 0.98));
            r9.Add(new Point(3.32, 0.95));
            r9.Add(new Point(4.17, 0.90));
            r9.Add(new Point(5.38, 0.80));
            r9.Add(new Point(6.39, 0.70));
            r9.Add(new Point(8.34, 0.50));
            r9.Add(new Point(10.66, 0.30));
            r9.Add(new Point(12.24, 0.20));
            r9.Add(new Point(14.68, 0.10));
            r9.Add(new Point(16.92, 0.05));
            r9.Add(new Point(19.68, 0.02));
            r9.Add(new Point(21.7, 0.01));
            r9.Add(new Point(27.9, 0.001));

            r10.Add(new Point(2.56, 0.99));//Хи,вероятность
            r10.Add(new Point(3.06, 0.98));
            r10.Add(new Point(3.94, 0.95));
            r10.Add(new Point(4.86, 0.90));
            r10.Add(new Point(6.18, 0.80));
            r10.Add(new Point(7.27, 0.70));
            r10.Add(new Point(9.34, 0.50));
            r10.Add(new Point(11.78, 0.30));
            r10.Add(new Point(13.44, 0.20));
            r10.Add(new Point(15.99, 0.10));
            r10.Add(new Point(18.31, 0.05));
            r10.Add(new Point(21.2, 0.02));
            r10.Add(new Point(23.2, 0.01));
            r10.Add(new Point(29.6, 0.001));

            r11.Add(new Point(3.06, 0.99));//Хи,вероятность
            r11.Add(new Point(3.61, 0.98));
            r11.Add(new Point(4.58, 0.95));
            r11.Add(new Point(5.58, 0.90));
            r11.Add(new Point(6.99, 0.80));
            r11.Add(new Point(8.15, 0.70));
            r11.Add(new Point(10.34, 0.50));
            r11.Add(new Point(12.90, 0.30));
            r11.Add(new Point(14.63, 0.20));
            r11.Add(new Point(17.28, 0.10));
            r11.Add(new Point(19.68, 0.05));
            r11.Add(new Point(22.6, 0.02));
            r11.Add(new Point(24.7, 0.01));
            r11.Add(new Point(31.3, 0.001));

            r12.Add(new Point(3.57, 0.99));//Хи,вероятность
            r12.Add(new Point(4.18, 0.98));
            r12.Add(new Point(5.23, 0.95));
            r12.Add(new Point(6.3, 0.90));
            r12.Add(new Point(7.81, 0.80));
            r12.Add(new Point(9.03, 0.70));
            r12.Add(new Point(11.34, 0.50));
            r12.Add(new Point(14.01, 0.30));
            r12.Add(new Point(15.81, 0.20));
            r12.Add(new Point(18.55, 0.10));
            r12.Add(new Point(21.0, 0.05));
            r12.Add(new Point(24.1, 0.02));
            r12.Add(new Point(26.2, 0.01));
            r12.Add(new Point(32.9, 0.001));

            r13.Add(new Point(4.11, 0.99));//Хи,вероятность
            r13.Add(new Point(4.76, 0.98));
            r13.Add(new Point(5.89, 0.95));
            r13.Add(new Point(7.04, 0.90));
            r13.Add(new Point(8.63, 0.80));
            r13.Add(new Point(9.93, 0.70));
            r13.Add(new Point(12.34, 0.50));
            r13.Add(new Point(15.12, 0.30));
            r13.Add(new Point(16.98, 0.20));
            r13.Add(new Point(19.81, 0.10));
            r13.Add(new Point(22.4, 0.05));
            r13.Add(new Point(25.5, 0.02));
            r13.Add(new Point(27.7, 0.01));
            r13.Add(new Point(34.6, 0.001));

            r14.Add(new Point(4.66, 0.99));//Хи,вероятность
            r14.Add(new Point(5.37, 0.98));
            r14.Add(new Point(6.57, 0.95));
            r14.Add(new Point(7.79, 0.90));
            r14.Add(new Point(9.47, 0.80));
            r14.Add(new Point(10.82, 0.70));
            r14.Add(new Point(13.34, 0.50));
            r14.Add(new Point(16.22, 0.30));
            r14.Add(new Point(18.15, 0.20));
            r14.Add(new Point(21.1, 0.10));
            r14.Add(new Point(23.7, 0.05));
            r14.Add(new Point(26.9, 0.02));
            r14.Add(new Point(29.1, 0.01));
            r14.Add(new Point(36.1, 0.001));

            r15.Add(new Point(5.23, 0.99));//Хи,вероятность
            r15.Add(new Point(5.98, 0.98));
            r15.Add(new Point(7.26, 0.95));
            r15.Add(new Point(8.55, 0.90));
            r15.Add(new Point(10.31, 0.80));
            r15.Add(new Point(11.72, 0.70));
            r15.Add(new Point(14.34, 0.50));
            r15.Add(new Point(17.32, 0.30));
            r15.Add(new Point(19.31, 0.20));
            r15.Add(new Point(22.3, 0.10));
            r15.Add(new Point(25.0, 0.05));
            r15.Add(new Point(28.3, 0.02));
            r15.Add(new Point(30.6, 0.01));
            r15.Add(new Point(37.7, 0.001));

            r16.Add(new Point(5.81, 0.99));//Хи,вероятность
            r16.Add(new Point(6.61, 0.98));
            r16.Add(new Point(7.96, 0.95));
            r16.Add(new Point(9.31, 0.90));
            r16.Add(new Point(11.15, 0.80));
            r16.Add(new Point(12.62, 0.70));
            r16.Add(new Point(15.34, 0.50));
            r16.Add(new Point(18.42, 0.30));
            r16.Add(new Point(20.5, 0.20));
            r16.Add(new Point(23.5, 0.10));
            r16.Add(new Point(26.3, 0.05));
            r16.Add(new Point(29.6, 0.02));
            r16.Add(new Point(32.0, 0.01));
            r16.Add(new Point(39.3, 0.001));

            r17.Add(new Point(6.41, 0.99));//Хи,вероятность
            r17.Add(new Point(7.26, 0.98));
            r17.Add(new Point(8.67, 0.95));
            r17.Add(new Point(10.08, 0.90));
            r17.Add(new Point(12.00, 0.80));
            r17.Add(new Point(13.53, 0.70));
            r17.Add(new Point(16.34, 0.50));
            r17.Add(new Point(19.51, 0.30));
            r17.Add(new Point(21.6, 0.20));
            r17.Add(new Point(24.8, 0.10));
            r17.Add(new Point(27.6, 0.05));
            r17.Add(new Point(31.0, 0.02));
            r17.Add(new Point(33.4, 0.01));
            r17.Add(new Point(40.8, 0.001));

            r18.Add(new Point(7.02, 0.99));//Хи,вероятность
            r18.Add(new Point(7.91, 0.98));
            r18.Add(new Point(9.39, 0.95));
            r18.Add(new Point(10.86, 0.90));
            r18.Add(new Point(12.86, 0.80));
            r18.Add(new Point(14.44, 0.70));
            r18.Add(new Point(17.34, 0.50));
            r18.Add(new Point(20.6, 0.30));
            r18.Add(new Point(22.8, 0.20));
            r18.Add(new Point(26.0, 0.10));
            r18.Add(new Point(28.9, 0.05));
            r18.Add(new Point(32.3, 0.02));
            r18.Add(new Point(34.8, 0.01));
            r18.Add(new Point(42.3, 0.001));

            r19.Add(new Point(7.63, 0.99));//Хи,вероятность
            r19.Add(new Point(8.57, 0.98));
            r19.Add(new Point(10.11, 0.95));
            r19.Add(new Point(11.65, 0.90));
            r19.Add(new Point(13.72, 0.80));
            r19.Add(new Point(15.35, 0.70));
            r19.Add(new Point(18.34, 0.50));
            r19.Add(new Point(21.7, 0.30));
            r19.Add(new Point(23.9, 0.20));
            r19.Add(new Point(27.2, 0.10));
            r19.Add(new Point(30.1, 0.05));
            r19.Add(new Point(33.7, 0.02));
            r19.Add(new Point(36.2, 0.01));
            r19.Add(new Point(43.8, 0.001));

            r20.Add(new Point(8.26, 0.99));//Хи,вероятность
            r20.Add(new Point(9.24, 0.98));
            r20.Add(new Point(10.85, 0.95));
            r20.Add(new Point(12.44, 0.90));
            r20.Add(new Point(14.58, 0.80));
            r20.Add(new Point(16.27, 0.70));
            r20.Add(new Point(19.34, 0.50));
            r20.Add(new Point(22.8, 0.30));
            r20.Add(new Point(25.0, 0.20));
            r20.Add(new Point(28.4, 0.10));
            r20.Add(new Point(31.4, 0.05));
            r20.Add(new Point(35.0, 0.02));
            r20.Add(new Point(37.6, 0.01));
            r20.Add(new Point(45.3, 0.001));

            r21.Add(new Point(8.90, 0.99));//Хи,вероятность
            r21.Add(new Point(9.92, 0.98));
            r21.Add(new Point(11.59, 0.95));
            r21.Add(new Point(13.24, 0.90));
            r21.Add(new Point(15.44, 0.80));
            r21.Add(new Point(17.18, 0.70));
            r21.Add(new Point(20.3, 0.50));
            r21.Add(new Point(23.9, 0.30));
            r21.Add(new Point(26.2, 0.20));
            r21.Add(new Point(29.6, 0.10));
            r21.Add(new Point(32.7, 0.05));
            r21.Add(new Point(36.3, 0.02));
            r21.Add(new Point(38.9, 0.01));
            r21.Add(new Point(46.8, 0.001));

            r22.Add(new Point(9.54, 0.99));//Хи,вероятность
            r22.Add(new Point(10.6, 0.98));
            r22.Add(new Point(12.34, 0.95));
            r22.Add(new Point(14.04, 0.90));
            r22.Add(new Point(16.31, 0.80));
            r22.Add(new Point(18.10, 0.70));
            r22.Add(new Point(21.3, 0.50));
            r22.Add(new Point(24.9, 0.30));
            r22.Add(new Point(27.3, 0.20));
            r22.Add(new Point(30.8, 0.10));
            r22.Add(new Point(33.9, 0.05));
            r22.Add(new Point(37.7, 0.02));
            r22.Add(new Point(40.3, 0.01));
            r22.Add(new Point(48.3, 0.001));

            r23.Add(new Point(10.2, 0.99));//Хи,вероятность
            r23.Add(new Point(11.29, 0.98));
            r23.Add(new Point(13.09, 0.95));
            r23.Add(new Point(14.85, 0.90));
            r23.Add(new Point(17.19, 0.80));
            r23.Add(new Point(19.02, 0.70));
            r23.Add(new Point(22.3, 0.50));
            r23.Add(new Point(26.0, 0.30));
            r23.Add(new Point(28.4, 0.20));
            r23.Add(new Point(32.0, 0.10));
            r23.Add(new Point(35.2, 0.05));
            r23.Add(new Point(39.0, 0.02));
            r23.Add(new Point(41.6, 0.01));
            r23.Add(new Point(49.7, 0.001));

            r24.Add(new Point(10.86, 0.99));//Хи,вероятность
            r24.Add(new Point(11.99, 0.98));
            r24.Add(new Point(13.85, 0.95));
            r24.Add(new Point(15.66, 0.90));
            r24.Add(new Point(18.06, 0.80));
            r24.Add(new Point(19.94, 0.70));
            r24.Add(new Point(23.3, 0.50));
            r24.Add(new Point(27.1, 0.30));
            r24.Add(new Point(29.6, 0.20));
            r24.Add(new Point(33.2, 0.10));
            r24.Add(new Point(36.4, 0.05));
            r24.Add(new Point(40.3, 0.02));
            r24.Add(new Point(43.0, 0.01));
            r24.Add(new Point(51.2, 0.001));

            r25.Add(new Point(11.52, 0.99));//Хи,вероятность
            r25.Add(new Point(12.70, 0.98));
            r25.Add(new Point(14.61, 0.95));
            r25.Add(new Point(16.47, 0.90));
            r25.Add(new Point(18.94, 0.80));
            r25.Add(new Point(20.9, 0.70));
            r25.Add(new Point(24.3, 0.50));
            r25.Add(new Point(28.2, 0.30));
            r25.Add(new Point(30.7, 0.20));
            r25.Add(new Point(34.2, 0.10));
            r25.Add(new Point(37.7, 0.05));
            r25.Add(new Point(41.7, 0.02));
            r25.Add(new Point(44.3, 0.01));
            r25.Add(new Point(52.6, 0.001));


            r26.Add(new Point(12.2, 0.99));//Хи,вероятность
            r26.Add(new Point(13.41, 0.98));
            r26.Add(new Point(15.38, 0.95));
            r26.Add(new Point(17.29, 0.90));
            r26.Add(new Point(19.82, 0.80));
            r26.Add(new Point(21.8, 0.70));
            r26.Add(new Point(25.3, 0.50));
            r26.Add(new Point(29.2, 0.30));
            r26.Add(new Point(31.8, 0.20));
            r26.Add(new Point(35.6, 0.10));
            r26.Add(new Point(38.9, 0.05));
            r26.Add(new Point(42.9, 0.02));
            r26.Add(new Point(45.6, 0.01));
            r26.Add(new Point(54.1, 0.001));

            r27.Add(new Point(12.88, 0.99));//Хи,вероятность
            r27.Add(new Point(14.12, 0.98));
            r27.Add(new Point(16.15, 0.95));
            r27.Add(new Point(18.11, 0.90));
            r27.Add(new Point(20.7, 0.80));
            r27.Add(new Point(22.7, 0.70));
            r27.Add(new Point(26.3, 0.50));
            r27.Add(new Point(30.3, 0.30));
            r27.Add(new Point(32.9, 0.20));
            r27.Add(new Point(36.7, 0.10));
            r27.Add(new Point(40.1, 0.05));
            r27.Add(new Point(44.1, 0.02));
            r27.Add(new Point(47.0, 0.01));
            r27.Add(new Point(55.5, 0.001));

            r28.Add(new Point(13.56, 0.99));//Хи,вероятность
            r28.Add(new Point(14.85, 0.98));
            r28.Add(new Point(16.93, 0.95));
            r28.Add(new Point(18.94, 0.90));
            r28.Add(new Point(21.6, 0.80));
            r28.Add(new Point(23.6, 0.70));
            r28.Add(new Point(27.3, 0.50));
            r28.Add(new Point(31.4, 0.30));
            r28.Add(new Point(34.0, 0.20));
            r28.Add(new Point(37.9, 0.10));
            r28.Add(new Point(41.3, 0.05));
            r28.Add(new Point(45.4, 0.02));
            r28.Add(new Point(48.3, 0.01));
            r28.Add(new Point(56.9, 0.001));

            r29.Add(new Point(14.26, 0.99));//Хи,вероятность
            r29.Add(new Point(15.57, 0.98));
            r29.Add(new Point(17.71, 0.95));
            r29.Add(new Point(19.77, 0.90));
            r29.Add(new Point(22.5, 0.80));
            r29.Add(new Point(24.6, 0.70));
            r29.Add(new Point(28.3, 0.50));
            r29.Add(new Point(32.5, 0.30));
            r29.Add(new Point(35.1, 0.20));
            r29.Add(new Point(39.1, 0.10));
            r29.Add(new Point(42.6, 0.05));
            r29.Add(new Point(46.7, 0.02));
            r29.Add(new Point(49.6, 0.01));
            r29.Add(new Point(58.3, 0.001));

            r30.Add(new Point(14.95, 0.99));//Хи,вероятность
            r30.Add(new Point(16.31, 0.98));
            r30.Add(new Point(18.49, 0.95));
            r30.Add(new Point(20.6, 0.90));
            r30.Add(new Point(23.4, 0.80));
            r30.Add(new Point(25.5, 0.70));
            r30.Add(new Point(29.3, 0.50));
            r30.Add(new Point(33.5, 0.30));
            r30.Add(new Point(36.2, 0.20));
            r30.Add(new Point(40.3, 0.10));
            r30.Add(new Point(43.8, 0.05));
            r30.Add(new Point(48.0, 0.02));
            r30.Add(new Point(50.9, 0.01));
            r30.Add(new Point(59.7, 0.001));
        }

        //возвращает табличное значение по Хи и числу степеней свободы
        public double GetP(double χ, int r)
        {
            List<Point> table = null;//находим нужную строку таблицы 
            switch (r)
            {
                case 1:
                    table = r1;
                    break;
                case 2:
                    table = r2;
                    break;
                case 3:
                    table = r3;
                    break;
                case 4:
                    table = r4;
                    break;
                case 5:
                    table = r5;
                    break;
                case 6:
                    table = r6;
                    break;
                case 7:
                    table = r7;
                    break;
                case 8:
                    table = r8;
                    break;
                case 9:
                    table = r9;
                    break;
                case 10:
                    table = r10;
                    break;
                case 11:
                    table = r11;
                    break;
                case 12:
                    table = r12;
                    break;
                case 13:
                    table = r13;
                    break;
                case 14:
                    table = r15;
                    break;
                case 15:
                    table = r15;
                    break;
                case 16:
                    table = r16;
                    break;
                case 17:
                    table = r17;
                    break;
                case 18:
                    table = r18;
                    break;
                case 19:
                    table = r19;
                    break;
                case 20:
                    table = r20;
                    break;
                case 21:
                    table = r21;
                    break;
                case 22:
                    table = r22;
                    break;
                case 23:
                    table = r23;
                    break;
                case 24:
                    table = r24;
                    break;
                case 25:
                    table = r25;
                    break;
                case 26:
                    table = r26;
                    break;
                case 27:
                    table = r27;
                    break;
                case 28:
                    table = r28;
                    break;
                case 29:
                    table = r29;
                    break;
                case 30:
                    table = r30;
                    break;
                default:
                    throw new Exception("Подходящее значение r в таблице не найдено");
            }
            double P = 0;
            if (χ > table[table.Count - 1].GetX)
            {
                return 0;//если хи слишком большое
            }
            for (int i = 0; i < table.Count - 1; i++)
            {
                if ((χ >= table[i].GetX) && (χ <= table[i + 1].GetX))//ищем два ближайших значения по Хи
                {
                    //линейно экстраполируем до искомого значения
                    P = table[i].GetP + (χ - table[i].GetX) * (table[i + 1].GetP - table[i].GetP) / (table[i + 1].GetX - table[i].GetX);
                    break;
                }
            }
            return P;
        }
    }
}
