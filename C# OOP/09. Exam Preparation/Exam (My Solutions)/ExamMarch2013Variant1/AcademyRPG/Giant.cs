using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    class Giant: Character, IFighter, IGatherer
    {
        private int attackPoints;

        public Giant(string name, Point position, int owner) : base(name, position, owner)
        {
            this.HitPoints = 200;
            this.AttackPoints = 150;
            this.AttackPointsIncreased = false;
        }
       
        public int AttackPoints
        {
            get 
            {
                return this.attackPoints;
            }
            set
            {
                this.attackPoints = value;
            }
        }

        public int DefensePoints
        {
            get
            {
                return 80;
            }
        }

        public bool AttackPointsIncreased
        {
            get; set;
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                if (this.AttackPointsIncreased == false)
                {
                    this.AttackPoints += 100;
                    this.AttackPointsIncreased = true;
                }                                
                return true;
            }

            return false;
        }
       
    }
}
