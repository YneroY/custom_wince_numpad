using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CNumpad
{
    /// <summary>
    /// Key-press detection class
    /// </summary>
    internal class NumKeys
    {
        [StructLayout(LayoutKind.Explicit)]
        public struct INPUT
        {
            [FieldOffset(4)]
            public HARDWAREINPUT hi;
            [FieldOffset(4)]
            public KEYBDINPUT ki;
            [FieldOffset(4)]
            public MOUSEINPUT mi;
            [FieldOffset(0)]
            public int type;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBDINPUT
        {
            public short wVk;
            public short wScan;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HARDWAREINPUT
        {
            public int uMsg;
            public short wParamL;
            public short wParamH;
        }

        [Flags]
        public enum InputType
        {
            INPUT_MOUSE = 0,
            INPUT_KEYBOARD = 1,
            INPUT_HARDWARE = 2
        }

        [Flags]
        public enum MOUSEEVENTF
        {
            MOVE = 0x0001, /* mouse move */
            LEFTDOWN = 0x0002, /* left button down */
            LEFTUP = 0x0004, /* left button up */
            RIGHTDOWN = 0x0008, /* right button down */
            RIGHTUP = 0x0010, /* right button up */
            MIDDLEDOWN = 0x0020, /* middle button down */
            MIDDLEUP = 0x0040, /* middle button up */
            XDOWN = 0x0080, /* x button down */
            XUP = 0x0100, /* x button down */
            WHEEL = 0x0800, /* wheel button rolled */
            MOVE_NOCOALESCE = 0x2000, /* do not coalesce mouse moves */
            VIRTUALDESK = 0x4000, /* map to entire virtual desktop */
            ABSOLUTE = 0x8000 /* absolute move */
        }

        [Flags]
        public enum KEYEVENTF
        {
            KEYDOWN = 0,
            EXTENDEDKEY = 0x0001,
            KEYUP = 0x0002,
            UNICODE = 0x0004,
            SCANCODE = 0x0008,
        }

        #region P/Invoke
        [DllImport("coredll.dll", SetLastError = true)]
        public static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        [DllImport("coredll.dll", SetLastError = true)]
        public static extern IntPtr WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);
        #endregion

        #region Keyboard's virtual code
        private const short zero = 0x30;
        private const short one = 0x31;
        private const short two = 0x32;
        private const short three = 0x33;
        private const short four = 0x34;
        private const short five = 0x35;
        private const short six = 0x36;
        private const short seven = 0x37;
        private const short eight = 0x38;
        private const short nine = 0x39;
        private const short backspace = 0x08;
        private const short dot = 0xBE;
        private const short space = 0x20;
        #endregion

        #region Individual key press event
        public static uint Zero()
        {
            INPUT structure = new INPUT();
            structure.type = (int)InputType.INPUT_KEYBOARD;
            structure.ki.wVk = zero;
            structure.ki.dwFlags = (int)KEYEVENTF.KEYDOWN;
            structure.ki.dwExtraInfo = IntPtr.Zero;

            INPUT input2 = new INPUT();
            input2.type = (int)InputType.INPUT_KEYBOARD;
            input2.ki.wVk = zero;
            input2.ki.dwFlags = (int)KEYEVENTF.KEYUP;
            input2.ki.dwExtraInfo = IntPtr.Zero;

            INPUT[] pInputs = new INPUT[] { structure, input2 };

            return SendInput(2, pInputs, Marshal.SizeOf(structure));
        }

        public static uint One()
        {
            INPUT structure = new INPUT();
            structure.type = (int)InputType.INPUT_KEYBOARD;
            structure.ki.wVk = one;
            structure.ki.dwFlags = (int)KEYEVENTF.KEYDOWN;
            structure.ki.dwExtraInfo = IntPtr.Zero;

            INPUT input2 = new INPUT();
            input2.type = (int)InputType.INPUT_KEYBOARD;
            input2.ki.wVk = one;
            input2.ki.dwFlags = (int)KEYEVENTF.KEYUP;
            input2.ki.dwExtraInfo = IntPtr.Zero;

            INPUT[] pInputs = new INPUT[] { structure, input2 };

            return SendInput(2, pInputs, Marshal.SizeOf(structure));
        }

        public static uint Two()
        {
            INPUT structure = new INPUT();
            structure.type = (int)InputType.INPUT_KEYBOARD;
            structure.ki.wVk = two;
            structure.ki.dwFlags = (int)KEYEVENTF.KEYDOWN;
            structure.ki.dwExtraInfo = IntPtr.Zero;

            INPUT input2 = new INPUT();
            input2.type = (int)InputType.INPUT_KEYBOARD;
            input2.ki.wVk = two;
            input2.ki.dwFlags = (int)KEYEVENTF.KEYUP;
            input2.ki.dwExtraInfo = IntPtr.Zero;

            INPUT[] pInputs = new INPUT[] { structure, input2 };

            return SendInput(2, pInputs, Marshal.SizeOf(structure));
        }

        public static uint Three()
        {
            INPUT structure = new INPUT();
            structure.type = (int)InputType.INPUT_KEYBOARD;
            structure.ki.wVk = three;
            structure.ki.dwFlags = (int)KEYEVENTF.KEYDOWN;
            structure.ki.dwExtraInfo = IntPtr.Zero;

            INPUT input2 = new INPUT();
            input2.type = (int)InputType.INPUT_KEYBOARD;
            input2.ki.wVk = three;
            input2.ki.dwFlags = (int)KEYEVENTF.KEYUP;
            input2.ki.dwExtraInfo = IntPtr.Zero;

            INPUT[] pInputs = new INPUT[] { structure, input2 };

            return SendInput(2, pInputs, Marshal.SizeOf(structure));
        }

        public static uint Four()
        {
            INPUT structure = new INPUT();
            structure.type = (int)InputType.INPUT_KEYBOARD;
            structure.ki.wVk = four;
            structure.ki.dwFlags = (int)KEYEVENTF.KEYDOWN;
            structure.ki.dwExtraInfo = IntPtr.Zero;

            INPUT input2 = new INPUT();
            input2.type = (int)InputType.INPUT_KEYBOARD;
            input2.ki.wVk = four;
            input2.ki.dwFlags = (int)KEYEVENTF.KEYUP;
            input2.ki.dwExtraInfo = IntPtr.Zero;

            INPUT[] pInputs = new INPUT[] { structure, input2 };

            return SendInput(2, pInputs, Marshal.SizeOf(structure));
        }

        public static uint Five()
        {
            INPUT structure = new INPUT();
            structure.type = (int)InputType.INPUT_KEYBOARD;
            structure.ki.wVk = five;
            structure.ki.dwFlags = (int)KEYEVENTF.KEYDOWN;
            structure.ki.dwExtraInfo = IntPtr.Zero;

            INPUT input2 = new INPUT();
            input2.type = (int)InputType.INPUT_KEYBOARD;
            input2.ki.wVk = five;
            input2.ki.dwFlags = (int)KEYEVENTF.KEYUP;
            input2.ki.dwExtraInfo = IntPtr.Zero;

            INPUT[] pInputs = new INPUT[] { structure, input2 };

            return SendInput(2, pInputs, Marshal.SizeOf(structure));
        }

        public static uint Six()
        {
            INPUT structure = new INPUT();
            structure.type = (int)InputType.INPUT_KEYBOARD;
            structure.ki.wVk = six;
            structure.ki.dwFlags = (int)KEYEVENTF.KEYDOWN;
            structure.ki.dwExtraInfo = IntPtr.Zero;

            INPUT input2 = new INPUT();
            input2.type = (int)InputType.INPUT_KEYBOARD;
            input2.ki.wVk = six;
            input2.ki.dwFlags = (int)KEYEVENTF.KEYUP;
            input2.ki.dwExtraInfo = IntPtr.Zero;

            INPUT[] pInputs = new INPUT[] { structure, input2 };

            return SendInput(2, pInputs, Marshal.SizeOf(structure));
        }

        public static uint Seven()
        {
            INPUT structure = new INPUT();
            structure.type = (int)InputType.INPUT_KEYBOARD;
            structure.ki.wVk = seven;
            structure.ki.dwFlags = (int)KEYEVENTF.KEYDOWN;
            structure.ki.dwExtraInfo = IntPtr.Zero;

            INPUT input2 = new INPUT();
            input2.type = (int)InputType.INPUT_KEYBOARD;
            input2.ki.wVk = seven;
            input2.ki.dwFlags = (int)KEYEVENTF.KEYUP;
            input2.ki.dwExtraInfo = IntPtr.Zero;

            INPUT[] pInputs = new INPUT[] { structure, input2 };

            return SendInput(2, pInputs, Marshal.SizeOf(structure));
        }

        public static uint Eight()
        {
            INPUT structure = new INPUT();
            structure.type = (int)InputType.INPUT_KEYBOARD;
            structure.ki.wVk = eight;
            structure.ki.dwFlags = (int)KEYEVENTF.KEYDOWN;
            structure.ki.dwExtraInfo = IntPtr.Zero;

            INPUT input2 = new INPUT();
            input2.type = (int)InputType.INPUT_KEYBOARD;
            input2.ki.wVk = eight;
            input2.ki.dwFlags = (int)KEYEVENTF.KEYUP;
            input2.ki.dwExtraInfo = IntPtr.Zero;

            INPUT[] pInputs = new INPUT[] { structure, input2 };

            return SendInput(2, pInputs, Marshal.SizeOf(structure));
        }

        public static uint Nine()
        {
            INPUT structure = new INPUT();
            structure.type = (int)InputType.INPUT_KEYBOARD;
            structure.ki.wVk = nine;
            structure.ki.dwFlags = (int)KEYEVENTF.KEYDOWN;
            structure.ki.dwExtraInfo = IntPtr.Zero;

            INPUT input2 = new INPUT();
            input2.type = (int)InputType.INPUT_KEYBOARD;
            input2.ki.wVk = nine;
            input2.ki.dwFlags = (int)KEYEVENTF.KEYUP;
            input2.ki.dwExtraInfo = IntPtr.Zero;

            INPUT[] pInputs = new INPUT[] { structure, input2 };

            return SendInput(2, pInputs, Marshal.SizeOf(structure));
        }

        public static uint Backspace()
        {
            INPUT structure = new INPUT();
            structure.type = (int)InputType.INPUT_KEYBOARD;
            structure.ki.wVk = backspace;
            structure.ki.dwFlags = (int)KEYEVENTF.KEYDOWN;
            structure.ki.dwExtraInfo = IntPtr.Zero;

            INPUT input2 = new INPUT();
            structure.type = (int)InputType.INPUT_KEYBOARD;
            structure.ki.wVk = backspace;
            input2.mi.dwFlags = (int)KEYEVENTF.KEYUP;
            input2.ki.dwExtraInfo = IntPtr.Zero;

            INPUT[] pInputs = new INPUT[] { structure, input2 };

            return SendInput(2, pInputs, Marshal.SizeOf(structure));
        }

        public static uint Dot()
        {
            INPUT structure = new INPUT();
            structure.type = (int)InputType.INPUT_KEYBOARD;
            structure.ki.wVk = dot;
            structure.ki.dwFlags = (int)KEYEVENTF.KEYDOWN;
            structure.ki.dwExtraInfo = IntPtr.Zero;

            INPUT input2 = new INPUT();
            structure.type = (int)InputType.INPUT_KEYBOARD;
            structure.ki.wVk = dot;
            input2.mi.dwFlags = (int)KEYEVENTF.KEYUP;
            input2.ki.dwExtraInfo = IntPtr.Zero;

            INPUT[] pInputs = new INPUT[] { structure, input2 };

            return SendInput(2, pInputs, Marshal.SizeOf(structure));
        }

        public static uint Space()
        {
            INPUT structure = new INPUT();
            structure.type = (int)InputType.INPUT_KEYBOARD;
            structure.ki.wVk = space;
            structure.ki.dwFlags = (int)KEYEVENTF.KEYDOWN;
            structure.ki.dwExtraInfo = IntPtr.Zero;

            INPUT input2 = new INPUT();
            structure.type = (int)InputType.INPUT_KEYBOARD;
            structure.ki.wVk = space;
            input2.mi.dwFlags = (int)KEYEVENTF.KEYUP;
            input2.ki.dwExtraInfo = IntPtr.Zero;

            INPUT[] pInputs = new INPUT[] { structure, input2 };

            return SendInput(2, pInputs, Marshal.SizeOf(structure));
        }
        #endregion
    }
}
