using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace WindowsFormsApplication4
{
    class GDI
    {
 
        [DllImport("GDI32.DLL", EntryPoint = "CreateRoundRectRgn")]
        public static extern int CreateRoundRectRgn(int x1, int y1, int x2, int y2, int x3, int y3);
        [DllImport("GDI32.DLL", EntryPoint = "CreateRectRgn")]
        public static extern int CreateRectRgn(int x1, int y1, int x2, int y2);
        [DllImport("user32.DLL", EntryPoint = "SetWindowRgn")]
        public static extern int SetWindowRgn(int hWnd, int hRgn, bool bRedraw);

        [DllImport("user32.dll")]
        public static extern IntPtr GetDCEx(IntPtr hwnd, IntPtr hrgnclip, uint fdwOptions);
        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hwnd, IntPtr hDC);
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

       
    }
}
