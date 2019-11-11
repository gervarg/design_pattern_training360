namespace AbstractFactory
{
    internal class GnomeButton : IButton
    {
        public void Click()
        {
            System.Console.WriteLine("GNOME button was clicked.");
        }

        public void Show()
        {
            System.Console.WriteLine("GNOME button is visible.");
        }
    }
}