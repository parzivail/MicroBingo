using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bingo
{
    class BingoGameTypes
    {
        public static IBingoGameType GameFourCorners = new GameTypeFourCorners();
        public static IBingoGameType GameLittlePictureFrame = new GameTypeLittlePictureFrame();

        internal class GameTypeFourCorners : IBingoGameType
        {
            public string GetName()
            {
                return "Four Corners";
            }

            public bool IsCategoryLegal(int category)
            {
                return category == 0 || category == 4;
            }
        }

        internal class GameTypeLittlePictureFrame : IBingoGameType
        {
            public string GetName()
            {
                return "Little Picture Frame";
            }

            public bool IsCategoryLegal(int category)
            {
                return category == 1 || category == 2 || category == 3;
            }
        }
    }
}
