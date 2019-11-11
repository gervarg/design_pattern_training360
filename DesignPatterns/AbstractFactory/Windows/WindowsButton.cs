namespace AbstractFactory
{
    internal class WindowsButton : IButton
    {
        public void Click()
        {
            System.Console.WriteLine("WINDOWS button was clicked.");
        }

        public void Show()
        {
            System.Console.WriteLine("WINDOWS button is visible.");
        }
    }
}