using girl_go_ahead.patterns;
using System;
using System.Drawing;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace girl_go_ahead
{
    public partial class Form1 : Form
    {
        public bool load;
        int timer;
        bool message = false;
        bool goleft = false;  // boolean which will control players going left
        bool goright = false; // boolean which will control players going right
        bool jumping = false; // boolean to check if player is jumping or not
        bool hasKey = false;  // default value of whether the player has the key

        int jumpSpeed = 10;   // integer to set jump speed
        int force = 8;        // fors of the jump ia an integer
        int score = 0;        // default score integer set to 0

        int playSpeed = 18;   //this integer will set players speed to 18
        //int backLeft = 4;     //this integer will set the background moving speed to 8

        Context context;     //use to change the player's game state

        Score stock;



        PictureBox[] coins;

        //sounds parameters
        Sound_param sound_param = new Sound_param();
        Parameters param;
        girl_logic girl = new girl_logic();

        //boy_logic boy = new boy_logic();

        VisualStudioFacade users;

        Programmer programmer = new Programmer();


        Component root = new main_sound_Composite("composite");
        Component other_sounds = new other_sounds("other_sounds");
        main_sound_Composite subtree = new main_sound_Composite("background");

        // object for saving game data
        GameHistory gameData = new GameHistory();


        public Form1()
        {

            Singleton.GetInstance();

            InitializeComponent();

            //initialize observer
            Score stock = new Score();
            Shop bank = new Shop(stock);
            Customer client = new Customer(stock);
            //--------

            int x = 0;
            for (int i = 0; i < 20; i++)
            {
                PictureBox picture = new PictureBox();

                picture.Name = "pictureBox";
                picture.Image = Properties.Resources.platform;
                picture.Tag = "platform";
                picture.Size = new System.Drawing.Size(100, 50);
                picture.Location = new System.Drawing.Point(x, 474);

                PictureBox pic_background = new PictureBox();
                pic_background.Name = "pictureBox";
                pic_background.Image = Properties.Resources.platform;
                pic_background.Tag = "platform";
                pic_background.Size = new System.Drawing.Size(100, 50);
                pic_background.Location = new System.Drawing.Point(x, 474);
                background.Controls.Add(pic_background);

                this.Controls.Add(picture);
                x += 100;
            }
            Singleton.Log("OK form platforms created");

            //create coin on the form
            //------------------------------------------------------------------
            int coinQuantity = 5;
            coinQuantity++;
            coins = new PictureBox[coinQuantity];
            x = 0;
            for (int i = 0; i < coinQuantity; i++)
            {
                PictureBox picture = new PictureBox();

                picture.Name = "coin";
                picture.Image = Properties.Resources.coin;
                picture.Tag = "coin";
                picture.Size = new System.Drawing.Size(35, 37);
                picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                picture.Location = new System.Drawing.Point(x, 400);

                PictureBox pic_background = new PictureBox();
                pic_background.Name = "coin";
                pic_background.Image = Properties.Resources.coin;
                pic_background.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pic_background.Tag = "coin";
                pic_background.Size = new System.Drawing.Size(35, 37);
                pic_background.Location = new System.Drawing.Point(x, 400);
                background.Controls.Add(pic_background);

                this.Controls.Add(picture);
                x += 200;
                //coins[i] = picture;
                coins[i] = pic_background;
            }

            // coins[coinQuantity] = pictureBox2;
            //--------------------------------
            //create Shop on the Form

            shop = new PictureBox();

            shop.Name = "shop";
            shop.Image = Properties.Resources.shop;
            shop.Tag = "shop";
            shop.Size = new System.Drawing.Size(215, 232);
            shop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            shop.Location = new System.Drawing.Point(2, 216);

            PictureBox shop_background = new PictureBox();
            shop_background.Name = "shop";
            shop_background.Image = Properties.Resources.shop;
            shop_background.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            shop_background.Tag = "shop";
            shop_background.Size = new System.Drawing.Size(215, 232);
            shop_background.Location = new System.Drawing.Point(2, 216);
            
            background.Controls.Add(shop_background);
            this.Controls.Add(shop);
            

            //-------------------------------------------------------------------
            //sound_param.refresh(ref goleft, ref goright, ref jumping, ref hasKey);

            root.Add(other_sounds);
            root.Add(subtree);
            root.Display();
            root.Play(sound_param);

            CreateExit();

            PictureBox[] monsters = new PictureBox[1];
            monsters[0] = monster;

            //context pattern 
            context = new Context(new UsualState(param));

            param = new Parameters();
            param.Refresh(ref shop, ref stock, ref message, ref timer, ref context, ref jumpSpeed, ref force, ref playSpeed, ref goleft, ref goright, ref jumping, ref hasKey, ref score,
                this, ref player, ref apple, ref monsters, ref gameTimer, ref background, ref house2, ref score_label, ref coins, ref info_lable, ref key);

            users = new VisualStudioFacade(girl);//, boy);

        }


        private void mainGameTimer(object sender, EventArgs e)
        {
            //initialize observer
            Score stock = new Score();
            Shop bank = new Shop(stock);
            Customer client = new Customer(stock);
            //--------


            //sound_param.refresh(ref goleft, ref goright, ref jumping, ref hasKey);

            if (timer%3 == 0 || timer % 3 == 2 || timer % 3 == 0)
                CreateEnemy(playSpeed, timer);

            PictureBox[] monsters = new PictureBox[1];
            monsters[0] = monster;


            param.Refresh(ref shop, ref stock, ref message, ref timer, ref context, ref jumpSpeed, ref force, ref playSpeed, ref goleft, ref goright, ref jumping, ref hasKey, ref score,
                this, ref player, ref apple, ref monsters, ref gameTimer, ref background, ref house, ref score_label, ref coins, ref info_lable, ref key);

            //if we must load last state of game
            if (load)
            {
                param = programmer.LoadState(param);
                load = false;
            }

            param.Refresh(programmer.CreateApplication(users, ref param));

            if (programmer.saved())
            {
                gameData.History.Push(programmer.SaveState()); // save game
            }
            else
            {
                if(timer % 100 < 20)
                    programmer.RestoreState(gameData.History.Pop());
            }



            RefreshActualParameters(param);
            RefreshTable();
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                goleft = true;
            }

            if(e.KeyCode == Keys.Right)
            {
                goright = true;
            }

            if(e.KeyCode == Keys.Space && !jumping)
            {
                jumping = true;
            }

        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if(e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if(jumping)
            {
                jumping = false;
            }
        }

        private void RefreshActualParameters(Parameters param)
        {
            message = param.message;
            context = param.context;
            hasKey = param.hasKey;
            jumpSpeed = param.jumpSpeed;
            force = param.force;
            score = param.score;
            playSpeed = param.playSpeed;
            timer = param.timer;

            if(param.shop.Enabled == false)
            {
                shop.Visible = false;
                shop.Enabled = false;
                this.Controls.Remove(shop);
            }

            //coins = new PictureBox[param.coins.Length];
            int i = 0;
            foreach (PictureBox item in param.coins)
            {
                coins[i] = item;
                i++;
            }
        }

        private void RefreshTable()
        {
            time_lable.Text = timer.ToString();
            score_label.Text = score.ToString();
            speed_label.Text = playSpeed.ToString();
        }

    }
}




/*
    public bool show message()
    {
        DialogResult res = MessageBox.Show("Do you want to eat an apple?",
        Choice", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

        { }
        if (res == DialogResult.OK)
        {
            MessageBox.Show("You eat an apple! And get an boost!");
            param = param.context.Request(ref param, ref param.apple);  // turn in other state
        }
        if (res == DialogResult.Cancel)
        {
            MessageBox.Show("You aren`t hungry!");
        }
 
    

    //while(res != DialogResult.OK && res != DialogResult.Cancel)

}


*/





//------------------------------------

//-----------------------------
//old Game ligic



/*
//linking the jumpspeed integer with the player picture boxes to location
player.Top += jumpSpeed;

//refresh the player picture box consistently
player.Refresh();

//if jumping is true and forse is less then 0
// then change jumping to false
if (jumping && force < 0)
{
    jumping = false;
}

// if jumping is true
// then change jumping speed to -12
// reduce force by 1
if(jumping)
{
    jumpSpeed = -12;
    force -= 1;
}
else
{
    //else change the jump speed to 12
    jumpSpeed = 12;
    force -= 1;
}

// if go left is true and players left is greater than 100 pixels
// only then move player toward left
if(goleft && player.Left > 100)
{
    player.Left -= playSpeed;
}
// by doing the if statement above, the player picture will stop on the forms left

//if go right Boolean is true
//player left plus players width plus 100 is less then the forms width
// then we move the player towards the right by adding to the players left
if(goright && player.Left + (player.Width + 100) < this.ClientSize.Width)
{
    player.Left += playSpeed;
}
//by doing the if statement above, the player picture will stop on the forms right 

//if go right is true and the background picture left is greter 1352
//then we move the background picture towards the left
if(goright && background.Left > -1353)
{
    background.Left -= backLeft;

    // the for loop below is checking to see the platforms and coins in the level
    // when they are found it will move them towards the left
    foreach (Control x in this.Controls)
    {
        if(x is PictureBox && x.Tag == "platform" || x is PictureBox && x.Tag == "coin" || 
            x is PictureBox && x.Tag == "door" || x is PictureBox && x.Tag == "key")
        {
            x.Left -= backLeft;
        }
    }
}

// if go left is true and the background pictures is less then 2
// then we move the background picture towar s the right
if (goleft && background.Left < 2)
{
    background.Left += backLeft;
    // below there is the for loop thats checking to see the platforms and coins in the level
    // when they are found in the level it will move them all towards the right with the background
    foreach (Control x in this.Controls)
    {
        if (x is PictureBox && x.Tag == "platform" || x is PictureBox && x.Tag == "coin" ||
            x is PictureBox && x.Tag == "door" || x is PictureBox && x.Tag == "key")
        {
            x.Left -= backLeft;
        }
    }
}

//below if the for loop thats checking for all of the controls in this form
foreach(Control x in this.Controls)
{
    //is X is a picture box and it has a tag of platform
    if (x is PictureBox && x.Tag == "platform")
    {
        //then we are checking if the player is the player is colliding with the platform
        //and jamping is set to false
        if(player.Bounds.IntersectsWith(x.Bounds) && !jumping)
        {
            force = 8;
            player.Top = x.Top - player.Height; // also we place the player on top of the picturebox
            jumpSpeed = 0; // set the jump speed to 0
        }
    }
}

// if the player collides with the door and has key boolean is true

if (player.Bounds.IntersectsWith(house.Bounds) && hasKey)
{
    // then we change the image of the door to open
    house.Image = Properties.Resources.open_house;
    //and we stop the timer
    score++;
    score++;
    score_label.Text = score.ToString();
    gameTimer.Stop();
    MessageBox.Show("You Complited the level!!");
}

// if the player collides with the coin

if (player.Bounds.IntersectsWith(coin.Bounds))
{
    info_lable.Text = "take a coin";
    coin.Visible = false;
    coin.Enabled = false;
    coin.Tag = "false";
    score++;
    score_label.Text = score.ToString();
}

// if the player collides with the key picture box

if (player.Bounds.IntersectsWith(key.Bounds))
{
    //then we remove the key from the game
    this.Controls.Remove(key);
    //change the has key boolean to true
    hasKey = true;
}

// this is where the player dies
// if the player goes below the forms height then we will end the game
if(player.Top + player.Height > this.ClientSize.Height + 60)
{
    gameTimer.Stop();
    MessageBox.Show("You Died!!!");
}

timer++;
*/
