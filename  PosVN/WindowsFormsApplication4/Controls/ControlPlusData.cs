using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace WindowsFormsApplication4.Controls
{
    public static class ControlPlusData
    {
        #region -------------- Event declaration --------------

        public delegate void OnColorSchemeChanged();

        public static event OnColorSchemeChanged OnColorSchemeChangeEvent;

        #endregion

        #region ------------ Private members ------------------

        private static Color m_DrawColor = Color.FromArgb(0x99, 0xCC, 0xFF);
        private static Color m_HighlightColor = Color.Gold;
        private static Color m_ShadowColor = Color.LightSlateGray;

        #endregion

        #region -------------- Public Color constants ---------

        public static readonly Color ColorThemeLightCyan = Color.FromArgb(0x99, 0xCC, 0xFF);
        public static readonly Color ColorThemeBlue = Color.Blue;
        public static readonly Color ColorThemeRed = Color.Red;

        //public static readonly Color ColorThemeLightGreen = Color.FromArgb(0x33, 0xCC, 0x33);
        public static readonly Color ColorThemeLightGreen = Color.FromArgb(0x33, 0x99, 0x99);
        public static readonly Color ColorThemeOrchid = Color.Magenta;
        public static readonly Color ColorThemeGray = Color.LightGray;

        #endregion

        #region ------- Public static Drawing tools -----------

        public static Brush DrawBrush = new SolidBrush(m_DrawColor);
        public static Pen DrawPen = new Pen(m_DrawColor);
        public static Brush HighlightBrush = new SolidBrush(m_HighlightColor);
        public static Pen HighlightPen = new Pen(m_HighlightColor);
        public static Pen ShadowPen = new Pen(m_ShadowColor);
        public static Brush DarkDrawBrush =
            new SolidBrush(Color.FromArgb(m_DrawColor.R/2, m_DrawColor.G/2, m_DrawColor.B/2));

        #endregion

        #region --------- Public Color properties -------------

        private static Color GetDarkColor(Color c)
        {
            return Color.FromArgb(c.R/2, c.G/2, c.B/2);
        }

        public static Color DrawColor
        {
            get { return m_DrawColor; }
            set
            {
                m_DrawColor = value;

                DrawBrush = new SolidBrush(m_DrawColor);
                DrawPen = new Pen(m_DrawColor);
                DarkDrawBrush = new SolidBrush(GetDarkColor(m_DrawColor));

                if (OnColorSchemeChangeEvent != null)
                    OnColorSchemeChangeEvent();
            }
        }

        public static Color HighlightColor
        {
            get { return m_HighlightColor; }
            set
            {
                m_HighlightColor = value;

                HighlightBrush = new SolidBrush(m_HighlightColor);
                HighlightPen = new Pen(m_HighlightColor);

                if (OnColorSchemeChangeEvent != null)
                    OnColorSchemeChangeEvent();
            }
        }

        public static Color ShadowColor
        {
            get{    return m_ShadowColor;   }
            set
            {
                m_ShadowColor = value;

                ShadowPen = new Pen(m_ShadowColor);

                if (OnColorSchemeChangeEvent != null)
                    OnColorSchemeChangeEvent();
            }
        }

        #endregion

        #region -------------- P/Invokes ----------------------
        
        [DllImport("coredll.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("coredll.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, uint wParam, uint lParam);

        [DllImport("coredll.dll")]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        /// <summary>
        /// Get relative window with a given window.
        /// </summary>
        /// <param name="hwnd">the Given window</param>
        /// <param name="cmd">an <see cref="GetWindowFlags"/> value, indicates the relation.</param>
        /// <returns></returns>
        [DllImport("coredll.dll")]
        public static extern IntPtr GetWindow(IntPtr hwnd, int cmd);

        [DllImport("coredll.dll")]
        static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("coredll.dll")]
        public static extern bool DestroyWindow(IntPtr hwnd);

        public enum GetWindowFlags
        {
            GW_HWNDFIRST = 0,
            GW_HWNDLAST = 1,
            GW_HWNDNEXT = 2,
            GW_HWNDPREV = 3,
            GW_OWNER = 4,
            GW_CHILD = 5,
            GW_MAX = 5
        }

        public enum EditMsg
        {
            EM_CANUNDO = 0x00C6,
            EM_CANPASTE = 0x0432,
            WM_CUT = 0x0300,
            WM_COPY = 0x0301,
            WM_PASTE = 0x0302,
            WM_CLEAR = 0x0303,
            WM_UNDO = 0x0304
        }

        public enum ClipboardFormat
        {
            CF_TEXT = 1,
            CF_UNICODETEXT = 13
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int X;
            public int Y;
            public int Width;
            public int Height;
        }

        #endregion
    }
}
