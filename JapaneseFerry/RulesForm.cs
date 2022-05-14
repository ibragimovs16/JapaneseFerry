using System;
using System.Windows.Forms;

namespace JapaneseFerry
{
    public partial class RulesForm : Form
    {
        public RulesForm() =>
            InitializeComponent();

        private void CloseRulesBtn_Click(object sender, EventArgs e) =>
            Close();
    }
}