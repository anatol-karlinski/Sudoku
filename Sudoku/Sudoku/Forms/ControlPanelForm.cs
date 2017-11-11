using System;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class ControlPanelForm : Form
    {
        private GameBoardForm _parentForm;
        public ControlPanelForm(GameBoardForm parentForm)
        {
            _parentForm = parentForm;
            InitializeComponent();
        }

        private void checkGameStateButton_Click(object sender, EventArgs e)
        {
            if(_parentForm.gameBoard.BoardIsSolved())
            {
                MessageBox.Show("Rozwiązanie jest prawidłowe :D", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Rozwiązanie nie jest jeszcze prawidłowe :(", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void exitButton_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            BoardStateLoader.LoadGameState(_parentForm.gameBoard);
        }
    }
}
