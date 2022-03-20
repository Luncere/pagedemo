namespace _1082007_final_project
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Show_Score_count = new System.Windows.Forms.Label();
            this.Start_btn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.show_level = new System.Windows.Forms.Label();
            this.show_HighScore = new System.Windows.Forms.Label();
            this.text = new System.Windows.Forms.Label();
            this.god_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox1.Location = new System.Drawing.Point(98, 103);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 500);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // Show_Score_count
            // 
            this.Show_Score_count.AutoSize = true;
            this.Show_Score_count.Font = new System.Drawing.Font("新細明體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Show_Score_count.Location = new System.Drawing.Point(283, 50);
            this.Show_Score_count.Name = "Show_Score_count";
            this.Show_Score_count.Size = new System.Drawing.Size(143, 40);
            this.Show_Score_count.TabIndex = 1;
            this.Show_Score_count.Text = "Score: 0";
            // 
            // Start_btn
            // 
            this.Start_btn.Location = new System.Drawing.Point(686, 442);
            this.Start_btn.Name = "Start_btn";
            this.Start_btn.Size = new System.Drawing.Size(114, 48);
            this.Start_btn.TabIndex = 2;
            this.Start_btn.Text = "開始遊戲";
            this.Start_btn.UseVisualStyleBackColor = true;
            this.Start_btn.Click += new System.EventHandler(this.Start_btn_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // show_level
            // 
            this.show_level.AutoSize = true;
            this.show_level.Font = new System.Drawing.Font("新細明體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.show_level.Location = new System.Drawing.Point(679, 103);
            this.show_level.Name = "show_level";
            this.show_level.Size = new System.Drawing.Size(142, 40);
            this.show_level.TabIndex = 3;
            this.show_level.Text = "Level: 1";
            // 
            // show_HighScore
            // 
            this.show_HighScore.Font = new System.Drawing.Font("新細明體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.show_HighScore.Location = new System.Drawing.Point(659, 291);
            this.show_HighScore.Name = "show_HighScore";
            this.show_HighScore.Size = new System.Drawing.Size(162, 39);
            this.show_HighScore.TabIndex = 4;
            this.show_HighScore.Text = "0";
            this.show_HighScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // text
            // 
            this.text.AutoSize = true;
            this.text.Font = new System.Drawing.Font("新細明體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.text.Location = new System.Drawing.Point(652, 227);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(179, 40);
            this.text.TabIndex = 5;
            this.text.Text = "HighScore";
            // 
            // god_btn
            // 
            this.god_btn.Location = new System.Drawing.Point(707, 536);
            this.god_btn.Name = "god_btn";
            this.god_btn.Size = new System.Drawing.Size(75, 57);
            this.god_btn.TabIndex = 6;
            this.god_btn.Text = "金手指";
            this.god_btn.UseVisualStyleBackColor = true;
            this.god_btn.Click += new System.EventHandler(this.god_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(878, 644);
            this.Controls.Add(this.god_btn);
            this.Controls.Add(this.text);
            this.Controls.Add(this.show_HighScore);
            this.Controls.Add(this.show_level);
            this.Controls.Add(this.Start_btn);
            this.Controls.Add(this.Show_Score_count);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Show_Score_count;
        private System.Windows.Forms.Button Start_btn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label show_level;
        private System.Windows.Forms.Label show_HighScore;
        private System.Windows.Forms.Label text;
        private System.Windows.Forms.Button god_btn;
    }
}

