using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1082007_HW3_2
{
    public partial class Form1 : Form
    {
        bool formtitle;
        int locationX, locationY;
        int widthX, heightY;
        int counter_step = 600;
        int speed = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            if (formtitle)
            {
                formtitle = false;
                this.Text = "鄭兆晉";
            }
            else
            {
                formtitle = true;
                this.Text = "1082007";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            formtitle = false;
            this.Text = "鄭兆晉";
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            label1.Text = "timer:" + counter_step.ToString();
            label2.Text = "Speed:" + speed.ToString();
            label3.Text = "10min泡麵";
            label1.Location = new System.Drawing.Point(0, (this.Size.Height - 136) / 2);
            label2.Location = new System.Drawing.Point((this.Size.Width - 250) / 2, 0);
            label3.Location = new System.Drawing.Point(0, 0);
            progressBar1.Location = new System.Drawing.Point(350, (this.Size.Height - 90) / 2);
           
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            locationX = this.Location.X;
            locationY = this.Location.Y;
            if (counter_step > speed)
            { 
                switch (e.KeyValue)
                {
                    case (char)37:
                        this.Location = new System.Drawing.Point(locationX - speed, locationY);
                        locationX -= speed;
                        counter_step -= speed;
                        break;
                    case (char)38:
                        this.Location = new System.Drawing.Point(locationX, locationY - speed);
                        locationY -= speed;
                        counter_step -= speed;
                        break;
                    case (char)39:
                        this.Location = new System.Drawing.Point(locationX + speed, locationY);
                        locationX += speed;
                        counter_step -= speed;
                        break;
                    case (char)40:
                        this.Location = new System.Drawing.Point(locationX, locationY + speed);
                        locationY -= speed;
                        counter_step -= speed;
                        break;
                }
                label1.Text = "timer:" + counter_step.ToString();
                progressBar1.Value = 100-(int)((double)counter_step * 100 / 600);
            }
            else
            {
                label1.Text = "timer:0";
                this.timer1.Enabled = false;
                MessageBox.Show("Finsh");
                Application.Exit();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (counter_step > 0)
            {
                counter_step--;
                label1.Text = "timer:" + counter_step.ToString();
            }
            else
            {
                this.timer1.Enabled = false;
                MessageBox.Show("Finsh");
                Application.Exit();
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
                this.BackColor = System.Drawing.Color.FromArgb((int)((double)e.X * 255 / (double)this.Size.Width), (int)((double)e.Y * 255 / (double)this.Size.Height), 0);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            widthX = this.Size.Width - 22;
            heightY = this.Size.Height - 56;
            label1.Location = new System.Drawing.Point(0, (heightY - 80) / 2);
            label2.Location = new System.Drawing.Point((widthX - 228) / 2, 0);
            switch (e.KeyChar)
            {
                case 'E':
                case 'e':
                    if (speed < 5)
                    {
                        this.Opacity -= 0.2;
                        speed++;
                        label2.Text = "Speed:" + speed.ToString();
                    }
                    break;
                case 'Q':
                case 'q':
                    if (speed > 1)
                    {
                        this.Opacity += 0.2;
                        speed--;
                        label2.Text = "Speed:" + speed.ToString();
                    }
                    break;
                case 'W':
                case 'w':
                    this.ClientSize = new System.Drawing.Size(widthX, --heightY);
                    break;
                case 'A':
                case 'a':
                    this.ClientSize = new System.Drawing.Size(--widthX, heightY);
                    break;
                case 'S':
                case 's':
                    this.ClientSize = new System.Drawing.Size(widthX, ++heightY);
                    break;
                case 'D':
                case 'd':
                    this.ClientSize = new System.Drawing.Size(++widthX, heightY);
                    break;
            }
       }
    }
}
