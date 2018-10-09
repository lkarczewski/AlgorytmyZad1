using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LukaszAlgo1
{
    class Test
    {
        public double BladWzgledny(double x, double x0)
        {
            if (x == 0 || x0 == 0)
                return 0;

            double blad = Math.Abs((x - x0) / x0);
            return blad;
        }

        public void TestSumowaniaSzereguOdPoczatku()
        {
            Obliczenia o1 = new Obliczenia();
            int dokladnosc = 50;
            double wynikFunkcji;
            int j = 0;
            double sredniBlad = 0.0;
            StreamWriter writer = new StreamWriter("SumowanieOdPoczatku.csv", false);

            for (double i = 0; i < 1; i += 0.000001, j++)
            {
                wynikFunkcji = o1.SumaSzereguOdPoczatku(i, dokladnosc);
                sredniBlad += BladWzgledny(wynikFunkcji, o1.FunkcjaWbudowana(i));
                if (j >= 10000)
                {
                    if (writer != null)
                    {
                        writer.WriteLine(String.Format(@"{0:F30};", sredniBlad/10000));
                    }
                    j = 0;
                    sredniBlad = 0.0;
                }
            }
            writer.Close();
        }

        public void TestSumowaniaSzereguOdKonca()
        {
            Obliczenia o1 = new Obliczenia();
            int dokladnosc = 50;
            double wynikFunkcji;
            int j = 0;
            double sredniBlad = 0.0;
            StreamWriter writer = new StreamWriter("SumowanieOdKonca.csv", false);

            for (double i = 0; i < 1; i += 0.000001, j++)
            {
                wynikFunkcji = o1.SumaSzereguOdKonca(i, dokladnosc);
                sredniBlad += BladWzgledny(wynikFunkcji, o1.FunkcjaWbudowana(i));
                if (j >= 10000)
                {
                    if (writer != null)
                    {
                        writer.WriteLine(String.Format(@"{0:F30};", sredniBlad / 10000));
                    }
                    j = 0;
                    sredniBlad = 0.0;
                }
            }
            writer.Close();
        }

        public void TestSumowaniaWzgledemPoprzedniegoOdPoczatku() {

            Obliczenia o1 = new Obliczenia();
            int dokladnosc = 50;
            double wynikFunkcji;
            int j = 0;
            double sredniBlad = 0.0;
            StreamWriter writer = new StreamWriter("SumowaniePoprzedniegoOdPoczatku.csv", false);

            for (double i = 0; i < 1; i += 0.000001, j++)
            {
                wynikFunkcji = o1.SumaPoprzedniegoOdPoczatku(i, dokladnosc);
                sredniBlad += BladWzgledny(wynikFunkcji, o1.FunkcjaWbudowana(i));
                if (j >= 10000)
                {
                    if (writer != null)
                    {
                        writer.WriteLine(String.Format(@"{0:F30};", sredniBlad / 10000));
                    }
                    j = 0;
                    sredniBlad = 0.0;
                }
            }
            writer.Close();
        }
        public void TestSumowaniaWzgledemPoprzedniegoOdKonca() {

            Obliczenia o1 = new Obliczenia();
            int dokladnosc = 50;
            double wynikFunkcji;
            int j = 0;
            double sredniBlad = 0.0;
            StreamWriter writer = new StreamWriter("SumowaniePoprzedniegoOdKonca.csv", false);

            for (double i = 0; i < 1; i += 0.000001, j++)
            {
                wynikFunkcji = o1.SumaSzereguOdKonca(i, dokladnosc);
                sredniBlad += BladWzgledny(wynikFunkcji, o1.FunkcjaWbudowana(i));
                if (j >= 10000)
                {
                    if (writer != null)
                    {
                        writer.WriteLine(String.Format(@"{0:F30};", sredniBlad / 10000));
                    }
                    j = 0;
                    sredniBlad = 0.0;
                }
            }
            writer.Close();
        }


        public void TestDokladnosciOdPoczatku()
        {
            Obliczenia o1 = new Obliczenia();
            double wynikFunkcji;
            double bladWzgledny = 0.0;
            double argument = 0.567;
            StreamWriter writer = new StreamWriter("TestDokladnosciOdPoczatku.csv", false);

            for (int i = 5; i <= 50; i = i+5)
            {
                wynikFunkcji = o1.SumaSzereguOdPoczatku(argument, i);
                bladWzgledny = BladWzgledny(wynikFunkcji, o1.FunkcjaWbudowana(argument));

                if (writer != null)
                {
                    writer.WriteLine(String.Format(i +";"+ @"{0:F30};",bladWzgledny));
                }
            }

            writer.Close();
        }

        public void TestDokladniosciOdKonca()
        {
            Obliczenia o1 = new Obliczenia();
            double wynikFunkcji;
            double bladWzgledny = 0.0;
            double argument = 0.567;
            StreamWriter writer = new StreamWriter("TestDokladnosciOdKonca.csv", false);

            for (int i = 5; i <= 50; i = i + 5)
            {
                wynikFunkcji = o1.SumaSzereguOdKonca(argument, i);
                bladWzgledny = BladWzgledny(wynikFunkcji, o1.FunkcjaWbudowana(argument));

                if (writer != null)
                {
                    writer.WriteLine(String.Format(i + ";" + @"{0:F30};", bladWzgledny));
                }
            }

            writer.Close();
        }
    }
}
