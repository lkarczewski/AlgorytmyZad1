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
            double silnia = 1;
            for (double i = 1; i <= x; i++)
            {
                silnia *= i;
            }
            return silnia;
        }

        public double Potega(double x, double n)
        {
            double wynik = 1.0;

            for (int i = 0; i < n; i++)
            {
                wynik = wynik * x ;
            }

            return wynik;
        }

        public double SumaSinus(double x, double k)
        {
            return (Potega(-1, k) * Potega(x, 1 + (2 * k))) / Silnia(1 + (2 * k));
        }

        public double SumaArcTg(double x, double k)
        {
            return ((Potega(-1, k) * Potega(x, 1 + (2 * k))) / (1 + (2 * k)));
        }

        public double SinusKolejnyWyraz(double x, double k)
        {
            return Potega(-x, 2) * (Silnia(1 + 2 * k) / Silnia(3 + 2 * k));
        }

        public double ArcTgKolejnyWyraz(double x, double k)
        {
            return Potega(-x, 2) * (1 + 2 * k) / (3 + 2 * k);
        }

        public double SumaSzereguOdPoczatku(double x, int k)
        {
            double sumaSin = 0;
            double sumaArctg = 0;

            for (int i = 0; i < k; i++)
            {
                sumaSin += SumaSinus(x, i); //(Potega(-1, i) * Potega(x, 1 + (2 * i))) / Silnia(1 + (2 * i));
                sumaArctg += SumaArcTg(x, i); //((Potega(-1, i) * Potega(x, 1 + (2 * i))) / (1 + (2 * i)));
            }
                       
            return sumaSin * sumaArctg;
        }

        public double SumaSzereguOdKonca(double x, int k)
        {
            double sumaSin = 0;
            double sumaArctg = 0;

            for (int i = k-1; i >= 0; i--)
            {
                sumaSin += SumaSinus(x, i);
                sumaArctg += SumaArcTg(x, i);
            }

            return sumaSin * sumaArctg;
        }

        public double SumaPoprzedniegoOdPoczatku(double x, double k)
        {
            int rozmiar = (int)k;
            double[] tablicaSinus;
            double[] tablicaArcTg;
            tablicaArcTg = new double[rozmiar];
            tablicaSinus = new double[rozmiar];
            double wyrazSinus = SumaSinus(x, 0);
            double wyrazArcTg = SumaArcTg(x, 0);
            double sumaSinus = wyrazSinus;
            double sumaArcTg = wyrazArcTg;

            for (int i = 1; i <= k-1; i++) {
                wyrazSinus = wyrazSinus * SinusKolejnyWyraz(x, k);
                wyrazArcTg = wyrazArcTg * ArcTgKolejnyWyraz(x, k);
                tablicaSinus[i] = wyrazSinus;
                tablicaArcTg[i] = wyrazArcTg;
                sumaSinus = sumaSinus + tablicaSinus[i];
                sumaArcTg = sumaArcTg + tablicaArcTg[i];
            }
            return sumaSinus * sumaArcTg;
        }

        public double SumaPoprzedniegoOdKonca(double x, double k)
        {
            int rozmiar = (int)k;
            double[] tablicaSinus;
            double[] tablicaArcTg;
            tablicaArcTg = new double[rozmiar];
            tablicaSinus = new double[rozmiar];
            double wyrazSinus = SumaSinus(x, 0);
            double wyrazArcTg = SumaArcTg(x, 0);
            double sumaSinus = wyrazSinus;
            double sumaArcTg = wyrazArcTg;

            for (int i = 1; i <= k - 1; i++)
            {
                wyrazSinus = wyrazSinus * SinusKolejnyWyraz(x, k);
                wyrazArcTg = wyrazArcTg * ArcTgKolejnyWyraz(x, k);
                tablicaSinus[i] = wyrazSinus;
                tablicaArcTg[i] = wyrazArcTg;
            }

            for (int i = rozmiar-1; i >= 0; i--)
            {
                sumaSinus = sumaSinus + tablicaSinus[i];
                sumaArcTg = sumaArcTg + tablicaArcTg[i];
            }
            return sumaSinus * sumaArcTg;
        }

        public double FunkcjaWbudowana(double x)
        {
            return Math.Sin(x) * Math.Atan(x);
        }
    }
}
