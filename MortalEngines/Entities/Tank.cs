using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {
        public bool DefenseMode { get; private set; }

        public Tank(string name, double attackPoints, double defencePoints) : base(name, attackPoints, defencePoints, 100)
        {
            this.DefenseMode = true;
        }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == true)
            {
                this.DefenseMode = false;
                this.DefensePoints += 30;
                this.AttackPoints -= 40;
            }
            else
            {
                this.DefenseMode = true;
                this.DefensePoints -= 30;
                this.AttackPoints += 40;
            }
        }

        public override string ToString()
        {
            return string.Format(" *Defense: {0}", this.DefenseMode ? "Yes" : "No");
        }
    }
}
