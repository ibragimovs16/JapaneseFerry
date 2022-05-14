using System.Drawing;
using System.Windows.Forms;
using JapaneseFerry.Enums;

namespace JapaneseFerry.Panels
{
    public class BoatPanel
    {
        public BoatPanel()
        {
            Panel = new Panel
            {
                Location = PositionState == PositionState.LeftSide ? LeftSidePos : RightSidePos,
                Size = Size,
                BackColor = Color.FromArgb(255, 139, 69, 19),
            };
        }

        public Point LeftSidePos { get; } = new(258, 247);
        public Point RightSidePos { get; } = new(454, 247);
        public Size Size { get; } = new(99, 195);
        public Panel Panel { get; }
        public PositionState PositionState { get; private set; } = PositionState.LeftSide;
        public BasePanel FirstCharacter { get; private set; }
        public BasePanel SecondCharacter { get; private set; }

        public bool IsEmpty =>
            FirstCharacter is null && SecondCharacter is null;

        public bool IsFull =>
            FirstCharacter is not null && SecondCharacter is not null;

        public bool ChangePosition()
        {
            if (IsEmpty) return false;
            
            if (PositionState == PositionState.LeftSide)
            {
                PositionState = PositionState.RightSide;
                FirstCharacter?.ChangePosition();
                SecondCharacter?.ChangePosition();
                Panel.Location = RightSidePos;
            }
            else
            {
                PositionState = PositionState.LeftSide;
                FirstCharacter?.ChangePosition();
                SecondCharacter?.ChangePosition();
                Panel.Location = LeftSidePos;
            }

            return true;
        }

        public bool Add(BasePanel character)
        {
            if (IsFull) return false;
            if (character.PositionState != PositionState) return false;

            character.IsOnBoat = true;
            
            if (FirstCharacter is null)
            {
                FirstCharacter = character;
                character.Panel.Location = new Point(3, 4);
            }
            else
            {
                SecondCharacter = character;
                character.Panel.Location = new Point(3, 100);
            }
            
            Panel.Controls.Add(character.Panel);
            return true;
        }

        public bool Remove(BasePanel character)
        {
            if (IsEmpty) return false;

            character.IsOnBoat = false;
            
            Panel.Controls.Remove(character.Panel);

            character.Panel.Location = PositionState == PositionState.LeftSide ? 
                character.LeftSidePos : 
                character.RightSidePos;

            if (FirstCharacter is not null && character.GetType() == FirstCharacter.GetType()) FirstCharacter = null;
            else SecondCharacter = null;
            
            return true;
        }

        public void RemoveAll()
        {
            Panel.Controls.Clear();

            if (FirstCharacter is not null)
            {
                FirstCharacter.IsOnBoat = false;
                FirstCharacter = null;
            }
            if (SecondCharacter is null) return;
            
            SecondCharacter.IsOnBoat = false;
            SecondCharacter = null;
        }
    }
}