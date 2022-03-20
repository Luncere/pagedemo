namespace _1082007_HW4_1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.show_picture = new System.Windows.Forms.PictureBox();
            this.btn_up = new System.Windows.Forms.Button();
            this.btn_down = new System.Windows.Forms.Button();
            this.btn_folder = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_pic = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.show_picture)).BeginInit();
            this.SuspendLayout();
            // 
            // show_picture
            // 
            this.show_picture.Location = new System.Drawing.Point(22, 12);
            this.show_picture.Name = "show_picture";
            this.show_picture.Size = new System.Drawing.Size(751, 319);
            this.show_picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.show_picture.TabIndex = 0;
            this.show_picture.TabStop = false;
            // 
            // btn_up
            // 
            this.btn_up.Location = new System.Drawing.Point(219, 386);
            this.btn_up.Name = "btn_up";
            this.btn_up.Size = new System.Drawing.Size(112, 34);
            this.btn_up.TabIndex = 1;
            this.btn_up.Text = "上一張";
            this.btn_up.UseVisualStyleBackColor = true;
            this.btn_up.Click += new System.EventHandler(this.btn_up_Click);
            // 
            // btn_down
            // 
            this.btn_down.Enabled = false;
            this.btn_down.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_down.Location = new System.Drawing.Point(459, 386);
            this.btn_down.Name = "btn_down";
            this.btn_down.Size = new System.Drawing.Size(112, 34);
            this.btn_down.TabIndex = 1;
            this.btn_down.Text = "下一張";
            this.btn_down.UseVisualStyleBackColor = true;
            this.btn_down.Click += new System.EventHandler(this.btn_down_Click);
            // 
            // btn_folder
            // 
            this.btn_folder.Location = new System.Drawing.Point(661, 355);
            this.btn_folder.Name = "btn_folder";
            this.btn_folder.Size = new System.Drawing.Size(112, 34);
            this.btn_folder.TabIndex = 1;
            this.btn_folder.Text = "選擇資料夾";
            this.btn_folder.UseVisualStyleBackColor = true;
            this.btn_folder.Click += new System.EventHandler(this.btn_folder_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(22, 386);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(112, 34);
            this.btn_clear.TabIndex = 2;
            this.btn_clear.Text = "reset";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_pic
            // 
            this.btn_pic.Location = new System.Drawing.Point(661, 396);
            this.btn_pic.Name = "btn_pic";
            this.btn_pic.Size = new System.Drawing.Size(112, 34);
            this.btn_pic.TabIndex = 3;
            this.btn_pic.Text = "選擇圖片";
            this.btn_pic.UseVisualStyleBackColor = true;
            this.btn_pic.Click += new System.EventHandler(this.btn_pic_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_pic);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_folder);
            this.Controls.Add(this.btn_down);
            this.Controls.Add(this.btn_up);
            this.Controls.Add(this.show_picture);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "簡易看圖程式";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.show_picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox show_picture;
        private System.Windows.Forms.Button btn_up;
        private System.Windows.Forms.Button btn_down;
        private System.Windows.Forms.Button btn_folder;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_pic;
    }
}

