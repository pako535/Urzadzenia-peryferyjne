using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCSC;         //bibloteka obsługująca API dl aczytnika kart SIM

namespace sim_card
{
    class Program
    {
        private static SCardError error;
        private static SCardReader reader;
        private static System.IntPtr intptr;
        private static SCardContext context;

        static void Main(string[] args)
        {
            byte[] commandB;    //odpowiendie polecenia będą przesyłane do czytnika w formie bitowej.
            try
            {
                connection(); 
               
                //wysłanie kolejnych komend do czytnika, celem programu jest odczytanie SMSa
                //poruszanie sie po poszczególnych poziomach:

                // wejscie w galaz telecom:
                commandB = new byte[] { 0xA0, 0xA4, 0x00, 0x00, 0x02, 0x7F, 0x10 }; // adres złożony z 2 znaków 107F
                sendCommand(commandB, "SELECT(TELECOM)");

                Console.WriteLine("Odpowiedz TELECOMU\n");
                commandB = new byte[] { 0xA0, 0xC0, 0x00, 0x00, 0x16 }; //oczekiwanie odpowiedzi o długości 22(10)
                sendCommand(commandB, "GET RESPONSE");

                // wejscie w galaz SMS     
                commandB = new byte[] { 0xA0, 0xA4, 0x00, 0x00, 0x02, 0x6F, 0x3C };
                sendCommand(commandB, "SELECT SMS");
                Console.WriteLine("Odpowiedz gałęzi SMS\n");
                commandB = new byte[] { 0xA0, 0xC0, 0x00, 0x00, 0x16 }; 

                // odczyt smsa
                commandB = new byte[] { 0xA0, 0xB2, 0x01, 0x04, 0xB0 };
                sendCommand(commandB, "READ RECORD");
                Console.WriteLine("Odczyt SMS");
                commandB = new byte[] { 0xA0, 0xC0, 0x00, 0x00, 0x16 };
                sendCommand(commandB, "GET RESPONSE");



                Console.WriteLine("Wcisnij dowolny klawisz by kontynowac...");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Podczas uruchamiana programu wystąpił blad.");
                Console.ReadKey();
            }
        }
        public static void connection()
        {
            context = new SCardContext(); //nawiązanie połączenia z czytnikiem

            string[] readerList = context.GetReaders(); // wczytanie dostępnych czytników do listy
            Boolean noReaders = readerList.Length <= 0;
            if (noReaders)
            {
                throw new PCSCException(SCardError.NoReadersAvailable, "Czytnik nie zostal odnaleziony"); 
            }

            int counter = 1;
            Console.WriteLine("Wybierz czytnik: ");
            foreach (string element in readerList)
            {
                Console.WriteLine("F" + counter + " -> " + element);
                counter++;
            }
            var input = Console.ReadKey();
            string tmp = readerList[0];
            switch (input.Key)
            {

                case ConsoleKey.F1:
                    tmp = readerList[0];
                    break;

                case ConsoleKey.F2:
                    tmp = readerList[1];
                    break;
            }

            Console.WriteLine("Wcisnij dowolny klawisz by kontynowac...");
            Console.ReadKey();

            //w zależności od wybranego czytniku wybrany zostanie odpowiedni protokół T0 lub T1. W przypadku pozostałych zostanie wyrzucony wyjątek 
            reader = new SCardReader(context);
            error = reader.Connect(tmp, SCardShareMode.Shared, SCardProtocol.T0 | SCardProtocol.T1);
            checkError(error);
            if (reader.ActiveProtocol == SCardProtocol.T0)
            {
                intptr = SCardPCI.T0;

            }
            else if (reader.ActiveProtocol == SCardProtocol.T1)
            {
                intptr = SCardPCI.T1;
            }
            else
            {
                Console.WriteLine("Protokol nie jest obslugiwany");
                Console.WriteLine("Wcisnij dowolny klawisz by kontynowac...");
                Console.ReadKey();
            }
        }

        public static void sendCommand(byte[] command, String name) // przesyłanie komend do karty
        {
            byte[] recivedBytes = new byte[256];
            error = reader.Transmit(intptr, command, ref recivedBytes);
            checkError(error);
            writeResponse(recivedBytes, name);
        }

        public static void writeResponse(byte[] recivedBytes, String responseCode)//odczytanie odpowiedzi z karty
        {
            Console.Write(responseCode + ": ");
            for (int i = 0; i < recivedBytes.Length; i++)
                Console.Write("{0:X2} ", recivedBytes[i]); // wypisanie odpowiedzi binarnie
            Console.WriteLine();
        }
        
        static void checkError(SCardError error) //sprawdzenie czy włożona została karta
        {
            if (error != SCardError.Success)
            {
                throw new PCSCException(error, SCardHelper.StringifyError(error));
            }
        }
    }
}
