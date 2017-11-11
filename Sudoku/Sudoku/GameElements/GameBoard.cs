using System.Windows.Forms;

namespace Sudoku
{
    /* klasa reprezentująca grę planszową */
    public class GameBoard
    {
        public TileSet[,] tileSetMatrix;
        public GameBoardForm parentForm;

        public GameBoard(GameBoardForm gameBoardForm)
        {
            parentForm = gameBoardForm;

            /* stworzenie 9 paneli, z któych każdy ma 9 pól  */ 
            tileSetMatrix = new TileSet[3, 3];
            for(int i = 0; i<3; i++)
            {
                for(int j=0; j<3; j++)
                {
                    tileSetMatrix[i, j] = new TileSet(this, i, j);
                }
            }
        }
        /* metoda sprawdzająca, czy obecne rozwiązanie planszy jest prawidłowe */
        public bool BoardIsSolved()
        {
            int[,] gameBoardValuesMatrix = GetAllTileValues();
            int[] solutionsArray;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    /* sprawdzenie czy poszczególne panele są prawidłowo rozwiązane
                     * (czy wewnątrz panelu nie powtarzają się liczby)
                     */
                    if (!tileSetMatrix[i, j].TileSetIsSolved())
                        return false;
                }
            }
            for (int i =0; i< 9; i++)
            {
                /* sprawdzenie, czy pion jest prawidłowy 
                 * (czy nie posiada powtarzających się liczb i czy te liczby są z przedziału od 1 do 9) 
                 */
                solutionsArray = new int[9];
                for (int j = 0; j < 9; j++)
                {
                    if (gameBoardValuesMatrix[i, j] > 0 && gameBoardValuesMatrix[i, j] <= 9)
                        solutionsArray[gameBoardValuesMatrix[i, j] - 1]++;
                    else
                        return false;

                    if (solutionsArray[gameBoardValuesMatrix[i, j] - 1] != 1)
                        return false;
                }
                /* to samo co wyrzej, tylko dla poziomu */
                solutionsArray = new int[9];
                for (int j = 0; j < 9; j++)
                {
                    if (gameBoardValuesMatrix[j, i] > 0 && gameBoardValuesMatrix[j, i] <= 9)
                        solutionsArray[gameBoardValuesMatrix[j, i] - 1]++;
                    else
                        return false;

                    if (solutionsArray[gameBoardValuesMatrix[j, i] - 1] != 1)
                        return false;
                }
            }
            return true;
        }
        /* 
         * metoda tworząca macierz liczb z wartościami z pól tekstowych 
         * (ta macierz jest użyta w algorytmie sprawdzającym czy plansza posiada prawidłowe rozwiązanie)
        */
        private int[,] GetAllTileValues()
        {
            int[,] valuesMatrix = new int[9, 9];
            int[,] tileValues = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tileValues = tileSetMatrix[i, j].GetMatrixOfTileValues();
                    HelperFunctions.InsertMatrixAtPoint(ref tileValues, ref valuesMatrix, i, j);
                }
            }
            return valuesMatrix;
        }
    }
}
