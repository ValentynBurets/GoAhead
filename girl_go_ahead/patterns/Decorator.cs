using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace girl_go_ahead.patterns
{
    public interface SimplePerson
    {
        int timer { get; set; }
        int jumpSpeed { get; set; }
        int force { get; set; }

        int playSpeed { get; set; }
        int backLeft { get; set; }

        void actions(Parameters param);
    }

    public class Person : SimplePerson
    {
        public int timer { get; set; }
        public int jumpSpeed { get; set; }
        public int force { get; set; }

        public int playSpeed { get; set; }
        public int backLeft { get; set; }

        public void actions(Parameters param)
        {
            //linking the jumpspeed integer with the player picture boxes to location
            param.player.Top += jumpSpeed;

            //refresh the player picture box consistently
            param.player.Refresh();

            //if jumping is true and forse is less then 0
            // then change jumping to false
            if (param.jumping && force < 0)
            {
                param.jumping = false;
            }

            // if jumping is true
            // then change jumping speed to -12
            // reduce force by 1
            if (param.jumping)
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
            if (param.goleft && param.player.Left > 100)
            {
                param.player.Left -= playSpeed;
            }
            // by doing the if statement above, the player picture will stop on the forms left

            //if go right Boolean is true
            //player left plus players width plus 100 is less then the forms width
            // then we move the player towards the right by adding to the players left
            if (param.goright && param.player.Left + (param.player.Width + 100) < param.form.ClientSize.Width)
            {
                param.player.Left += playSpeed;
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
                        x is PictureBox && x.Tag == "door" || x is PictureBox && x.Tag == "key")
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
                        x is PictureBox && x.Tag == "door" || x is PictureBox && x.Tag == "key")
                    {
                        x.Left -= backLeft;
                    }
                }
            }
        }
    }

    public class PersonDecorator: SimplePerson
    {
        public int timer { get; set; }
        public int jumpSpeed { get; set; }
        public int force { get; set; }

        public int playSpeed { get; set; }
        public int backLeft { get; set; }

        protected readonly SimplePerson _component;

        public PersonDecorator(SimplePerson component)
        {
            this._component = component;
        }

        public virtual void actions(Parameters param)
        {
            this._component.actions(param);
        }

        
    }


    public class Girl_with_appotunities : PersonDecorator
    {
        public Girl_with_appotunities(SimplePerson person) : base(person) { }
        public override void actions(Parameters param)
        {
            this._component.actions(param);

            this.meet_objects(param);
        }

        public void meet_objects(Parameters param)
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
                        force = 8;
                        param.player.Top = x.Top - param.player.Height; // also we place the player on top of the picturebox
                        jumpSpeed = 0; // set the jump speed to 0
                    }
                }
            }

            // if the player collides with the door and has key boolean is true

            if (param.player.Bounds.IntersectsWith(param.house.Bounds) && param.hasKey)
            {
                // then we change the image of the door to open
                param.house.Image = Properties.Resources.open_house;
                //and we stop the timer
                param.score++;
                param.score++;
                param.score_label.Text = param.score.ToString();
                param.gameTimer.Stop();
                MessageBox.Show("You Complited the level!!");
            }

            // if the player collides with the coin

            foreach (PictureBox item in param.coins)
            {
                if (param.player.Bounds.IntersectsWith(item.Bounds))
                {
                    param.info_lable.Text = "take a coin";
                    item.Visible = false;
                    item.Enabled = false;
                    item.Tag = "false";
                    param.score++;
                    param.score_label.Text = param.score.ToString();
                }
            }

            // if the player collides with the key picture box

            if (param.player.Bounds.IntersectsWith(param.key.Bounds))
            {
                //then we remove the key from the game
                param.form.Controls.Remove(param.key);
                //change the has key boolean to true
                param.hasKey = true;
            }

            // this is where the player dies
            // if the player goes below the forms height then we will end the game
            if (param.player.Top + param.player.Height > param.form.ClientSize.Height + 60)
            {
                param.gameTimer.Stop();
                MessageBox.Show("You Died!!!");
            }
            timer++;
        }
    }

    public class Boy_with_appotunities : PersonDecorator
    {
        public Boy_with_appotunities(SimplePerson person) : base(person) { }
        public override void actions(Parameters param)
        {
            this._component.actions(param);

            this.meet_objects(param);
        }

        public void meet_objects(Parameters param)
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
                        force = 8;
                        param.player.Top = x.Top - param.player.Height; // also we place the player on top of the picturebox
                        jumpSpeed = 0; // set the jump speed to 0
                    }
                }
            }

            // if the player collides with the door and has key boolean is true

            if (param.player.Bounds.IntersectsWith(param.house.Bounds) && param.hasKey)
            {
                // then we change the image of the door to open
                param.house.Image = Properties.Resources.open_house;
                //and we stop the timer
                param.score++;
                param.score++;
                param.score_label.Text = param.score.ToString();
                param.gameTimer.Stop();
                MessageBox.Show("You Complited the level!!");
            }

            // if the player collides with the coin

            foreach (PictureBox item in param.coins)
            {
                if (param.player.Bounds.IntersectsWith(item.Bounds))
                {
                    param.info_lable.Text = "take a coin";
                    item.Visible = false;
                    item.Enabled = false;
                    item.Tag = "false";
                    param.score++;
                    param.score_label.Text = param.score.ToString();
                }
            }

            // if the player collides with the key picture box

            if (param.player.Bounds.IntersectsWith(param.key.Bounds))
            {
                //then we remove the key from the game
                param.form.Controls.Remove(param.key);
                //change the has key boolean to true
                param.hasKey = true;
            }

            // this is where the player dies
            // if the player goes below the forms height then we will end the game
            if (param.player.Top + param.player.Height > param.form.ClientSize.Height + 60)
            {
                param.gameTimer.Stop();
                MessageBox.Show("You Died!!!");
            }
            timer++;
        }
    }

    public static class DecoratorDemo
    {
        public static void ActionPerson(SimplePerson element, Parameters param)
        {
            element.actions(param);
        }

        public static void Execute(Parameters param)
        {
            Person person = new Person();
            DecoratorDemo.ActionPerson(person, param);

            Girl_with_appotunities girl = new Girl_with_appotunities(person);
            girl.meet_objects(param);

            Boy_with_appotunities boy = new Boy_with_appotunities(person);
            boy.meet_objects(param);

            DecoratorDemo.ActionPerson(boy, param);
        }
    }

}
