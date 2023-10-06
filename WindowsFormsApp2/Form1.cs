using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Timer timerBaku = new Timer();
        Timer timerLondon = new Timer();
        TimeZoneInfo londonTimeZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
        public Form1()
        {
            InitializeComponent();


            timelbl.Text = DateTime.Now.ToLongTimeString();

            timerBaku.Interval = 1000;
            timerBaku.Tick += Timer_Tick;
            timerBaku.Start(); 
        }
        private void Timer_Tick(object sender, EventArgs e)
        {

            timelbl.Text = DateTime.Now.ToLongTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowLondonTime();
            this.BackgroundImage = Properties.Resources.london_image;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowBakuTime();
            this.BackgroundImage = Properties.Resources.baki_image;
        }
        private void ShowLondonTime()
        {
            timerBaku.Stop();
            DateTime londonTime = TimeZoneInfo.ConvertTime(DateTime.Now, londonTimeZone);
            timelbl.Text = londonTime.ToLongTimeString();

            
            timerLondon.Interval = 1000;
            timerLondon.Tick += TimerLondon_Tick;
            timerLondon.Start();
        }

        private void ShowBakuTime()
        {
            timerLondon.Stop(); 
            timerBaku.Start();
            timelbl.Text = DateTime.Now.ToLongTimeString();
        }

        private void TimerLondon_Tick(object sender, EventArgs e)
        {
            ShowLondonTime(); 
        }
    }
}
