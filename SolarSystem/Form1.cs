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
        PictureBox sun = new PictureBox();          // Sun
        Mercury merc = new Mercury();               // Mercury
        Venus ven = new Venus();                    // Venus
        Earth earth = new Earth();                  // Earth
        Mars mars = new Mars();                     // Mars
        Earth.Moon moon = new Earth.Moon();         // Moon
        Mars.Phobos phob = new Mars.Phobos();       // Phobos
        Mars.Deimos dei = new Mars.Deimos();        // Deimos
        Timer paintOrbitPlanets = new Timer();      // Timer for drawing the orbits of the planets
        Timer Log = new Timer();
        int LogLine = 0;

        public Form1()
        {
            InitializeComponent();

            // Sun
            sun = pictureBox2;
            sun.Location = new Point(this.ClientRectangle.Width / 2 - 40, this.ClientRectangle.Height / 2 - 40);

            // Mercury
            merc.icon = pictureBox1;
            merc.labelLocation = label22;
            merc.timer = new Timer();
            merc.timer.Interval = 5;
            merc.centerPositionX = this.ClientRectangle.Width / 2;
            merc.centerPositionY = this.ClientRectangle.Height / 2;
            merc.radiusOrbit = 58;
            merc.speedSpin = 0.416;
            merc.timer.Start();
            
            // Venus
            ven.icon = pictureBox3;
            ven.labelLocation = label27;
            ven.timer = new Timer();
            ven.timer.Interval = 20;
            ven.centerPositionX = this.ClientRectangle.Width / 2;
            ven.centerPositionY = this.ClientRectangle.Height / 2;
            ven.radiusOrbit = 108;
            ven.speedSpin = 0.416;
            ven.timer.Start();

            // Earth
            earth.icon = pictureBox4;
            earth.labelLocation = label38;
            earth.timer = new Timer();
            earth.timer.Interval = 20;
            earth.centerPositionX = this.ClientRectangle.Width / 2;
            earth.centerPositionY = this.ClientRectangle.Height / 2;
            earth.radiusOrbit = 150;
            earth.speedSpin = 0.1;
            earth.timer.Start();

            // Mars
            mars.icon = pictureBox5;
            mars.labelLocation = label45;
            mars.timer = new Timer();
            mars.timer.Interval = 20;
            mars.centerPositionX = this.ClientRectangle.Width / 2;
            mars.centerPositionY = this.ClientRectangle.Height / 2;
            mars.radiusOrbit = 228;
            mars.speedSpin = 0.053;
            mars.timer.Start();

            // Moon
            moon.ear = earth;
            moon.labelLocation = label52;
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
            phob.labelLocation = label59;
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
            dei.labelLocation = label66;
            dei.icon = pictureBox8;
            dei.timer = new Timer();
            dei.timer.Interval = 20;
            dei.centerPositionX = mars.Xposition;
            dei.centerPositionY = mars.Yposition;
            dei.radiusOrbit = 12;
            dei.speedSpin = 0.1;
            dei.timer.Tick += new EventHandler(dei.timer_Tick);
            dei.timer.Start();

            // Timer for drawing the orbits of the planets
            paintOrbitPlanets.Interval = 50;
            paintOrbitPlanets.Start();

            Log.Interval = 100;
            Log.Tick += new EventHandler(LogStart);
            Log.Start();
        }

        //
        public void LogStart(object sender, EventArgs e)
        {
            switch (LogLine)
            {
                case (0):
                    label13.Text = "/ Running the standard program modules...";
                    Log.Interval = 100;
                    break;
                case (1):
                    label1.Text = "Running the program...";
                    Log.Interval = 600;
                    break;
                case (2):
                    label2.Text = "# The program was launched";
                    Log.Interval = 50;
                    break;
                case (3):
                    label3.Text = "Making the Sun...";
                    Log.Interval = 1500;
                    break;
                case (4):
                    label4.Text = "# The Sun is created";
                    sun.Visible = true;
                    label17.Text = "Sun";
                    label18.Text = "Location:";
                    label19.Text = "X: " + this.ClientRectangle.Width / 2 + ", Y: " + this.ClientRectangle.Height / 2;
                    label32.Text = "Size:";
                    label33.Text = "3";
                    Log.Interval = 50;
                    break;
                case (5):
                    label5.Text = "Create the other planets...";
                    Log.Interval = 2500;
                    break;
                case (6):
                    label6.Text = "# Other planets is created";

                    merc.icon.Visible = true;
                    label20.Text = "Mercury";
                    label21.Text = "Location:";
                    label22.Text = "X: 525, Y: 371";
                    label23.Text = "Speed:";
                    label24.Text = merc.speedSpin.ToString();
                    label30.Text = "Size:";
                    label31.Text = "3";

                    ven.icon.Visible = true;
                    label25.Text = "Venus";
                    label26.Text = "Location:";
                    label27.Text = "X: 515, Y: 411";
                    label28.Text = "Speed:";
                    label29.Text = ven.speedSpin.ToString();
                    label34.Text = "Size:";
                    label35.Text = "2";

                    earth.icon.Visible = true;
                    label36.Text = "Earth";
                    label37.Text = "Location:";
                    label38.Text = "X: 510, Y: 498";
                    label39.Text = "Speed:";
                    label40.Text = earth.speedSpin.ToString();
                    label41.Text = "Size:";
                    label42.Text = "6";

                    mars.icon.Visible = true;
                    label43.Text = "Mars";
                    label44.Text = "Location:";
                    label45.Text = "X: 520, Y: 606";
                    label46.Text = "Speed:";
                    label47.Text = mars.speedSpin.ToString();
                    label48.Text = "Size:";
                    label49.Text = "4";

                    Log.Interval = 50;
                    break;
                case (7):
                    label7.Text = "Attempt to move planets...";
                    Log.Interval = 1500;
                    break;
                case (8):
                    label8.Text = "# The planets began to move";
                    merc.timer.Tick += new EventHandler(merc.timer_Tick);
                    ven.timer.Tick += new EventHandler(ven.timer_Tick);
                    earth.timer.Tick += new EventHandler(earth.timer_Tick);
                    mars.timer.Tick += new EventHandler(mars.timer_Tick);
                    Log.Interval = 50;
                    break;
                case (9):
                    label9.Text = "Create satellites of the planets...";
                    Log.Interval = 2000;
                    break;
                case (10):
                    label10.Text = "# Satellites of planets created";
                    moon.icon.Visible = true;
                    label50.Text = "Moon";
                    label51.Text = "Location:";
                    label52.Visible = true;
                    label53.Text = "Speed:";
                    label54.Text = moon.speedSpin.ToString();
                    label55.Text = "Size:";
                    label56.Text = "2";

                    phob.icon.Visible = true;
                    label57.Text = "Phobos";
                    label58.Text = "Location:";
                    label59.Visible = true;
                    label60.Text = "Speed:";
                    label61.Text = phob.speedSpin.ToString();
                    label62.Text = "Size:";
                    label63.Text = "1";

                    dei.icon.Visible = true;
                    label64.Text = "Deimos";
                    label65.Text = "Location:";
                    label66.Visible = true;
                    label67.Text = "Speed:";
                    label68.Text = dei.speedSpin.ToString();
                    label69.Text = "Size:";
                    label70.Text = "1";

                    Log.Interval = 50;
                    break;
                case (11):
                    label14.Text = "/ Modules are started";
                    Log.Interval = 500;
                    break;
                case (12):
                    label15.Text = "/ Running additional program modules...";
                    Log.Interval = 100;
                    break;
                case (13):
                    label11.Text = "Running the function of drawing the orbits...";
                    Log.Interval = 2000;
                    break;
                case (14):
                    label12.Text = "# The function of drawing the orbits is started";
                    paintOrbitPlanets.Tick += new EventHandler(orbitPaintTimer);
                    Log.Interval = 50;
                    break;
                case (15):
                    label16.Text = "/ Modules are started";
                    break;
            }
            LogLine++;
        }

        // Function-timer for drawing the orbits of the planets
        public void orbitPaintTimer(object sender, EventArgs e)
        {
            pictureBox9.Paint += new PaintEventHandler(this.orbitPaint);
        }
      
        // Function for drawing the orbits of the planets
        private void orbitPaint(object sender,
        System.Windows.Forms.PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            System.Drawing.Pen myPen;
            myPen = new System.Drawing.Pen(System.Drawing.Color.LightGray, 2);

            for (double angle=0; angle < 2 * 3.14;)
            {
                // Stop the timer
                paintOrbitPlanets.Stop();

                int Xposition = (int)(58 * Math.Sin(angle) + (this.ClientRectangle.Width / 2));
                int Yposition = (int)(58 * Math.Cos(angle) + (this.ClientRectangle.Height / 2));
                g.DrawLine(myPen, Xposition, Yposition, Xposition+1, Yposition+1);

                int Xposition2 = (int)(108 * Math.Sin(angle) + (this.ClientRectangle.Width / 2));
                int Yposition2 = (int)(108 * Math.Cos(angle) + (this.ClientRectangle.Height / 2));
                g.DrawLine(myPen, Xposition2, Yposition2, Xposition2 + 1, Yposition2 + 1);

                int Xposition3 = (int)(200 * Math.Sin(angle) + (this.ClientRectangle.Width / 2));
                int Yposition3 = (int)(200 * Math.Cos(angle) + (this.ClientRectangle.Height / 2));
                g.DrawLine(myPen, Xposition3, Yposition3, Xposition3 + 1, Yposition3 + 1);

                int Xposition4 = (int)(298 * Math.Sin(angle) + (this.ClientRectangle.Width / 2));
                int Yposition4 = (int)(298 * Math.Cos(angle) + (this.ClientRectangle.Height / 2));
                g.DrawLine(myPen, Xposition4, Yposition4, Xposition4+1 , Yposition4+1);

                angle = angle + 0.15;
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
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
        public double angle = 0;
        public Label labelLocation;

        public void timer_Tick(object sender, EventArgs e)
        {
            Xposition = (int)(radiusOrbit * Math.Sin(angle) + (centerPositionX - 15));
            Yposition = (int)(radiusOrbit * Math.Cos(angle) + (centerPositionY - 15));
            icon.Location = new Point(Xposition, Yposition);
            angle = angle + ((double)1 / radiusOrbit) * speedSpin * 10;
            labelLocation.Text = "X: " + Xposition + ", Y: " + Yposition;
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
        public Label labelLocation;

        public void timer_Tick(object sender, EventArgs e)
        {
            Xposition = (int)(radiusOrbit  * Math.Sin(angle) + (centerPositionX - 25));
            Yposition = (int)(radiusOrbit * Math.Cos(angle) + (centerPositionY - 25));
            icon.Location = new Point(Xposition, Yposition);
            angle = angle + ((double)1 / radiusOrbit) * speedSpin * 10;
            labelLocation.Text = "X: " + Xposition + ", Y: " + Yposition;
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
        public Label labelLocation;

        public void timer_Tick(object sender, EventArgs e)
        {
            Xposition = (int)((50+radiusOrbit) * Math.Sin(angle) + (centerPositionX - 30));
            Yposition = (int)((50+radiusOrbit) * Math.Cos(angle) + (centerPositionY - 30));
            icon.Location = new Point(Xposition, Yposition);
            angle = angle + ((double)1 / radiusOrbit) * speedSpin * 10;
            labelLocation.Text = "X: " + Xposition + ", Y: " + Yposition;
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
            public Label labelLocation;

            public void timer_Tick(object sender, EventArgs e)
            {
                Xposition = (int)((30 + radiusOrbit) * Math.Sin(angle) + (ear.Xposition + 20));
                Yposition = (int)((30 + radiusOrbit) * Math.Cos(angle) + (ear.Yposition + 20));
                icon.Location = new Point(Xposition, Yposition);
                angle = angle + ((double)1 / radiusOrbit) * speedSpin * 10;
                labelLocation.Text = "X: " + Xposition + ", Y: " + Yposition;
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
        public Label labelLocation;

        public void timer_Tick(object sender, EventArgs e)
        {
            Xposition = (int)((70 + radiusOrbit) * Math.Sin(angle) + (centerPositionX - 20));
            Yposition = (int)((70 + radiusOrbit) * Math.Cos(angle) + (centerPositionY - 20));
            icon.Location = new Point(Xposition, Yposition);
            angle = angle + ((double)1 / radiusOrbit) * speedSpin * 10;
            labelLocation.Text = "X: " + Xposition + ", Y: " + Yposition;
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
            public Label labelLocation;

            public void timer_Tick(object sender, EventArgs e)
            {
                Xposition = (int)((20 + radiusOrbit) * Math.Sin(angle) + (mar.Xposition + 15));
                Yposition = (int)((20 + radiusOrbit) * Math.Cos(angle) + (mar.Yposition + 15));
                icon.Location = new Point(Xposition, Yposition);
                angle = angle + ((double)1 / radiusOrbit) * speedSpin * 10;
                labelLocation.Text = "X: " + Xposition + ", Y: " + Yposition;
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
            public Label labelLocation;

            public void timer_Tick(object sender, EventArgs e)
            {
                Xposition = (int)((25 + radiusOrbit) * Math.Sin(angle) + (mar.Xposition + 15));
                Yposition = (int)((25 + radiusOrbit) * Math.Cos(angle) + (mar.Yposition + 15));
                icon.Location = new Point(Xposition, Yposition);
                angle = angle + ((double)1 / radiusOrbit) * speedSpin * 10;
                labelLocation.Text = "X: " + Xposition + ", Y: " + Yposition;
            }
        }
    }
}
