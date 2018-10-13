using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LukaszAlgo1
{
    class Program
    {
        static void Main(string[] args)
        {
            Obliczenia o1 = new Obliczenia();

            //double x = 0.5;
            //double a = 0.9;
            //double b = 0.2;
            //int k = 30;

            //double wynikFunkcji1 = o1.SumaSzereguOdPoczatku(a, k);
            //double wynikFunkcji2 = o1.SumaSzereguOdPoczatku(b, k);
            //double wynikFunkcji2 = o1.SumaSzereguOdKonca(x, k);
            //double wynikFunkcji3 = o1.SumaPoprzedniegoOdPoczatku(x, k);
            //double wynikFunkcji4 = o1.SumaPoprzedniegoOdKonca(x, k);
            //double wynikMath1 = o1.FunkcjaWbudowana(a);
            //double wynikMath2 = o1.FunkcjaWbudowana(b);

            //Console.WriteLine(String.Format("{0:F30}", wynikFunkcji1));
            //Console.WriteLine(String.Format("{0:F30}", wynikFunkcji2));
            //Console.WriteLine(String.Format("{0:F30}", wynikFunkcji3));
            //Console.WriteLine(String.Format("{0:F30}", wynikFunkcji4));
            //Console.WriteLine("a teraz wbudowana");
            //Console.WriteLine(String.Format("{0:F30}", wynikMath1));
            //Console.WriteLine(String.Format("{0:F30}", wynikMath2));

            Test t1 = new Test();
            //t1.TestSzereguOdPoczatku();
            //t1.TestSzereguOdKonca();
            //t1.TestSumowaniaWzgledemPoprzedniegoOdPoczatku();
            //t1.TestSumowaniaWzgledemPoprzedniegoOdKonca();
            //t1.TestDokladnosciKolejnosciSumowania(0.5,50);
            //t1.TestDokladnosciWzoru(0.5,30);
            //t1.TestWielkosciArgumentu(0.5, 1, 30);
            t1.TestLiczbySumowanychWyrazow(30);
        }
    }
}
