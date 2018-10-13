using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace LukaszAlgo1
{
    class Obliczenia
    {
        public double Silnia(double x)
        {
            double silnia = 1.0;
            for (double i = 1.0; i <= x; i++)
            {
                silnia *= i;
            }
            return silnia;
        }

        public double PotegaInt(int x, int n)
        {
            double wynik = 1;

            for (int i = 0; i < n; i++)
            {
                wynik *= x ;
            }

            return wynik;
        }

        public double PotegaDouble(double x, int n)
        {
            double wynik = 1.0;

            for (int i = 0; i < n; i++)
            {
                wynik *= x;
            }

            return wynik;
        }

        public double FunkcjaWbudowana(double x)
        {
            return Math.Sin(x) * Math.Atan(x);
        }

        public double SumowanieSinus(double x, int k)
        {
            return PotegaInt(-1, k) * PotegaDouble(x, 2 * k + 1) / Silnia(2 * k + 1);
        }

        public double SumowanieArcTg(double x, int k)
        {
            return PotegaInt(-1, k) * (PotegaDouble(x, 2 * k + 1) / (2 * k + 1));
        }

        public double SumaSzereguOdPoczatku(double x, int k)
        {
            double sumaSin = 0;
            double sumaArctg = 0;

            for (int i = 0; i < k; i++)
            {
                sumaSin += SumowanieSinus(x, i);
                sumaArctg += SumowanieArcTg(x, i);
            }

            return sumaSin * sumaArctg;
        }

        public double SumaSzereguOdKonca(double x, int k)
        {
            double[] tablicaSinus = new double[k];
            double[] tablicaArcTg = new double[k];
            double sumaSinus = 0.0;
            double sumaArctg = 0.0;

            for (int i = k-1; i >= 0; i--)
            {
                tablicaSinus[i] = SumowanieSinus(x, i);
                tablicaArcTg[i] = SumowanieArcTg(x, i);
                sumaSinus += tablicaSinus[i];
                sumaArctg += tablicaArcTg[i];
            }

            return sumaSinus * sumaArctg;
        }

        public double SinusPoprzedniWyraz(double x, int k)
        {
            return (-1) * x * x * (Silnia(2.0 * k - 1.0) / Silnia(2.0 * k + 1.0));
        }

        public double ArcTgPoprzedniWyraz(double x, int k)
        {
            return (-1) * x * x * ((2.0 * k - 1.0) / (2.0 * k + 1.0));

        }

        public double SumaPoprzedniegoOdPoczatku(double x, int k)
        {
            double[] tablicaSinus = new double[k];
            double[] tablicaArcTg = new double[k];
            double sumaSinus = tablicaSinus[0] = x;
            double sumaArcTg = tablicaArcTg[0] = x;

            for (int i = 1; i < k; i++)
            {
                tablicaSinus[i] = tablicaSinus[i - 1] * SinusPoprzedniWyraz(x, i);
                tablicaArcTg[i] = tablicaArcTg[i - 1] * ArcTgPoprzedniWyraz(x, i);
                sumaSinus += tablicaSinus[i];
                sumaArcTg += tablicaArcTg[i];
            }

            return sumaSinus * sumaArcTg;
        }

        public double SumaPoprzedniegoOdKonca(double x, int k)
        {
            double[] tablicaSinus = new double[k];
            double[] tablicaArcTg = new double[k];
            double sumaSinus = 0.0;
            double sumaArcTg = 0.0;
            tablicaSinus[0] = x;
            tablicaArcTg[0] = x;

            for (int i = 1; i < k; i++)
            {
                tablicaSinus[i] = tablicaSinus[i - 1] * SinusPoprzedniWyraz(x, i);
                tablicaArcTg[i] = tablicaArcTg[i - 1] * ArcTgPoprzedniWyraz(x, i);
            }

            for (int i = k - 1; i >= 0; i--)
            {
                sumaSinus += tablicaSinus[i];
                sumaArcTg += tablicaArcTg[i];
            }

            return sumaSinus * sumaArcTg;
        }
    }
}
