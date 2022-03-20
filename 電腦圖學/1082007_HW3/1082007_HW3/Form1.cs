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

namespace _1082007_HW3
{
    public partial class Form1 : Form
    {
        const double DEGREE_TO_RAD = 0.01745329; // 3.1415926/180
        double Radius =15.0, Longitude = 0.0, Latitude = 0.0;
        DateTime localDate = DateTime.Now;
        int light_rot = 0;
        Boolean lightIO_0 = false;
        Boolean lightIO_1 = false;
        Boolean lightIO_2 = false;
        Boolean lightIO_3 = false;
        Boolean lightIO_4 = false;

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

            Glu.gluPerspective(45, aspect, 0.1, 20.0);
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


            float[] global_ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
            float[] light0_ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
            float[] light0_diffuse = new float[] { 0.6f, 0.6f, 0.6f, 1.0f };
            float[] light0_specular = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };

            Gl.glLightModeli(Gl.GL_LIGHT_MODEL_TWO_SIDE, Gl.GL_TRUE);
            Gl.glLightModeli(Gl.GL_LIGHT_MODEL_LOCAL_VIEWER, Gl.GL_TRUE);
            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, global_ambient);

            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, light0_ambient);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, light0_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPECULAR, light0_specular);
            Gl.glLightf(Gl.GL_LIGHT0, Gl.GL_SPOT_CUTOFF, 7.0f);
            Gl.glLightf(Gl.GL_LIGHT0, Gl.GL_SPOT_EXPONENT, 10.0f);

            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_AMBIENT, light0_ambient);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_DIFFUSE, light0_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPECULAR, light0_specular);
            Gl.glLightf(Gl.GL_LIGHT1, Gl.GL_SPOT_CUTOFF, 7.0f);
            Gl.glLightf(Gl.GL_LIGHT1, Gl.GL_SPOT_EXPONENT, 10.0f);

            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_AMBIENT, light0_ambient);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_DIFFUSE, light0_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_SPECULAR, light0_specular);
            Gl.glLightf(Gl.GL_LIGHT2, Gl.GL_SPOT_CUTOFF, 7.0f);
            Gl.glLightf(Gl.GL_LIGHT2, Gl.GL_SPOT_EXPONENT, 10.0f);

            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_AMBIENT, light0_ambient);
            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_DIFFUSE, light0_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_SPECULAR, light0_specular);
            Gl.glLightf(Gl.GL_LIGHT3, Gl.GL_SPOT_CUTOFF, 7.0f);
            Gl.glLightf(Gl.GL_LIGHT3, Gl.GL_SPOT_EXPONENT, 10.0f);


            float[] light4_ambient = new float[] { 0.3f, 0.3f, 0.3f, 1.0f };
            float[] light4_diffuse = new float[] { 0.2f, 0.2f, 0.2f, 0.5f };
            float[] light4_specular = new float[] { 0.3f, 0.3f, 0.3f, 1.0f };
            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_AMBIENT, light4_ambient);
            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_DIFFUSE, light4_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_SPECULAR, light4_specular);
            Gl.glLightf(Gl.GL_LIGHT4, Gl.GL_SPOT_CUTOFF, 7.0f);
            Gl.glLightf(Gl.GL_LIGHT4, Gl.GL_SPOT_EXPONENT, 1.0f);
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

                case Keys.F2:
                    if (lightIO_1)
                    {
                        lightIO_1 = false;
                        Gl.glDisable(Gl.GL_LIGHT1);
                    }
                    else
                    {
                        lightIO_1 = true;
                        Gl.glEnable(Gl.GL_LIGHT1);
                    }
                    break;

                case Keys.F3:
                    if (lightIO_2)
                    {
                        lightIO_2 = false;
                        Gl.glDisable(Gl.GL_LIGHT2);
                    }
                    else
                    {
                        lightIO_2 = true;
                        Gl.glEnable(Gl.GL_LIGHT2);
                    }
                    break;

                case Keys.F4:
                    if (lightIO_3)
                    {
                        lightIO_3 = false;
                        Gl.glDisable(Gl.GL_LIGHT3);
                    }
                    else
                    {
                        lightIO_3 = true;
                        Gl.glEnable(Gl.GL_LIGHT3);
                    }
                    break;
                case Keys.F5:
                    if (lightIO_4)
                    {
                        lightIO_4 = false;
                        Gl.glDisable(Gl.GL_LIGHT4);
                    }
                    else
                    {
                        lightIO_4 = true;
                        Gl.glEnable(Gl.GL_LIGHT4);
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
        private void room()
        {
            Gl.glPushMatrix();
            Gl.glColor3ub(81, 110, 65);
            Gl.glScaled(10.0, 10.0, 10.0);
            Gl.glPushMatrix();
            Gl.glRotated(-90.0, 1.0, 0.0, 0.0);
            Gl.glTranslated(0.5, 0.01, 0.5);
            Gl.glScaled(1.0, 0.02, 1.0);
            MySizeCube(1.0, 50.0);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(0.5, 0.01, 0.5);
            Gl.glScaled(1.0, 0.02, 1.0);
            MySizeCube(1.0, 50.0);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(90.0, 0.0, 0.0, 1.0);
            Gl.glTranslated(0.5, 0.01, 0.5);
            Gl.glScaled(1.0, 0.02, 1.0);
            MySizeCube(1.0, 50.0);
            Gl.glPopMatrix();
            Gl.glPopMatrix();
        }
        private void table(double topWidth, double thickness, double legLen, double legThick)
        {
            Gl.glTranslated(topWidth / 2, legLen + thickness, topWidth / 2);
            Gl.glPushMatrix();
            Gl.glColor3ub(51, 166, 184);
            Gl.glScaled(topWidth, thickness, topWidth);
            Glut.glutSolidCube(1.0);
            Gl.glPopMatrix();

            double d = topWidth / 2 * 0.8;
            Gl.glPushMatrix();
            Gl.glColor3ub(51, 166, 184);
            Gl.glTranslated(d, 0.0, -d);
            Gl.glTranslated(0.0, -legLen / 2, 0.0);
            Gl.glScaled(legThick, legLen, legThick);
            Glut.glutSolidCube(1.0);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3ub(51, 166, 184);
            Gl.glTranslated(d, 0.0, d);
            Gl.glTranslated(0.0, -legLen / 2, 0.0);
            Gl.glScaled(legThick, legLen, legThick);
            Glut.glutSolidCube(1.0);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3ub(51, 166, 184);
            Gl.glTranslated(-d, 0.0, -d);
            Gl.glTranslated(0.0, -legLen / 2, 0.0);
            Gl.glScaled(legThick, legLen, legThick);
            Glut.glutSolidCube(1.0);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3ub(51, 166, 184);
            Gl.glTranslated(-d, 0.0, d);
            Gl.glTranslated(0.0, -legLen / 2, 0.0);
            Gl.glScaled(legThick, legLen, legThick);
            Glut.glutSolidCube(1.0);
            Gl.glPopMatrix();
        }
        private void jackPart()
        {
            Gl.glPushMatrix();
            Gl.glScaled(0.2, 1.0, 0.2);
            Glut.glutSolidSphere(1.0, 32, 32);
            Gl.glPopMatrix();
            Gl.glPushMatrix();

            Gl.glTranslated(0.0, 1.0, 0.0);
            Gl.glScaled(0.2, 0.2, 0.2);
            Glut.glutSolidSphere(1.0, 32, 32);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(0.0, -1.0, 0.0);
            Gl.glScaled(0.2, 0.2, 0.2);
            Glut.glutSolidSphere(1.0, 32, 32);
            Gl.glPopMatrix();
        }
        private void jack()
        {
            Gl.glColor3ub(178, 143, 206);
            Gl.glPushMatrix();
            Gl.glTranslated(0.0, 0.1, 0.2);
            Gl.glRotated(45, 1.0, 1.0, 0.0);
            Gl.glScaled(0.1, 0.1, 0.1);
            Gl.glPushMatrix();
            jackPart();
            Gl.glPopMatrix();
            Gl.glPushMatrix();
            Gl.glRotated(90, 1.0, 0.0, 0.0);
            jackPart();
            Gl.glPopMatrix();
            Gl.glPushMatrix();
            Gl.glRotated(90, 0.0, 0.0, 1.0);
            jackPart();
            Gl.glPopMatrix();
            Gl.glPopMatrix();
        }

        private void ball()
        {

            Gl.glPushMatrix();
            Gl.glColor3ub(172, 50, 206);
            Gl.glTranslated(0.0, 0.0, -0.5);
            Gl.glScaled(5, 5,0.1);
            Glut.glutSolidSphere(1.0, 100, 100);
            Gl.glPopMatrix();

        }
        private void timeline()
        {
            Gl.glPushMatrix();
            Gl.glColor3ub(178, 143, 206);
            Gl.glRotated(int.Parse(localDate.ToString("ss"))*360/60, 0.0, 0.0, -1.0);
            Gl.glTranslated(0.0, 2.5, 0.0);
            Gl.glScaled(0.2, 5, 0.1);
            Glut.glutSolidCube(1);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3ub(178, 100, 206);
            Gl.glRotated(int.Parse(localDate.ToString("mm")) * 360 / 60, 0.0, 0.0, -1.0);
            Gl.glTranslated(0.0, 2.5, 0.0);
            Gl.glScaled(0.5, 5, 0.1);
            Glut.glutSolidCube(1);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3ub(178, 143, 255);
            Gl.glRotated(int.Parse(localDate.ToString("hh")) * 360 / 12 + (int.Parse(localDate.ToString("mm")) * 30 / 60), 0.0, 0.0, -1.0);
            Gl.glTranslated(0.0, 1.5, 0.0);
            Gl.glScaled(0.5, 3, 0.1);
            Glut.glutSolidCube(1);
            Gl.glPopMatrix();
        }
        private void MySizeCube(double size, double slices)
        {
            double s = 1.0 / slices;
            Gl.glPushMatrix();
            Gl.glScaled(size, size, size);
            for (int i = 0; i < slices; i++)
            {
                for (int j = 0; j < slices; j++)
                {
                    Gl.glPushMatrix();
                    Gl.glTranslated(-0.5 + i * s, 0.0, -0.5 + j * s);
                    Gl.glScaled(s, 1.0, s);
                    Gl.glTranslated(0.5, 0.0, 0.5);
                    Glut.glutSolidCube(1.0);
                    Gl.glPopMatrix();
                }
            }
            Gl.glScaled(s, 1.0, s);
            Gl.glTranslated(0.5, 0.0, 0.5);
            Glut.glutSolidCube(1.0);
            Gl.glPopMatrix();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            localDate = DateTime.Now;
            label1.Text = localDate.ToString("hh:mm:ss");
            this.openGLControl1.Refresh();
        }

        private void clockline()
        {
            for(int i = 0; i < 12; i++)
            {
                Gl.glPushMatrix();
                Gl.glColor3ub(178, 143, 206);
                Gl.glRotated(i * 30, 0, 0, 1);
                Gl.glTranslated(0.0, 4.0, 0.1);
                Gl.glScaled(0.2, 1, 0.1);
                Glut.glutSolidCube(1);
                Gl.glPopMatrix();
            }
        }
        private void outcircle()
        {
            Gl.glPushMatrix();
            Gl.glColor3ub(100, 100, 206);
            Glut.glutSolidTorus(0.5, 5, 10, 50);
            Gl.glPopMatrix();
        }
        private void openGLControl1_Paint(object sender, PaintEventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            //Gl.glPushMatrix();

            //float[] light0_position = new float[] { 10.0f, 0.0f, -1.0f, 0.5f };
            //float[] light0_direction = new float[] { -0.1f, 0.0f, 0.0f };
            ////Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light0_position);
            ////Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPOT_DIRECTION, light0_direction);

            //float[] light1_position = new float[] { 0.0f, 5.0f, 0.0f,1.0f };
            //float[] light1_direction = new float[] { 0.0f, 0.0f, -0.5f };
            //Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_POSITION, light1_position);
            //Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPOT_DIRECTION, light1_direction);

            //float[] light2_position = new float[] { -5.0f, 0.0f, 0.0f, 1.0f };
            //float[] light2_direction = new float[] { 0.1f, 0.0f, 0.0f };
            //Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_POSITION, light2_position);
            //Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_SPOT_DIRECTION, light2_direction);

            //float[] light3_position = new float[] { 0.0f, -5.0f, 0.0f, 1.0f };
            //float[] light3_direction = new float[] { 0.0f, 0.1f, 0.0f };
            //Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_POSITION, light3_position);
            //Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_SPOT_DIRECTION, light3_direction);
            //Gl.glPopMatrix();




            Glu.gluLookAt(Radius * Math.Cos(Latitude * DEGREE_TO_RAD)
                                 * Math.Sin(Longitude * DEGREE_TO_RAD),
                          Radius * Math.Sin(Latitude * DEGREE_TO_RAD),
                          Radius * Math.Cos(Latitude * DEGREE_TO_RAD)
                                 * Math.Cos(Longitude * DEGREE_TO_RAD),
                          0.0, 0.0, 0.0, 0.0, 1.0, 0.0);

            Gl.glPushMatrix();


            float[] light0_position = new float[] { 0.8f, 0.0f, 0.4f, 0.1f };
            float[] light0_direction = new float[] { -0.1f, 0.0f, -0.15f };
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light0_position);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPOT_DIRECTION, light0_direction);
            Gl.glLightf(Gl.GL_LIGHT0, Gl.GL_SPOT_CUTOFF, (float)(Math.Atan(0.3) * 180.0 / Math.PI));
            Gl.glLightf(Gl.GL_LIGHT0, Gl.GL_SPOT_EXPONENT, 10.0f);

            float[] light1_position = new float[] { 0.0f, 0.8f, 0.4f, 0.1f };
            float[] light1_direction = new float[] { 0.0f, -0.1f, -0.15f };
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_POSITION, light1_position);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPOT_DIRECTION, light1_direction);
            Gl.glLightf(Gl.GL_LIGHT1, Gl.GL_SPOT_CUTOFF, (float)(Math.Atan(0.3) * 180.0 / Math.PI));
            Gl.glLightf(Gl.GL_LIGHT1, Gl.GL_SPOT_EXPONENT, 10.0f);


            float[] light2_position = new float[] { -0.8f, 0.0f, 0.4f, 0.1f };
            float[] light2_direction = new float[] { 0.1f, 0.0f, -0.15f };
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_POSITION, light2_position);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_SPOT_DIRECTION, light2_direction);
            Gl.glLightf(Gl.GL_LIGHT2, Gl.GL_SPOT_CUTOFF, (float)(Math.Atan(0.3) * 180.0 / Math.PI));
            Gl.glLightf(Gl.GL_LIGHT2, Gl.GL_SPOT_EXPONENT, 10.0f);

            float[] light3_position = new float[] { 0.0f, -0.8f, 0.4f, 0.1f };
            float[] light3_direction = new float[] { 0.0f, 0.1f, -0.15f };
            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_POSITION, light3_position);
            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_SPOT_DIRECTION, light3_direction);
            Gl.glLightf(Gl.GL_LIGHT3, Gl.GL_SPOT_CUTOFF, (float)(Math.Atan(0.3) * 180.0 / Math.PI));
            Gl.glLightf(Gl.GL_LIGHT3, Gl.GL_SPOT_EXPONENT, 10.0f);


            float[] light4_position = new float[] { 2.0f, 0.0f, 10.0f, 0.1f };
            float[] light4_direction = new float[] { 0.0f, 0.0f, -0.15f };
            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_POSITION, light4_position);
            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_SPOT_DIRECTION, light4_direction);
            Gl.glLightf(Gl.GL_LIGHT4, Gl.GL_SPOT_CUTOFF, (float)(Math.Atan(0.3) * 180.0 / Math.PI));
            Gl.glLightf(Gl.GL_LIGHT4, Gl.GL_SPOT_EXPONENT, 1.0f);



            //light0_position[0] = (float)(Radius * Math.Cos(Latitude * DEGREE_TO_RAD) * Math.Sin(Longitude * DEGREE_TO_RAD));
            //light0_position[1] = (float)(Radius * Math.Sin(Latitude * DEGREE_TO_RAD));
            //light0_position[2] = (float)(Radius * Math.Cos(Latitude * DEGREE_TO_RAD) * Math.Cos(Longitude * DEGREE_TO_RAD));

            //light0_direction[0] = 0.0f - light0_position[0];
            //light0_direction[1] = 0.0f - light0_position[1];
            //light0_direction[2] = 0.0f - light0_position[2];


            //Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light0_position);
            //Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPOT_DIRECTION, light0_direction);
            Gl.glPopMatrix();

            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            //room();
            // table(0.6, 0.02, 0.3, 0.02);
            // jack();
            // ball();

            outcircle();
            ball();
            clockline();
            timeline();
            Gl.glDisable(Gl.GL_COLOR_MATERIAL);


            float[] mat_ambient = new float[3];
            float[] mat_diffuse = new float[3];
            float[] mat_specular = new float[3];
            float mat_shininess;

            mat_ambient[0] = 0.329412f;
            mat_ambient[1] = 0.223529f;
            mat_ambient[2] = 0.027451f;
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, mat_ambient);
            mat_diffuse[0] = 0.780392f;
            mat_diffuse[1] = 0.568627f;
            mat_diffuse[2] = 0.113725f;
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, mat_diffuse);
            mat_specular[0] = 0.992157f;
            mat_specular[1] = 0.941176f;
            mat_specular[2] = 0.807843f;
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, mat_specular);
            mat_shininess = 27.8974f;
            Gl.glMaterialf(Gl.GL_FRONT, Gl.GL_SHININESS, mat_shininess);

            //Gl.glPushMatrix();
            //Gl.glTranslated(0.0, 0.1, 0.0);
            //Gl.glScaled(0.1, 0.1, 0.1);
            //Gl.glFrontFace(Gl.GL_CW);
            //Glut.glutSolidTeapot(1.0);
            //Gl.glFrontFace(Gl.GL_CCW);
            //Gl.glPopMatrix();
        }
    }
}
