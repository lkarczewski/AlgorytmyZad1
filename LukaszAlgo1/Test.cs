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
        //public double BladWzgledny(double x, double x0)
        //{
        //    double blad = Math.Abs((x - x0) / x);
        //    return blad;
        //}

        //public void TestSumowaniaSzereguOdPoczatku()
        //{
        //    Obliczenia o1 = new Obliczenia();
        //    int dokladnosc = 50;
        //    double wynikFunkcji;
        //    int j = 0;
        //    double sredniBlad = 0.0;
        //    StreamWriter writer = new StreamWriter("SumowanieOdPoczatku.csv", false);

        //    for (double i = 0; i < 1; i += 0.000001, j++)
        //    {
        //        wynikFunkcji = o1.SumaSzereguOdPoczatku(i, dokladnosc);
        //        sredniBlad += BladWzgledny(wynikFunkcji, o1.FunkcjaWbudowana(i));
        //        if (j >= 10000)
        //        {
        //            if (writer != null)
        //            {
        //                writer.WriteLine(String.Format(@"{0:F50};", sredniBlad / 10000));
        //            }
        //            j = 0;
        //            sredniBlad = 0.0;
        //        }
        //    }
        //    writer.Close();
        //}

        //public void TestSumowaniaSzereguOdKonca()
        //{
        //    Obliczenia o1 = new Obliczenia();
        //    int dokladnosc = 50;
        //    double wynikFunkcji;
        //    int j = 0;
        //    double sredniBlad = 0.0;
        //    StreamWriter writer = new StreamWriter("SumowanieOdKonca.csv", false);

        //    for (double i = 0; i < 1; i += 0.000001, j++)
        //    {
        //        wynikFunkcji = o1.SumaSzereguOdKonca(i, dokladnosc);
        //        sredniBlad += BladWzgledny(o1.FunkcjaWbudowana(i), wynikFunkcji);
        //        if (j >= 10000)
        //        {
        //            if (writer != null)
        //            {
        //                writer.WriteLine(String.Format(@"{0:F50};", sredniBlad / 10000));
        //            }
        //            j = 0;
        //            sredniBlad = 0.0;
        //        }
        //    }
        //    writer.Close();
        //}

        //public void TestSumowaniaWzgledemPoprzedniegoOdPoczatku() {

        //    Obliczenia o1 = new Obliczenia();
        //    int dokladnosc = 50;
        //    double wynikFunkcji;
        //    int j = 0;
        //    double sredniBlad = 0.0;
        //    StreamWriter writer = new StreamWriter("SumowaniePoprzedniegoOdPoczatku.csv", false);

        //    for (double i = 0; i < 1; i += 0.000001, j++)
        //    {
        //        wynikFunkcji = o1.SumaPoprzedniegoOdPoczatku(i, dokladnosc);
        //        sredniBlad += BladWzgledny(wynikFunkcji, o1.FunkcjaWbudowana(i));
        //        if (j >= 10000)
        //        {
        //            if (writer != null)
        //            {
        //                writer.WriteLine(String.Format(@"{0:F30};", sredniBlad / 10000));
        //            }
        //            j = 0;
        //            sredniBlad = 0.0;
        //        }
        //    }
        //    writer.Close();
        //}

        //public void TestSumowaniaWzgledemPoprzedniegoOdKonca() {

        //    Obliczenia o1 = new Obliczenia();
        //    int dokladnosc = 50;
        //    double wynikFunkcji;
        //    int j = 0;
        //    double sredniBlad = 0.0;
        //    StreamWriter writer = new StreamWriter("SumowaniePoprzedniegoOdKonca.csv", false);

        //    for (double i = 0; i < 1; i += 0.000001, j++)
        //    {
        //        wynikFunkcji = o1.SumaSzereguOdKonca(i, dokladnosc);
        //        sredniBlad += BladWzgledny(wynikFunkcji, o1.FunkcjaWbudowana(i));
        //        if (j >= 10000)
        //        {
        //            if (writer != null)
        //            {
        //                writer.WriteLine(String.Format(@"{0:F30};", sredniBlad / 10000));
        //            }
        //            j = 0;
        //            sredniBlad = 0.0;
        //        }
        //    }
        //    writer.Close();
        //}

        public void TestDokladnosciKolejnosciSumowania(double argument, int ilosc)
        {
            Obliczenia o1 = new Obliczenia();
            StreamWriter writer = new StreamWriter("TestDokladnosciKolejnosciSumowania.csv", false);
            writer.WriteLine("ilosc-argumentow;od-poczatku;od-konca");

            for (int i = 1; i <= ilosc; i++)
            {
                double funkcjaLib = o1.FunkcjaWbudowana(argument);
                double bladOdPoczatku = Math.Abs((funkcjaLib - o1.SumaSzereguOdPoczatku(argument,i)) / funkcjaLib);
                double bladOdKonca = Math.Abs((funkcjaLib - o1.SumaSzereguOdKonca(argument, i)) / funkcjaLib);

                if (writer != null)
                {
                    writer.WriteLine(String.Format(i + ";" + bladOdPoczatku + ";" + bladOdKonca));
                }
            }

            writer.Close();
        }

        public void TestDokladnosciWzoru(double argument, int iloscElementow)
        {
            Obliczenia o1 = new Obliczenia();
            StreamWriter writer = new StreamWriter("TestDokladnosciWzoru.csv", false);
            writer.WriteLine("ilosc-argumentow;wzorem;poprzednim-wyrazem");

            for (int i = 1; i <= iloscElementow; i++)
            {
                double funkcjaLib = o1.FunkcjaWbudowana(argument);
                double bladWzoru = Math.Abs((funkcjaLib - o1.SumaSzereguOdKonca(argument, i)) / funkcjaLib);
                double bladPoprzedniego = Math.Abs((funkcjaLib - o1.SumaPoprzedniegoOdKonca(argument, i)) / funkcjaLib);

                if (writer != null)
                {
                    writer.WriteLine(String.Format(i + ";" + bladWzoru + ";" + bladPoprzedniego));
                }
            }

            writer.Close();
        }

        public void TestWielkosciArgumentu(double argument1, double argument2, int iloscElementow)
        {
            Obliczenia o1 = new Obliczenia();
            StreamWriter writer = new StreamWriter("TestWielkosciArgumentu.csv", false);
            writer.WriteLine("ilosc-argumentow;f(" + argument1 + ");f(" + argument2 + ")");

            for (int i = 1; i <= iloscElementow; i++)
            {
                double funkcjaLib1 = o1.FunkcjaWbudowana(argument1);
                double funkcjaLib2 = o1.FunkcjaWbudowana(argument2);
                double bladArgument1 = Math.Abs((funkcjaLib1 - o1.SumaSzereguOdKonca(argument1, i)) / funkcjaLib1);
                double bladArgument2 = Math.Abs((funkcjaLib2 - o1.SumaSzereguOdKonca(argument2, i)) / funkcjaLib2);

                if (writer != null)
                {
                    writer.WriteLine(String.Format(i + ";" + bladArgument1 + ";" + bladArgument2));
                }
            }

            writer.Close();
        }

        public void TestLiczbySumowanychWyrazow(int iloscElementow) {

            Obliczenia o1 = new Obliczenia();
            StreamWriter writer = new StreamWriter("TestLiczbySumowanychWyrazow.csv", false);
            writer.WriteLine("ilosc-argumentow;x=0.5;x=0.65;x=0.8;x=0.99");

            double funkcjaLib, blad1, blad2, blad3, blad4;

            for(int i = 1; i <= iloscElementow; i++)
            {
                funkcjaLib = o1.FunkcjaWbudowana(0.5);
                blad1 = Math.Abs((funkcjaLib - o1.SumaSzereguOdKonca(0.5, i)) / funkcjaLib);

                //if (writer != null)
                //{
                //    writer.WriteLine(String.Format(i + ";" + blad1));
                //}

                funkcjaLib = o1.FunkcjaWbudowana(0.65);
                blad2 = Math.Abs((funkcjaLib - o1.SumaSzereguOdKonca(0.65, i)) / funkcjaLib);

                //if (writer != null)
                //{
                //    writer.WriteLine(String.Format(";" + blad2));
                //}

                funkcjaLib = o1.FunkcjaWbudowana(0.8);
                blad3 = Math.Abs((funkcjaLib - o1.SumaSzereguOdKonca(0.8, i)) / funkcjaLib);

                //if (writer != null)
                //{
                //    writer.WriteLine(String.Format(";" + blad3));
                //}

                funkcjaLib = o1.FunkcjaWbudowana(0.99);
                blad4 = Math.Abs((funkcjaLib - o1.SumaSzereguOdKonca(0.99, i)) / funkcjaLib);

                if (writer != null)
                {
                    writer.WriteLine(String.Format(i + ";" + blad1 + ";" + blad2 + ";" + blad3 +";" + blad4));
                }
            }
            writer.Close();
        }
    }
}
