namespace _1082007_HW4
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
            this.openGLControl1 = new MyOpenGLControl();
            this.SuspendLayout();
            // 
            // openGLControl1
            // 
            this.openGLControl1.AccumBits = ((byte)(0));
            this.openGLControl1.AutoCheckErrors = false;
            this.openGLControl1.AutoFinish = false;
            this.openGLControl1.AutoMakeCurrent = true;
            this.openGLControl1.AutoSwapBuffers = true;
            this.openGLControl1.BackColor = System.Drawing.Color.Black;
            this.openGLControl1.ColorBits = ((byte)(32));
            this.openGLControl1.DepthBits = ((byte)(16));
            this.openGLControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openGLControl1.Location = new System.Drawing.Point(0, 0);
            this.openGLControl1.Name = "openGLControl1";
            this.openGLControl1.Size = new System.Drawing.Size(800, 450);
            this.openGLControl1.StencilBits = ((byte)(0));
            this.openGLControl1.TabIndex = 0;
            this.openGLControl1.Load += new System.EventHandler(this.openGLControl1_Load);
            this.openGLControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.openGLControl1_Paint);
            this.openGLControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.openGLControl1_KeyDown);
            this.openGLControl1.Resize += new System.EventHandler(this.openGLControl1_Resize);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.openGLControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.OpenGLControl openGLControl1;
    }
    public class MyOpenGLControl : Tao.Platform.Windows.OpenGLControl
    {
        protected override bool IsInputKey(System.Windows.Forms.Keys keyData)
        {
            if (keyData == System.Windows.Forms.Keys.Left ||
                keyData == System.Windows.Forms.Keys.Right ||
                keyData == System.Windows.Forms.Keys.Up ||
                keyData == System.Windows.Forms.Keys.Down)
                return true;
            return base.IsInputKey(keyData);
        }
    }

}

