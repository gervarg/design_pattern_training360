namespace AbstractFactory
{
    internal class GnomeWindow : IWindow
    {
        public void Resize()
        {
            System.Console.WriteLine("GNOME window was resized.");
        }

        public void Show()
        {
            System.Console.WriteLine("GNOME window is visible.");
        }
    }
}