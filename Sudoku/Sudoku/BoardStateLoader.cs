using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Sudoku
{
    public static class BoardStateLoader
    {
        /* metoda ładująca stan planszy z pliku tekstowego */
        public static void LoadGameState(GameBoard gameBoard)
        {
            int[,] boardStateMatrix = new int[9, 9];
            int[,] subMatrix = new int[3, 3];
            char tempChar;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                    {
                        /* próba stworzenia macierzy 9x9 z pliku tekstowego */
                        for (int i = 0; i < 9; i++)
                        {
                            for (int j = 0; j < 9; j++)
                            {
                                /* pobieranie z pliku tylko cyfr i ignorowanie innych znaków */
                                do
                                {
                                    tempChar = (char)sr.Read();
                                } while (!Char.IsNumber(tempChar));
                                /* odjęcia 48 wynika z konwersji znaku ASCII (char) do liczby (int) */
                                boardStateMatrix[i, j] = tempChar - 48;
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Błąd!", "Nie udało się wczytać stanu planszy :(", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            /* kopiowanie podmacierzy 3x3 do poszczególnych paneli pola gry */
            for (int i=0;i<3;i++)
            {
                for(int j=0; j<3;j++)
                {
                    subMatrix = HelperFunctions.GetSubmatrix(ref boardStateMatrix, new Point(3*i, 3*j), new Size(3, 3));
                    gameBoard.tileSetMatrix[j, i].LoadTileSet(subMatrix);
                }
            }
        }

    }
}
