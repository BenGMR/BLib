using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLibMonoGame
{
    public static class Extensions
    {
        /// <summary>
        /// Converts an int to a float
        /// </summary>
        /// <param name="numToConvert"></param>
        /// <returns></returns>
        public static float ToFloat(this int numToConvert)
        {
            return Convert.ToSingle(numToConvert);
        }

        /// <summary>
        /// Converts a string to a float.
        /// </summary>
        /// <param name="stringToConvert"></param>
        /// <returns></returns>
        public static float ToFloat(this string stringToConvert)
        {
            return Convert.ToSingle(stringToConvert);
        }

        /// <summary>
        /// Converts a double to a float
        /// </summary>
        /// <param name="doubleToConvert"></param>
        /// <returns></returns>
        public static float ToFloat(this double doubleToConvert)
        {
            return Convert.ToSingle(doubleToConvert);
        }

        /// <summary>
        /// Converts a degree into a radian
        /// </summary>
        /// <param name="degreeToConvert"></param>
        /// <returns></returns>
        public static float ToRadian(this float degreeToConvert)
        {
            return Convert.ToSingle(degreeToConvert * (Math.PI / 180));
        }

        /// <summary>
        /// Converts a radian into a degree
        /// </summary>
        /// <param name="degreeToConvert"></param>
        /// <returns></returns>
        public static float ToDegree(this float radianToConvert)
        {
            return Convert.ToSingle(radianToConvert * (180/Math.PI));
        }

       /// <summary>
       /// Converts a string into an int.
       /// </summary>
       /// <param name="stringToConvert"></param>
       /// <returns></returns>
        public static int ToInt(this string stringToConvert)
        {
            return Convert.ToInt32(stringToConvert);
        }

        /// <summary>
        /// Converts a float into an int, taking into account whether to round or not.
        /// </summary>
        /// <param name="floatToConvert"></param>
        /// <param name="round">True to round</param>
        /// <returns></returns>
        public static int ToInt(this float floatToConvert, bool round = false)
        {
            if (round)
            {
              return Convert.ToInt32(Math.Round(floatToConvert));
            }
              return Convert.ToInt32(floatToConvert);
        }

        /// <summary>
        /// Converts a double to an int.
        /// </summary>
        /// <param name="floatToConvert"></param>
        /// <returns></returns>
        public static int ToInt(this double doubleToConvert)
        {
            return Convert.ToInt32(doubleToConvert);
        }

        /// <summary>
        /// Converts a double to an int, taking into account whether to round or not.
        /// </summary>
        /// <param name="floatToConvert"></param>
        /// <returns></returns>
        public static int ToInt(this double doubleToConvert, bool round)
        {
            if (round)
            {
                return Convert.ToInt32(Math.Round(doubleToConvert));
            }
            return Convert.ToInt32(doubleToConvert);
        }

        /// <summary>
        /// Converts a float into a double
        /// </summary>
        /// <param name="floatToConvert"></param>
        /// <returns></returns>
        public static double ToDouble(this float floatToConvert)
        {
            return Convert.ToDouble(floatToConvert);
        }

        /// <summary>
        /// Converts an int into a double
        /// </summary>
        /// <param name="floatToConvert"></param>
        /// <returns></returns>
        public static double ToDouble(this int intToConvert)
        {
            return Convert.ToDouble(intToConvert);
        }

        /// <summary>
        /// Converts a long into a double
        /// </summary>
        /// <param name="floatToConvert"></param>
        /// <returns></returns>
        public static double ToDouble(this long longToConvert)
        {
            return Convert.ToDouble(longToConvert);
        }

        /// <summary>
        /// Converts an int into a long
        /// </summary>
        /// <param name="floatToConvert"></param>
        /// <returns></returns>
        public static long ToLong(this int intToConvert)
        {
            return Convert.ToInt64(intToConvert);
        }

        /// <summary>
        /// Converts a float into a long
        /// </summary>
        /// <param name="floatToConvert"></param>
        /// <returns></returns>
        public static long ToLong(this float floatToConvert, bool round = false)
        {
            if (round)
            {
                return Convert.ToInt64(Math.Round(floatToConvert));
            }

            return Convert.ToInt64(floatToConvert);
        }

        /// <summary>
        /// Converts a double into a long
        /// </summary>
        /// <param name="floatToConvert"></param>
        /// <returns></returns>
        public static long ToLong(this double doubleToConvert, bool round = false)
        {
            if (round)
            {
                return Convert.ToInt64(Math.Round(doubleToConvert));
            }

            return Convert.ToInt64(doubleToConvert);
        }

        /// <summary>
        /// Returns whether or not the number is a power of 2.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static bool IsPowerOfTwo(this int num)
        {
            return (num & (num - 1)) == 0;
        }

        public static T Cast<T>(this object thing)
        {
            return (T)thing;
        }

        public static int[] Sort(this int[] a)
        {
            int temp1 = 0;
            bool isSorted = false;
            do
            {
                isSorted = true;
                for (int i = 0; i < a.Length-1; i++)
                {
                    if (a[i + 1] < a[i])
                    {
                        isSorted = false;
                        temp1 = a[i];
                        a[i] = a[i + 1];
                        a[i + 1] = temp1;
                    }

                }

            } while (!isSorted);

            return a;
        }

        public static T[] DisplayInConsole<T>(this T[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i].ToString());
            }
            return a;
        }
    }
}
