using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonoBrick.NXT;
using System.Timers;
using System.Diagnostics;

namespace BLib.MonoBrick
{
    /// <summary>
    /// A simple MonoBrick Engine to make life slightly easier for those using it.
    /// </summary>
    public class MonoBrickEngine
    {
        private Brick<Sensor, Sensor, Sensor, Sensor> _brick;

        private Stopwatch _stopwatch;

        public Brick<Sensor, Sensor, Sensor, Sensor> Brick
        {
            get
            {
                return _brick;
            }
        }

        public Stopwatch Stopwatch
        {
            get
            {
                return _stopwatch;
            }
        }

        #region Motor Properties

        public Motor MotorA
        {
            get
            {
                return _brick.MotorA;
            }
        }

        public Motor MotorB
        {
            get
            {
                return _brick.MotorB;
            }
        }

        public Motor MotorC
        {
            get
            {
                return _brick.MotorC;
            }
        }

        #endregion Motor Properties

        #region Sensor Properties
        public Sensor Sensor1
        {
            get
            {
                return _brick.Sensor1;
            }
            set
            {
                _brick.Sensor1 = value;
            }
        }

        public Sensor Sensor2
        {
            get
            {
                return _brick.Sensor2;
            }
            set
            {
                _brick.Sensor2 = value;
            }
        }

        public Sensor Sensor3
        {
            get
            {
                return _brick.Sensor3;
            }
            set
            {
                _brick.Sensor3 = value;
            }
        }

        public Sensor Sensor4
        {
            get
            {
                return _brick.Sensor4;
            }
            set
            {
                _brick.Sensor4 = value;
            }
        }

        #endregion Sensor Properties

        /// <summary>
        /// Initializes an instance of the MonoBrickEngine class with the specified connection.
        /// </summary>
        /// <param name="connection">The name of the connection to the robot</param>
        public MonoBrickEngine(string connection)
        {
            _brick = new Brick<Sensor, Sensor, Sensor, Sensor>(connection);
            _stopwatch = new Stopwatch();
            _brick.Connection.Connected += new Action(Connection_Connected);
        }

        void Connection_Connected()
        {
            _brick.PlayTone(1000, 100);
        }

        /// <summary>
        /// Gets the specified sensor type from the specified port.
        /// </summary>
        /// <typeparam name="T">The type of sensor to retrieve</typeparam>
        /// <param name="port">The port to retrieve the sensor from</param>
        /// <returns></returns>
        public T GetSensor<T>(SensorPort port) where T : Sensor
        {
            T sensor = null;
            try
            {
                switch (port)
                {
                    case SensorPort.In1:
                        sensor = (T)Sensor1;
                        break;

                    case SensorPort.In2:
                        sensor = (T)Sensor2;
                        break;

                    case SensorPort.In3:

                        sensor = (T)Sensor3;
                        break;

                    case SensorPort.In4:
                        sensor = (T)Sensor4;
                        break;
                }
            }
            catch (InvalidCastException e)
            {
                //todo: tell person to initialize the sensor. 
                throw new InvalidCastException("Could not return the specified sensor as the specified type. This usually happens because the sensor was not initialized.",e);
            }

            return sensor;
            
        }

        //public T ReadSensor<T>(SensorPort port, SensorType type) 
        //{
        //    switch (port)
        //    {
        //        case SensorPort.In1:
                    
        //            break;

        //        case SensorPort.In2:

        //            break;

        //        case SensorPort.In3:

        //            break;

        //        case SensorPort.In4:

        //            break;
        //    }
        //}

        /// <summary>
        /// Opens the connection to the brick.
        /// </summary>
        public void OpenConnection()
        {
            _brick.Connection.Open();
        }
        /// <summary>
        /// Moves the specified motors for a certain amount of degrees.
        /// </summary>
        /// <param name="powerB">The power for Motor B</param>
        /// <param name="powerC">The power for Motor C</param>
        /// <param name="degrees">The amount of degrees to move</param>
        public void MoveByDegrees(sbyte powerA, sbyte powerB, sbyte powerC, uint degrees)
        {
            MotorA.On(powerA, degrees);
            MotorB.On(powerB, degrees);
            MotorC.On(powerC, degrees);
            Wait1MSec(100);
            do
            {
            
            } while (MotorB.IsRunning() && MotorC.IsRunning());
            StopAllMotors();
        }

        /// <summary>
        /// Moves the specified motors at a given speed for a certain amount of time.
        /// </summary>
        /// <param name="powerA">The power for Motor A.</param>
        /// <param name="powerB">The power for Motor B.</param>
        /// <param name="powerC">The power for Motor C.</param>
        /// <param name="milliseconds">The amount of milliseconds to wait.</param>
        /// <param name="coast">Determines whether to immediately stop the robot or to have it coast.</param>
        public void Move(sbyte powerA,sbyte powerB, sbyte powerC, int milliseconds, bool stop = true)
        {
            MotorA.On(powerA);
            MotorB.On(powerB);
            MotorC.On(powerC);
            Wait1MSec(milliseconds);
            if (stop)
            {
                StopAllMotors();
            }
        }
        /// <summary>
        /// Turns off all motors.
        /// </summary>
        /// <param name="coast">Determines whether to immediately stop the robot or to have it coast.</param>
        public void StopAllMotors(bool coast = false)
        {
            if (coast)
            {
                Wait1MSec(100);
            }
            
            _brick.MotorA.Off();
            _brick.MotorB.Off();
            _brick.MotorC.Off();
        }
        /// <summary>
        /// Opens and closes the connection to the robot.
        /// </summary>
        public void TestConnection()
        {
            _brick.Connection.Open();
            _brick.Connection.Close();
           
        }
        /// <summary>
        /// Stops all motors and closes connection to the brick
        /// </summary>
        public void Disconnect()
        {
            StopAllMotors();
            _brick.PlayTone(600, 100);
            _brick.Connection.Close();
        }
        /// <summary>
        /// Waits for a given amount of milliseconds
        /// </summary>
        /// <param name="milliseconds">The amount of milliseconds to wait</param>
        public void Wait1MSec(int milliseconds)
        {
            _stopwatch.Start();
            do
            { } while (_stopwatch.ElapsedMilliseconds < milliseconds);
            _stopwatch.Stop();
        }
    }
}
