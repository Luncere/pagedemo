using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1082007_HW4_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            show_text.Text = textName.Text + "您好，";
            if (checkedListBox1.CheckedItems.Count > 0)
            {
                show_text.Text += "你買了";
                for(int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                {
                    show_text.Text += checkedListBox1.CheckedItems[i] + ",";
                }
            }
            show_text.Text += "付款為";
            if (radiobt.Checked)
            {
                show_text.Text += radiobt.Text+"，";
            }
            else
            {
                show_text.Text += radioATM.Text+"，";
            }
            show_text.Text += "產品於" + dateTimePicker1.Text + "送達，謝謝";
        }
        public void check_bt()
        {
            if (textName.Text != "" && checkedListBox1.CheckedItems.Count > 0 &&(radiobt.Checked||radioATM.Checked))
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void textName_TextChanged(object sender, EventArgs e)
        {
            check_bt();
        }

        private void checkedListBox1_MouseUp(object sender, MouseEventArgs e)
        {
            check_bt();
        }
    }
}
