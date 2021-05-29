namespace girl_go_ahead
{
    partial class HomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ExitButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.OpenFirst = new System.Windows.Forms.Button();
            this.LoadL1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::girl_go_ahead.Properties.Resources.home_background;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(990, 554);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(371, 379);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(208, 37);
            this.ExitButton.TabIndex = 1;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(371, 310);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(208, 42);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // OpenFirst
            // 
            this.OpenFirst.Location = new System.Drawing.Point(371, 168);
            this.OpenFirst.Name = "OpenFirst";
            this.OpenFirst.Size = new System.Drawing.Size(208, 34);
            this.OpenFirst.TabIndex = 3;
            this.OpenFirst.Text = "Level 1";
            this.OpenFirst.UseVisualStyleBackColor = true;
            this.OpenFirst.Click += new System.EventHandler(this.OpenFirst_Click);
            // 
            // LoadL1
            // 
            this.LoadL1.Location = new System.Drawing.Point(620, 168);
            this.LoadL1.Name = "LoadL1";
            this.LoadL1.Size = new System.Drawing.Size(157, 34);
            this.LoadL1.TabIndex = 4;
            this.LoadL1.Text = "Load L1";
            this.LoadL1.UseVisualStyleBackColor = true;
            this.LoadL1.Click += new System.EventHandler(this.LoadL1_Click);
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 551);
            this.Controls.Add(this.LoadL1);
            this.Controls.Add(this.OpenFirst);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.pictureBox1);
            this.Name = "HomeForm";
            this.Text = "Home";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button OpenFirst;
        private System.Windows.Forms.Button LoadL1;
    }
}