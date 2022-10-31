using System;

namespace EventHandler1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press A to simulate a button click");
            var key = Console.ReadLine();
            if (key=="a")
            {
                KeyPressed();
            }
        }
        static void KeyPressed()
        {
            Button button = new Button();
            button.ClickEvent += (s, args) =>
            {
                Console.WriteLine($"You clicked a button {args.Name}");
            };
            button.OnClick();
        }
    }
    public class Button
    {
        public EventHandler<MyCustomArgs> ClickEvent;
        public virtual void OnClick()
        {
            MyCustomArgs myArgs = new MyCustomArgs();
            myArgs.Name = "Tsvetan";
            ClickEvent(this, myArgs);
        }
    }
    public class MyCustomArgs : EventArgs
    {
        public string Name { get; set; }
    }
}
