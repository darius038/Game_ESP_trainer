using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        private static Random r = new Random();

        int compNo = r.Next(1, 5);
        int picNo = r.Next(0, 7);

        int count = 0;

        //Image resources array
        private readonly string[] pic = { "h1", "h2", "h3", "h4", "h5", "h6", "h7" };

        public Form1()
        {
            InitializeComponent();
            Application.EnableVisualStyles();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Botton label/link
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitLink();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }       
        
        private void VisitLink()
        {
            System.Diagnostics.Process.Start("http://www.espresearch.com");
        }
               
        // Reset game
        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            count = 0;
            progressBar1.Value = 0;
            label1.Text = "0";
            label7.Text = "Tap the correct color to see a picture.";
        }
        // Green square
        private void button1_Click(object sender, EventArgs e)
        {
            ++count;
            countCalc();
            progressCalc(1, compNo);
        }
        // Yeallow square
        private void button2_Click(object sender, EventArgs e)
        {
            ++count;
            countCalc();
            progressCalc(2, compNo);
        }
        // Red square
        private void button3_Click(object sender, EventArgs e)
        {
            ++count;
            countCalc();
            progressCalc(3, compNo);
        }
        // Blue square
        private void button4_Click(object sender, EventArgs e)
        {
            ++count;
            countCalc();
            progressCalc(4, compNo);
        }

        // Select/dysplay random picture
        private void picDisplay()
        {
            pictureBox1.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(pic[picNo], Properties.Resources.Culture);
            picNo = r.Next(0, 7);
            pictureBox1.Visible = true;
            timer1.Interval = 1500;
            timer1.Start();
        }

        // Check user progress
        private void progressCalc(int u, int c)
        {
            if (u == c)
            {
                picDisplay();
                progressBar1.Value += 10;
            }
            else compSel(c);

            switch (progressBar1.Value / 10)
            {
                case int n when (n >= 4 && n < 8):
                    label7.Text = "Good begining!";
                    break;
                case int n when (n >= 8 && n < 12):
                    label7.Text = "ESP ability present!";
                    break;
                case int n when (n >= 12):
                    label7.Text = "Psychic, Medium, Oracle!";
                    break;
            }
        }

        //Show computer selection (button click simulation)
        private void compSel(int c)
        {
            switch (c)
            {
                case 1:
                    button1.BackColor = button1.FlatAppearance.MouseDownBackColor;
                    timer2.Interval = 1000;
                    timer2.Start();
                    break;
                case 2:
                    button2.BackColor = button2.FlatAppearance.MouseDownBackColor;
                    timer2.Interval = 1000;
                    timer2.Start();
                    break;
                case 3:
                    button3.BackColor = button3.FlatAppearance.MouseDownBackColor;
                    timer2.Interval = 1000;
                    timer2.Start();
                    break;
                case 4:
                    button4.BackColor = button4.FlatAppearance.MouseDownBackColor;
                    timer2.Interval = 1000;
                    timer2.Start();
                    break;
            }
        }

        //Count calculator
        private void countCalc()
        {
            label1.Text = count.ToString();
            if (count == 24)
            {
                panel2.Visible = true;
            }
            compNo = r.Next(1, 5);
        }

        //Timer for temporarily picture dysplay
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            timer1.Stop();
        }

        //Timer to show computer choise
        private void timer2_Tick(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightGreen;
            button2.BackColor = Color.Khaki;
            button3.BackColor = Color.Salmon;
            button4.BackColor = Color.LightSkyBlue;
            timer2.Stop();
        }

        //Minimize window
        private void label3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Close window
        private void label4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        //For draging window
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CAPTION = 0x2;      
    }
}
