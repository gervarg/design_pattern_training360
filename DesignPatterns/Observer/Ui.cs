using System;
using System.Collections.Generic;

namespace Observer
{
    interface IButtonObserver
    {
        void OnButtonClicked(Button button);
    }

    class UiElement : IButtonObserver
    {
        public UiElement(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void OnButtonClicked(Button button)
        {
            Console.WriteLine($"{Name} observes that {button.Name} was clicked!");
        }
    }

    interface IButtonObservable
    {
        List<IButtonObserver> ButtonObservers { get; }

        void Click();
    }

    class Button : IButtonObservable
    {
        public Button(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public List<IButtonObserver> ButtonObservers { get; } = new List<IButtonObserver>();

        public void Click()
        {
            OnClicked();
        }

        private void OnClicked()
        {
            ButtonObservers.ForEach(o => o.OnButtonClicked(this));
        }
    }
}
