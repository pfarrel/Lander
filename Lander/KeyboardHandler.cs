using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lander
{
    public static class KeyboardHandler
    {
        public static KeyboardState LastState;
        public static KeyboardState CurrentState;

        public static List<Keys> Pressed;
        public static List<Keys> Released;


        public static void Update()
        {
            LastState = CurrentState;

            CurrentState = Keyboard.GetState();

           Pressed = CurrentState.GetPressedKeys().Where(k => LastState.IsKeyUp(k)).ToList();
           Released = LastState.GetPressedKeys().Where(k => CurrentState.IsKeyUp(k)).ToList();
        }
    }
}
