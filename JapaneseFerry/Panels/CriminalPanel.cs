using System.Drawing;
using System.Windows.Forms;

namespace JapaneseFerry.Panels
{
    public class CriminalPanel : BasePanel
    {
        public CriminalPanel() :
            base(
                new Point(52, 264),
                new Point(666, 264),
                Color.FromArgb(255, 220, 20, 60),
                "Преступник",
                "Criminal"
            )
        {
        }
    }
}