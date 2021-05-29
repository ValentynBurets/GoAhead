using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace girl_go_ahead.patterns
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Hero hero = new Hero();
    //        hero.actions(); // делаем выстрел, осталось 9 патронов
    //        GameHistory game = new GameHistory();

    //        game.History.Push(hero.SaveState()); // сохраняем игру

    //        hero.actions(); //делаем выстрел, осталось 8 патронов

    //        hero.RestoreState(game.History.Pop());

    //        hero.actions(); //делаем выстрел, осталось 8 патронов

    //        Console.Read();
    //    }
    //}

    //// Originator
    //class Hero
    //{

    //    private int x_position;
    //    private int y_position;
    //    private int playSpeed;

    //    public void actions()
    //    {
    //        Console.WriteLine("do actions");
    //    }
    //    // save state
    //    public HeroMemento SaveState()
    //    {
    //        Console.WriteLine("Save game: {0} x_position, {1} y_position, {2} playSpeed", x_position, y_position, playSpeed);
    //        return new HeroMemento(x_position, y_position, playSpeed);
    //    }

    //    // восстановление состояния
    //    public void RestoreState(HeroMemento memento)
    //    {
    //        this.x_position = memento.x_position;
    //        this.y_position = memento.y_position;
    //        this.playSpeed = memento.playSpeed;
    //        Console.WriteLine("Reload game: {0} x_position, {1} y_position, {2} playSpeed", x_position, y_position, playSpeed);

    //    }
    //}


    // Memento
    class HeroMemento
    {
        public int x_position { get; private set; }
        public int y_position { get; private set; }
        public int playSpeed { get; private set; }

        private void write_in_file(Invoker invok)
        {
            mementoParam p = new mementoParam(x_position, y_position, playSpeed);
            invok.Save(p);
        }

        public HeroMemento(Invoker invok, int x_pos, int y_pos, int speed)
        {
            this.x_position = x_pos;
            this.y_position = y_pos;
            this.playSpeed = speed;
            
            this.write_in_file(invok);
        }
    }

    // Caretaker
    class GameHistory
    {
        public Stack<HeroMemento> History { get; private set; }
        public GameHistory()
        {
            History = new Stack<HeroMemento>();
        }
    }


    class Programmer
    {
        private int x_position = 0;
        private int y_position = 0;
        private int playSpeed = 0;

        //from class command
        Invoker invok = new Invoker();
        Receiver sr = new Receiver();

        public Programmer()
        {
            invok.SetCommand(new SaveCommand(sr));
        }

        public Parameters CreateApplication(VisualStudioFacade facade, ref Parameters param)
        {
            param.Refresh(facade.Start(ref param));
            this.initparam(ref param);
            facade.Stop();
            return param;
        }

        //save state
        public HeroMemento SaveState()
        {
            Console.WriteLine("Save game: {0} x_position, {1} y_position, {2} playSpeed", x_position, y_position, playSpeed);
            return new HeroMemento(invok, x_position, y_position, playSpeed);
        }

        public Parameters LoadState(Parameters param)
        {
            //return new HeroMemento.LoadMemento(invok, param);
            return invok.Load(param);
        }

        // refresh state
        public void RestoreState(HeroMemento memento)
        {
            this.x_position = memento.x_position;
            this.y_position = memento.y_position;
            this.playSpeed = memento.playSpeed;
            Console.WriteLine("Reload game: {0} x_position, {1} y_position, {2} playSpeed", x_position, y_position, playSpeed);
        }

        private void initparam(ref Parameters param)
        {

            x_position = param.player.Location.X;
            y_position = param.player.Location.Y;
            playSpeed = param.playSpeed;


            //MessageBox.Show("test x_position = {0}", x_position.ToString());

        }

        public bool saved()
        {
            if (x_position != 0 && y_position != 0 && playSpeed != 0)
                return true;
            else
                return false;
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


}


