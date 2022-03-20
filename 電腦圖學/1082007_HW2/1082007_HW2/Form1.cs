using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace _1082007_HW2
{
    public partial class Form1 : Form
    {
        double tR = 0;
        int timercount = 0;
        double[] xrot = new double[9];
        double[] yrot = new double[9];
        const double DEGREE_TO_RAD = 0.01745329; // 3.1415926/180

        double radius = 10;
        int rot = 0;
        int cx = 0;
        int cy = 0;
        int cz = 0;
        int r = 50;
        double Rx = 0.0;
        double Ry = 1.0;
        double Rz = 3.0;
        double xstep = 1.0;
        double ystep = 2.0;
        double zstep = 1.0;


        int cwidth = 60;

        public Form1()
        {
            InitializeComponent();
            this.openGLControl1.InitializeContexts();
            Glut.glutInit();
        }
        private void MyInit()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClearDepth(1.0);
            Gl.glEnable(Gl.GL_DEPTH_TEST);

        }
        private void SetViewingVolume()
        {
            Gl.glViewport(0, 0, openGLControl1.Size.Width, openGLControl1.Size.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            double aspect = (double)openGLControl1.Size.Width /
                            (double)openGLControl1.Size.Height;

            Glu.gluPerspective(45, aspect, 0.1, 140.0);
        }
        private void openGLControl1_Load(object sender, EventArgs e)
        {
            MyInit();
            SetViewingVolume();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timercount > 0)
            {
                timercount -= 1;
                rot += 4;
            }
            else if (timercount < 0)
            {
                timercount += 1;
                rot -= 4;
            }
            else
            {
                timer1.Enabled = false;
            }
            this.openGLControl1.Refresh();

        }
        private void Sierpinski(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            int[,] T = new int[3, 2];
            Random rn = new Random();
            int index = rn.Next(0, 3);
            int[] point = new int[2];

            T[0, 0] = x1; T[0, 1] = y1;
            T[1, 0] = x2; T[1, 1] = y2;
            T[2, 0] = x3; T[2, 1] = y3;

            point[0] = T[index, 0]; point[1] = T[index, 1];
            Gl.glBegin(Gl.GL_POINTS);
            for (int i = 0; i < 3000; i++)
            {
                index = rn.Next(0, 3);
                point[0] = (point[0] + T[index, 0]) / 2;
                point[1] = (point[1] + T[index, 1]) / 2;
                Gl.glVertex2i(point[0], point[1]);
            }
            Gl.glEnd();
        }
        private void drawc(double dig)
        {
            Gl.glPushMatrix();
            Gl.glTranslated(Rx, Ry, Rz);
            Gl.glTranslated(0.0, 0.0, r);
            Gl.glRotated(dig, 1.0, 1.0, 1.0);
            int x1, y1, x2, y2, x3, y3;
            x1 = (int)(cx + radius * Math.Cos(rot * Math.PI / 180.0));
            y1 = (int)(cy + radius * Math.Sin(rot * Math.PI / 180.0));
            x2 = (int)(cx + radius * Math.Cos((rot + 120.0) * Math.PI / 180.0));
            y2 = (int)(cy + radius * Math.Sin((rot + 120.0) * Math.PI / 180.0));
            x3 = (int)(cx + radius * Math.Cos((rot - 120.0) * Math.PI / 180.0));
            y3 = (int)(cy + radius * Math.Sin((rot - 120.0) * Math.PI / 180.0));
            Sierpinski(x1, y1, x2, y2, x3, y3);
            x1 = (int)(cx + radius * Math.Cos((rot + 180.0) * Math.PI / 180.0));
            y1 = (int)(cy + radius * Math.Sin((rot + 180.0) * Math.PI / 180.0));
            x2 = (int)(cx + radius * Math.Cos((rot + 120.0 + 180.0) * Math.PI / 180.0));
            y2 = (int)(cy + radius * Math.Sin((rot + 120.0 + 180.0) * Math.PI / 180.0));
            x3 = (int)(cx + radius * Math.Cos((rot - 120.0 + 180.0) * Math.PI / 180.0));
            y3 = (int)(cy + radius * Math.Sin((rot - 120.0 + 180.0) * Math.PI / 180.0));
            Sierpinski(x1, y1, x2, y2, x3, y3);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            for (int i = 0; i < 360; i += 3)
                Gl.glVertex3d(cx + radius * Math.Cos(i * Math.PI / 180.0), cy + radius * Math.Sin(i * Math.PI / 180.0), cz);
            Gl.glEnd();
            Gl.glPopMatrix();
        }
        private void openGLControl1_Paint(object sender, PaintEventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(0.0, 0.0, 130.0, 0.0, 0.0,0.0, 0.0, 1.0, 0.0);
            Gl.glPushMatrix();
            Gl.glColor3ub(0, 0, 0);
            drawc(0+tR);
            drawc(30+tR);
            drawc(60+tR);
            drawc(90 + tR);
            drawc(120 + tR);
            drawc(150 + tR);
            Gl.glPopMatrix();
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glColor3ub(150, 150, 150);
            Gl.glVertex3i(-cwidth/2, -cwidth / 2, 0);
            Gl.glVertex3i(cwidth / 2, -cwidth / 2, 0);
            Gl.glVertex3i(cwidth / 2, cwidth / 2, 0);
            Gl.glVertex3i(-cwidth / 2, cwidth / 2, 0);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glColor3ub(255, 255, 0);
            Gl.glVertex3i(-cwidth / 2, -cwidth / 2, cwidth);
            Gl.glVertex3i(-cwidth / 2, -cwidth / 2, 0);
            Gl.glVertex3i(-cwidth / 2, cwidth / 2, 0);
            Gl.glVertex3i(-cwidth / 2, cwidth / 2, cwidth);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glColor3ub(255, 0, 0);
            Gl.glVertex3i(cwidth / 2, -cwidth / 2, cwidth);
            Gl.glVertex3i(cwidth / 2, -cwidth / 2, 0);
            Gl.glVertex3i(cwidth / 2, cwidth / 2, 0);
            Gl.glVertex3i(cwidth / 2, cwidth / 2, cwidth);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glColor3ub(255, 0, 255);
            Gl.glVertex3i(-cwidth / 2, cwidth / 2, cwidth);
            Gl.glVertex3i(-cwidth / 2, cwidth / 2, 0);
            Gl.glVertex3i(cwidth / 2, cwidth / 2, 0);
            Gl.glVertex3i(cwidth / 2, cwidth / 2, cwidth);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glColor3ub(0, 255, 255);
            Gl.glVertex3i(-cwidth / 2, -cwidth / 2, cwidth);
            Gl.glVertex3i(-cwidth / 2, -cwidth / 2, 0);
            Gl.glVertex3i(cwidth / 2, -cwidth / 2, 0);
            Gl.glVertex3i(cwidth / 2, -cwidth / 2, cwidth );
            Gl.glEnd();
            
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

            if (Rx + radius > cwidth/2 || Rx - radius < -cwidth/2) 
            {
                xstep = -xstep;
            }
            if (Ry + radius > cwidth / 2 || Ry - radius < -cwidth / 2) 
            {
                ystep = -ystep;
            }
            if (Rz + radius > cwidth || Rz - radius <-50) 
            {
                zstep = -zstep;
           }
            Rx -= xstep;
            Ry -= ystep;
            Rz -= zstep;
            tR++;
            this.openGLControl1.Refresh();
        }
    }
}
