using System.Drawing;

namespace Sudoku
{
    /* statyczna klasa definiująca ogólne ustawienai gry */
    public static class GameSettings
    {
        public static Size tileSize = new Size(20, 20);
        public static int tileMargin = 5;
        public static int tileSetMargin = 5;
        public static Point gameBoardStartingPoint = new Point(12, 47);
        public static Size tileSetSize = new Size(
            (tileSize.Width + tileMargin) * 3 + tileSetMargin,
            (tileSize.Height + tileMargin) * 3 + tileSetMargin);

    }
}
