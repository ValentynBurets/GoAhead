using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace girl_go_ahead.patterns
{
    
    //class Program
    //{
    //    static void jgyu()
    //    {
    //        Parameters param = new Parameters();
    //        Parameters actualParam = new Parameters();
    //        PictureBox picture = new PictureBox();
    //        Context context = new Context(new UsualState(param));
    //        actualParam = context.Request(ref param, ref picture);  // turn in other state

    //    }
    //}
    
    public abstract class State
    {
        public abstract Parameters Met(Context context, ref Parameters param, ref PictureBox metObject);
        public abstract Parameters GetParam();
    }
    class UsualState : State
    {
        Parameters param;
        public UsualState(Parameters param)
        {
            this.param = param;
        }
        public override Parameters Met(Context context, ref Parameters param, ref PictureBox metObject)
        {
            if (metObject.Tag == "key")
            {
                context.State = new HappyState(param);
                this.param = context.State.GetParam();
            }
            if (metObject.Tag == "apple")
            {
                context.State = new BonusState(param);
                this.param = context.State.GetParam();
            }
            if (metObject.Tag == "shop")
            {
                context.State = new DressState(param);
                this.param = context.State.GetParam();
            }

            return this.param;
        }

        public override Parameters GetParam()
        {
            return this.param;
        }
    }


    class BonusState : State
    {
        Parameters param;
        public BonusState(Parameters param)
        {
            this.param = param;
            this.param.force += 15;
            this.param.playSpeed += 15;
        }

        public override Parameters Met(Context context, ref Parameters param, ref PictureBox metObject)
        {
            if(param.key.Enabled == false && param.apple.Enabled == false)
            {
                context.State = new UsualState(param);
                this.param = context.State.GetParam();
            }

            if (metObject.Tag == "key")
            {
                context.State = new HappyState(param);
                this.param = context.State.GetParam();
            }
            if (metObject.Tag == "shop")
            {
                context.State = new DressState(param);
                this.param = context.State.GetParam();
            }

            return this.param;
        }

        public override Parameters GetParam()
        {
            return this.param;
        }
    }

    class HappyState : State
    {
        Parameters param;
        public HappyState(Parameters param)
        {
            this.param = param;
            param.player.Image = Properties.Resources.girl_happy;
            this.param.force += 7;
            this.param.playSpeed += 7;
        }

        public override Parameters Met(Context context, ref Parameters param, ref PictureBox metObject)
        {
            if (metObject.Tag == "house")
            {
                context.State = new UsualState(param);
                this.param = context.State.GetParam();
            }

            if (metObject.Tag == "apple")
            {
                context.State = new BonusState(param);
                this.param = context.State.GetParam();
            }
            if (metObject.Tag == "shop")
            {
                context.State = new DressState(param);
                this.param = context.State.GetParam();
            }
            return this.param;
        }

        public override Parameters GetParam()
        {
            return this.param;
        }
    }

    class DressState : State
    {
        Parameters param;
        public DressState(Parameters param)
        {
            this.param = param;
            this.param.player.Image = Properties.Resources.cute_girl_png_clipart;
            
        }

        public override Parameters Met(Context context, ref Parameters param, ref PictureBox metObject)
        {
            if (param.key.Enabled == false && param.apple.Enabled == false)
            {
                context.State = new UsualState(param);
                this.param = context.State.GetParam();
            }
            if (metObject.Tag == "key")
            {
                context.State = new HappyState(param);
                this.param = context.State.GetParam();
            }
            if (metObject.Tag == "apple")
            {
                context.State = new BonusState(param);
                this.param = context.State.GetParam();
            }
            if (metObject.Tag == "shop")
            {
                context.State = new DressState(param);
                this.param = context.State.GetParam();
            }

            return this.param;
        }

        public override Parameters GetParam()
        {
            return this.param;
        }
    }

    public class Context
    {
        public State State { get; set; }
        public Context(State state)
        {
            this.State = state;
        }
        public Parameters Request(ref Parameters param, ref PictureBox metObject)
        {
            Parameters retParam = this.State.Met(this, ref param, ref metObject);
            return retParam;
        }
    }
    
}
