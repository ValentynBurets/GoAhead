using System.Drawing;
using System.Windows.Forms;

namespace girl_go_ahead
{
    partial class Form1
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

        //void call(int timer, int move)
        void CreateEnemy(int gameSpeed, int timer)
        {
            NPC enemy = new NPC(new MonsterFactory());
            enemy.Hit(this, background, monster);
            enemy.Run(monster, gameSpeed, timer);
        }


        void CreateExit()
        {
            int width = 291;
            int height = 271;
            int x = 1165;
            int y = 200;
            prototype_parameters param = new prototype_parameters(house, width, height, x, y);
            Home figure = new simple_house(param);
            Home clonedFigure = figure.Clone();

            int width_castle = 391;
            int height_castle = 471;
            int x_castle = 1665;
            int y_castle = 0;
            prototype_parameters param_castle = new prototype_parameters(house2, width_castle, height_castle, x_castle, y_castle);

            figure = new castle(param_castle);
            clonedFigure = figure.Clone();
        }


        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.time_lable = new System.Windows.Forms.Label();
            this.info_lable = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.score_label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.speed_label = new System.Windows.Forms.Label();
            this.apple = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.house = new System.Windows.Forms.PictureBox();
            this.house2 = new System.Windows.Forms.PictureBox();
            this.monster = new System.Windows.Forms.PictureBox();
            this.sun = new System.Windows.Forms.PictureBox();
            this.key = new System.Windows.Forms.PictureBox();
            this.player = new System.Windows.Forms.PictureBox();
            this.background = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.apple)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.house)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.house2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.key)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.background)).BeginInit();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.mainGameTimer);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Time";
            // 
            // time_lable
            // 
            this.time_lable.AutoSize = true;
            this.time_lable.Location = new System.Drawing.Point(53, 9);
            this.time_lable.Name = "time_lable";
            this.time_lable.Size = new System.Drawing.Size(13, 13);
            this.time_lable.TabIndex = 17;
            this.time_lable.Text = "0";
            // 
            // info_lable
            // 
            this.info_lable.AutoSize = true;
            this.info_lable.Location = new System.Drawing.Point(78, 55);
            this.info_lable.Name = "info_lable";
            this.info_lable.Size = new System.Drawing.Size(24, 13);
            this.info_lable.TabIndex = 18;
            this.info_lable.Text = "test";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "current info";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Score";
            // 
            // score_label
            // 
            this.score_label.AutoSize = true;
            this.score_label.Location = new System.Drawing.Point(53, 31);
            this.score_label.Name = "score_label";
            this.score_label.Size = new System.Drawing.Size(35, 13);
            this.score_label.TabIndex = 21;
            this.score_label.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "curent speed";
            // 
            // speed_label
            // 
            this.speed_label.AutoSize = true;
            this.speed_label.Location = new System.Drawing.Point(91, 77);
            this.speed_label.Name = "speed_label";
            this.speed_label.Size = new System.Drawing.Size(24, 13);
            this.speed_label.TabIndex = 32;
            this.speed_label.Text = "test";
            // 
            // apple
            // 
            this.apple.Image = global::girl_go_ahead.Properties.Resources.apple;
            this.apple.Location = new System.Drawing.Point(695, 191);
            this.apple.Name = "apple";
            this.apple.Size = new System.Drawing.Size(34, 36);
            this.apple.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.apple.TabIndex = 29;
            this.apple.TabStop = false;
            this.apple.Tag = "apple";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::girl_go_ahead.Properties.Resources.platform;
            this.pictureBox3.Location = new System.Drawing.Point(667, 233);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 50);
            this.pictureBox3.TabIndex = 28;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Tag = "platform";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::girl_go_ahead.Properties.Resources.platform;
            this.pictureBox1.Location = new System.Drawing.Point(290, 200);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "platform";
            // 
            // house
            // 
            this.house.Image = global::girl_go_ahead.Properties.Resources.castle;
            this.house.Location = new System.Drawing.Point(1227, 395);
            this.house.Name = "house";
            this.house.Size = new System.Drawing.Size(100, 50);
            this.house.TabIndex = 25;
            this.house.TabStop = false;
            this.house.Tag = "house";
            // 
            // house2
            // 
            this.house2.Location = new System.Drawing.Point(1904, 398);
            this.house2.Name = "house2";
            this.house2.Size = new System.Drawing.Size(100, 50);
            this.house2.TabIndex = 24;
            this.house2.TabStop = false;
            // 
            // monster
            // 
            this.monster.Image = ((System.Drawing.Image)(resources.GetObject("monster.Image")));
            this.monster.Location = new System.Drawing.Point(1351, 31);
            this.monster.Name = "monster";
            this.monster.Size = new System.Drawing.Size(100, 106);
            this.monster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.monster.TabIndex = 22;
            this.monster.TabStop = false;
            // 
            // sun
            // 
            this.sun.Image = ((System.Drawing.Image)(resources.GetObject("sun.Image")));
            this.sun.Location = new System.Drawing.Point(442, 12);
            this.sun.Name = "sun";
            this.sun.Size = new System.Drawing.Size(140, 98);
            this.sun.TabIndex = 15;
            this.sun.TabStop = false;
            // 
            // key
            // 
            this.key.Image = ((System.Drawing.Image)(resources.GetObject("key.Image")));
            this.key.Location = new System.Drawing.Point(850, 398);
            this.key.Name = "key";
            this.key.Size = new System.Drawing.Size(90, 47);
            this.key.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.key.TabIndex = 14;
            this.key.TabStop = false;
            this.key.Tag = "key";
            // 
            // player
            // 
            this.player.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("player.BackgroundImage")));
            this.player.Image = global::girl_go_ahead.Properties.Resources.girl_go_ahead;
            this.player.Location = new System.Drawing.Point(319, 286);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(71, 126);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player.TabIndex = 9;
            this.player.TabStop = false;
            this.player.Tag = "player";
            // 
            // background
            // 
            this.background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.background.Image = ((System.Drawing.Image)(resources.GetObject("background.Image")));
            this.background.Location = new System.Drawing.Point(-9, -12);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(2000, 480);
            this.background.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.background.TabIndex = 0;
            this.background.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1491, 480);
            this.Controls.Add(this.speed_label);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.apple);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.house);
            this.Controls.Add(this.house2);
            this.Controls.Add(this.monster);
            this.Controls.Add(this.score_label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.info_lable);
            this.Controls.Add(this.time_lable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sun);
            this.Controls.Add(this.key);
            this.Controls.Add(this.player);
            this.Controls.Add(this.background);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "level1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyisup);
            ((System.ComponentModel.ISupportInitialize)(this.apple)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.house)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.house2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.key)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.background)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.PictureBox key;
        private System.Windows.Forms.PictureBox sun;
        private System.Windows.Forms.Timer gameTimer;
        private Label label1;
        private Label time_lable;
        private Label info_lable;
        private Label label2;
        private Label label3;
        private Label score_label;
        private PictureBox monster;
        public PictureBox background;
        private PictureBox house;
        private PictureBox house2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private PictureBox apple;
        private Label label5;
        private Label speed_label;
        PictureBox shop;
    }
}

