using System.Drawing;


namespace WindowsFormsApplication4.Controls
{
    public interface IControlPlus
    {
        Color OwnDrawColor
        {
            get;
            set;
        }

        bool UseOwnColor
        {
            get;
            set;
        }
    }
}
