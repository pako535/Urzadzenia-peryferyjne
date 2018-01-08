using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using BarcodeLib;
using System.Drawing.Imaging;
using System.IO;

/*
Program korzysta z Biblioteki Barcode.dll
*/


namespace ConsoleApplication1 {
    class Program
    {
        public static void Druk() {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += PrintPage;
            pd.Print();
        }
        public static void PrintPage(object o, PrintPageEventArgs e) {
            System.Drawing.Image img = System.Drawing.Image.FromFile("C:\\Users\\lab\\Desktop\\MikolajJarek\\ConsoleApplication1\\ConsoleApplication1\\bin\\Debug\\kot.png");
            Point loc = new Point(100, 100);
            e.Graphics.DrawImage(img, loc);
        }
        static void Main(string[] args) {
            //Generowanie zmiennych
            Image img = null;
            int szerokosc = 200;
            //Generowanie Sumy kontrolnej
            Console.Write("Ręcę do góry! Wyskakuj z kodu. 12 cyferek. Ale już! ");
            String kod = Console.ReadLine();
            long.Parse(kod);
            int sumakontrolna = 0;
            for (int i = 0; i < kod.Length - 1; i += 2) {
                sumakontrolna += Int32.Parse(kod[i] + "");
                sumakontrolna += 3 * Int32.Parse(kod[i + 1] + "");
            }
            sumakontrolna = sumakontrolna % 10;
            sumakontrolna = 10 - sumakontrolna;
            if (sumakontrolna == 10)
                sumakontrolna = 0;

            if (kod.Length != 12) {
                Console.WriteLine("Podaj dokladnie 12 cyfr kodu");
            }
            else {
                //Generowanie Kodu Kreskowego
                BarcodeLib.Barcode barcode = new BarcodeLib.Barcode();
                barcode.LabelFont = new Font(barcode.LabelFont.FontFamily, szerokosc / 15);
                barcode.IncludeLabel = true;
                img = barcode.Encode(TYPE.EAN13, kod);
                Console.WriteLine("Ha! Ha! Mam sume kontrolna do Twojego kodu gagatku! " + sumakontrolna);
                Console.ReadLine();
                using (FileStream fs = new FileStream("kot.png", FileMode.Create, FileAccess.Write)) {
                     img.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                     fs.Close();
                 }
                //Otwieranie
                string komenda;
                komenda = "/C C:\\Users\\lab\\Desktop\\MikolajJarek\\ConsoleApplication1\\ConsoleApplication1\\bin\\Debug\\kot.png";
                System.Diagnostics.Process.Start("cmd", komenda);
                //Drukowanie
                Druk();     
            }
             Console.ReadLine();   
        }
    }
}