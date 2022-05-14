using System.Drawing;
using System.Windows.Forms;
using JapaneseFerry.Enums;

namespace JapaneseFerry.Panels
{
    public abstract class BasePanel
    {
        public BasePanel(Point leftSidePos, Point rightSidePos, Color color, string labelText, string name)
        {
            LeftSidePos = leftSidePos;
            RightSidePos = rightSidePos;
            Color = color;
            Name = name;
            
            Panel = new Panel
            {
                Location = PositionState == PositionState.LeftSide ? LeftSidePos : RightSidePos,
                BackColor = Color,
                Size = Size
            };
            
            Panel.Controls.Add(new Label
            {
                Size = Size,
                Text = labelText,
                Font = new Font(
                    "Microsoft Sans Serif", 
                    11.78182F, 
                    FontStyle.Bold, 
                    GraphicsUnit.Point, 
                    204
                ),
                Name = Name
            });
        }
        
        public Point LeftSidePos { get; }
        public Point RightSidePos { get; }
        public Size Size { get; } = new Size(93, 90);
        public Color Color { get; }
        public Panel Panel { get; }
        public string Name { get; }
        public PositionState PositionState { get; private set; } = PositionState.LeftSide;
        public bool IsOnBoat { get; set; }

        public void ChangePosition()
        {
            if (PositionState == PositionState.LeftSide)
            {
                PositionState = PositionState.RightSide;
                Panel.Location = RightSidePos;
            }
            else
            {
                PositionState = PositionState.LeftSide;
                Panel.Location = LeftSidePos;
            }
        }
    }
}