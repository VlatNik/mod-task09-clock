using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace ClockLab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
            label1.Text = "";
            timer1.Enabled = true;
            timer1.Interval = 1000;
        }

        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            DateTime dt = DateTime.Now;
            Pen cir_pen = new Pen(Color.Black, 2);
            Brush brush = new SolidBrush(Color.Pink);
            Graphics g = e.Graphics;
            GraphicsState gs;
            this.Width = 1000;
            this.Height = 1000;
            g.TranslateTransform(Width / 2, Height / 2);
            g.ScaleTransform(Width / 400, Height / 400);
            g.DrawEllipse(cir_pen, -120, -120, 240, 240);
            gs = g.Save();
            Pen p = new Pen(new SolidBrush(Color.DarkRed), 4);
            Pen p2 = new Pen(new SolidBrush(Color.BlueViolet), 2);
            Pen p3 = new Pen(new SolidBrush(Color.Green), 6);

            for (int i = 1; i < 61; i++)
            {
                g.DrawLine(p2, 0, -120, 0, -105);
                g.RotateTransform(6);
                if (i % 5 == 0)
                    g.DrawLine(p, 0, -120, 0, -100);
                if (i % 15 == 0)
                    g.DrawLine(p, 0, -120, 0, -90);
            }

            gs = g.Save();
            g.RotateTransform(6 * (dt.Minute + (float)dt.Second / 60));
            g.DrawLine(p, 0, 0, 0, -75);
            g.Restore(gs);
            gs = g.Save();
            g.RotateTransform(6 * (float)dt.Second);
            g.DrawLine(p2, 0, 0, 0, -100);
            g.Restore(gs);
            gs = g.Save();
            g.RotateTransform(30 * (dt.Hour + (float)dt.Minute / 60 + (float)dt.Second / 3600));
            g.DrawLine(p3, 0, 0, 0, -50);
            g.Restore(gs);
            gs = g.Save();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            this.Invalidate();
            label1.Text = DateTime.Now.ToLongTimeString();
        }

        private void timer2_Tick_2(object sender, EventArgs e)
        {  
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            DoubleBuffered = true;
            
        }
    }
}
