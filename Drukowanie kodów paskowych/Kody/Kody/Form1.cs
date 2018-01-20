using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kody
{
    public partial class Generator : Form
    {
        public Generator()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            Zen.Barcode.CodeEan13BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.CodeEan13WithChecksum; // ustawienie trybu generowanie kodow EAN-13
            pictureBox1.Image = barcode.Draw(txtBarcode.Text, 100); // stworzenie obrazu w oknie na podstawie cyfr wprowadzonych w polu tekstowym
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void myPrintDocument2_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)

        {

            Bitmap myBitmap1 = new Bitmap(pictureBox1.Width, pictureBox1.Height); // stworzenie bitmapy poprzez pobranie szerokosci i wysokosci okna

            pictureBox1.DrawToBitmap(myBitmap1, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height)); // renderowanie zawartosci okna do mapy bitowej

            e.Graphics.DrawImage(myBitmap1, 0, 0); // rysowanie 

            myBitmap1.Dispose(); // zwolnienie zasobow uzywanych przez mape bitowa

        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            // stworzenie obiektu typu PrintDocument 
            System.Drawing.Printing.PrintDocument myPrintDocument1 = new System.Drawing.Printing.PrintDocument();
            // stworzenie obiektu typu PrintDialog (okno dialogowe)
            PrintDialog myPrinDialog1 = new PrintDialog();
            //stworzenie akcji drukowania stron
            myPrintDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(myPrintDocument2_PrintPage);

            myPrinDialog1.Document = myPrintDocument1;


            // jesli zatwierdzimy okno dialogowe wykonamy wydruk
            if (myPrinDialog1.ShowDialog() == DialogResult.OK)

            {

                myPrintDocument1.Print();

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Save("kod_" + txtBarcode.Text + ".jpg"); // zapisanie zawartosci okna do pliku jpg
            MessageBox.Show("Zapisano plik " + "kod_" + txtBarcode.Text + ".jpg"); // okno dialogowe informujace o zapisaniu pliku

        }
    }
}
