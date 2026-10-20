using System;

namespace WorkersTeams
{
    public class Manager : Worker
    {
        private Random _random = new Random();

        public Manager(string name) : base(name)
        {
            Position = "Менеджер";
        }

        public override void FillWorkDay()
        {
            int first = _random.Next(1, 11);
            for (int i = 0; i < first; i++) Call();

            Relax();

            int second = _random.Next(1, 6); 
            for (int i = 0; i < second; i++) Call();
        }
    }
}