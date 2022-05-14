using System.Drawing;
using System.Windows.Forms;

namespace JapaneseFerry.Panels
{
    public class DaughterTwoPanel : BasePanel
    {
        public DaughterTwoPanel() :
            base(
                new Point(151, 264),
                new Point(567, 264),
                Color.FromArgb(255, 0, 191, 255),
                "Дочь",
                "DaughterTwo"
            )
        {
        }
    }
}