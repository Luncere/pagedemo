using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1082007_final_project
{
    public partial class Form1 : Form
    {
        int score;
        int highscore;
        int level;
        int ball;
        bool gold;
        Point point_p;
        Point []point_c=new Point[5];
        Graphics g;
        int player_size=20;

        public Form1()
        {
            InitializeComponent();
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            Start_btn.Enabled = false;
            level = 1;
            score = 0;
            ball = 1;
            show_level.Text = "Level: " + level;
            Show_Score_count.Text = "Score: " + score;
            timer1.Interval = 100;
            timer1.Enabled = true;
            for (int i = 0; i < 3; i++) {
                point_c[i].X = 500;
                point_c[i].Y = 500;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            score++;
            Show_Score_count.Text = "Score: " + score;
            g = this.pictureBox1.CreateGraphics();
            Pen pen_b = new Pen(Color.Black);
            Pen pen_r = new Pen(Color.Red);
            g.Clear(Color.White);
            for (int i = 0; i < ball; i++)
            {
                point_c[i]=computer_move(point_c[i]);
            }
            if (IsHit())
            {
                timer1.Enabled = false;
                if (score > highscore)
                {
                    highscore = score;
                    show_HighScore.Text = highscore.ToString();
                    MessageBox.Show("HighScore: " + highscore);
                }
                else {
                    MessageBox.Show("Score: " + score);
                }
                Start_btn.Enabled = true;
            }
            for(int i = 0; i < ball; i++)
            {
                for(int j = i +1; j < ball; j++)
                {
                    if(point_c[i].X==point_c[j].X&& point_c[i].Y == point_c[j].Y)
                    {
                        point_c[i] = point_lock(point_c[i]);
                    }
                }
            }
            if (score > level * (50*level))
            {
                level++;
                show_level.Text = "Level: " + level;
                if (level >ball&&ball!=5)
                {
                    ball++;
                }
                if (timer1.Interval > 50)
                {
                    timer1.Interval -= 25;
                }
                if (player_size < 200)
                {
                    player_size += 10;
                }
            }
            g.DrawEllipse(pen_b, point_p.X - player_size/2, point_p.Y - player_size/2, player_size, player_size);
            for (int i = 0; i < ball; i++)
            {
                g.DrawEllipse(pen_r, point_c[i].X, point_c[i].Y, 20, 10);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gold=true;
            highscore = 0;
            this.Text = "普通模式";
            timer1.Enabled = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            point_p.X = e.X;
            point_p.Y = e.Y;
        }
        Point computer_move(Point name)
        {
            if (name.X > point_p.X)
            {
                name.X -= 10;
            }
            else
            {
                name.X += 10;
            }
            if (name.Y > point_p.Y)
            {
                name.Y -= 10;
            }
            else
            {
                name.Y += 10;
            }
            return name;
        }
        Point point_lock(Point name)
        {
            name.X = 500;
            name.Y = 500;
            return name;
        }
        bool IsHit()
        {
            int gap_X;
            int gap_Y;
            for (int i = 0; i < ball; i++)
            {
                gap_X = Math.Abs(point_c[i].X - point_p.X);
                gap_Y = Math.Abs(point_c[i].Y - point_p.Y);
                if (gap_X <= player_size / 2 && gap_Y <= player_size / 2)
                {
                    return gold;
                }
            }
                return false;
        }

        private void god_btn_Click(object sender, EventArgs e)
        {
            if (gold)
            {
                gold = false;
                this.Text = "金手指:開啟中";
            }
            else
            {
                gold = true;
                this.Text = "普通模式";
            }
        }
    }
}
