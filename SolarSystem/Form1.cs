using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolarSystem
{
    public partial class Form1 : Form
    {
        PictureBox sun = new PictureBox();
        Mercury merc = new Mercury();
        Venus ven = new Venus();

        public Form1()
        {
            InitializeComponent();

            sun = pictureBox2;
            sun.Location = new Point(this.ClientRectangle.Width / 2 - 40, this.ClientRectangle.Height / 2 - 40);
            merc.icon = pictureBox1;
            merc.timer = new Timer();
            merc.timer.Interval = 20;
            merc.centerPositionX = this.ClientRectangle.Width / 2;
            merc.centerPositionY = this.ClientRectangle.Height / 2;
            merc.radiusOrbit = 58;
            merc.speedSpin = 0.416;
            merc.timer.Tick += new EventHandler(merc.timer_Tick);
            merc.timer.Start();
            ven.icon = pictureBox3;
            ven.timer = new Timer();
            ven.timer.Interval = 20;
            ven.centerPositionX = this.ClientRectangle.Width / 2;
            ven.centerPositionY = this.ClientRectangle.Height / 2;
            ven.radiusOrbit = 108;
            ven.speedSpin = 0.416;
            ven.timer.Tick += new EventHandler(ven.timer_Tick);
            ven.timer.Start();
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
        public int Size;
        public PictureBox icon;
        public Timer timer;
        public double angle = 0;

        public void timer_Tick(object sender, EventArgs e)
        {
            Xposition = (int)(radiusOrbit  * Math.Sin(angle) + (centerPositionX - 15));
            Yposition = (int)(radiusOrbit * Math.Cos(angle) + (centerPositionY - 15));
            icon.Location = new Point(Xposition, Yposition);
            angle = angle + ((double)1 / radiusOrbit) * speedSpin * 10;
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
        public int Size;
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
}
