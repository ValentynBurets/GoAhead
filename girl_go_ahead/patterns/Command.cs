using System;
using System.Drawing;
using System.IO;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace girl_go_ahead.patterns
{
    /*
    class Program
    {
        static void Main(string[] args)
        {
            Parameters pp = new Parameters();
            mementoParam p = new mementoParam(2, 5, 8);
            Invoker Invok = new Invoker();
            Receiver sr = new Receiver();
            Invok.SetCommand(new SaveCommand(sr));
            Invok.Save(p);
            pp = Invok.Load(pp);
        }
    }
    */

    interface ICommand
    {
        //Execute
        void Save(mementoParam p);
        Parameters Load(Parameters param);
    }

    // Receiver - Получатель
    class Receiver
    {
        public void Write_in_file(mementoParam p)
        {
            using (StreamWriter writer = new StreamWriter("D:\\TERM 2.2\\mapz\\Lab4\\project\\girl_go_ahead\\girl_go_ahead\\bin\\Debug\\saved.txt"))
            {
                writer.WriteLine(p.x_position.ToString() + "\t");
                writer.WriteLine(p.y_position.ToString() + "\t");
                writer.WriteLine(p.playSpeed.ToString() + "\n");
            }
        }

        public Parameters LoadState(Parameters param)
        {
            string readText = File.ReadAllText("D:\\TERM 2.2\\mapz\\Lab4\\project\\girl_go_ahead\\girl_go_ahead\\bin\\Debug\\saved.txt");
            int param_quant = 3;
            string[] p = new string[param_quant];

            int i = 0;
            int j = 0;
            while (j < param_quant && i < readText.Length)
            {
                if (!(Char.IsDigit(readText[i])) || readText[i] == ' ' || readText[i] == '\t' || readText[i] == '\n')
                {
                    i++;
                    if (i >= readText.Length)
                        break;
                    if (Char.IsDigit(readText[i]))
                    {
                        j++;
                    }
                }
                else
                {
                    p[j] += readText[i];
                    i++;
                }
            }

            param.player.Location = new Point(Int16.Parse(p[0]), Int16.Parse(p[1]));

            param.playSpeed = Int16.Parse(p[2]);

            return param;
        }
    }

    class SaveCommand : ICommand
    {
        Receiver sr;
        public SaveCommand(Receiver tvSet)
        {
            sr = tvSet;
        }
        public void Save(mementoParam p)
        {
            sr.Write_in_file(p);
        }
        public Parameters Load(Parameters param)
        {
            return sr.LoadState(param);
        }
    }

    // Invoker - инициатор
    class Invoker
    {
        ICommand command;

        public Invoker() { }

        public void SetCommand(ICommand com)
        {
            command = com;
        }

        public void Save(mementoParam p)
        {
            command.Save(p);
        }
        public Parameters Load(Parameters p)
        {
            return command.Load(p);
        }
    }
}


class mementoParam
{
    public int x_position = 0;
    public int y_position = 0;
    public int playSpeed = 0;

    public mementoParam()
    { }

    public mementoParam(int x, int y, int p)
    {
        this.x_position = x;
        this.y_position = y;
        this.playSpeed = p;
    }
}



