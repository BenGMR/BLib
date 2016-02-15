using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace BLibXNA
{
    /// <summary>
    /// Work in progress
    /// </summary>
    public static class InputManager
    {
        public static Vector2 MousePosition;
        private static MouseState _currentMS;

        public static MouseState CurrentMouseState
        {
            get { return _currentMS; }
        }

        private static KeyboardState _currentKS;

        public static KeyboardState CurrentKeyboardState
        {
            get { return _currentKS; }
        }

        private static MouseState _lastMS;

        public static MouseState LastMouseState
        {
            get { return _lastMS; }
        }

        private static KeyboardState _lastKS;

        public static KeyboardState LastKeyboardState
        {
            get { return _lastKS; }
        }

        public static void Update()
        {
            _lastKS = _currentKS;
            _lastMS = _currentMS;

            _currentKS = Keyboard.GetState();
            _currentMS = Mouse.GetState();

            MousePosition.X = _currentMS.X;
            MousePosition.Y = _currentMS.Y;
        }

        public static bool JustLeftClicked()
        {
            return _currentMS.LeftButton == ButtonState.Pressed && _lastMS.LeftButton != ButtonState.Pressed;
        }

        public static bool JustRightClicked()
        {
            return _currentMS.RightButton == ButtonState.Pressed && _lastMS.RightButton != ButtonState.Pressed;
        }

        public static bool KeyJustPressed(Keys k)
        {
            return _currentKS.IsKeyDown(k) && !_lastKS.IsKeyDown(k);
        }

        
    }
}
