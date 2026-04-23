using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ComputerGraphics_3
{

    interface InputOutputStream
    {
        string ReadLine();
        void WriteLine(string line);
    }


    internal class MouseCapture
    {
        public InputOutputStream MouseConsole;

        private CheckBox RKMCheckBox;
        private CheckBox MKMCheckBox;
        private CheckBox LKMCheckBox;

        private Label y_coord_out;
        private Label x_coord_out;

        public bool debug;

        private int startX = 0;
        private int startY = 0;
        private int wheelDelta = 0;
        private bool isDragging = false;
        private MouseButtons draggingButton = MouseButtons.None;

        private string Console
        {
            get
            {
                return MouseConsole.ReadLine();
            }
            set
            {
                if (debug)
                    MouseConsole.WriteLine(value);
            }
        }

        public void ConnectStream(InputOutputStream mouseIO)
        {
            MouseConsole = mouseIO;
        }

        public void ConnectLabel(Label x_coord_out, Label y_coord_out)
        {
            this.x_coord_out = x_coord_out;
            this.y_coord_out = y_coord_out;
        }
        public void ConnectCheckBox(CheckBox RKMCheckBoxIO, CheckBox MKMCheckBoxIO, CheckBox LKMCheckBoxIO)
        {
            RKMCheckBox = RKMCheckBoxIO;
            MKMCheckBox = MKMCheckBoxIO;
            LKMCheckBox = LKMCheckBoxIO;
        }
        public void ConnectEvents(Form Window)
        {
            Window.MouseClick += this.MouseClick;
            Window.MouseDown += this.MouseDown;
            Window.MouseUp += this.MouseUp;
            Window.MouseMove += this.MouseMove;
            Window.MouseDoubleClick += this.MouseDoubleClick;
            Window.MouseWheel += this.MouseWheel;
            SubscribeAllControls(Window);
        }

        private void SubscribeAllControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                control.MouseClick += this.MouseClick;
                control.MouseDown += this.MouseDown;
                control.MouseUp += this.MouseUp;
                control.MouseMove += this.MouseMove;
                control.MouseDoubleClick += this.MouseDoubleClick;
                control.MouseWheel += this.MouseWheel;

                if (control.HasChildren)
                {
                    SubscribeAllControls(control);
                }
            }
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            string button = GetButtonName(e.Button);

            isDragging = true;
            draggingButton = e.Button;
            startX = e.X;
            startY = e.Y;

            Console = $"MouseDown: {button} ({e.X}, {e.Y})";
            SetCheckBox(e.Button, true);
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            SetCheckBox(e.Button, false);
            string button = GetButtonName(e.Button);

            if (isDragging && draggingButton == e.Button)
            {
                int deltaX = e.X - startX;
                int deltaY = e.Y - startY;
                if (deltaX != 0 || deltaY != 0)
                {
                    Console = $"Drag: {button} Delta({deltaX:+0;-0;0}, {deltaY:+0;-0;0})";
                }
                isDragging = false;
            }

            Console = $"MouseUp: {button} ({e.X}, {e.Y})";
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            string button = GetButtonName(e.Button);

            Console = $"MouseMove: {button} ({e.X}, {e.Y})";

            if (isDragging && e.Button == draggingButton)
            {
                int deltaX = e.X - startX;
                int deltaY = e.Y - startY;
                Console = $"DragDelta: {GetButtonName(draggingButton)} ({deltaX:+0;-0;0}, {deltaY:+0;-0;0})";
            }
            x_coord_out.Text = $"X: {e.X}";
            y_coord_out.Text = $"Y: {e.Y}";
        }

        private void MouseClick(object sender, MouseEventArgs e)
        {
            string button = GetButtonName(e.Button);
            Console = $"MouseClick: {button} ({e.X}, {e.Y})";
        }

        private void MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string button = GetButtonName(e.Button);
            Console = $"MouseDoubleClick: {button} ({e.X}, {e.Y})";
        }

        private void MouseWheel(object sender, MouseEventArgs e)
        {
            int delta = e.Delta;
            wheelDelta += delta;
            string direction = delta > 0 ? "Up" : "Down";
            Console = $"MouseWheel: {direction} Delta({delta:+0;-0;0})";
        }

        private string GetButtonName(MouseButtons button)
        {
            switch (button)
            {
                case MouseButtons.Left:
                    return "L";
                case MouseButtons.Right:
                    return "R";
                case MouseButtons.Middle:
                    return "M";
                default:
                    return "-";
            }
        }

        private void SetCheckBox(MouseButtons button, bool state)
        {
            switch (button)
            {
                case MouseButtons.Left:
                    LKMCheckBox.Checked = state;
                    break;
                case MouseButtons.Right:
                    RKMCheckBox.Checked = state;
                    break;
                case MouseButtons.Middle:
                    MKMCheckBox.Checked = state;
                    break;
                default:
                    return;
            }
        }

        public int GetWheelDelta()
        {
            return wheelDelta;
        }

        public void ResetWheelDelta()
        {
            wheelDelta = 0;
        }

        public bool IsDragging()
        {
            return isDragging;
        }
    }
}