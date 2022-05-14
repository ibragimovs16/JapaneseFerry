using System.Drawing;
using System.Windows.Forms;

namespace JapaneseFerry.Panels
{
    public class FatherPanel : BasePanel
    {
        public FatherPanel() :
            base(
                new Point(151, 360),
                new Point(567, 360),
                Color.FromArgb(255, 138, 43, 226),
                "Отец",
                "Father"
            )
        {
        }
    }
}