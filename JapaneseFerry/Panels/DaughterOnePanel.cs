using System.Drawing;
using System.Windows.Forms;

namespace JapaneseFerry.Panels
{
    public class DaughterOnePanel : BasePanel
    {
        public DaughterOnePanel() :
            base(
                new Point(151, 168),
                new Point(567, 168),
                Color.FromArgb(255, 0, 191, 255),
                "Дочь",
                "DaughterOne"
            )
        {
        }
    }
}