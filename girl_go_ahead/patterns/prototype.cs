using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace girl_go_ahead
{
    /*
    class Program
    {
        static void Main(string[] args)
        {
            int width = 291;
            int height = 271;
            int x = 1165;
            int y = 177;
            prototype_parameters param = new prototype_parameters(this, width, height, x, y);
            Home figure = new simple_house(param);
            Home clonedFigure = figure.Clone();
            
            int width_castle = 391;
            int height_castle = 471;
            int x_castle = 1665;
            int y_castle = 177;
            prototype_parameters param_castle = new prototype_parameters(this, width_castle, height_castle, x_castle, y_castle);

            figure = new castle(param_castle);
            clonedFigure = figure.Clone();

        }
    }
    */


    abstract class Home
    {
        protected prototype_parameters parameters = new prototype_parameters();

        public Home(prototype_parameters param)
        {
            this.parameters.pic = param.pic;
            this.parameters.width = param.width;
            this.parameters.height = param.height;
            this.parameters.x_position = param.x_position;
            this.parameters.y_position = param.y_position;
        }

        public abstract Home Clone();
        public abstract void GetInfo();
    }

    class simple_house : Home
    {
        
        public simple_house(prototype_parameters param)
            :base(param)
        { }

        private void CreateObject()
        {
            parameters.pic.Name = "door";
            parameters.pic.Image = Properties.Resources.closed_house;
            parameters.pic.Location = new System.Drawing.Point(parameters.x_position, parameters.y_position);
            parameters.pic.Size = new System.Drawing.Size(parameters.width, parameters.height);
            parameters.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            parameters.pic.TabIndex = 8;
            parameters.pic.TabStop = false;
            parameters.pic.Tag = "door";
        }

        public override Home Clone()
        {
            CreateObject();
            return new simple_house(this.parameters);
        }
        public override void GetInfo()
        {
            Console.WriteLine("Simple House with height {0} and width {1}", this.parameters.height, this.parameters.width);
        }
    }

    class castle : Home
    {
        private void CreateObject()
        {
            parameters.pic.Name = "door";
            parameters.pic.Image = Properties.Resources.castle;
            parameters.pic.Location = new System.Drawing.Point(parameters.x_position, parameters.y_position);
            parameters.pic.Size = new System.Drawing.Size(parameters.width, parameters.height);
            parameters.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            parameters.pic.TabIndex = 8;
            parameters.pic.TabStop = false;
            parameters.pic.Tag = "door";
        }
        public castle(prototype_parameters param)
            : base(param)
        { }

        public override Home Clone()
        {
            CreateObject();
            return new castle(this.parameters);
        }
        public override void GetInfo()
        {
            Console.WriteLine("castle with height {0} and width {1}", this.parameters.height, this.parameters.width);
        }
    }


    //class for parameters
    class prototype_parameters
    {
        public prototype_parameters()
        { }

        public prototype_parameters(PictureBox pic,  int width, int height, int x_position, int y_position)
        {
            this.pic = pic;
            this.width = width;
            this.height = height;
            this.x_position = x_position;
            this.y_position = y_position;
        }
        public PictureBox pic{ get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int x_position { get; set; }
        public int y_position { get; set; }
    }
}
