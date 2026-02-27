using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRAIN_OBJECTS_MADE_REAL_ACTUAL_PatrickM
{
    internal class DoubleDouble
    {
        //My variables

        private int usesLeftover;
        private float speedBoost;
        private bool isActive;
        private float boostTime;

        private float originalBoostTime;

        //Argumented Constructor

        public DoubleDouble(int usesLeftover, float speedBoost, float boostTime)
        {
            this.usesLeftover = usesLeftover;
            this.speedBoost = speedBoost;
            this.boostTime = boostTime;
            this.originalBoostTime = boostTime;
            this.isActive = false;
        }

        //Accessor Methods

        public int GetUsesLeftover()
        {
            return usesLeftover;
        }

        public float GetSpeedBoost()
        { 
            return speedBoost;
        }

        public float GetBoostTime()
        { 
            return boostTime;
        }

        public bool GetIsActive()
        {
            return isActive;
        }

    }
}
