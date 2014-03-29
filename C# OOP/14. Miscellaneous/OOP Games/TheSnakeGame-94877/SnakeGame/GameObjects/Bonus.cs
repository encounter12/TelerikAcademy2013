using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeGame.GameObjects
{
     public class Bonus : GameObject, IDestroyable
    {
        private BonusType bonusType;

        public Bonus(Position pos, int size, BonusType bonusType)
            : base(pos,size)
        {
            this.bonusType = bonusType;
        }

        public Bonus(int x, int y, int size, BonusType bonusType)
            : this(new Position(x,y), size,bonusType)
        {
        }

        public void Destroy()
        {
            this.IsDestroyed = true;
        }

        public bool IsDestroyed
        {
            get;
            set;
        }

        public BonusType BonusType
        {
            get
            {
                return this.bonusType;
            }
        }
    }
}
