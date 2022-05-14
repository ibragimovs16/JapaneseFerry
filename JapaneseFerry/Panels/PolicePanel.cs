using System.Drawing;
using System.Windows.Forms;

namespace JapaneseFerry.Panels
{
    public class PolicePanel : BasePanel
    {
        public PolicePanel() :
            base(
                new Point(52, 360),
                new Point(666, 360),
                Color.FromArgb(255, 0, 255, 0),
                "Полиция",
                "Police"
            )
        {
        }
    }
}