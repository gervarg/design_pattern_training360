using System;

namespace State
{
    interface IColoredBrush
    {
        void Draw(string text);
    }

    class RedBrush : IColoredBrush
    {
        public void Draw(string text)
        {
            Console.WriteLine($"RED: {text}");
        }
    }

    class BlueBrush : IColoredBrush
    {
        public void Draw(string text)
        {
            Console.WriteLine($"BLUE: {text}");
        }
    }

    class BlackBrush : IColoredBrush
    {
        public void Draw(string text)
        {
            Console.WriteLine($"BLACK: {text}");
        }
    }

    class Brush
    {
        public IColoredBrush ColoredBrush { get; set; } = new BlackBrush();

        public void Draw(string text)
        {
            ColoredBrush.Draw(text);
        }
    }
}
