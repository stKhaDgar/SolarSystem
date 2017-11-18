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
            Xposition = (int)((radiusOrbit + 20) * Math.Sin(angle) + (centerPositionX - 15));
            Yposition = (int)((radiusOrbit + 20) * Math.Cos(angle) + (centerPositionY - 15));
            icon.Location = new Point(Xposition, Yposition);
            angle = angle + 0.05 * speedSpin;
        }
    }
}
