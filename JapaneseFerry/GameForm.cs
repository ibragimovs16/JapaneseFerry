using System;
using System.Linq;
using System.Timers;
using System.Windows.Forms;
using JapaneseFerry.Enums;

namespace JapaneseFerry
{
    public partial class GameForm : Form
    {
        private readonly RulesForm _rules = new();
        private int _remainingTime = 900;

        public GameForm()
        {
            InitializeComponent();
            _rules.ShowDialog();

            foreach (var item in GameRulesChecker.AllPanels.Values)
            {
                item.Panel.Click += PanelsClick;
                item.Panel.Controls[0].Click += PanelsClick;
                Controls.Add(item.Panel);
            }

            Controls.Add(GameRulesChecker.Boat.Panel);
            
            Timer.Enabled = true;
        }

        private void RulesBtn_Click(object sender, EventArgs e)
        {
            _rules.CloseRulesBtn.Text = "Закрыть правила";
            _rules.ShowDialog();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _remainingTime--;

            var ts = TimeSpan.FromSeconds(_remainingTime);
            TimerLbl.Text = $@"{ts.Minutes}:{ts.Seconds}";

            if (_remainingTime != 0) return;
            
            Timer.Enabled = false;
            MessageBox.Show(@"Вы проиграли.");
        }

        private void SwimAcrossBtn_Click(object sender, EventArgs e)
        {
            if (GameRulesChecker.Boat.IsEmpty)
            {
                MessageBox.Show("Лодка не может плыть пустой.");
                return;
            }
            if (!GameRulesChecker.Check(GameRulesChecker.AllPanels, GameRulesChecker.Boat.PositionState, out var message))
            {
                MessageBox.Show(message);
                return;
            }

            GameRulesChecker.Boat.ChangePosition();
            
            if (GameRulesChecker.Boat.FirstCharacter is not null) 
                Controls.Add(GameRulesChecker.Boat.FirstCharacter.Panel);
            if (GameRulesChecker.Boat.SecondCharacter is not null)
                Controls.Add(GameRulesChecker.Boat.SecondCharacter.Panel);

            GameRulesChecker.Boat.RemoveAll();

            var countOfLeftSidePanels = GameRulesChecker.AllPanels.Values
                .Count(item => item.PositionState == PositionState.LeftSide);
            if (countOfLeftSidePanels != 0) return;
            
            Timer.Enabled = false;
            var ts = TimeSpan.FromSeconds(900 - _remainingTime);
            MessageBox.Show($"ПОБЕДА!\nВам потребовалось: {ts.Minutes}:{ts.Seconds} минут.");
        }

        private void PanelsClick(object sender, EventArgs e) 
        {
            if (sender is not Label currentLabel) return;
            
            var currentObject = GameRulesChecker.AllPanels[currentLabel.Name];
            if (currentObject.IsOnBoat)
            {
                if (!GameRulesChecker.Boat.Remove(currentObject)) MessageBox.Show("Лодка пуста.");
                Controls.Add(currentObject.Panel);
            }
            else
            {
                if (GameRulesChecker.Boat.Add(currentObject)) return;
                
                if (currentObject.PositionState == GameRulesChecker.Boat.PositionState) 
                    MessageBox.Show("Лодка переполнена.");
            }
        }
    }
}