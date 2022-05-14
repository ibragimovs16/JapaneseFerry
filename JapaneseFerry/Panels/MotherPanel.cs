using System.Drawing;
using System.Windows.Forms;

namespace JapaneseFerry.Panels
{
    public class MotherPanel : BasePanel
    {
        public MotherPanel() :
            base(
                new Point(151, 72),
                new Point(567, 72),
                Color.FromArgb(255, 0, 102, 203),
                "Мать",
                "Mother"
            )
        {
        }
    }
}