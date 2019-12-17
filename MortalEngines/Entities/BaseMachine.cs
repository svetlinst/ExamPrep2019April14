namespace MortalEngines.Entities
{
    using System;
    using System.Collections.Generic;
    using MortalEngines.Entities.Contracts;
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Machine name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get => this.pilot;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }
                this.pilot = value;
            }
        }
        public double HealthPoints { get; set; }

        public double AttackPoints { get; }

        public double DefensePoints { get; }

        public IList<string> Targets { get; }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }
            //TODO: check the behavior of the below code when the defence is higher than the attack points
            target.HealthPoints -= (this.AttackPoints- target.DefensePoints);
            if (target.HealthPoints<0)
            {
                target.HealthPoints = 0;
            }
            Targets.Add(target.Name);
        }
    }
}
