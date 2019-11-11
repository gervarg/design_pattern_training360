namespace AbstractFactory
{
    internal class WindowsWindow : IWindow
    {
        public void Resize()
        {
            System.Console.WriteLine("WINDOWS window was resized.");
        }

        public void Show()
        {
            System.Console.WriteLine("WINDOWS window is visible.");
        }
    }
}