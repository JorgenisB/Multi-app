using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiapp
{
    public partial class Paint : Form
    {

        Graphics Gr;
        int x = -1;
        int y = -1;
        bool mov;
        Pen pen;

        public Paint()
        {
            InitializeComponent();
            Gr = panel1.CreateGraphics();
            Gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 5);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void Paint_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = true;
            x = e.X;
            y = e.Y;
            panel1.Cursor = Cursors.Cross;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov && x != -1 && y != -1)
            {
                Gr.DrawLine(pen, new Point(x,y), e.Location);
                x = e.X;
                y = e.Y;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = false;
            x = -1;
            y = -1;
            panel1.Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pen = new Pen(Color.White, 20);
        }
    }
}
