using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCSC;




namespace ChipReader
{
    class Program
    {
        private static SCardError error;
        private static SCardReader reader;
        private static System.IntPtr intptr;
        private static SCardContext context;

        static void Main(string[] args)
        {
            connection();

           // public string Atr {get;}
            

            byte[] commandB;
          //  bool flag = true;
            //   do

            //Console.WriteLine("\n\nWybierz co chcesz zrobic\nF1 -> SELECT(TELECOM)\nF2 -> SELECT - odczytaj sms'a\nF3 -> READ RECORD\nF12 - > Wyjscie");
         //   var input = Console.ReadKey();

            commandB = new byte[] { 0xA0, 0xA4, 0x00, 0x00, 0x02, 0x7F, 0x10 }; // wejscie w galaz telecom
            sendCommand(commandB, "SELECT(TELECOM)");
            //odpowiedz
            Console.WriteLine("Odpowiedz TELECOMU\n");
            commandB = new byte[] { 0xA0, 0xC0, 0x00, 0x00, 0x16 };
            sendCommand(commandB, "GET RESPONSE");


            commandB = new byte[]{0xA0, 0xA4, 0x00, 0x00, 0x02, 0x6F, 0x3C};// { 0xA0, 0xA4, 0x00, 0x00, 0x02, 0x6F, 0x3C }; // wejscie w galaz SMS 
            sendCommand(commandB, "SELECT SMS");
            Console.WriteLine("Odpowiedz wejscia w galaz SMS\n");
            commandB = new byte[] { 0xA0, 0xC0, 0x00, 0x00, 0x16 };
            sendCommand(commandB, "GET RESPONSE");

            commandB = new byte[] {0xA0, 0xB2, 0x01, 0x04, 0xB0};//{ 0xA0, 0xB2, 0x03, 0x01, 0xB0 }; // odczyt smsa 
            sendCommand(commandB, "READ RECORD");
            Console.WriteLine("Odczyt SMS");
            commandB = new byte[] { 0xA0, 0xC0, 0x00, 0x00, 0x16 };
            sendCommand(commandB, "GET RESPONSE");




            //switch (input.Key)
            //{

            //    case ConsoleKey.F1:
            //        Console.WriteLine("F1");
            //        commandB = new byte[] { 0xA0, 0xA4, 0x00, 0x00, 0x02, 0x7F, 0x10 };
            //        sendCommand(commandB, "SELECT(TELECOM)");
            //        //odpowiedz
            //        commandB = new byte[] { 0xA0, 0xC0, 0x00, 0x00, 0x16 };
            //        sendCommand(commandB, "GET RESPONSE");
            //        break;

            //    case ConsoleKey.F2:
            //        Console.WriteLine("F3");
            //        commandB = new byte[] { 0xA0, 0xA4, 0x00, 0x00, 0x02, 0x6F, 0x3C };
            //        sendCommand(commandB, "SELECT SMS");

            //        commandB = new byte[] { 0xA0, 0xC0, 0x00, 0x00, 0x16 };
            //        sendCommand(commandB, "GET RESPONSE");
            //        break;

            //    case ConsoleKey.F3:
            //        Console.WriteLine("F4");
            //        commandB = new byte[] { 0xA0, 0xB2, 0x03, 0x04, 0xB0 };
            //        sendCommand(commandB, "READ RECORD");

            //        commandB = new byte[] { 0xA0, 0xC0, 0x00, 0x00, 0x16 };
            //        sendCommand(commandB, "GET RESPONSE");
            //        break;

            //    case ConsoleKey.F12:
            //        flag = false;
            //        break;

            //    //default:
            //    //   Console.WriteLine("Blad");
            //}
            Console.WriteLine("Wcisnij dowolny klawisz by kontynowac...");
            Console.ReadKey();
        }


            //} while (flag );
  



        public static void connection()
        {
            context = new SCardContext();
            context.Establish(SCardScope.System);

            string[] readerList = context.GetReaders();
            Boolean noReaders = readerList.Length <= 0;
            if (noReaders)
            {
                throw new PCSCException(SCardError.NoReadersAvailable, "Czytnik nie zostal odnaleziony");
               // Console.WriteLine("Czytnik nie zostal odnaleziony");
            }



            int counter = 1;
            Console.WriteLine("Wybierz czytnik: ");
            foreach (string element in readerList)
            {
                Console.WriteLine("F"+counter +" -> "+element);
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

                reader = new SCardReader(context);

                error = reader.Connect(tmp, SCardShareMode.Shared, SCardProtocol.T0 | SCardProtocol.T1);
                checkError(error);
                if(reader.ActiveProtocol == SCardProtocol.T0)
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

        public static void sendCommand(byte[] command, String name)
        {
            byte[] recivedBytes = new byte[256];
            error = reader.Transmit(intptr, command, ref recivedBytes);
            checkError(error);
            writeResponse(recivedBytes, name);
        }

        public static void writeResponse(byte[] recivedBytes, String responseCode)
        {
            Console.Write(responseCode + ": ");
            for (int i = 0; i < recivedBytes.Length; i++)
                Console.Write("{0:X2} ", recivedBytes[i]); // wypisanie odpowiedzi binarnie
            Console.WriteLine();
        }


        static void checkError(SCardError error)
        {
            if (error != SCardError.Success)
            {
                throw new PCSCException(error, SCardHelper.StringifyError(error));
            }
        }

    }
}
