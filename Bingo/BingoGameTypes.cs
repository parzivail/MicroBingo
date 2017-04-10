using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bingo
{
    class BingoGameTypes
    {
        public static IBingoGameType GameStandard = new GameTypeStandard("Standard");
        public static IBingoGameType GameFourCorners = new GameTypeFourCorners();
        public static IBingoGameType GameLittlePictureFrame = new GameTypeLittlePictureFrame();
        public static IBingoGameType GameX = new GameTypeX();
        public static IBingoGameType GamePostageStamp = new GameTypePostageStamp();
        public static IBingoGameType GameBlackout = new GameTypeStandard("Blackout");

        internal class GameTypePostageStamp : IBingoGameType
        {
            public string GetName()
            {
                return "Postage Stamp";
            }

            public List<int> GetLegalCategories()
            {
                return new List<int> {3, 4};
            }
        }

        internal class GameTypeX : IBingoGameType
        {
            public string GetName()
            {
                return "X";
            }

            public List<int> GetLegalCategories()
            {
                return new List<int> { 0, 1, 3, 4 };
            }
        }

        internal class GameTypeLittlePictureFrame : IBingoGameType
        {
            public string GetName()
            {
                return "Little Picture Frame";
            }

            public List<int> GetLegalCategories()
            {
                return new List<int> { 1, 2, 3 };
            }
        }

        internal class GameTypeFourCorners : IBingoGameType
        {
            public string GetName()
            {
                return "Four Corners";
            }

            public List<int> GetLegalCategories()
            {
                return new List<int> { 0, 4 };
            }
        }

        internal class GameTypeStandard : IBingoGameType
        {
            private readonly string _name;

            public GameTypeStandard(string name)
            {
                _name = name;
            }

            public string GetName()
            {
                return _name;
            }

            public List<int> GetLegalCategories()
            {
                return new List<int> { 0, 1, 2, 3, 4};
            }
        }
    }
}
