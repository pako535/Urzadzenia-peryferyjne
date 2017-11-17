using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SlimDX.DirectInput;

namespace JoyStrick
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CheckJoy();
            Sticks = GetSticks();
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        DirectInput Input = new DirectInput();
        private SlimDX.DirectInput.Joystick stick;
        private Joystick[] Sticks;
    
        private bool mouseClicked = false;
        private int yvalue = 0;
        private int xvalue = 0;
        private int zvalue = 0;

        [DllImport("User32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        [DllImport("User32.dll")]
        public static extern void mouse_event(uint flag, uint _x, uint _y, uint btn, uint exInfo);

        private const int MOUSEEVENT_LEFTDOWN = 0x02;
        private const int MOUSEEVENT_LEFTUP = 0x04;

       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetCursor(200, 200);
        }

        private static void SetCursor(int x, int y)
        {
            // Powrócenie kursora myszy do początkowego położenia
            var xL = (int)App.Current.MainWindow.Left;
            var yT = (int)App.Current.MainWindow.Top;

            SetCursorPos(x + xL, y + yT); //
        }


        public void CheckJoy()
        {

            
            var directInput = new DirectInput();

            
            var joystickGuid = Guid.Empty;
            List<string> names = new List<string>();
           

            foreach (var deviceInstance in directInput.GetDevices(DeviceType.Gamepad,
                        DeviceEnumerationFlags.AllDevices))
            {
                joystickGuid = deviceInstance.InstanceGuid;
                names.Add( deviceInstance.InstanceName);    // dodanie Gamepad'a do listy urządzeń
                    }
            
                foreach (var deviceInstance in directInput.GetDevices(DeviceType.Joystick,
                        DeviceEnumerationFlags.AllDevices))
                {
                    joystickGuid = deviceInstance.InstanceGuid;
                    names.Add(deviceInstance.InstanceName); // dodanie Joysticka do listy urządzeń
                }
            // Jeśli Joystick lub Gamepad nie jest podłączony wyświetl powiadomienie o braku podłączonych urządzeń
            if (joystickGuid == Guid.Empty)
            {

               
                MessageBox.Show("Joystick nie jest podlaczony");
                    Environment.Exit(1);
            }
            else
            {
               // wypisz wszystkie Gamepady i Joysticki
                foreach (string i in names)
                {
                    MessageBox.Show(i);

                }
                
            }
           
        }
        // funkcja pobierająca informacje o przyciskach
        public Joystick[] GetSticks()
        {
            var sticks = new List<Joystick>();

            foreach (DeviceInstance device in Input.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly))
            {
                try
                {
                    stick = new SlimDX.DirectInput.Joystick(Input, device.InstanceGuid);
                    stick.Acquire();

                    foreach (DeviceObjectInstance deviceObject in stick.GetObjects())
                    {
                        if ((deviceObject.ObjectType & ObjectDeviceType.Axis) != 0)
                        {
                            stick.GetObjectPropertiesById((int)deviceObject.ObjectType).SetRange(-100,100);
                        }
                    }
                    sticks.Add(stick);

                }
                catch (DirectInputException)
                {
                    
                }
            }
            return sticks.ToArray();
        }

        void stickHandle(Joystick stick, int id)
        {   
            JoystickState state = new JoystickState();
            state = stick.GetCurrentState();
            yvalue = state.Y;
            xvalue = state.X;
            zvalue = state.Z;
            SetCursor(xvalue,yvalue);

            bool[] buttons = state.GetButtons();

            if (id == 0)
            {
                if (buttons[0])
                {
                    if (mouseClicked == false)
                    {
                        mouse_event(MOUSEEVENT_LEFTDOWN,0,0,0,0);
                        mouseClicked = true;
             
                    }
                }
                else
                {
                    if (mouseClicked)
                    {
                        mouse_event(MOUSEEVENT_LEFTUP, 0, 0, 0, 0);
                        mouseClicked = false;
                     
                    }
                    
                }
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Sticks.Length; i++)
            {
                stickHandle(Sticks[i], i);
            }
        }


    }
}
