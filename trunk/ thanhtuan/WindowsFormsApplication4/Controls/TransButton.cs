using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication4.Controls
{
    public partial class TransButton : UserControl
    {
        public string invoiceNum = "";
        public string tableName = "";
        public string cashierId = "";

        #region Contructor
        public TransButton(int x,int y,int width,int height)
        {
            this.SuspendLayout();
            // 
            // TransButton
            // 
            this.Name = "TransButton";
            this.Size = new System.Drawing.Size(width, height);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TransButton_Paint);
            this.ResumeLayout(false);
            this.Resize += new EventHandler(TransButton_Paint);
            Location = new Point(x,y);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.BackColor = Color.Transparent;
        }
        public TransButton()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.BackColor = Color.Transparent;
        }
        #endregion
        #region -  Enums  -

        public enum Shape
        {
            Elip = 0,
            Rec = 2,
            Square = 3
        } ;
        /// <summary>
        /// A private enumeration that determines 
        /// the mouse state in relation to the 
        /// current instance of the control.
        /// </summary>
        enum State { None, Hover, Pressed };

        /// <summary>
        /// A public enumeration that determines whether
        /// the button background is painted when the 
        /// mouse is not inside the ClientArea.
        /// </summary>
        public enum Style
        {
            /// <summary>
            /// Draw the button as normal
            /// </summary>
            Default,
            /// <summary>
            /// Only draw the background on mouse over.
            /// </summary>
            Flat
        };

        #endregion

        #region -  Text  -

        private string mText;
        /// <summary>
        /// The text that is displayed on the button.
        /// </summary>
        [Category("Text"),
         Description("The text that is displayed on the button.")]
        public string ButtonText
        {
            get { return mText; }
            set { mText = value; this.Invalidate(); }
        }

        private Color mForeColor = Color.White;
        /// <summary>
        /// The color with which the text is drawn.
        /// </summary>
        [Category("Text"),
         Browsable(true),
         DefaultValue(typeof(Color), "White"),
         Description("The color with which the text is drawn.")]
        public override Color ForeColor
        {
            get { return mForeColor; }
            set { mForeColor = value; this.Invalidate(); }
        }

        private ContentAlignment mTextAlign = ContentAlignment.MiddleCenter;
        /// <summary>
        /// The alignment of the button text
        /// that is displayed on the control.
        /// </summary>
        [Category("Text"),
         DefaultValue(typeof(ContentAlignment), "MiddleCenter"),
         Description("The alignment of the button text " +
                     "that is displayed on the control.")]
        public ContentAlignment TextAlign
        {
            get { return mTextAlign; }
            set { mTextAlign = value; this.Invalidate(); }
        }


        private Color mBorderColor = Color.DarkGray;
        [Category("Appearance"),
         DefaultValue(typeof(Color), "DarkGray"),
         Description("MyBorderColor")]
        public Color BorderColor
        {
            get
            {
                return mBorderColor;
            }
            set
            {
                mBorderColor = value;
                Invalidate();
            }
        }
        #endregion

        #region -  Image  -

        private Image mImage;
        /// <summary>
        /// The image displayed on the button that 
        /// is used to help the user identify
        /// it's function if the text is ambiguous.
        /// </summary>
        [Category("Image"),
         DefaultValue(null),
         Description("The image displayed on the button that " +
                     "is used to help the user identify" +
                     "it's function if the text is ambiguous.")]
        public Image Image
        {
            get { return mImage; }
            set { mImage = value; this.Invalidate(); }
        }

        private ContentAlignment mImageAlign = ContentAlignment.MiddleLeft;
        /// <summary>
        /// The alignment of the image 
        /// in relation to the button.
        /// </summary>
        [Category("Image"),
         DefaultValue(typeof(ContentAlignment), "MiddleLeft"),
         Description("The alignment of the image " +
                     "in relation to the button.")]
        public ContentAlignment ImageAlign
        {
            get { return mImageAlign; }
            set { mImageAlign = value; this.Invalidate(); }
        }

        private Size mImageSize = new Size(24, 24);
        /// <summary>
        /// The size of the image to be displayed on the
        /// button. This property defaults to 24x24.
        /// </summary>
        [Category("Image"),
         DefaultValue(typeof(Size), "24, 24"),
         Description("The size of the image to be displayed on the" +
                     "button. This property defaults to 24x24.")]
        public Size ImageSize
        {
            get { return mImageSize; }
            set { mImageSize = value; this.Invalidate(); }
        }

        #endregion

        #region -  Appearance  -

        private Shape mButtonShape = Shape.Rec;
      
        [Category("Appearance"),
         DefaultValue(typeof(Shape), "Rec"),
         Description("MyShape")]
        public Shape ButtonShape
        {
            get { return mButtonShape; }
            set { mButtonShape = value; this.Invalidate(); }
        }
        //private Style mButtonStyle = Style.Flat;
        ///// <summary>
        ///// Sets whether the button background is drawn 
        ///// while the mouse is outside of the client area.
        ///// </summary>
        //[Category("Appearance"),
        // DefaultValue(typeof(Style), "Default"),
        // Description("Sets whether the button background is drawn " +
        //             "while the mouse is outside of the client area.")]
        //public Style ButtonStyle
        //{
        //    get { return mButtonStyle; }
        //    set { mButtonStyle = value; this.Invalidate(); }
        //}

        private int mCornerRadius = 8;
        /// <summary>
        /// The radius for the button corners. The 
        /// greater this value is, the more 'smooth' 
        /// the corners are. This property should
        ///  not be greater than half of the 
        ///  controls height.
        /// </summary>
        [Category("Appearance"),
         DefaultValue(8),
         Description("The radius for the button corners. The " +
                     "greater this value is, the more 'smooth' " +
                     "the corners are. This property should " +
                     "not be greater than half of the " +
                     "controls height.")]
        public int CornerRadius
        {
            get { return mCornerRadius; }
            set { mCornerRadius = value; this.Invalidate(); }
        }

        private Color mHighlightColor = Color.White;
        /// <summary>
        /// The colour of the highlight on the top of the button.
        /// </summary>
        [Category("Appearance"),
         DefaultValue(typeof(Color), "White"),
         Description("The colour of the highlight on the top of the button.")]
        public Color HighlightColor
        {
            get { return mHighlightColor; }
            set { mHighlightColor = value; this.Invalidate(); }
        }

        private Color mButtonColor = Color.Black;
        /// <summary>
        /// The bottom color of the button that 
        /// will be drawn over the base color.
        /// </summary>
        [Category("Appearance"),
         DefaultValue(typeof(Color), "Black"),
         Description("The bottom color of the button that " +
                     "will be drawn over the base color.")]
        public Color ButtonColor
        {
            get { return mButtonColor; }
            set { mButtonColor = value; this.Invalidate(); }
        }

        private Color mBaseColor = Color.Black;
        /// <summary>
        /// The backing color that the rest of 
        /// the button is drawn. For a glassier 
        /// effect set this property to Transparent.
        /// </summary>
        [Category("Appearance"),
         DefaultValue(typeof(Color), "Black"),
         Description("The backing color that the rest of" +
                     "the button is drawn. For a glassier " +
                     "effect set this property to Transparent.")]
        public Color BaseColor
        {
            get { return mBaseColor; }
            set { mBaseColor = value; this.Invalidate(); }
        }

        #endregion

        #region -  Functions  -

        private StringFormat StringFormatAlignment(ContentAlignment textalign)
        {
            StringFormat sf = new StringFormat();
            switch (textalign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopRight:
                    sf.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleRight:
                    sf.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomCenter:
                case ContentAlignment.BottomRight:
                    sf.LineAlignment = StringAlignment.Far;
                    break;
            }
            switch (textalign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.BottomLeft:
                    sf.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopCenter:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.BottomCenter:
                    sf.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.TopRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.BottomRight:
                    sf.Alignment = StringAlignment.Far;
                    break;
            }
            return sf;
        }

        #endregion


        private void TransButton_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            DrawBackground(e.Graphics);
            DrawText(e.Graphics);

        }
        private void TransButton_Paint(object sender, EventArgs e)
        {
            Width = ClientRectangle.Width;
            Height = ClientRectangle.Height;
        }

        private void DrawBackground(Graphics g)
        {

            if (this.ButtonShape==Shape.Rec||this.ButtonShape==Shape.Square)
            {
                GraphicsPath gpath = new GraphicsPath();
                gpath.AddRectangle(ClientRectangle);
                this.Region = new Region(gpath);
                g.DrawRectangle(new Pen(mBorderColor, 2), ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width-1, ClientRectangle.Height-1);
            }
            else if(this.ButtonShape==Shape.Elip)
            {
                GraphicsPath gpath=new GraphicsPath();
                gpath.AddEllipse(ClientRectangle);
                this.Region=new Region(gpath);
                g.DrawEllipse(new Pen(mBorderColor, 2), ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width , ClientRectangle.Height );
            }
          }

        private void DrawText(Graphics g)
        {
            StringFormat sf = StringFormatAlignment(this.TextAlign);
            Rectangle r = new Rectangle(8, 8, this.Width - 17, this.Height - 17);
            g.DrawString(this.ButtonText, this.Font, new SolidBrush(this.ForeColor), r, sf);
        }


    }
}
