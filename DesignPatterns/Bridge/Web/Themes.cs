namespace Bridge
{
    interface ITheme
    {
        string GetColor();
    }

    class DarkTheme : ITheme
    {
        public string GetColor()
        {
            return "Dark Black";
        }
    }

    class LightTheme : ITheme
    {
        public string GetColor()
        {
            return "Off white";
        }
    }

    class AquaTheme : ITheme
    {
        public string GetColor()
        {
            return "Light blue";
        }
    }
}
