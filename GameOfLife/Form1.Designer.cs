namespace GameOfLife
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
            this.cmdReinitialize = new System.Windows.Forms.Button();
            this.picLife = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.picLife)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdReinitialize
            // 
            this.cmdReinitialize.Location = new System.Drawing.Point(659, 12);
            this.cmdReinitialize.Name = "cmdReinitialize";
            this.cmdReinitialize.Size = new System.Drawing.Size(129, 44);
            this.cmdReinitialize.TabIndex = 0;
            this.cmdReinitialize.Text = "Neu starten";
            this.cmdReinitialize.UseVisualStyleBackColor = true;
            this.cmdReinitialize.Click += new System.EventHandler(this.cmdReinitialize_Click);
            // 
            // picLife
            // 
            this.picLife.Location = new System.Drawing.Point(12, 81);
            this.picLife.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.picLife.Name = "picLife";
            this.picLife.Size = new System.Drawing.Size(776, 357);
            this.picLife.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLife.TabIndex = 1;
            this.picLife.TabStop = false;
            this.picLife.Click += new System.EventHandler(this.picLife_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(505, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.Location = new System.Drawing.Point(12, 13);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(3, 3, 50, 3);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(400, 45);
            this.trackBar1.TabIndex = 3;
            //this.trackBar1.Scroll += new System.EventHandler(this.track1_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picLife);
            this.Controls.Add(this.cmdReinitialize);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picLife)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdReinitialize;
        private System.Windows.Forms.PictureBox picLife;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}
