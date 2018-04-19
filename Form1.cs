using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoticeTime
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Location = Properties.Settings.Default.Pos; 
        }

        Point mPoint = new Point();
        DateTime odt = DateTime.Parse(Properties.Settings.Default.dt);

        private void timer_Tick(object sender, EventArgs e)
        {
            String str = ((int)(DateTime.Now - odt).TotalSeconds).ToString("X");
            String s = String.Empty;
            for (int i = 0; i < 8; i++)
            {
                switch (str[i])
                {
                    case '0':
                        s += "□□□□";
                        break;
                    case '1':
                        s += "□□□■";
                        break;
                    case '2':
                        s += "□□■□";
                        break;
                    case '3':
                        s += "□□■■";
                        break;
                    case '4':
                        s += "□■□□";
                        break;
                    case '5':
                        s += "□■□■";
                        break;
                    case '6':
                        s += "□■■□";
                        break;
                    case '7':
                        s += "□■■■";
                        break;
                    case '8':
                        s += "■□□□";
                        break;
                    case '9':
                        s += "■□□■";
                        break;
                    case 'A':
                        s += "■□■□";
                        break;
                    case 'B':
                        s += "■□■■";
                        break;
                    case 'C':
                        s += "■■□□";
                        break;
                    case 'D':
                        s += "■■□■";
                        break;
                    case 'E':
                        s += "■■■□";
                        break;
                    case 'F':
                        s += "■■■■";
                        break;
                }
                if (i % 2 == 1)
                    s += "\n";
            }
            label1.Text = s;
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint.X = e.X;
            mPoint.Y = e.Y;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point myPosittion = MousePosition;
                myPosittion.Offset(-mPoint.X, -mPoint.Y);
                Location = myPosittion;
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Pos = Location;
            Properties.Settings.Default.Save();
            Close();
        }
    }
}
