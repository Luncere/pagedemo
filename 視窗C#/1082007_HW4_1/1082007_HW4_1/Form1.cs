using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _1082007_HW4_1
{
    public partial class Form1 : Form
    {
        List<string> filename_box = new List<string>();
        int this_point=0;
        public Form1(){
            InitializeComponent();
        }

        private void btn_folder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fileflg = new FolderBrowserDialog();
            if (fileflg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    add(fileflg.SelectedPath, "*.jpg");
                    add(fileflg.SelectedPath, "*.png");
                    add(fileflg.SelectedPath, "*.gif");
                    show_picture.Load(filename_box[this_point]);
                    this.Text = "目前所在第" + (this_point + 1).ToString() + "張";
                    check_Enabled();
                }
                catch (Exception )
                {
                }
            }
        }
        private void add(string Path,string filetype)
        {
            var Files = Directory.EnumerateFiles(Path, filetype);
            for (int i = 0; i < Files.Count(); i++)
            {
                filename_box.Add(Files.ElementAt(i));
            }
        }
        private void btn_pic_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileflg = new OpenFileDialog();
            fileflg.Filter = "JPG files(*.jpg)|*.jpg|PNG files(*.png)|*.png|GIF files(*.gif)|*.gif";
            if (fileflg.ShowDialog() == DialogResult.OK)
            {
                filename_box.Add(fileflg.FileName);
                show_picture.Load(filename_box[this_point]);
            }
            this.Text = "目前所在第" + (this_point + 1).ToString() + "張";
            check_Enabled();
        }

        private void btn_down_Click(object sender, EventArgs e){
            if (this_point < filename_box.Count-1){
                show_picture.Load(filename_box[++this_point]);
            }
            this.Text = "目前所在第" + (this_point + 1).ToString() + "張";
            check_Enabled();
        }

        private void btn_up_Click(object sender, EventArgs e){
            if (this_point > 0){
                show_picture.Load(filename_box[--this_point]);
            }
            this.Text = "目前所在第" + (this_point+1).ToString() + "張";
            check_Enabled();
        }
        public void check_Enabled(){
            if (this_point >= filename_box.Count - 1){
                btn_down.Enabled = false;
            }
            else{
                btn_down.Enabled = true;
            }
            if (this_point == 0){
                btn_up.Enabled = false;
            }
            else{
                btn_up.Enabled = true;
            }
        }
        private void Form1_Load(object sender, EventArgs e){
            check_Enabled();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            show_picture.Image = null;
            filename_box.Clear();
            this_point = 0;
            check_Enabled();
            this.Text="簡易看圖程式";
        }
    }
}
