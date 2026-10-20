namespace WorkersTeams
{
    public class Developer : Worker
    {
        public Developer(string name) : base(name)
        {
            Position = "Розробник";
        }

        public override void FillWorkDay()
        {
            WriteCode();
            Call();
            Relax();
            WriteCode();
        }
    }
}