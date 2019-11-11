namespace Bridge
{
    interface IWebPage
    {
        string GetContent();
    }

    class About : IWebPage
    {
        private ITheme Theme { get; set; }

        public About(ITheme theme)
        {
            Theme = theme;
        }

        public string GetContent()
        {
            return "About page in " + Theme.GetColor();
        }
    }

    class Careers : IWebPage
    {
        private ITheme Theme { get; set; }

        public Careers(ITheme theme)
        {
            Theme = theme;
        }

        public string GetContent()
        {
            return "Careers page in " + Theme.GetColor();
        }
    }
}
