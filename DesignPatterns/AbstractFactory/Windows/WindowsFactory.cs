namespace AbstractFactory
{
    internal class WindowsFactory : IGuiFactory
    {
        public IButton CreateButton()
        {
            return new WindowsButton();
        }

        public IWindow CreateWindow()
        {
            return new WindowsWindow();
        }
    }
}