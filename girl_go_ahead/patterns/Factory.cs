using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace girl_go_ahead
{

    abstract class Weapon
    {
        public abstract void Hit(Form form, PictureBox background, PictureBox npc);
    }

    abstract class Movement
    {
        public abstract void Move(PictureBox npc, int PlaySpeed, int timer);
    }


    class Fire : Weapon
    {
        public override void Hit(Form form, PictureBox background, PictureBox npc)
        {
            for (int i = 0; i < 2; i++)
            {

                PictureBox first_picture = new PictureBox();
                PictureBox second_picture = new PictureBox();

                first_picture.Name = "FireBall";
                first_picture.Image = Properties.Resources.fire;
                first_picture.SizeMode = PictureBoxSizeMode.StretchImage;
                first_picture.Tag = "fireBall";
                first_picture.Size = new System.Drawing.Size(30, 30);

                second_picture.Name = "FireBall";
                second_picture.Image = Properties.Resources.fire;
                second_picture.SizeMode = PictureBoxSizeMode.StretchImage;
                second_picture.Tag = "fireBall";
                second_picture.Size = new System.Drawing.Size(30, 30);

                int x = npc.Location.X;
                int y = npc.Location.Y + 50;

                if (i == 0)
                {
                    first_picture.Location = new System.Drawing.Point(x + 200, y);
                    second_picture.Location = new System.Drawing.Point(x + 200, y);
                }
                else
                {
                    first_picture.Location = new System.Drawing.Point(x - 100, y);
                    second_picture.Location = new System.Drawing.Point(x - 100, y);
                }

                background.Controls.Add(first_picture);

                form.Controls.Add(second_picture);

            }
        }
    }
 
    class gun : Weapon
    {
        public override void Hit(Form form, PictureBox background, PictureBox npc)
        {
            for (int i = 0; i < 2; i++)
            {

                PictureBox first_picture = new PictureBox();
                PictureBox second_picture = new PictureBox();

                first_picture.Name = "bullet";
                first_picture.Image = Properties.Resources.bullet;
                first_picture.Tag = "bullet";
                first_picture.Size = new System.Drawing.Size(30, 30);

                second_picture.Name = "bullet";
                second_picture.Image = Properties.Resources.bullet;
                second_picture.Tag = "bullet";
                second_picture.Size = new System.Drawing.Size(30, 30);

                int x = npc.Location.X;
                int y = npc.Location.Y + 50;

                var rand = new Random();
                int duration = rand.Next(0, 100);


                if (i == 0)
                {
                    first_picture.Location = new System.Drawing.Point(x + duration, y);
                    second_picture.Location = new System.Drawing.Point(x + duration, y);
                }
                else
                {
                    first_picture.Location = new System.Drawing.Point(x - duration, y);
                    second_picture.Location = new System.Drawing.Point(x - duration, y);
                }

                background.Controls.Add(first_picture);
                //background.Controls.Add(second_picture);

                //form.Controls.Add(first_picture);
                form.Controls.Add(second_picture);

            }
        }
    }

    class FlyMovement : Movement
    {
        public override void Move(PictureBox npc, int playSpeed, int timer)
        {
            var rand = new Random();
            int flyHeight = rand.Next(0, 100);
            if (npc.Top < 240)
                npc.Top += flyHeight;
            else
                npc.Top -= flyHeight;

            if (timer % 10 <= 5)
                npc.Left -= playSpeed / 5;
            else
                npc.Left += playSpeed / 5;

        }
    }

    class RunMovement : Movement
    {
        public override void Move(PictureBox pnc, int playSpeed, int timer)
        {
            if (timer % 10 <= 5)
                pnc.Left -= playSpeed;
            else
                pnc.Left += playSpeed;
        }
    }

    abstract class heroFactory
    {
        public abstract Movement CreateMovement();
        public abstract Weapon CreateWeapon();
    }

    class MonsterFactory : heroFactory
    {
        public override Movement CreateMovement()
        {
            return new FlyMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Fire();
        }
    }

    class KillerFactory : heroFactory
    {
        public override Movement CreateMovement()
        {
            return new RunMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new gun();
        }
    }

    // client
    class NPC
    {
        private Weapon weapon;
        private Movement movement;
        public NPC(heroFactory factory)
        {
            weapon = factory.CreateWeapon();
            movement = factory.CreateMovement();
        }

        internal void Hit(Form1 form1, PictureBox background, PictureBox monster)
        {
            var rand = new Random();
            int i = rand.Next(10, 100);

            if (i % 3 == 0)
                weapon.Hit(form1, background, monster);
        }

        internal void Run(PictureBox pnc, int playSpeed, int timer)
        {
            var rand = new Random();
            int i = rand.Next(10, 100);

            if (i % 3 == 0)
                movement.Move(pnc, playSpeed, timer);
        }
    }
}

