using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    class JobPost
    {
        public string Title { get; set; }

        public JobPost(string title)
        {
            this.Title = title;
        }
    }

    interface IObserver
    {
        void OnJobPosted(JobPost job);
    }

    class JobSeeker : IObserver
    {
        public string Name { get; set; }

        public JobSeeker(string name)
        {
            this.Name = name;
        }

        public void OnJobPosted(JobPost job)
        {            
            Console.WriteLine($"Hi {Name}! New job posted: {job.Title}");
        }
    }

    interface IObservable
    {
        void Attach(IObserver observer); // + detach
        void AddJob(JobPost jobPosting);
    }

    class JobPostings : IObservable
    {
        private readonly List<IObserver> observers = new List<IObserver>();

        private void Notify(JobPost jobPosting)
        {
            foreach (var observer in this.observers)
            {
                observer.OnJobPosted(jobPosting);
            }
        }

        public void Attach(IObserver observer)
        {
            this.observers.Add(observer);
        }

        public void AddJob(JobPost jobPosting)
        {
            this.Notify(jobPosting);
        }
    }
}
