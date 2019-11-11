namespace Bridge
{
    interface ISettings
    {
        string GetSettings();
    }

    class HungarianSettings : ISettings
    {
        public string GetSettings()
        {
            return "with HU settings";
        }
    }

    class EnglishSettings : ISettings
    {
        public string GetSettings()
        {
            return "with EN settings";
        }
    }
}
