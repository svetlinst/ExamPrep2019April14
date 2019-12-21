namespace MortalEngines.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MortalEngines.Entities.Contracts;
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;

        public BaseMachine(string name, double attackPoints, double defencePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defencePoints;
            this.HealthPoints = healthPoints;
        }

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

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {this.name}");     
            sb.AppendLine($" * Type: {this.GetType()}");
            sb.AppendLine($" *Health: {this.HealthPoints}");
            sb.AppendLine($" *Attack: {this.AttackPoints}");
            sb.AppendLine($" *Defense: {this.DefensePoints}");
            sb.Append($" *Targets: ");
            if (this.Targets.Count>0)
            {
                sb.AppendLine(string.Join(",",this.Targets));
            }
            else
            {
                sb.AppendLine("None");
            }
            return sb.ToString();
        }
    }
}
