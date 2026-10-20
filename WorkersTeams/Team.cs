using System;
using System.Collections.Generic;

namespace WorkersTeams
{
    public class Team
    {
        public string Name { get; }
        private List<Worker> _workers = new List<Worker>();

        public Team(string name)
        {
            Name = name;
        }

        public void AddWorker(Worker worker)
        {
            _workers.Add(worker);
        }
        public void PrintInfo()
        {
            Console.WriteLine($"Команда: {Name}");
            foreach (var w in _workers)
                Console.WriteLine(w.Name);
        }

        public void PrintDetailedInfo()
        {
            Console.WriteLine($"Команда: {Name}");
            foreach (var w in _workers)
                Console.WriteLine($"{w.Name} - {w.Position} - {w.WorkDay}");
        }
    }
}