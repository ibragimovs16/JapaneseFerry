using System.Drawing;
using System.Windows.Forms;

namespace JapaneseFerry.Panels
{
    public class SonTwoPanel : BasePanel
    {
        public SonTwoPanel() :
            base(
                new Point(151, 552),
                new Point(567, 552),
                Color.FromArgb(255, 147, 112, 219),
                "Сын",
                "SonTwo"
            )
        {
        }
    }
}