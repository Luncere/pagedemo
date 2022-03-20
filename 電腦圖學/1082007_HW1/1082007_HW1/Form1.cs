using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.OpenGl;

namespace _1082007_HW1
{
    public partial class Form1 : Form
    {
        int EX = 0;
        int EY = 0;
        public Form1()
        {
            InitializeComponent();
            this.openGLControl1.InitializeContexts();
        }

        private void openGLControl1_Load(object sender, EventArgs e)
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0.0f, this.openGLControl1.Size.Width, 0.0f, this.openGLControl1.Size.Height);
        }

        private void openGLControl1_Paint(object sender, PaintEventArgs e)
        {
            Random rn = new Random();
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            if (EX % 3 == 0)
            {
                Gl.glBegin(Gl.GL_POINTS);
                Gl.glColor3f(1.0f, 1.0f, 1.0f);            
                for (int i = 0; i < 200; i++)
                {
                    Gl.glVertex2i(rn.Next(0, this.openGLControl1.Size.Width),
                                  rn.Next(0, this.openGLControl1.Size.Height));
                }
                Gl.glEnd();
            }
            Gl.glLineWidth(3);
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glColor3ub(255, 0, 0);
            Gl.glVertex2i(EX + 289, EY + 190);
            Gl.glColor3ub(255, 125, 0);
            Gl.glVertex2i(EX + 320, EY + 128);         
            Gl.glColor3ub(255, 255, 0);
            Gl.glVertex2i(EX + 239, EY + 67);
            Gl.glColor3ub(0, 255, 0);
            Gl.glVertex2i(EX + 194, EY + 101);
            Gl.glColor3ub(0, 0, 255);
            Gl.glVertex2i(EX + 129, EY + 83);
            Gl.glColor3ub(0, 255, 255);
            Gl.glVertex2i(EX + 74, EY + 74);
            Gl.glColor3ub(255, 0, 255);
            Gl.glVertex2i(EX + 20, EY + 10);
            Gl.glEnd();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (EX > 700)
            {
                EX = -500;
                EY = -250;
            }
            else
            {
                EX += 2;
                EY++;
            }
            this.openGLControl1.Refresh();
        }
    }
}
