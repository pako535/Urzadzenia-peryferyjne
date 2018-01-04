using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using FTD2XX_NET;

namespace SMB
{
    class Program
    {
        FTD2XX_NET.FTDI.FT_STATUS ftstatus;
        FTD2XX_NET.FTDI.FT_DEVICE_INFO_NODE[] devicelist = new FTD2XX_NET.FTDI.FT_DEVICE_INFO_NODE[1];
        FTDI device = new FTDI();

        byte[] LeftP = { 0x08, 0x02, 0x04, 0x01 };  // jednofazowe krokowe
        byte[] RightP = { 0x01, 0x04, 0x02, 0x08 };

        byte[] LeftD = { 0x09, 0x0A, 0x06, 0x05 }; //dwufazowe krokowe
        byte[] RightD = { 0x05, 0x06, 0x0A, 0x09 };

        byte[] LeftU = { 0x09, 0x08, 0x0A, 0x02, 0x06, 0x04, 0x05, 0x01 };  // polkrokowe
        byte[] RightU = { 0x01, 0x05, 0x04, 0x06, 0x02, 0x0A, 0x08, 0x09 };

        byte[] stop = { 0x00 }; //po zakonczeniu przesylania syganlow sterujacych 

        int degree = 360; //obrot o odpowiedni kat
        int speed = 60;   //szybkosc przesylania 


        public void rote(int skoki, byte[] buff)
        {

            int loops = (degree * 10) / 50 * skoki; //7.5 stopnia na skok //jezeli półkrokowe do 2*50 -> 360/7.5=50
            int steps = 4 * skoki; //wysokie na wyjsciu RS232 potrzebne do wykonania obrotu, w przypadku krokowego przesylane jest 4 a polkrokowego przesylanie jest 8 sygnalow 
            Int32 bytesToWrite = 1;
            UInt32 bytesWritten = 0;

            byte[][] controlByte = new byte[steps][];

            for (int i = 0; i < steps; i++)
                controlByte[i] = new byte[] { buff[i] };

            for (int k = 0, i = steps - 1; k < loops; k++)
            {

                ftstatus = device.Write(controlByte[i], bytesToWrite, ref bytesWritten); //przesłanie odpowiedniej kombinacji bitowej do sterownika
                System.Threading.Thread.Sleep(1000 / speed);

                if (i == 0)
                    i = steps - 1;
                else
                    i--;
            }

            ftstatus = device.Write(stop, 1, ref bytesWritten); //zaprzestanie wysylania stanów wysokich do silnika krokowego
        }

        public void Connect()
        {
            ftstatus = device.GetDeviceList(devicelist);
            try
            {
                //sprawdzenie czy urzadzenie zostalo podlaczone
                ftstatus = device.OpenByDescription(devicelist[0].Description);
                ftstatus = device.SetBitMode(0xff, 1); //pozwala na przesylanie danych do ukladu
                Console.WriteLine("Status: " + ftstatus.ToString());
            }

            catch (Exception e)
            {
                Console.WriteLine("Urzadzenie nie zostao podlaczone!\nNacisnij [ENTER] aby zamknac program");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }

        public Program()
        {
            string choise;
            Connect();
            do
            {
                Console.WriteLine("**********STEROWANIE SILNIKIEM KROKOWY**********\nSzybkosc obrotu:");
                //speed = Console.ReadLine();
                speed = Convert.ToInt32(Console.ReadLine());
                try
                {
                    Console.WriteLine("Kat obrotu:");
                }
                catch(Exception e)
                {
                    Console.WriteLine("Nie podales liczby!");
                }
                
                try
                {
                    degree = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Nie podales liczby!");
                }
                Console.WriteLine("1 ->Lewo Krokowe-jednofazowe\n2 ->Prawo Krokowe-jednofazowe\n3 ->Lewo polkrokowe-jednofazowe + dwufazowe\n4 -> Prawo polkrokowe-jednofazowe + dwufazowe\nInne klawisze zakoncza dzialanie programu");
                choise = Console.ReadLine();
                
                switch (choise[0])
                {
                    case '1':
                        rote(1, LeftP);
                        break;
                    case '2':
                        rote(1, RightP);
                        break;
                    case '3':
                        rote(2, LeftU);
                        break;
                    case '4':
                        rote(2, RightU);
                        break;
                    default:
                        return;
                }
            } while (true);

          Console.ReadLine();
        }

        static void Main(string[] args)
        {
            new Program();
        }
    }
}