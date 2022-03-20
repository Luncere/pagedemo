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
using Tao.Platform;
using Tao.DevIl;
using ModelLoadingByAssimp;



namespace _1082007_HW4
{
    public partial class Form1 : Form
    {
        const double DEGREE_TO_RAD = 0.01745329; 
        double Radius = 3.0, Longitude = 0.0, Latitude = 0.0;
        uint[] texName = new uint[6]; 
        Camera cam = new Camera();
        Model myModel;
        float modelSize;
        float[] modelCenter = new float[3];
        Boolean lightIO_0 = false;
        Boolean lightIO_1 = false;
        Boolean lightIO_2 = false;
        Boolean lightIO_3 = false;
        Boolean lightIO_4 = false;
        Boolean lightIO_5 = false;
        Boolean lightIO_6 = false;
        Boolean lightIO_7 = false;
        public Form1()
        {
            InitializeComponent();
            this.openGLControl1.InitializeContexts();
            Glut.glutInit();
            Il.ilInit();
            Ilu.iluInit();
            Gl.ReloadFunctions();
        }
        private void SetViewingVolume()
        {
            Gl.glViewport(0, 0, openGLControl1.Size.Width, openGLControl1.Size.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            double aspect = (double)openGLControl1.Size.Width /
                            (double)openGLControl1.Size.Height;

            Glu.gluPerspective(45, aspect, 0.1, 100.0);
        }
        private void MyInit()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClearDepth(1.0);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_LIGHTING);

            Gl.glEnable(Gl.GL_NORMALIZE);
            Gl.glEnable(Gl.GL_TEXTURE_2D);

            Gl.glColorMaterial(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE);
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClearDepth(1.0);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);

            myModel = new Model(@"..\..\3D\dog.obj");
            float[] min = new float[3];
            float[] max = new float[3];

            myModel.ComputeBoundingBox(min, max);
            modelSize = (float)Math.Max(max[0] - min[0], Math.Max(max[1] - min[1], max[2] - min[2])); 
            modelCenter[0] = 0.5f * (min[0] + max[0]); 
            modelCenter[1] = 0.5f * (min[1] + max[1]);
            modelCenter[2] = 0.5f * (min[2] + max[2]); 



            cam.SetPosition(0.0, 0.25, 3.0);
            cam.SetDirection(0.0, 0.0, -1.0);

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
            Gl.glLightf(Gl.GL_LIGHT0, Gl.GL_SPOT_CUTOFF, 10.0f);
            Gl.glLightf(Gl.GL_LIGHT0, Gl.GL_SPOT_EXPONENT, 20.0f);

            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_AMBIENT, light0_ambient);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_DIFFUSE, light0_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPECULAR, light0_specular);
            Gl.glLightf(Gl.GL_LIGHT1, Gl.GL_SPOT_CUTOFF, 10.0f);
            Gl.glLightf(Gl.GL_LIGHT1, Gl.GL_SPOT_EXPONENT, 20.0f);

            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_AMBIENT, light0_ambient);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_DIFFUSE, light0_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_SPECULAR, light0_specular);
            Gl.glLightf(Gl.GL_LIGHT2, Gl.GL_SPOT_CUTOFF, 10.0f);
            Gl.glLightf(Gl.GL_LIGHT2, Gl.GL_SPOT_EXPONENT, 20.0f);

            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_AMBIENT, light0_ambient);
            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_DIFFUSE, light0_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_SPECULAR, light0_specular);
            Gl.glLightf(Gl.GL_LIGHT3, Gl.GL_SPOT_CUTOFF, 10.0f);
            Gl.glLightf(Gl.GL_LIGHT3, Gl.GL_SPOT_EXPONENT, 20.0f);

            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_AMBIENT, light0_ambient);
            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_DIFFUSE, light0_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_SPECULAR, light0_specular);
            Gl.glLightf(Gl.GL_LIGHT4, Gl.GL_SPOT_CUTOFF, 10.0f);
            Gl.glLightf(Gl.GL_LIGHT4, Gl.GL_SPOT_EXPONENT, 20.0f);

            Gl.glLightfv(Gl.GL_LIGHT5, Gl.GL_AMBIENT, light0_ambient);
            Gl.glLightfv(Gl.GL_LIGHT5, Gl.GL_DIFFUSE, light0_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT5, Gl.GL_SPECULAR, light0_specular);
            Gl.glLightf(Gl.GL_LIGHT5, Gl.GL_SPOT_CUTOFF, 10.0f);
            Gl.glLightf(Gl.GL_LIGHT5, Gl.GL_SPOT_EXPONENT, 20.0f);

            Gl.glLightfv(Gl.GL_LIGHT6, Gl.GL_AMBIENT, light0_ambient);
            Gl.glLightfv(Gl.GL_LIGHT6, Gl.GL_DIFFUSE, light0_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT6, Gl.GL_SPECULAR, light0_specular);
            Gl.glLightf(Gl.GL_LIGHT6, Gl.GL_SPOT_CUTOFF, 10.0f);
            Gl.glLightf(Gl.GL_LIGHT6, Gl.GL_SPOT_EXPONENT, 20.0f);

            Gl.glLightfv(Gl.GL_LIGHT7, Gl.GL_AMBIENT, light0_ambient);
            Gl.glLightfv(Gl.GL_LIGHT7, Gl.GL_DIFFUSE, light0_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT7, Gl.GL_SPECULAR, light0_specular);
            Gl.glLightf(Gl.GL_LIGHT7, Gl.GL_SPOT_CUTOFF, 10.0f);
            Gl.glLightf(Gl.GL_LIGHT7, Gl.GL_SPOT_EXPONENT, 20.0f);



            Gl.glGenTextures(6, texName); 

            LoadTexture(@"../../images/pos1.png", texName[0]);
            LoadTexture(@"../../images/pos2.png", texName[1]);
            LoadTexture(@"../../images/pos3.png", texName[2]);

            Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_MODULATE);


        }
        private void openGLControl1_Load(object sender, EventArgs e)
        {
            MyInit();
            cam.SetViewVolume(45, openGLControl1.Size.Width, openGLControl1.Size.Height, 0.1, 50.0);

        }
        private void LoadTexture(string filename, uint texture)
        {
            if (Il.ilLoadImage(filename)) 
            {
                int BitsPerPixel = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);
                Ilu.iluFlipImage();
                int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);
                width = (width / 4) * 4; 
                int Depth = Il.ilGetInteger(Il.IL_IMAGE_DEPTH);
                Ilu.iluScale(width, height, Depth);
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture); 
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);

                if (BitsPerPixel == 24) Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB, width, height, 0,
                 Il.ilGetInteger(Il.IL_IMAGE_FORMAT), Il.ilGetInteger(Il.IL_IMAGE_TYPE), Il.ilGetData());
                if (BitsPerPixel == 32) Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, width, height, 0,
                 Il.ilGetInteger(Il.IL_IMAGE_FORMAT), Il.ilGetInteger(Il.IL_IMAGE_TYPE), Il.ilGetData());
                Gl.glGenerateMipmap(Gl.GL_TEXTURE_2D);
            }
            else
            {
                string message = "Cannot open file " + filename + ".";
                MessageBox.Show(message, "Image file open error!!!", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }

        private void openGLControl1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (e.Control) cam.HSlide(-0.1);
                    else if (e.Alt) cam.Roll(1.0);
                    else cam.Pan(1.0);
                    this.openGLControl1.Refresh();
                    break;
                case Keys.Right:
                    if (e.Control) cam.HSlide(0.1);
                    else if (e.Alt) cam.Roll(-1.0);
                    else cam.Pan(-1.0);
                    this.openGLControl1.Refresh();
                    break;

                case Keys.Up:
                    if (e.Control) cam.VSlide(0.1);
                    else cam.Tilt(1.0);
                    this.openGLControl1.Refresh();
                    break;

                case Keys.Down:
                    if (e.Control) cam.VSlide(-0.1);
                    else cam.Tilt(-1.0);
                    this.openGLControl1.Refresh();
                    break;
                case Keys.F1:
                    Radius += 1.0;
                    cam.Slide(-0.1);
                    break;
                case Keys.F2:
                    Radius -= 1.0;
                    cam.Slide(0.1);
                    break;
                case Keys.F3:
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

                case Keys.F4:
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

                case Keys.F5:
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

                case Keys.F6:
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
                case Keys.F7:
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
                case Keys.F8:
                    if (lightIO_5)
                    {
                        lightIO_5 = false;
                        Gl.glDisable(Gl.GL_LIGHT5);
                    }
                    else
                    {
                        lightIO_5 = true;
                        Gl.glEnable(Gl.GL_LIGHT5);
                    }
                    break;

                case Keys.F9:
                    if (lightIO_6)
                    {
                        lightIO_6 = false;
                        Gl.glDisable(Gl.GL_LIGHT6);
                    }
                    else
                    {
                        lightIO_6 = true;
                        Gl.glEnable(Gl.GL_LIGHT6);
                    }
                    break;

                case Keys.F10:
                    if (lightIO_7)
                    {
                        lightIO_7 = false;
                        Gl.glDisable(Gl.GL_LIGHT7);
                    }
                    else
                    {
                        lightIO_7 = true;
                        Gl.glEnable(Gl.GL_LIGHT7);
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
           
            Gl.glPushMatrix();
            Gl.glColor3ub(81, 110, 0);
            Gl.glTranslated(0.0, 0.0, -7.0);
            Gl.glRotated(90.0, 1.0, 0.0, 0.0);
            Gl.glTranslated(-7.0, 0.0, -4.0);
            Gl.glScaled(14.0, 0.0, 8.0);
            face(100, 1);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3ub(0, 110, 65);
            Gl.glTranslated(0.0, 0.0, 7.0);
            Gl.glRotated(-90.0, 1.0, 0.0, 0.0);
            Gl.glTranslated(-7.0, 0.0, -4.0);
            Gl.glScaled(14.0, 0.0, 8.0);
            face(100, 1);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3ub(81, 0, 65);
            Gl.glTranslated(-7.0, 0.0, 0.0);
            Gl.glRotated(90.0, 0.0, 1.0, 0.0);
            Gl.glRotated(90.0, 1.0, 0.0, 0.0);
            Gl.glTranslated(-7.0, 0.0, -4.0);
            Gl.glScaled(14.0, 0.0, 8.0);
            face(100, 1);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(7.0, 0.0, 0.0);
            Gl.glRotated(-90.0, 0.0, 1.0, 0.0);
            Gl.glRotated(90.0, 1.0, 0.0, 0.0);
            Gl.glTranslated(-7.0, 0.0, -4.0);
            Gl.glScaled(14.0, 0.0, 8.0);
            face(100, 1);
            Gl.glPopMatrix();
         
            Gl.glPushMatrix();
            Gl.glTranslated(0.0, -4.0, 0.0);
            Gl.glTranslated(-7.0, 0.0, -7.0);
            Gl.glScaled(14.0, 0.0, 14.0);
            face(200, 1);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(0.0, 4.0, 0.0);
            Gl.glRotated(180.0, 1.0, 0.0, 0.0);
            Gl.glTranslated(-7.0, 0.0, -7.0);
            Gl.glScaled(14.0, 0.0, 14.0);
     
            face(100, 1);
            Gl.glPopMatrix();
            Gl.glPopMatrix();
        }
        private void Table_cube()
        {
            Gl.glPushMatrix();
            Gl.glColor3ub(51, 166, 184);
            Gl.glTranslated(0.0, 0.0, 0.0);
            Gl.glTranslated(0.0, -3, 0.0);
            Gl.glScaled(2, 3, 2);
            MySizeCube(1, 10);
            Gl.glPopMatrix();
        }
        private void face(int Slices, double thickness)
        {
            double dx = 1.0 / Slices;
            double dz = 1.0 / Slices;

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glNormal3d(0.0, 1.0, 0.0);
            for (double x = 0; x < 1.0; x += dx)
            {
                for (double z = 0; z < 1.0; z += dz)
                {
                    Gl.glVertex3d(x, thickness, z);
                    Gl.glVertex3d(x, thickness, z + dz);
                    Gl.glVertex3d(x + dx, thickness, z + dz);
                    Gl.glVertex3d(x + dx, thickness, z);
                }
            }
            Gl.glEnd();
        }
        private void poster0()
        {
            double aspect = 900.0 / 1600.0;
            Gl.glPushMatrix();
            Gl.glTranslated(-5.2, -2, -0.7);
            Gl.glScaled(6, 6, 6);
            Gl.glTranslated(-0.299, -0.25, -0.25);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glNormal3d(1.0, 0.0, 0.0);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texName[0]);
            Gl.glColor3ub(255, 255, 255);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(1.0, 0.0);
            Gl.glVertex3d(0.001, 0.3, 0.2);
            Gl.glTexCoord2d(1.0, 1.0);
            Gl.glVertex3d(0.001, 0.3 + 0.5, 0.2);
            Gl.glTexCoord2d(0.0, 1.0);
            Gl.glVertex3d(0.001, 0.3 + 0.5, 0.2 + 0.5 * aspect);
            Gl.glTexCoord2d(0.0, 0.0);
            Gl.glVertex3d(0.001, 0.3, 0.2 + 0.5 * aspect);
            Gl.glEnd();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glPopMatrix();
        }
        private void poster1()
        {
            double aspect = 900.0 / 1600.0;
            Gl.glPushMatrix();
            Gl.glTranslated(8.7, -2, 3.8);
            Gl.glScaled(6, 6, 6);
            Gl.glTranslated(-0.299, -0.25, -0.25);
            Gl.glRotated(180, 0, 1, 0);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glNormal3d(1.0, 0.0, 0.0);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texName[1]);
            Gl.glColor3ub(255, 255, 255);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(1.0, 0.0);
            Gl.glVertex3d(0.001, 0.3, 0.2);
            Gl.glTexCoord2d(1.0, 1.0);
            Gl.glVertex3d(0.001, 0.3 + 0.5, 0.2);
            Gl.glTexCoord2d(0.0, 1.0);
            Gl.glVertex3d(0.001, 0.3 + 0.5, 0.2 + 0.5 * aspect);
            Gl.glTexCoord2d(0.0, 0.0);
            Gl.glVertex3d(0.001, 0.3, 0.2 + 0.5 * aspect);
            Gl.glEnd();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glPopMatrix();
        }
        private void poster2()
        {
            double aspect = 900.0 / 1600.0;
            Gl.glPushMatrix();
            Gl.glTranslated(4.0, -2, -5.2);
            Gl.glScaled(6, 6, 6);
            Gl.glTranslated(-0.299, -0.25, -0.25);
            Gl.glRotated(-90, 0, 1, 0);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glNormal3d(1.0, 0.0, 0.0);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texName[2]);
            Gl.glColor3ub(255, 255, 255);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(1.0, 0.0);
            Gl.glVertex3d(0.001, 0.3, 0.2);
            Gl.glTexCoord2d(1.0, 1.0);
            Gl.glVertex3d(0.001, 0.3 + 0.5, 0.2);
            Gl.glTexCoord2d(0.0, 1.0);
            Gl.glVertex3d(0.001, 0.3 + 0.5, 0.2 + 0.5 * aspect);
            Gl.glTexCoord2d(0.0, 0.0);
            Gl.glVertex3d(0.001, 0.3, 0.2 + 0.5 * aspect);
            Gl.glEnd();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
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

        private void glass()
        {
            Gl.glPushMatrix();
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glTranslated(-0.8, -1.5, -0.8);
            Gl.glScaled(1.7, 1.7, 1.7);
            Gl.glColor4d(0, 1, 0, 0.2);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(0, 1, 1);
            Gl.glVertex3d(0, 0, 1);
            Gl.glVertex3d(1, 0, 1);
            Gl.glVertex3d(1, 1, 1);
            Gl.glEnd();
            Gl.glColor4d(0, 1, 0, 0.2);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(1, 1, 1);
            Gl.glVertex3d(1, 0, 1);
            Gl.glVertex3d(1, 0, 0);
            Gl.glVertex3d(1, 1, 0);
            Gl.glEnd();
            Gl.glColor4d(0, 1, 0, 0.2);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(1, 1, 0);
            Gl.glVertex3d(0, 1, 0);
            Gl.glVertex3d(0, 1, 1);
            Gl.glVertex3d(1, 1, 1);
            Gl.glEnd();
            Gl.glColor4d(0, 1, 0, 0.2);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(1, 1, 0);
            Gl.glVertex3d(1, 0, 0);
            Gl.glVertex3d(0, 0, 0);
            Gl.glVertex3d(0, 1, 0);
            Gl.glEnd();
            Gl.glColor4d(0, 1, 0, 0.2);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(0, 1, 0);
            Gl.glVertex3d(0, 0, 0);
            Gl.glVertex3d(0, 0, 1);
            Gl.glVertex3d(0, 1, 1);
            Gl.glEnd();
            Gl.glColor4d(0, 1, 0, 0.2);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(1, 0, 1);
            Gl.glVertex3d(0, 0, 1);
            Gl.glVertex3d(0, 0, 0);
            Gl.glVertex3d(1, 0, 0);
            Gl.glEnd();
            Gl.glDisable(Gl.GL_BLEND);
            Gl.glPopMatrix();
        }
        private void openGLControl1_Paint(object sender, PaintEventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            cam.LookAt();

            Gl.glPushMatrix();
            Gl.glTranslated(0.0, 1.0, -3.0);

            float[] light0_position = new float[] { 7.0f, 5.0f, 0.0f, 1.0f };
            float[] light0_direction = new float[] { 0.0f, -1.0f, 0.0f };
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light0_position);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPOT_DIRECTION, light0_direction);

            float[] light1_position = new float[] { -7.0f, 5.0f, 0.0f, 1.0f };
            float[] light1_direction = new float[] { 0.0f, -1.0f, 0.0f };
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_POSITION, light1_position);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPOT_DIRECTION, light1_direction);

            float[] light2_position = new float[] { 0.0f, 5.0f, -7.0f, 1.0f };
            float[] light2_direction = new float[] { 0.0f, -1.0f, 0.0f };
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_POSITION, light2_position);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_SPOT_DIRECTION, light2_direction);

            float[] light3_position = new float[] { 0.0f, 5.0f, 0.0f, 1.0f };
            float[] light3_direction = new float[] { 0.0f, -1.0f, 0.0f };
            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_POSITION, light3_position);
            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_SPOT_DIRECTION, light3_direction);

            float[] light4_position = new float[] { 4.0f, 5.0f, 4.0f, 1.0f };
            float[] light4_direction = new float[] { 0.0f, -1.0f, 0.0f };
            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_POSITION, light4_position);
            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_SPOT_DIRECTION, light4_direction);

            float[] light5_position = new float[] { -4.0f, 5.0f, 4.0f, 1.0f };
            float[] light5_direction = new float[] { 0.0f, -1.0f, 0.0f };
            Gl.glLightfv(Gl.GL_LIGHT5, Gl.GL_POSITION, light5_position);
            Gl.glLightfv(Gl.GL_LIGHT5, Gl.GL_SPOT_DIRECTION, light5_direction);

            float[] light6_position = new float[] { 4.0f, 5.0f, -4.0f, 1.0f };
            float[] light6_direction = new float[] { 0.0f, -1.0f, 0.0f };
            Gl.glLightfv(Gl.GL_LIGHT6, Gl.GL_POSITION, light6_position);
            Gl.glLightfv(Gl.GL_LIGHT6, Gl.GL_SPOT_DIRECTION, light6_direction);

            float[] light7_position = new float[] { -4.0f, 5.0f, -4.0f, 1.0f };
            float[] light7_direction = new float[] { 0.0f, -1.0f, 0.0f };
            Gl.glLightfv(Gl.GL_LIGHT7, Gl.GL_POSITION, light7_position);
            Gl.glLightfv(Gl.GL_LIGHT7, Gl.GL_SPOT_DIRECTION, light7_direction);
            Gl.glPopMatrix();

            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            Gl.glPushMatrix();
            Gl.glTranslated(0.0, 1.0, -3.0);
            room();
            Table_cube();
            poster0();
            poster1();
            poster2();         
            Gl.glPushMatrix();
            float scale = 2.0f / modelSize; 
            Gl.glScalef(scale, scale, scale); 
            Gl.glTranslatef(-modelCenter[0], -modelCenter[1]-7.5f, -modelCenter[2]-1f);
            myModel.DrawByOpenGL2();
            Gl.glPopMatrix();

            glass();
   
            Gl.glPopMatrix();
            Gl.glDisable(Gl.GL_COLOR_MATERIAL);
            
        }
    }
}
