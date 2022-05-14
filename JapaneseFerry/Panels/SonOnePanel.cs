using System.Drawing;
using System.Windows.Forms;

namespace JapaneseFerry.Panels
{
    public class SonOnePanel : BasePanel
    {
        public SonOnePanel() :
            base(
                new Point(151, 456),
                new Point(567, 456),
                Color.FromArgb(255, 147, 112, 219),
                "Сын",
                "SonOne"
            )
        {
        }
    }
}