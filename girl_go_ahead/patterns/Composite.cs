using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace girl_go_ahead.patterns
{
    /*
class Client
{
    public void Main()
    {
        Component root = new main_sound_Composite("background");
        Component other_sounds = new other_sounds("other_sounds");
        main_sound_Composite subtree = new main_sound_Composite("Subtree");
        root.Add(other_sounds);
        root.Add(subtree);
        root.Display();
    }
}
*/
    abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        public abstract void Display();
        public abstract void Play(Sound_param param);
        public abstract void Stop();
        public abstract void Add(Component c);
        public abstract void Remove(Component c);
    }
    class main_sound_Composite : Component
    {
        List<Component> children = new List<Component>();
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();

        public main_sound_Composite(string name)
        : base(name)
        { }

        public override void Add(Component component)
        {
            children.Add(component);
        }

        public override void Remove(Component component)
        {
            children.Remove(component);
        }

        public override void Display()
        {
            string text = "OK Playing Background sound " + name.ToString();
            text += "\n";
            Singleton.Log(text);

            foreach (Component component in children)
            {
                component.Display();
            }
        }

        public override void Play(Sound_param param)
        {
            player.SoundLocation = "background.wav";
            player.Play();
        }

        public override void Stop()
        {
            player.Stop();
        }
    }
    class other_sounds : Component
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        public other_sounds(string name)
            : base(name)
        { }

        public override void Display()
        {
            string text = "OK Playing other sound " + name.ToString();
            text += "\n";
            Singleton.Log(text);
        }

        public override void Add(Component component)
        {
            throw new NotImplementedException();
        }

        public override void Remove(Component component)
        {
            throw new NotImplementedException();
        }
        public override void Play(Sound_param param)
        {
            if (param.jumping)
            {

                player.SoundLocation = "Mario_Jumping-Mike_Koenig-989896458.wav";
                player.LoadAsync();
                player.PlaySync();
            }
            if (param.goleft || param.goright)
            {
                player.SoundLocation = "Fast_Heel_Walk-Kyanna_Johnson-1646343608.wav";
                player.LoadAsync();
                player.PlaySync();
            }
            else
            {

            }

        }

        public override void Stop()
        {
            player.Stop();
        }
    }

    class Sound_param
    {
        public bool goleft;
        public bool goright;
        public bool jumping;
        public bool hasKey;

        public Sound_param() { }

        public void refresh(ref bool goleft, ref bool goright, ref bool jumping, ref bool hasKey)
        {
            this.goleft = goleft;
            this.goright = goright;
            this.jumping = jumping;
            this.hasKey = hasKey;
        }
    }
}
