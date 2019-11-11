using System;
using System.Collections.Generic;

namespace ChainOfResponsibility
{
    class JobDistributor
    {
        public List<Worker> Workers { get; } = new List<Worker>();

        public void Distribute(Job job)
        {
            foreach (Worker worker in Workers)
            {
                if (worker.CanHandle(job))
                {
                    worker.DoIt(job);
                    return;
                }
            }
            Console.WriteLine("None of the workers can do this job!");
        }

    }

    class Job
    {
        public Job(string description, Competence requiredCompetence)
        {
            Description = description;
            RequiredCompetence = requiredCompetence;
        }

        public string Description { get; }
        public Competence RequiredCompetence { get; }
    }

    class Worker
    {
        public Worker(string name, Competence competence)
        {
            Name = name;
            Competence = competence;
            IsIdle = true;
        }
        
        public string Name { get; }
        public Competence Competence { get; }
        public bool IsIdle { get; private set; }

        internal bool CanHandle(Job job)
        {
            return job.RequiredCompetence == Competence && IsIdle;
        }

        internal void DoIt(Job job)
        {
            IsIdle = false;
            Console.WriteLine($"{Name} is currently working on {job.Description}");
        }
    }

    enum Competence { Web, Design, Db };
}
