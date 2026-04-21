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

        public bool debug;
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
            SubscribeAllControls(Window);
        }

        private void SubscribeAllControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                // Подписываем каждый контрол
                control.MouseClick += this.MouseClick;
                control.MouseDown += this.MouseDown;
                control.MouseUp += this.MouseUp;
                control.MouseMove += this.MouseMove;
                control.MouseDoubleClick += this.MouseDoubleClick;

                // Рекурсивно для вложенных контролов
                if (control.HasChildren)
                {
                    SubscribeAllControls(control);
                }
            }
        }

        //main
        private void MouseDown(object sender, MouseEventArgs e)
        {
            string button = GetButtonName(e.Button);
            Console = $"MouseDown: {button} ({e.X}, {e.Y})";
            SetCheckBox(e.Button, true);

        }
        //main
        private void MouseUp(object sender, MouseEventArgs e)
        {
            SetCheckBox(e.Button, false );
            string button = GetButtonName(e.Button);
            Console = $"MouseUp: {button} ({e.X}, {e.Y})";
        }
        //main
        private void MouseMove(object sender, MouseEventArgs e)
        {
            string button = GetButtonName(e.Button);
            Console = $"MouseMove: {button} ({e.X}, {e.Y})";
        }

        //slave
        private void MouseClick(object sender, MouseEventArgs e)
        {
            string button = GetButtonName(e.Button);
            Console = $"MouseClick: {button}  ({e.X}, {e.Y})";
        }
        //slave
        private void MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string button = GetButtonName(e.Button);
            Console = $"MouseDoubleClick: {button}  ({e.X}, {e.Y})";
        }


        private string GetButtonName(MouseButtons button)
        {
            switch (button)
            {
                case MouseButtons.Left:
                    return "Left";
                case MouseButtons.Right:
                    return "Right";
                case MouseButtons.Middle:
                    return "Middle";
                default:
                    return "-";
            }
        }
        private void SetCheckBox(MouseButtons button, bool state)
        {
            switch (button)
            {
                case MouseButtons.Left:
                    RKMCheckBox.Checked = state;
                    break;

                case MouseButtons.Right:
                    MKMCheckBox.Checked = state;
                    break;

                case MouseButtons.Middle:
                    LKMCheckBox.Checked = state;
                    break;

                default:
                    return;
            }
        }
    }


}
