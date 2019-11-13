using System;

namespace Observer
{
    // Summary:
    // * Defines a dependency between objects 
    // so that whenever an object changes its state, all its dependents are notified.
    // * The observer pattern is a software design pattern in which an object, called the subject, 
    // maintains a list of its dependents, called observers, and notifies them automatically of any state changes, 
    // usually by calling one of their methods.
    // ~ events
    class Program
    {
        static void Main(string[] args)
        {
            //JobExample();

            //ButtonExample();

            //EventExample();
        }

        private static void EventExample()
        {
            var button = new Button2("button-1");
            var textbox1 = new UiElement2("textbox-1");
            var textbox2 = new UiElement2("textbox-2");
            var dropdownlist = new UiElement2("dropdownlist");
            
            button.Clicked += textbox1.OnButtonClicked;
            button.Clicked += textbox2.OnButtonClicked;
            button.Clicked += dropdownlist.OnButtonClicked;

            button.Click();
        }

        private static void ButtonExample()
        {
            IButtonObservable button = new Button("button-1");
            button.ButtonObservers.Add(new UiElement("textbox-1"));
            button.ButtonObservers.Add(new UiElement("textbox-2"));
            button.ButtonObservers.Add(new UiElement("dropdownlist"));
            button.Click();
        }

        private static void JobExample()
        {
            // Create subscribers
            var johnDoe = new JobSeeker("John Doe");
            var janeDoe = new JobSeeker("Jane Doe");
            var kaneDoe = new JobSeeker("Kane Doe");

            // Create publisher and attach subscribers
            var jobPostings = new JobPostings();
            jobPostings.Attach(johnDoe);
            jobPostings.Attach(janeDoe);

            // Add a new job and see if subscribers get notified
            jobPostings.AddJob(new JobPost("Software Engineer"));
        }
    }
}
