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

            double x = 0.004;
            int k = 49;

            //double wynikFunkcji = o1.SumaSzereguOdPoczatku(x, k);
            //double wynikFunkcji = o1.SumaSzereguOdKonca(x, k);
            //double wynikFunkcji1 = o1.SumaPoprzedniegoOdPoczatku(x, k);
            //double wynikFunkcji2 = o1.SumaPoprzedniegoOdKonca(x, k);
            //double wynikMath = o1.FunkcjaWbudowana(x);
            //Console.WriteLine(String.Format("{0:F30}", wynikFunkcji));
            //Console.WriteLine(String.Format("{0:F30}", wynikFunkcji1));
            //Console.WriteLine(String.Format("{0:F30}", wynikFunkcji2));
            //Console.WriteLine("a teraz wbudowana");
            //Console.WriteLine(String.Format("{0:F30}", wynikMath));

            Test t1 = new Test();
            //t1.TestSzereguOdPoczatku();
            //t1.TestSzereguOdKonca();
            //t1.TestSumowaniaWzgledemPoprzedniegoOdPoczatku();
            t1.TestSumowaniaWzgledemPoprzedniegoOdKonca();
            //t1.TestDokladnosciOdPoczatku();
            //t1.TestDokladniosciOdKonca();
        }
    }
}
