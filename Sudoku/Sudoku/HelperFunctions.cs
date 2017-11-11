using System.Drawing;

namespace Sudoku
{
    /* klasa z metodami pomocniczymi */
    public static class HelperFunctions
    {
        /* metoda pozwalająca na wstawienie mniejszej macierzy w większą w podanym miejscu (kolumnie i rzędzie)*/
        public static void InsertMatrixAtPoint(ref int[,] sourceMatrix, ref int[,] destMatrix, int row, int column)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    destMatrix[i + column * 3, j + row * 3] = sourceMatrix[i, j];
                }
            }
        }
        /* metoda pozwalająca wyciagąć podmacierz z podanej macierzy, z podanego miejsca i o podanym rozmiarze */
        public static int[,] GetSubmatrix(ref int [,] mainMatrix, Point submatrixStartingPoint, Size submatrixSize)
        {
            int[,] subMatrix = new int[submatrixSize.Width, submatrixSize.Height];
            for(int i=0; i<submatrixSize.Width; i++)
            {
                for(int j=0; j<submatrixSize.Height; j++)
                {
                    subMatrix[i, j] = mainMatrix[submatrixStartingPoint.Y + j, submatrixStartingPoint.X + i];
                }
            }
            return subMatrix;
        }
    }
}
