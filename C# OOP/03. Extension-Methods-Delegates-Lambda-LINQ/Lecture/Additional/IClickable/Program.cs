using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegates_events_demos
{
    //public delegate void ClickEventHandler(object snd, MouseEventArgs e);

    interface IClickable
    {
        event EventHandler<MouseEventArgs> Clicked;

        void Click(int x,int y);
    }

    class Button : IClickable
    {
        public event EventHandler<MouseEventArgs> Clicked;

        public void Click(int x,int y)
        {
            this.OnClicked(x,y);
        }

        private void OnClicked(int x,int y)
        {
            if (this.Clicked != null)
            {
                MouseEventArgs e = new MouseEventArgs(x, y);
                this.Clicked(this, e);
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Button b = new Button();
            b.Clicked +=
                (obj, e) =>
                {
                    int x = e.X;
                    int y = e.Y;

                    Console.WriteLine("Clicked at (" + x + ", " + y + ")");
                };

            b.Click(200, 500);
            b.Click(500, 200);
            b.Click(100, 500);
        }
    }
}