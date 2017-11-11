using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class GameBoardForm : Form
    {
        public GameBoard gameBoard;
        public GameBoardForm()
        {
            InitializeComponent();
        }

        private void GameBoardForm_Load(object sender, EventArgs e)
        {
            /* stworzenie nowej planszy do gry */
            gameBoard = new GameBoard(this);
            /* stworzenie i pokazanie panelu kontrolnego */
            ControlPanelForm controlPanel = new ControlPanelForm(this);
            controlPanel.Show();
        }
    }
}
