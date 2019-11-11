using System;

namespace Observer
{

    class UiElement2
    {
        public UiElement2(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void OnButtonClicked(object sender, EventArgs e)
        {
            string senderName = (sender as Button2)?.Name;
            Console.WriteLine($"{Name} observes that {senderName} was clicked!");
        }
    }

    class Button2
    {
        public Button2(string name)
        {
            Name = name;
        }

        public string Name { get; }

        #region event deep dive
        // https://stackoverflow.com/questions/213638/how-do-c-sharp-events-work-behind-the-scenes
        // https://docs.microsoft.com/en-us/dotnet/api/system.delegate?view=netcore-3.0
        // https://docs.microsoft.com/en-us/dotnet/api/system.delegate.combine?view=netcore-3.0
        // https://docs.microsoft.com/en-us/dotnet/api/system.multicastdelegate?view=netcore-3.0
        #endregion
        public event EventHandler<EventArgs> Clicked;

        public void Click()
        {
            OnClicked();
        }

        private void OnClicked()
        {
            Clicked?.Invoke(this, new EventArgs());
        }
    }
}
