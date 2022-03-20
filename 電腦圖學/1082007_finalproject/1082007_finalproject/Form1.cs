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

namespace _1082007_finalproject
{
    public partial class Form1 : Form
    {
        const double DEGREE_TO_RAD = 0.01745329; // 3.1415926/180
        double Radius = 15.0, Longitude = 0.0, Latitude = 0.0;
        DateTime localDate = DateTime.Now;
        Boolean lightIO_0 = false;

        public Form1()
        {
            InitializeComponent();
            this.openGLControl1.InitializeContexts();
            Glut.glutInit();
        }
        private void SetViewingVolume()
        {
            Gl.glViewport(0, 0, openGLControl1.Size.Width, openGLControl1.Size.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            double aspect = (double)openGLControl1.Size.Width /
                            (double)openGLControl1.Size.Height;

            Glu.gluPerspective(45, aspect, 0.1, 30.0);
        }
        private void MyInit()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClearDepth(1.0);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_NORMALIZE);

            Gl.glColorMaterial(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE);
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClearDepth(1.0);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);


            float[] global_ambient = new float[] { 0.2f, 0.2f, 0.2f }; //全域環境光的數值
            float[] light0_ambient = new float[] { 0.2f, 0.2f, 0.0f }; //偏黃色的環境光
            float[] light0_diffuse = new float[] { 0.7f, 0.7f, 0.0f }; //偏黃色的散射光
            float[] light0_specular = new float[] { 0.9f, 0.9f, 0.0f }; //偏黃色的鏡射光

            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, global_ambient); //設定全域環境光
            Gl.glLightModeli(Gl.GL_LIGHT_MODEL_LOCAL_VIEWER, Gl.GL_TRUE); //觀者位於場景內
            Gl.glLightModeli(Gl.GL_LIGHT_MODEL_TWO_SIDE, Gl.GL_FALSE); //只對物體正面進行光影計算

            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, light0_ambient); //設定第一個光源的環境光成份
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, light0_diffuse); //設定第一個光源的散射光成份
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPECULAR, light0_specular); //設定第一個光源的鏡射光成份

        }
        private void openGLControl1_Load(object sender, EventArgs e)
        {
            MyInit();
            SetViewingVolume();
        }
        private void openGLControl1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    Longitude -= 5.0;
                    break;
                case Keys.Right:
                    Longitude += 5.0;
                    break;
                case Keys.Up:
                    Latitude += 5.0;
                    if (Latitude >= 90.0) Latitude = 89.0;
                    break;
                case Keys.Down:
                    Latitude -= 5.0;
                    if (Latitude <= -90.0) Latitude = -89.0;
                    break;
                case Keys.F1:
                    if (lightIO_0)
                    {
                        lightIO_0 = false;
                        Gl.glDisable(Gl.GL_LIGHT0);
                    }
                    else
                    {
                        lightIO_0 = true;
                        Gl.glEnable(Gl.GL_LIGHT0);
                    }
                    break;

                default:
                    break;
            }
            this.openGLControl1.Refresh();
        }
        private void openGLControl1_Resize(object sender, EventArgs e)
        {
            SetViewingVolume();
        }
        private void board()
        {
            Gl.glPushMatrix();
            Gl.glColor3ub(81, 168, 221);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(-6, -3, -3);
            Gl.glVertex3d(6, -3, -3);
            Gl.glVertex3d(6, -3, 3);
            Gl.glVertex3d(-6, -3, 3);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(-6, 3, 3);
            Gl.glVertex3d(6, 3, 3);
            Gl.glVertex3d(6, 3, -3);
            Gl.glVertex3d(-6, 3, -3);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(-6, 3, -3);
            Gl.glVertex3d(-6, -3, -3);
            Gl.glVertex3d(-6, -3, 3);
            Gl.glVertex3d(-6, 3, 3);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(6, 3, 3);
            Gl.glVertex3d(6, -3, 3);
            Gl.glVertex3d(6, -3, -3);
            Gl.glVertex3d(6, 3, -3);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(6, 3, -3);
            Gl.glVertex3d(6, -3, -3);
            Gl.glVertex3d(-6, -3, -3);
            Gl.glVertex3d(-6, 3, -3);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(6, 2, 3);
            Gl.glVertex3d(6, 3, 3);
            Gl.glVertex3d(-6, 3, 3);
            Gl.glVertex3d(-6, 2, 3);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(-6, -2, 3);
            Gl.glVertex3d(-6, -3, 3);
            Gl.glVertex3d(6, -3, 3);
            Gl.glVertex3d(6, -2, 3);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(-6, 2, 3);
            Gl.glVertex3d(-6, -2, 3);
            Gl.glVertex3d(-5, -2, 3);
            Gl.glVertex3d(-5, 2, 3);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(5, 2, 3);
            Gl.glVertex3d(5, -2, 3);
            Gl.glVertex3d(6, -2, 3);
            Gl.glVertex3d(6, 2, 3);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(-5, 2, 3);
            Gl.glVertex3d(-5, -2, 3);
            Gl.glVertex3d(-5, -2, 2.5);
            Gl.glVertex3d(-5, 2, 2.5);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(5, 2, 2.5);
            Gl.glVertex3d(5, -2, 2.5);
            Gl.glVertex3d(5, -2, 3);
            Gl.glVertex3d(5, 2, 3);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(5, -2, 2.5);
            Gl.glVertex3d(-5, -2, 2.5);
            Gl.glVertex3d(-5, -2, 3);
            Gl.glVertex3d(5, -2, 3);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(5, 2, 3);
            Gl.glVertex3d(-5, 2, 3);
            Gl.glVertex3d(-5, 2, 2.5);
            Gl.glVertex3d(5, 2, 2.5);
            Gl.glEnd();

            Gl.glPushMatrix();
            Gl.glColor3ub(120, 120, 120);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(-5, 2, 2.5);
            Gl.glVertex3d(-5, -2, 2.5);
            Gl.glVertex3d(5, -2, 2.5);
            Gl.glVertex3d(5, 2, 2.5);
            Gl.glEnd();

            Gl.glPopMatrix();

            Gl.glPopMatrix();
        }
        private void numbersign()
        {
            Gl.glPushMatrix();
            Gl.glScaled(1.0, 0.4, 1.0);
            Gl.glScaled(0.8, 0.8, 0.8);
            Gl.glColor3ub(11, 16, 19);
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glVertex3d(2, 1.5, 0);
            Gl.glVertex3d(-2, 1.5, 0);
            Gl.glVertex3d(-3, 1, 0);
            Gl.glVertex3d(-3, -1, 0);
            Gl.glVertex3d(-2, -1.5, 0);
            Gl.glVertex3d(2, -1.5, 0);
            Gl.glVertex3d(3, -1, 0);
            Gl.glVertex3d(3, 1, 0);
            Gl.glEnd();
            Gl.glPopMatrix();
        }
        private void numberss(bool a, bool b, bool c, bool d, bool e, bool f, bool g)
        {
            if (a)
            {
                Gl.glPushMatrix();
                Gl.glTranslated(0, 5, 0);
                numbersign();
                Gl.glPopMatrix();
            }
            if (b)
            {
                Gl.glPushMatrix();
                Gl.glTranslated(-3, 2.5, 0);
                Gl.glRotated(90, 0, 0, 1);
                numbersign();
                Gl.glPopMatrix();
            }
            if (c)
            {

                Gl.glPushMatrix();
                Gl.glTranslated(3, 2.5, 0);
                Gl.glRotated(90, 0, 0, 1);
                numbersign();
                Gl.glPopMatrix();
            }
            if (d)
            {
                Gl.glPushMatrix();
                Gl.glTranslated(0, 0, 0);
                numbersign();
                Gl.glPopMatrix();
            }
            if (e)
            {
                Gl.glPushMatrix();
                Gl.glTranslated(-3, -2.5, 0);
                Gl.glRotated(90, 0, 0, 1);
                numbersign();
                Gl.glPopMatrix();

            }
            if (f)
            {
                Gl.glPushMatrix();
                Gl.glTranslated(3, -2.5, 0);
                Gl.glRotated(90, 0, 0, 1);
                numbersign();
                Gl.glPopMatrix();
            }
            if (g)
            {
                Gl.glPushMatrix();
                Gl.glTranslated(0, -5, 0);
                numbersign();
                Gl.glPopMatrix();
            }
        }
        private void numberword(int a) {
            if (a == 1)
            {
                numberss(false,false,true,false, false, true, false);
            }
            else if (a == 2)
            {
                numberss(true, false, true, true, true, false, true);
            }
            else if (a == 3)
            {
                numberss(true, false, true, true, false, true, true);
            }
            else if (a == 4)
            {
                numberss(false, true, true, true, false, true, false);
            }
            else if (a == 5)
            {
                numberss(true, true, false, true, false, true, true);
            }
            else if (a == 6)
            {
                numberss(true, true, false, true, true, true, true);
            }
            else if (a == 7)
            {
                numberss(true, false, true, false, false, true, false);
            }
            else if (a == 8)
            {
                numberss(true, true, true, true, true, true, true);
            }
            else if (a == 9)
            {
                numberss(true, true, true, true, false, true, true);
            }
            else if (a == 0)
            {
                numberss(true, true, true, false, true, true, true);
            }
        }
        private void timemin1(int number)
        {

            Gl.glPushMatrix();
            Gl.glTranslated(0, 0, 2.7);
            Gl.glScaled(0.3, 0.3, 0.3);
            Gl.glTranslated(-12, 0, 0);
            numberword(number);
            Gl.glPopMatrix();
        }
        private void timemin2(int number)
        {
            Gl.glPushMatrix();
            Gl.glTranslated(0, 0, 2.7);
            Gl.glScaled(0.3, 0.3, 0.3);
            Gl.glTranslated(-4, 0, 0);
            numberword(number);
            Gl.glPopMatrix();
        }
        private void timesec1(int number)
        {
            Gl.glPushMatrix();
            Gl.glTranslated(0, 0, 2.7);
            Gl.glScaled(0.3, 0.3, 0.3);
            Gl.glTranslated(4, 0, 0);
            numberword(number);
            Gl.glPopMatrix();
        }
        private void timesec2(int number)
        {
            Gl.glPushMatrix();
            Gl.glTranslated(0, 0, 2.7);
            Gl.glScaled(0.3, 0.3, 0.3);
            Gl.glTranslated(12, 0, 0);
            numberword(number);
            Gl.glPopMatrix();
        }

        private void timeline(int number)
        {
            if (number % 2 == 0)
            {
                Gl.glPushMatrix();
                Gl.glScaled(0.05, 0.5, 1);
                Gl.glTranslated(0, 1, 2.7);
                numbersign();
                Gl.glPopMatrix();
                Gl.glPushMatrix();
                Gl.glScaled(0.05, 0.5, 1);
                Gl.glTranslated(0, -1, 2.7);
                numbersign();
                Gl.glPopMatrix();
            }
        }
        private void glass()
        {
            Gl.glPushMatrix();
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glColor4d(0, 1, 0, 0.2);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(6, 2.5, 3);
            Gl.glVertex3d(-6 ,2.5, 3);
            Gl.glVertex3d(-6, -2.5, 3);
            Gl.glVertex3d(6, -2.5, 3);
            Gl.glEnd();
            Gl.glDisable(Gl.GL_BLEND);
            Gl.glPopMatrix();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            localDate = DateTime.Now;
            label1.Text = localDate.ToString("hh:mm:ss");
            this.openGLControl1.Refresh();
        }
        private void openGLControl1_Paint(object sender, PaintEventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            float[] light0_position = new float[] { 0.0f, .0f, 0f, 0.5f };
            float[] light0_direction = new float[] { 0.0f, 1.0f, 0.0f };
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPOT_DIRECTION, light0_direction);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light0_position);
            Gl.glColorMaterial(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);

            Glu.gluLookAt(Radius * Math.Cos(Latitude * DEGREE_TO_RAD)
                                 * Math.Sin(Longitude * DEGREE_TO_RAD),
                          Radius * Math.Sin(Latitude * DEGREE_TO_RAD),
                          Radius * Math.Cos(Latitude * DEGREE_TO_RAD)
                                 * Math.Cos(Longitude * DEGREE_TO_RAD),
                          0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            board();
            timeline(int.Parse(localDate.ToString("ss")));
            timemin1(int.Parse(localDate.ToString("hh"))/10);
            timemin2(int.Parse(localDate.ToString("hh"))%10);
            timesec1(int.Parse(localDate.ToString("mm"))/10);
            timesec2(int.Parse(localDate.ToString("mm"))%10);
            glass();
            Gl.glDisable(Gl.GL_COLOR_MATERIAL);
        }
    }
}
