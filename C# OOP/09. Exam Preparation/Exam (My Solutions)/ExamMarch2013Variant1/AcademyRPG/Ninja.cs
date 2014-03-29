using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    class Ninja: Character, IFighter, IGatherer
    {
        private int attackPoints;

        public Ninja(string name, Point position, int owner) : base(name, position, owner)
        {
            this.HitPoints = 1;
            this.AttackPoints = 0;
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
                return int.MaxValue; 
            }            
        }

        
        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            int maxHitPoints = int.MinValue;
            int maxHitPointsI = -1;

            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    if (availableTargets[i].HitPoints > maxHitPoints)
                    {
                        maxHitPointsI = i;
                        maxHitPoints = availableTargets[i].HitPoints;
                    }                    
                }
            }

            return maxHitPointsI;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber)
            {
                this.AttackPoints += resource.Quantity;
                return true;
            }
            else if (resource.Type == ResourceType.Stone)
            {
                this.AttackPoints += resource.Quantity * 2;
                return true;
            }
            return false;
        }
    }
}
