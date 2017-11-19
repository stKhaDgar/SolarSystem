using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace SolarSystem
{


    public partial class Form1 : Form
    {
        
        PictureBox sun = new PictureBox();
        Mercury merc = new Mercury();
        Venus ven = new Venus();
        Earth earth = new Earth();
        Mars mars = new Mars();
        Earth.Moon moon = new Earth.Moon();
        Mars.Phobos phob = new Mars.Phobos();
        Mars.Deimos dei = new Mars.Deimos();
        
        public Form1()
        {
            InitializeComponent();
            
            // Sun
            sun = pictureBox2;
            sun.Location = new Point(this.ClientRectangle.Width / 2 - 40, this.ClientRectangle.Height / 2 - 40);

            // Mercury
            merc.icon = pictureBox1;
            merc.draw = pictureBox9;
            merc.timerdraw = new Timer();
            merc.timerdraw.Interval = 1000;
            merc.timerdraw.Tick += new EventHandler(merc.timer_P);
            merc.timerdraw.Start();
            merc.timer = new Timer();
            merc.timer.Interval = 5;
            merc.centerPositionX = this.ClientRectangle.Width / 2;
            merc.centerPositionY = this.ClientRectangle.Height / 2;
            merc.radiusOrbit = 58;
            merc.speedSpin = 0.416;
            merc.timer.Tick += new EventHandler(merc.timer_Tick);
            merc.timer.Start();
            

            // Venus
            ven.icon = pictureBox3;
            ven.timer = new Timer();
            ven.timer.Interval = 20;
            ven.centerPositionX = this.ClientRectangle.Width / 2;
            ven.centerPositionY = this.ClientRectangle.Height / 2;
            ven.radiusOrbit = 108;
            ven.speedSpin = 0.416;
            ven.timer.Tick += new EventHandler(ven.timer_Tick);
            ven.timer.Start();

            // Earth
            earth.icon = pictureBox4;
            earth.timer = new Timer();
            earth.timer.Interval = 20;
            earth.centerPositionX = this.ClientRectangle.Width / 2;
            earth.centerPositionY = this.ClientRectangle.Height / 2;
            earth.radiusOrbit = 150;
            earth.speedSpin = 0.1;
            earth.timer.Tick += new EventHandler(earth.timer_Tick);
            earth.timer.Start();

            // Mars
            mars.icon = pictureBox5;
            mars.timer = new Timer();
            mars.timer.Interval = 20;
            mars.centerPositionX = this.ClientRectangle.Width / 2;
            mars.centerPositionY = this.ClientRectangle.Height / 2;
            mars.radiusOrbit = 228;
            mars.speedSpin = 0.053;
            mars.timer.Tick += new EventHandler(mars.timer_Tick);
            mars.timer.Start();

            // Moon
            moon.ear = earth;
            moon.icon = pictureBox6;
            moon.timer = new Timer();
            moon.timer.Interval = 20;
            moon.centerPositionX = earth.Xposition;
            moon.centerPositionY = earth.Yposition;
            moon.radiusOrbit = 15;
            moon.speedSpin = 0.1;
            moon.timer.Tick += new EventHandler(moon.timer_Tick);
            moon.timer.Start();

            // Phobos
            phob.mar = mars;
            phob.icon = pictureBox7;
            phob.timer = new Timer();
            phob.timer.Interval = 20;
            phob.centerPositionX = mars.Xposition;
            phob.centerPositionY = mars.Yposition;
            phob.radiusOrbit = 7;
            phob.speedSpin = 0.3;
            phob.timer.Tick += new EventHandler(phob.timer_Tick);
            phob.timer.Start();

            // Deimos
            dei.mar = mars;
            dei.icon = pictureBox8;
            dei.timer = new Timer();
            dei.timer.Interval = 20;
            dei.centerPositionX = mars.Xposition;
            dei.centerPositionY = mars.Yposition;
            dei.radiusOrbit = 12;
            dei.speedSpin = 0.1;
            dei.timer.Tick += new EventHandler(dei.timer_Tick);
            dei.timer.Start();

            pictureBox9.Paint += new PaintEventHandler(this.orbitPaint);
        }

        private void orbitPaint(object sender,
   System.Windows.Forms.PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            System.Drawing.Pen myPen;
            myPen = new System.Drawing.Pen(System.Drawing.Color.LightGray, 2);

            
            for (double angle=0; angle < 2 * 3.14;)
            {
               /* int Xposition = (int)(58 * Math.Sin(angle) + (this.ClientRectangle.Width / 2));
                int Yposition = (int)(58 * Math.Cos(angle) + (this.ClientRectangle.Height / 2));
                g.DrawLine(myPen, Xposition, Yposition, Xposition+1, Yposition+1); */

                int Xposition2 = (int)(108 * Math.Sin(angle) + (this.ClientRectangle.Width / 2));
                int Yposition2 = (int)(108 * Math.Cos(angle) + (this.ClientRectangle.Height / 2));
                g.DrawLine(myPen, Xposition2, Yposition2, Xposition2 + 1, Yposition2 + 1);

                int Xposition3 = (int)(200 * Math.Sin(angle) + (this.ClientRectangle.Width / 2));
                int Yposition3 = (int)(200 * Math.Cos(angle) + (this.ClientRectangle.Height / 2));
                g.DrawLine(myPen, Xposition3, Yposition3, Xposition3 + 1, Yposition3 + 1);

                int Xposition4 = (int)(278 * Math.Sin(angle) + (this.ClientRectangle.Width / 2));
                int Yposition4 = (int)(278 * Math.Cos(angle) + (this.ClientRectangle.Height / 2));
                g.DrawLine(myPen, Xposition4, Yposition4, Xposition4 + 1, Yposition4 + 1);
                angle = angle + 0.15;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }

    public class Mercury
    {
        public int Xposition;
        public int Yposition;
        public int centerPositionX;
        public int centerPositionY;
        public int radiusOrbit;
        public double speedSpin;
        public PictureBox icon;
        public Timer timer;
        public Timer timerdraw;
        public double angle = 0;
        public PictureBox draw;

        public void timer_Tick(object sender, EventArgs e)
        {
            Xposition = (int)(radiusOrbit  * Math.Sin(angle) + (centerPositionX - 15));
            Yposition = (int)(radiusOrbit * Math.Cos(angle) + (centerPositionY - 15));
            icon.Location = new Point(Xposition, Yposition);
            angle = angle + ((double)1 / radiusOrbit) * speedSpin * 10;
        }

        public void timer_P(object sender, EventArgs e)
        {
            draw.Paint += new PaintEventHandler(timer_Paint);
        }

        public void timer_Paint(object sender, System.Windows.Forms.PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            System.Drawing.Pen myPen;
            myPen = new System.Drawing.Pen(System.Drawing.Color.LightGray, 25);
            g.DrawLine(myPen, Xposition, Yposition, Xposition+2, Yposition+2);
        }

    }

    public class Venus
    {
        public int Xposition;
        public int Yposition;
        public int centerPositionX;
        public int centerPositionY;
        public double radiusOrbit;
        public double speedSpin;
        public PictureBox icon;
        public Timer timer;
        public double angle = 0;

        public void timer_Tick(object sender, EventArgs e)
        {
            Xposition = (int)(radiusOrbit  * Math.Sin(angle) + (centerPositionX - 25));
            Yposition = (int)(radiusOrbit * Math.Cos(angle) + (centerPositionY - 25));
            icon.Location = new Point(Xposition, Yposition);
            angle = angle + ((double)1 / radiusOrbit) * speedSpin * 10;
        }
    }

    public class Earth
    {
        public int Xposition;
        public int Yposition;
        public int centerPositionX;
        public int centerPositionY;
        public double radiusOrbit;
        public double speedSpin;
        public PictureBox icon;
        public Timer timer;
        public double angle = 0;

        public void timer_Tick(object sender, EventArgs e)
        {
            Xposition = (int)((50+radiusOrbit) * Math.Sin(angle) + (centerPositionX - 30));
            Yposition = (int)((50+radiusOrbit) * Math.Cos(angle) + (centerPositionY - 30));
            icon.Location = new Point(Xposition, Yposition);
            angle = angle + ((double)1 / radiusOrbit) * speedSpin * 10;
        }

        public class Moon
        {
            public int Xposition;
            public int Yposition;
            public int centerPositionX;
            public int centerPositionY;
            public double radiusOrbit;
            public double speedSpin;
            public PictureBox icon;
            public Timer timer;
            public double angle = 0;
            public Earth ear;

            public void timer_Tick(object sender, EventArgs e)
            {
                Xposition = (int)((30 + radiusOrbit) * Math.Sin(angle) + (ear.Xposition + 20));
                Yposition = (int)((30 + radiusOrbit) * Math.Cos(angle) + (ear.Yposition + 20));
                icon.Location = new Point(Xposition, Yposition);
                angle = angle + ((double)1 / radiusOrbit) * speedSpin * 10;
            }
        }
    }

    public class Mars
    {
        public int Xposition;
        public int Yposition;
        public int centerPositionX;
        public int centerPositionY;
        public double radiusOrbit;
        public double speedSpin;
        public PictureBox icon;
        public Timer timer;
        public double angle = 0;

        public void timer_Tick(object sender, EventArgs e)
        {
            Xposition = (int)((50 + radiusOrbit) * Math.Sin(angle) + (centerPositionX - 20));
            Yposition = (int)((50 + radiusOrbit) * Math.Cos(angle) + (centerPositionY - 20));
            icon.Location = new Point(Xposition, Yposition);
            angle = angle + ((double)1 / radiusOrbit) * speedSpin * 10;
        }

        public class Phobos
        {
            public int Xposition;
            public int Yposition;
            public int centerPositionX;
            public int centerPositionY;
            public double radiusOrbit;
            public double speedSpin;
            public PictureBox icon;
            public Timer timer;
            public double angle = 0;
            public Mars mar;

            public void timer_Tick(object sender, EventArgs e)
            {
                Xposition = (int)((20 + radiusOrbit) * Math.Sin(angle) + (mar.Xposition + 15));
                Yposition = (int)((20 + radiusOrbit) * Math.Cos(angle) + (mar.Yposition + 15));
                icon.Location = new Point(Xposition, Yposition);
                angle = angle + ((double)1 / radiusOrbit) * speedSpin * 10;
            }
        }

        public class Deimos
        {
            public int Xposition;
            public int Yposition;
            public int centerPositionX;
            public int centerPositionY;
            public double radiusOrbit;
            public double speedSpin;
            public PictureBox icon;
            public Timer timer;
            public double angle = 0;
            public Mars mar;

            public void timer_Tick(object sender, EventArgs e)
            {
                Xposition = (int)((25 + radiusOrbit) * Math.Sin(angle) + (mar.Xposition + 15));
                Yposition = (int)((25 + radiusOrbit) * Math.Cos(angle) + (mar.Yposition + 15));
                icon.Location = new Point(Xposition, Yposition);
                angle = angle + ((double)1 / radiusOrbit) * speedSpin * 10;
            }
        }
    }

}
