using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace girl_go_ahead.patterns
{
    /*
    class Program
    {
        static void Main(string[] args)
        {
            Parameters param = new Parameters();
            Score stock = new Score();
            Shop bank = new Shop(stock);
            Customer client = new Customer(stock);

            stock.AddMoney(10);

            param = stock.Market(param);
            
            client.Stop();
            
            param = stock.Market(param);

        }
    }


    */

    public interface IObserver
    {
        Parameters Update(Object ob, Parameters param);
    }

    interface IObservable
    {
        void RegisterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        Parameters NotifyObservers(Parameters param);
    }

    public class Score : IObservable
    {
        StockInfo sInfo; // информация о торгах

        List<IObserver> observers;
        public Score()
        {
            observers = new List<IObserver>();
            sInfo = new StockInfo();
        }
        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public Parameters NotifyObservers(Parameters param)
        {
            foreach (IObserver o in observers)
            {
                param = o.Update(sInfo, param);
            }
            return param;
        }

        public Parameters Market(Parameters param)
        {
            sInfo.value = param.score;
            param = NotifyObservers(param);
            return param;
        }

        public Parameters AddMoney(Parameters param, int value)
        {
            sInfo.value += value;
            param.score = sInfo.value;
            return param;
        }
    }

    class StockInfo
    {
        public int value { get; set; }
    }

    class Customer : IObserver
    {
        public string Name { get; set; }
        IObservable stock;
        public Customer(IObservable obs)
        {
            stock = obs;
            stock.RegisterObserver(this);
        }
        public Parameters Update(object ob, Parameters param)
        {
            StockInfo sInfo = (StockInfo)ob;

            param = param.context.Request(ref param, ref param.shop);
            
            param.info_lable.Text = "customer bought dress";
            param.score -= 100;
            return param;
        }
        public void Stop()
        {
            stock.RemoveObserver(this);
            stock = null;
        }
    }

    class Shop : IObserver
    {
        public int bonus { get; set; }
        IObservable stock;
        public Shop(IObservable obs)
        {
            bonus = 3;
            stock = obs;
            stock.RegisterObserver(this);
        }
        public Parameters Update(object ob, Parameters param)
        {
            StockInfo sInfo = (StockInfo)ob;

            bonus--;

            Console.WriteLine("shop sell");

            return param;
        }
    }


}



/*
 *             if (param.player.Bounds.IntersectsWith(param.apple.Bounds))
            {
                bool k = param.message;
                
                    DialogResult res = MessageBox.Show("Do you want to eat an apple?",
                    "Choice", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                
                if (res == DialogResult.OK)
                    {
                        
                        MessageBox.Show("You eat an apple! And get an boost!");
                        param = param.context.Request(ref param, ref param.apple);  // turn in other state
                        param.info_lable.Text = "ate an apple";

                        param.score++;
                        param.score++;

                        param.apple.Image = Properties.Resources.ate_apple;
                        param.apple.Enabled = false;
                 }
                 if (res == DialogResult.Cancel)
                 {
                    MessageBox.Show("You aren`t hungry!");
                 }
                

                param.message = k;
            }

*/
