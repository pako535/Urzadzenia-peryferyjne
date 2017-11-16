using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SlimDX.DirectInput;
using System.Runtime.InteropServices;


namespace Paint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetSticks();
            Sticks = GetSticks();
            timer1.Enabled = true;
        }

        private SolidBrush myBrush;
        private Graphics myGraphics;
        bool isPainting = false;
        DirectInput Input = new DirectInput();
        SlimDX.DirectInput.Joystick stick;
        Joystick[] Sticks;
        bool mouseClicked = false;
        int xValue = 0;
        int yValue = 0;
        int zValue = 0;



        int blue_rgb_a = 0;
        int blue_rgb_b = 0;
        int blue_rgb_c = 205;
        int red_rgb_a = 175;
        int red_rgb_b = 0;
        int red_rgb_c = 0;
        int yellow_rgb_a = 255;
        int yellow_rgb_b = 255;
        int yellow_rgb_c = 0;
        int green_rgb_a = 0;
        int green_rgb_b = 175;
        int green_rgb_c = 0;
        int black_rgb_a = 0;
        int black_rgb_b = 0;
        int black_rgb_c = 0;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void mouse_event(uint flag, uint _x, uint _y, uint btn, uint exInfo);
        private const int MOUSEEVENT_LEFTDOWN = 0x02;
        private const int MOUSEEVENT_LEFTUP = 0x04;

        public Joystick[] GetSticks()
        {
            List<SlimDX.DirectInput.Joystick> sticks = new List<SlimDX.DirectInput.Joystick>();
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
                            stick.GetObjectPropertiesById((int)deviceObject.ObjectType).SetRange(-100, 100);
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
            state = stick.GetCurrentState();    // pobranie aktualnego stanu joysticka
            if (Math.Abs(state.X) > 90)
                xValue = state.X;
            else
                xValue = 0;
            yValue = state.Y;
            zValue = state.Z;
            MouseMove(xValue, yValue);
            bool[] buttons = state.GetButtons();
            if (id == 0)
            {
                if (buttons[0])
                {
                    isPainting = true;
                }
                else if (buttons[1])
                {
                    if (mouseClicked == false)
                    {
                        mouse_event(MOUSEEVENT_LEFTDOWN, 0, 0, 0, 0);
                        mouseClicked = true;
                    }
                }
                else if (buttons[5])
                {

                    if (buttons[3])
                    {
                        blue_rgb_c -= 10;
                        if (blue_rgb_c < 0)
                            blue_rgb_c = 0;
                    }
                    if (buttons[4])
                    {
                        blue_rgb_c += 10;
                        if (blue_rgb_c > 255)
                            blue_rgb_c = 255;
                    }

                    myBrush = new SolidBrush(Color.FromArgb(255, blue_rgb_a, blue_rgb_b, blue_rgb_c));

                }
                else if (buttons[6])
                {
                    if (buttons[3])
                    {
                        red_rgb_a -= 10;
                        if (red_rgb_a < 0)
                            red_rgb_a = 0;
                    }
                    if (buttons[4])
                    {
                        red_rgb_a += 10;
                        if (red_rgb_a > 255)
                            red_rgb_a = 255;
                    }
                    myBrush = new SolidBrush(Color.FromArgb(255, red_rgb_a, red_rgb_b, red_rgb_c));

                }
                else if (buttons[7])
                {
                    panel1.Invalidate();
                }
                else if (buttons[8])
                {

                    if (buttons[3])
                    {
                        black_rgb_a -= 10;
                        black_rgb_b -= 10;
                        black_rgb_c -= 10;
                        if (black_rgb_a < 0)
                            black_rgb_a = 0;
                        if (black_rgb_b < 0)
                            black_rgb_b = 0;
                        if (black_rgb_c < 0)
                            black_rgb_c = 0;
                    }
                    if (buttons[4])
                    {
                        black_rgb_a += 10;
                        black_rgb_b += 10;
                        black_rgb_c += 10;
                        if (black_rgb_a > 255)
                            black_rgb_a = 255;
                        if (black_rgb_b > 255)
                            black_rgb_b = 255;
                        if (black_rgb_c > 255)
                            black_rgb_c = 255;
                    }

                    myBrush = new SolidBrush(Color.FromArgb(255, black_rgb_a, black_rgb_b, black_rgb_c));

                }
                else if (buttons[9])
                {
                    if (buttons[3])
                    {
                        yellow_rgb_c -= 10;
                        if (yellow_rgb_c < 0)
                            yellow_rgb_c = 0;

                    }
                    if (buttons[4])
                    {
                        yellow_rgb_c += 10;
                        if (yellow_rgb_c > 255)
                            yellow_rgb_c = 255;
                    }
                    myBrush = new SolidBrush(Color.FromArgb(255, yellow_rgb_a, yellow_rgb_b, yellow_rgb_c));
                }
                else if (buttons[10])
                {
                    if (buttons[3])
                    {
                        green_rgb_b -= 10;
                        if (green_rgb_b < 0)
                            green_rgb_b = 0;
                    }
                    if (buttons[4])
                    {
                        green_rgb_b += 10;
                        if (green_rgb_b > 255)
                            green_rgb_b = 255;
                    }
                    myBrush = new SolidBrush(Color.FromArgb(255, green_rgb_a, green_rgb_b, green_rgb_c));

                }
                else
                {
                    isPainting = false;
                    if (mouseClicked == true)
                    {
                        mouse_event(MOUSEEVENT_LEFTUP, 0, 0, 0, 0);
                        mouseClicked = false;
                    }
                }
            }
        }

        public void MouseMove(int posx, int posy)
        {
            Cursor.Position = new Point(Cursor.Position.X + posx / 10, Cursor.Position.Y + posy / 10);
            Cursor.Clip = new Rectangle(this.Location, this.Size);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Sticks.Length; i++)
            {
                stickHandle(Sticks[i], i);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Joystick[] joystick = GetSticks();
            myBrush = new SolidBrush(Color.Black);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPainting)
            {
                myGraphics = panel1.CreateGraphics();
                myGraphics.FillEllipse(myBrush, e.X, e.Y, zValue, zValue);
            }
        }
    }
}