using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        public bool AggressiveMode { get; private set; }

        public Fighter(string name, double attackPoints, double defencePoints) : base(name, attackPoints, defencePoints, 200)
        {
            this.AggressiveMode = true;
        }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode ==true)
            {
                this.AggressiveMode = false;
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
            else
            {
                this.AggressiveMode = true;
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }
        }

        public override string ToString()
        {
            //TODO: User ternary operator
            return string.Format(" *Aggressive: {0}",this.AggressiveMode ? "Yes" : "No");
        }
    }
}
