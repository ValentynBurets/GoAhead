using girl_go_ahead.patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace girl_go_ahead
{
    public class Parameters
    {
        public int jumpSpeed = 10;   // integer to set jump speed
        public int force = 8;        // fors of the jump ia an integer
        public int score = 0;        // default score integer set to 0
        public int playSpeed = 18;   //this integer will set players speed to 18

        public bool message;

        public bool goleft;
        public bool goright;
        public bool jumping;
        public bool hasKey;
        public int timer;
        public Context context;
        public PictureBox shop;

        public Form form;
        public PictureBox player;
        public PictureBox[] monsters;
        public PictureBox[] coins;
        public PictureBox apple;

        public System.Windows.Forms.Timer gameTimer;
        public PictureBox background;
        public PictureBox house;
        public Label score_label;
        public Label info_lable;
        public PictureBox key;

        public Score stock;

        public Parameters() { }
        public void Refresh(ref PictureBox shop, ref Score stock, ref bool message, ref int timer, ref Context context, ref int jumpSpeed, ref int force, ref int playSpeed, ref bool goleft, ref bool goright, ref bool jumping, ref bool hasKey, ref int score,
            Form form, ref PictureBox player, ref PictureBox apple, ref PictureBox[] monsters, ref System.Windows.Forms.Timer gameTimer, ref PictureBox background,
            ref PictureBox house, ref Label score_label, ref PictureBox[] coins, ref Label info_lable, ref PictureBox key)
        {
            this.shop = shop;
            this.stock = stock;
            this.message = message;
            this.timer = timer;
            this.context = context;
            this.jumpSpeed = jumpSpeed;
            this.force = force;
            this.playSpeed = playSpeed;
            this.goleft = goleft;
            this.goright = goright;
            this.jumping = jumping;
            this.hasKey = hasKey;

            this.score = score;
            this.form = form;
            this.player = player;
            this.apple = apple;

            this.monsters = new PictureBox[monsters.Length];
            int i = 0;
            foreach (PictureBox item in monsters)
            {
                this.monsters[i] = item;
                i++;
            }

            this.gameTimer = gameTimer;
            this.background = background;
            this.house = house;
            this.score_label = score_label;

            this.coins = new PictureBox[coins.Length];
            i = 0;
            foreach (PictureBox item in coins)
            {
                this.coins[i] = item;
                i++;
            }

            this.info_lable = info_lable;
            this.key = key;
        }

        public void Refresh(Parameters p)
        {
            this.message = p.message;
            this.context = p.context;
            this.jumpSpeed = p.jumpSpeed;
            this.force = p.force;
            this.playSpeed = p.playSpeed;
            this.hasKey = p.hasKey;
            this.score = p.score;

            //this.coins = new PictureBox[p.coins.Length];
            int i = 0;
            foreach (PictureBox item in p.coins)
            {
                this.coins[i] = item;
                i++;
            }



            //this.form = form;
            //this.player = player;
            //this.gameTimer = gameTimer;
            //this.background = background;
            //this.house = house;
            //this.score_label = score_label;
            //this.coin = coin;
            //this.info_lable = info_lable;
            //this.key = key;
        }
    }
}
