using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;

using FTD2XX_NET;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        FTDI myFtdiDevice;
        byte[] tab = { 0x05, 0x01, 0x09, 0x08, 0x0A, 0x02, 0x06, 0x04 };
        byte[] tab2 = { 0x05F, 0x01F, 0x09F, 0x08F, 0x0AF, 0x02F, 0x06F, 0x04F };


        int index = 0;
        UInt32 numBytesWritten = 0;

        public void krok( int count, int direction, int speed, byte [] tab )
        {
            for ( int i = 0; i < count; i++ )
            {
                index += direction;
                if ( index > 7 )
                {
                    index = 0;
                }
                else if ( index < 0 )
                {
                    index = 7;
                }

                byte[] x = { tab[index] };
                    
                 myFtdiDevice.Write( x, 1, ref numBytesWritten );
                 Thread.Sleep( speed );
                    
                
                
                
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        

        private void button5_Click( object sender, EventArgs e )
        {
            UInt32 ftdiDeviceCount = 0;
            

            // Create new instance of the FTDI device class
            myFtdiDevice = new FTDI();
            myFtdiDevice.GetNumberOfDevices( ref ftdiDeviceCount );
            FTDI.FT_DEVICE_INFO_NODE[] ftdiDeviceList = new FTDI.FT_DEVICE_INFO_NODE[ftdiDeviceCount];
            myFtdiDevice.GetDeviceList( ftdiDeviceList );
            myFtdiDevice.OpenBySerialNumber( ftdiDeviceList[0].SerialNumber );
            myFtdiDevice.SetBaudRate( 9600 );
            myFtdiDevice.SetDataCharacteristics( FTDI.FT_DATA_BITS.FT_BITS_8, FTDI.FT_STOP_BITS.FT_STOP_BITS_1, FTDI.FT_PARITY.FT_PARITY_NONE );
            myFtdiDevice.SetFlowControl( FTDI.FT_FLOW_CONTROL.FT_FLOW_RTS_CTS, 0x11, 0x13 );
            myFtdiDevice.SetTimeouts( 5000, 0 );
            richTextBox1.AppendText("polaczono");
        }

        private void lewoKroki_Click( object sender, EventArgs e )
        {
            int c = Convert.ToInt32( kroki.Text );
            int s = Convert.ToInt32( speed.Text );
            krok(c,-1,s, tab);
        }

        private void prawoKroki_Click( object sender, EventArgs e )
        {
            int c = Convert.ToInt32( kroki.Text );
            int s = Convert.ToInt32( speed.Text );
            krok( c, 1, s, tab );
        }

        private void lewoKat_Click( object sender, EventArgs e )
        {
            int c = 2 * (int)(Convert.ToInt32( kat.Text ) / 7.5);
            int s = Convert.ToInt32( speed.Text );
            krok( c, -1, s, tab );
        }

        private void prawoKat_Click( object sender, EventArgs e )
        {
            int c = 2 * (int)(Convert.ToInt32( kat.Text ) / 7.5);
            int s = Convert.ToInt32( speed.Text );
            krok( c, 1, s, tab );
        }

        private void button1_Click( object sender, EventArgs e )
        {
            int c = Convert.ToInt32( kroki.Text );
            int s = Convert.ToInt32( speed.Text );
            krok( c, -1, s, tab2 );
        }

        private void button2_Click( object sender, EventArgs e )
        {
            int c = Convert.ToInt32( kroki.Text );
            int s = Convert.ToInt32( speed.Text );
            krok( c, 1, s, tab2 );
        }

        private void button3_Click( object sender, EventArgs e )
        {
            int c = 2 * (int)(Convert.ToInt32( kat.Text ) / 0.75);
            int s = Convert.ToInt32( speed.Text );
            krok( c, -1, s, tab2 );
        }

        private void button4_Click( object sender, EventArgs e )
        {
            int c = 2 * (int)(Convert.ToInt32( kat.Text ) / 0.75);
            int s = Convert.ToInt32( speed.Text );
            krok( c, -1, s, tab2 );
        }
    }
}
