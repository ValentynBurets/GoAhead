using girl_go_ahead.patterns;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace girl_go_ahead
{
    
    class person
    {
        protected int backLeft = 4;     //this integer will set the background moving speed to 8

        public person()
        { }

        public void actions(Parameters param)
        {
            //linking the jumpspeed integer with the player picture boxes to location
            param.player.Top += param.jumpSpeed;

            //refresh the player picture box consistently
            param.player.Refresh();

            //if jumping is true and forse is less then 0
            // then change jumping to false
            if (param.jumping && param.force < 0)
            {
                param.jumping = false;
            }

            // if jumping is true
            // then change jumping speed to -12
            // reduce force by 1
            if (param.jumping)
            {
               // param = param.context.Request(ref param, ref param.apple);  // turn in other state
                param.jumpSpeed = -12;
                param.force -= 1;
            }
            else
            {
                //else change the jump speed to 12
                param.jumpSpeed = 12;
                param.force -= 1;
            }

            // if go left is true and players left is greater than 100 pixels
            // only then move player toward left
            if (param.goleft && param.player.Left > 100)
            {
                param.player.Left -= param.playSpeed;
            }
            // by doing the if statement above, the player picture will stop on the forms left

            //if go right Boolean is true
            //player left plus players width plus 100 is less then the forms width
            // then we move the player towards the right by adding to the players left
            if (param.goright && param.player.Left + (param.player.Width + 100) < param.form.ClientSize.Width)
            {
                param.player.Left += param.playSpeed;
            }

            //by doing the if statement above, the player picture will stop on the forms right 

            //if go right is true and the background picture left is greter 1352
            //then we move the background picture towards the left
            if (param.goright && param.background.Left > -1353)
            {
                param.background.Left -= backLeft;

                // the for loop below is checking to see the platforms and coins in the level
                // when they are found it will move them towards the left
                foreach (Control x in param.form.Controls)
                {
                    if (x is PictureBox && x.Tag == "platform" || x is PictureBox && x.Tag == "coin" ||
                        x is PictureBox && x.Tag == "door" || x is PictureBox && x.Tag == "key" || x is PictureBox && x.Tag == "apple")
                    {
                        x.Left -= backLeft;
                    }
                }
            }

            // if go left is true and the background pictures is less then 2
            // then we move the background picture towar s the right
            if (param.goleft && param.background.Left < 2)
            {
                param.background.Left += backLeft;
                // below there is the for loop thats checking to see the platforms and coins in the level
                // when they are found in the level it will move them all towards the right with the background
                foreach (Control x in param.form.Controls)
                {
                    if (x is PictureBox && x.Tag == "platform" || x is PictureBox && x.Tag == "coin" ||
                        x is PictureBox && x.Tag == "door" || x is PictureBox && x.Tag == "key" || x is PictureBox && x.Tag == "apple")
                    {
                        x.Left -= backLeft;
                    }
                }
            }
        }
        public Parameters meet_objects(ref Parameters param)
        {
            //below if the for loop thats checking for all of the controls in this form
            foreach (Control x in param.form.Controls)
            {
                //is X is a picture box and it has a tag of platform
                if (x is PictureBox && x.Tag == "platform")
                {
                    //then we are checking if the player is the player is colliding with the platform
                    //and jamping is set to false
                    if (param.player.Bounds.IntersectsWith(x.Bounds) && !param.jumping)
                    {
                        param.force = 8;
                        param.player.Top = x.Top - param.player.Height; // also we place the player on top of the picturebox
                        param.jumpSpeed = 0; // set the jump speed to 0
                    }
                }
            }

            // if the player collides with the door and has key boolean is true

            if (param.hasKey)
             //   MessageBox.Show("ok");

            if (param.player.Bounds.IntersectsWith(param.house.Bounds) && param.hasKey)
            {
                // then we change the image of the door to open
                param.house.Image = Properties.Resources.open_house;
                //and we stop the timer
                param.score++;
                param.score_label.Text = param.score.ToString();
                param.gameTimer.Stop();
                MessageBox.Show("You Complited the level!!");
            }
            
            // if the player collides with the coin

            if(param.coins.Length != 0 && param.coins != null)
            {
                int i = 0;
                foreach (PictureBox item in param.coins)
                {
                    if (item == null)
                    {
                        continue;
                    }
                    if (param.player.Bounds.IntersectsWith(item.Bounds))
                    {
                        param.info_lable.Text = "take a coin";
                        param.coins[i] = null;

                        param = param.stock.AddMoney(param, 100);


                        param.score_label.Text = param.score.ToString();
                    }
                    i++;
                }
            }

  
            // if the player collides with the key picture box

            if (param.player.Bounds.IntersectsWith(param.key.Bounds))
            {
                param = param.context.Request(ref param, ref param.key);  // turn in other state
                param.info_lable.Text = "take a key";

                //then we remove the key from the game
                param.form.Controls.Remove(param.key);
                //change the has key boolean to true
                param.hasKey = true;
            }

            // if the player collides with the apple picture box
            
            if (param.player.Bounds.IntersectsWith(param.apple.Bounds))
            {

                param = param.context.Request(ref param, ref param.apple);  // turn in other state
                param.info_lable.Text = "ate an apple";

                param.apple.Image = Properties.Resources.ate_apple;
                //param.apple.Enabled = false;
                param.form.Controls.Remove(param.shop);
                param.background.Controls.Remove(param.shop);
            }


            // if the player collides with the shop picture box

            if (param.player.Bounds.IntersectsWith(param.shop.Bounds))
            {

                param = param.stock.Market(param);
                //param = param.context.Request(ref param, ref param.shop);  // turn in other state

                param.info_lable.Text = "visited shop";

                //param.shop.Image = Properties.Resources.
                param.shop.Enabled = false;
            }

            // if the player collides with the moster picture box

            foreach (PictureBox item in param.monsters)
            {
                if (param.player.Bounds.IntersectsWith(item.Bounds))
                {
                    param.info_lable.Text = "met monster";
                    param.gameTimer.Stop();
                    MessageBox.Show("You Died!!! YOU MET MONSTER");
                }
            }
            

            // this is where the player dies
            // if the player goes below the forms height then we will end the game
            if (param.player.Top + param.player.Height > param.form.ClientSize.Height + 60)
            {
                param.gameTimer.Stop();
                MessageBox.Show("You Died!!!");
            }
            param.timer++;
            return param;
        }
    }
    class girl_logic: person
    {
        int backLeft = 8;     //this integer will set the background moving speed to 8

        public girl_logic()
        { }

    }


    class boy_logic: person
    {
        int backLeft = 12;     //this integer will set the background moving speed to 8


        public boy_logic()
        { }

       
                 
    }
    



    class VisualStudioFacade
    {
        girl_logic girl;
        //boy_logic boy;
        public VisualStudioFacade(girl_logic g)//, boy_logic b)
        {
            this.girl = g;
            //this.boy = b;
        }
        public Parameters Start(ref Parameters param)
        {
            girl.actions(param);
            param.Refresh(girl.meet_objects(ref param));

            //boy.actions(param);
            //boy.meet_objects(param);
            return param;
        }
        public void Stop()
        {
            
        }
    }


}
