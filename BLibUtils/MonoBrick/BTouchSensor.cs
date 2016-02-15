using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonoBrick.NXT;

namespace BLib.MonoBrick
{
    public class BTouchSensor : TouchSensor
    {
        public BTouchSensor()
            : base()
        {

        }

        public BTouchSensor(SensorMode mode)
            : base(mode)
        {

        }

        public bool IsTouched
        {
            get
            {
                if (this.SensorMode == global::MonoBrick.NXT.SensorMode.Bool)
                {
                    return this.Read() == 1;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
