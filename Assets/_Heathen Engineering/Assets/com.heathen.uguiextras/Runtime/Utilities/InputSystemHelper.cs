﻿#if HE_SYSCORE
using UnityEngine;
using System.Collections.Generic;

namespace HeathenEngineering.UX
{
    public static class InputSystemHelper
    {
        public static bool GetKeyDown(KeyCode key)
        {
#if ENABLE_LEGACY_INPUT_MANAGER
            return Input.GetKeyDown(key);
#else
            return UnityEngine.InputSystem.Keyboard.current[MapKeyCode(key)].wasPressedThisFrame;
#endif
        }

        public static bool GetKey(KeyCode key)
        {
#if ENABLE_LEGACY_INPUT_MANAGER
            return Input.GetKey(key);
#else
            return UnityEngine.InputSystem.Keyboard.current[MapKeyCode(key)].isPressed;
#endif
        }

        public static bool GetKeyUp(KeyCode key)
        {
#if ENABLE_LEGACY_INPUT_MANAGER
            return Input.GetKeyUp(key);
#else
            return UnityEngine.InputSystem.Keyboard.current[MapKeyCode(key)].wasReleasedThisFrame;
#endif
        }

#if ENABLE_INPUT_SYSTEM
        public static UnityEngine.InputSystem.Key MapKeyCode(KeyCode key)
        {
            switch (key)
            {
                case KeyCode.None:
                    return UnityEngine.InputSystem.Key.None;
                case KeyCode.Space:
                    return UnityEngine.InputSystem.Key.Space;
                case KeyCode.Return:
                    return UnityEngine.InputSystem.Key.Enter;
                case KeyCode.Tab:
                    return UnityEngine.InputSystem.Key.Tab;
                case KeyCode.BackQuote:
                    return UnityEngine.InputSystem.Key.Backquote;
                case KeyCode.Quote:
                    return UnityEngine.InputSystem.Key.Quote;
                case KeyCode.Semicolon:
                    return UnityEngine.InputSystem.Key.Semicolon;
                case KeyCode.Comma:
                    return UnityEngine.InputSystem.Key.Comma;
                case KeyCode.Period:
                    return UnityEngine.InputSystem.Key.Period;
                case KeyCode.Slash:
                    return UnityEngine.InputSystem.Key.Slash;
                case KeyCode.Backslash:
                    return UnityEngine.InputSystem.Key.Backslash;
                case KeyCode.LeftBracket:
                    return UnityEngine.InputSystem.Key.LeftBracket;
                case KeyCode.RightBracket:
                    return UnityEngine.InputSystem.Key.RightBracket;
                case KeyCode.Minus:
                    return UnityEngine.InputSystem.Key.Minus;
                case KeyCode.Equals:
                    return UnityEngine.InputSystem.Key.Equals;
                case KeyCode.A:
                    return UnityEngine.InputSystem.Key.A;
                case KeyCode.B:
                    return UnityEngine.InputSystem.Key.B;
                case KeyCode.C:
                    return UnityEngine.InputSystem.Key.C;
                case KeyCode.D:
                    return UnityEngine.InputSystem.Key.D;
                case KeyCode.E:
                    return UnityEngine.InputSystem.Key.E;
                case KeyCode.F:
                    return UnityEngine.InputSystem.Key.F;
                case KeyCode.G:
                    return UnityEngine.InputSystem.Key.G;
                case KeyCode.H:
                    return UnityEngine.InputSystem.Key.H;
                case KeyCode.I:
                    return UnityEngine.InputSystem.Key.I;
                case KeyCode.J:
                    return UnityEngine.InputSystem.Key.J;
                case KeyCode.K:
                    return UnityEngine.InputSystem.Key.K;
                case KeyCode.L:
                    return UnityEngine.InputSystem.Key.L;
                case KeyCode.M:
                    return UnityEngine.InputSystem.Key.M;
                case KeyCode.N:
                    return UnityEngine.InputSystem.Key.N;
                case KeyCode.O:
                    return UnityEngine.InputSystem.Key.O;
                case KeyCode.P:
                    return UnityEngine.InputSystem.Key.P;
                case KeyCode.Q:
                    return UnityEngine.InputSystem.Key.Q;
                case KeyCode.R:
                    return UnityEngine.InputSystem.Key.R;
                case KeyCode.S:
                    return UnityEngine.InputSystem.Key.S;
                case KeyCode.T:
                    return UnityEngine.InputSystem.Key.T;
                case KeyCode.U:
                    return UnityEngine.InputSystem.Key.U;
                case KeyCode.V:
                    return UnityEngine.InputSystem.Key.V;
                case KeyCode.W:
                    return UnityEngine.InputSystem.Key.W;
                case KeyCode.X:
                    return UnityEngine.InputSystem.Key.X;
                case KeyCode.Y:
                    return UnityEngine.InputSystem.Key.Y;
                case KeyCode.Z:
                    return UnityEngine.InputSystem.Key.Z;
                case KeyCode.Alpha0:
                    return UnityEngine.InputSystem.Key.Digit0;
                case KeyCode.Alpha1:
                    return UnityEngine.InputSystem.Key.Digit1;
                case KeyCode.Alpha2:
                    return UnityEngine.InputSystem.Key.Digit2;
                case KeyCode.Alpha3:
                    return UnityEngine.InputSystem.Key.Digit3;
                case KeyCode.Alpha4:
                    return UnityEngine.InputSystem.Key.Digit4;
                case KeyCode.Alpha5:
                    return UnityEngine.InputSystem.Key.Digit5;
                case KeyCode.Alpha6:
                    return UnityEngine.InputSystem.Key.Digit6;
                case KeyCode.Alpha7:
                    return UnityEngine.InputSystem.Key.Digit7;
                case KeyCode.Alpha8:
                    return UnityEngine.InputSystem.Key.Digit8;
                case KeyCode.Alpha9:
                    return UnityEngine.InputSystem.Key.Digit9;
                case KeyCode.LeftShift:
                    return UnityEngine.InputSystem.Key.LeftShift;
                case KeyCode.RightShift:
                    return UnityEngine.InputSystem.Key.RightShift;
                case KeyCode.LeftAlt:
                    return UnityEngine.InputSystem.Key.LeftAlt;
                case KeyCode.RightAlt:
                    return UnityEngine.InputSystem.Key.RightAlt;
                case KeyCode.AltGr:
                    return UnityEngine.InputSystem.Key.AltGr;
                case KeyCode.LeftControl:
                    return UnityEngine.InputSystem.Key.LeftCtrl;
                case KeyCode.RightControl:
                    return UnityEngine.InputSystem.Key.RightCtrl;
                case KeyCode.LeftWindows:
                case KeyCode.LeftCommand:
                    return UnityEngine.InputSystem.Key.LeftMeta;
                case KeyCode.RightWindows:
                case KeyCode.RightCommand:
                    return UnityEngine.InputSystem.Key.LeftMeta;
                case KeyCode.Menu:
                    return UnityEngine.InputSystem.Key.ContextMenu;
                case KeyCode.Escape:
                    return UnityEngine.InputSystem.Key.Escape;
                case KeyCode.LeftArrow:
                    return UnityEngine.InputSystem.Key.LeftArrow;
                case KeyCode.RightArrow:
                    return UnityEngine.InputSystem.Key.RightArrow;
                case KeyCode.UpArrow:
                    return UnityEngine.InputSystem.Key.UpArrow;
                case KeyCode.DownArrow:
                    return UnityEngine.InputSystem.Key.DownArrow;
                case KeyCode.Backspace:
                    return UnityEngine.InputSystem.Key.Backspace;
                case KeyCode.PageDown:
                    return UnityEngine.InputSystem.Key.PageDown;
                case KeyCode.PageUp:
                    return UnityEngine.InputSystem.Key.PageUp;
                case KeyCode.Home:
                    return UnityEngine.InputSystem.Key.Home;
                case KeyCode.End:
                    return UnityEngine.InputSystem.Key.End;
                case KeyCode.Insert:
                    return UnityEngine.InputSystem.Key.Insert;
                case KeyCode.Delete:
                    return UnityEngine.InputSystem.Key.Delete;
                case KeyCode.CapsLock:
                    return UnityEngine.InputSystem.Key.CapsLock;
                case KeyCode.Numlock:
                    return UnityEngine.InputSystem.Key.NumLock;
                case KeyCode.Print:
                    return UnityEngine.InputSystem.Key.PrintScreen;
                case KeyCode.ScrollLock:
                    return UnityEngine.InputSystem.Key.ScrollLock;
                case KeyCode.Pause:
                    return UnityEngine.InputSystem.Key.Pause;
                case KeyCode.KeypadEnter:
                    return UnityEngine.InputSystem.Key.NumpadEnter;
                case KeyCode.KeypadDivide:
                    return UnityEngine.InputSystem.Key.NumpadDivide;
                case KeyCode.KeypadMultiply:
                    return UnityEngine.InputSystem.Key.NumpadMultiply;
                case KeyCode.KeypadPlus:
                    return UnityEngine.InputSystem.Key.NumpadPlus;
                case KeyCode.KeypadMinus:
                    return UnityEngine.InputSystem.Key.NumpadMinus;
                case KeyCode.KeypadPeriod:
                    return UnityEngine.InputSystem.Key.NumpadPeriod;
                case KeyCode.KeypadEquals:
                    return UnityEngine.InputSystem.Key.NumpadEquals;
                case KeyCode.Keypad0:
                    return UnityEngine.InputSystem.Key.Numpad0;
                case KeyCode.Keypad1:
                    return UnityEngine.InputSystem.Key.Numpad1;
                case KeyCode.Keypad2:
                    return UnityEngine.InputSystem.Key.Numpad2;
                case KeyCode.Keypad3:
                    return UnityEngine.InputSystem.Key.Numpad3;
                case KeyCode.Keypad4:
                    return UnityEngine.InputSystem.Key.Numpad4;
                case KeyCode.Keypad5:
                    return UnityEngine.InputSystem.Key.Numpad5;
                case KeyCode.Keypad6:
                    return UnityEngine.InputSystem.Key.Numpad6;
                case KeyCode.Keypad7:
                    return UnityEngine.InputSystem.Key.Numpad7;
                case KeyCode.Keypad8:
                    return UnityEngine.InputSystem.Key.Numpad8;
                case KeyCode.Keypad9:
                    return UnityEngine.InputSystem.Key.Numpad9;
                case KeyCode.F1:
                    return UnityEngine.InputSystem.Key.F1;
                case KeyCode.F2:
                    return UnityEngine.InputSystem.Key.F2;
                case KeyCode.F3:
                    return UnityEngine.InputSystem.Key.F3;
                case KeyCode.F4:
                    return UnityEngine.InputSystem.Key.F4;
                case KeyCode.F5:
                    return UnityEngine.InputSystem.Key.F5;
                case KeyCode.F6:
                    return UnityEngine.InputSystem.Key.F6;
                case KeyCode.F7:
                    return UnityEngine.InputSystem.Key.F7;
                case KeyCode.F8:
                    return UnityEngine.InputSystem.Key.F8;
                case KeyCode.F9:
                    return UnityEngine.InputSystem.Key.F9;
                case KeyCode.F10:
                    return UnityEngine.InputSystem.Key.F10;
                case KeyCode.F11:
                    return UnityEngine.InputSystem.Key.F11;
                case KeyCode.F12:
                    return UnityEngine.InputSystem.Key.F12;
                case KeyCode.F13:
                    return UnityEngine.InputSystem.Key.OEM1;
                case KeyCode.F14:
                    return UnityEngine.InputSystem.Key.OEM2;
                case KeyCode.F15:
                    return UnityEngine.InputSystem.Key.OEM3;
                default:
                    return UnityEngine.InputSystem.Key.None;
            }
        }
#endif
    }
}
#endif