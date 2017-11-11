using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sudoku
{
    /* klasa reprezentująca pojedyńczy panel 3x3 */ 
    public class TileSet
    {
        public TextBox[,] tileMatrix;
        public int[,] tileValuesMatrix;

        public TileSet(GameBoard gameBoard, int row, int column)
        {
            tileValuesMatrix = new int[3, 3];
            tileMatrix = new TextBox[3, 3];
            TextBox tile;

            /* tworzenie poszeczególnych pól tekstowych (TextBox) i nadawanie im odpowiedznich właściwości */
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tile = tileMatrix[i, j] = new TextBox();
                    tile.BackColor = Color.White;
                    tile.ForeColor = Color.DimGray;
                    tile.Size = GameSettings.tileSize;
                    tile.Location = new Point(
                        GameSettings.gameBoardStartingPoint.X + (GameSettings.tileSetSize.Width * column) + i * (GameSettings.tileSize.Width + GameSettings.tileMargin),
                        GameSettings.gameBoardStartingPoint.Y + (GameSettings.tileSetSize.Height * row) + j * (GameSettings.tileSize.Height + GameSettings.tileMargin)
                        );
                    tile.KeyPress += new KeyPressEventHandler((sender, ev) =>
                    {
                        if ((ev.KeyChar < 49 || ev.KeyChar > 57) && ev.KeyChar != 8)
                            ev.Handled = true;
                    });
                    gameBoard.parentForm.Controls.Add(tileMatrix[i, j]);
                }
            }
        }
        /* metoda sprawdzająca, czy panel jest prawidłowo rozwiązany
         * (czy nie powtarzają się w nim liczby i czy są one z przedziału od 1 do 9)
         */
        public bool TileSetIsSolved()
        {
            CreateMatrixOfTileValues();
            int[] answerCountArray = new int[9];
            foreach(int tileValue in tileValuesMatrix)
            {
                if (tileValue > 0 && tileValue <= 9)
                    answerCountArray[tileValue - 1]++;
                else
                    return false;

                if (answerCountArray[tileValue - 1] != 1)
                    return false;
            }
            return true;
        }
        /* metoda tworząca macierz wartości z pól tekstowych całego panelu */
        public void CreateMatrixOfTileValues()
        {
            tileValuesMatrix = new int[3, 3];
            int tileValue;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Int32.TryParse(tileMatrix[i, j].Text, out tileValue))
                        tileValuesMatrix[i, j] = tileValue;
                    else
                        tileValuesMatrix[i, j] = 0;
                }
            }
        }
        /* metoda zwracająca macierz wartości z pól tekstowych całego panelu */
        public int[,] GetMatrixOfTileValues()
        {
            CreateMatrixOfTileValues();
            return tileValuesMatrix;
        }
        /* metoda ładująca watości z podanej macierzy do pól tekstowych panelu */
        public void LoadTileSet(int[,] valuesMaxtrix)
        {
            for(int i=0; i<3;i++)
            {
                for(int j=0; j < 3; j++)
                {
                    tileMatrix[i, j].Text = valuesMaxtrix[i, j].ToString() == "0" ? "" : valuesMaxtrix[i, j].ToString();
                }
            }
        }
    }
}
