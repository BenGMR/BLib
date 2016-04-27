using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


namespace BLibMonoGame
{
    public static class XNA_Extensions
    {
        /// <summary>
        /// Converts an angle in radians to a Vector2.
        /// </summary>
        /// <param name="radianToConvert"></param>
        /// <returns></returns>
        public static Vector2 RadianToVector(this float radianToConvert)
        {
            
            return new Vector2((float)Math.Sin(radianToConvert), (float)-Math.Cos(radianToConvert));
        }
        
        /// <summary>
        /// Converts an angle in radians to a Vector2.
        /// </summary>
        /// <param name="angleToConvert"></param>
        /// <returns></returns>
        public static Vector2 DegreeToVector(this float degreeToConvert)
        {
            degreeToConvert *= (Math.PI.ToFloat()/180);
            return new Vector2((float)Math.Sin(degreeToConvert), (float)-Math.Cos(degreeToConvert));
        }

        /// <summary>
        /// Converts a Vector2 to a rotation in radians
        /// </summary>
        /// <param name="vectorToConvert"></param>
        /// <returns></returns>
        public static double VectorToRadianAngle(this Vector2 vectorToConvert)
        {
            return Math.Atan2(vectorToConvert.X,-vectorToConvert.Y);
        }

        /// <summary>
        /// Converts a Vector2 to a rotation in degrees
        /// </summary>
        /// <param name="vectorToConvert"></param>
        /// <returns></returns>
        public static double VectorToDegreeAngle(this Vector2 vectorToConvert)
        {
            return (Math.Atan2(vectorToConvert.X, -vectorToConvert.Y) * (180 / Math.PI.ToFloat()));
        }
    }
}

