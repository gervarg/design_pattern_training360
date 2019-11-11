namespace AbstractFactory
{
    internal interface IGuiFactory
    {
        IWindow CreateWindow();
        IButton CreateButton();
    }
}