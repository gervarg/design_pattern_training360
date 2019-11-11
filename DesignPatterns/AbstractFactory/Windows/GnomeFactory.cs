namespace AbstractFactory
{
    internal class GnomeFactory : IGuiFactory
    {
        public IButton CreateButton()
        {
            return new GnomeButton();
        }

        public IWindow CreateWindow()
        {
            return new GnomeWindow();
        }
    }
}