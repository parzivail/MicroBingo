using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bingo
{
    public class BingoBoard
    {
        private static readonly string[] Bingo = { "B", "I", "N", "G", "O" };
        
        private readonly byte[] _rngBuffer = new byte[4];

        public const int BoardNumberWidth = 120;
        public const int BoardNumberHeight = 110;
        
        public HashSet<int> Numbers { get; } = new HashSet<int>();
        public HashSet<int> NumbersShowing { get; } = new HashSet<int>();
        public RandomNumberGenerator Rng { get; } = RandomNumberGenerator.Create();
        public int CurrentNumber { get; set; } = -1;
        public IBingoGameType GameType;

        public static string LetterForNumber(int num)
        {
            return Bingo[GetRowForNumber(num)];
        }

        private static int GetRowForNumber(int num)
        {
            return (int)Math.Floor((num - 1) / 15f);
        }

        private static int GetColumnForNumber(int num)
        {
            return (num - 1) % 15;
        }

        public static Point GetPositionForNumber(int num)
        {
            var col = GetColumnForNumber(num);
            var row = GetRowForNumber(num);

            var pt = new Point(134 + col * BoardNumberWidth, 24 + row * BoardNumberHeight);

            if (col >= 7)
                pt.X += 14;

            return pt;
        }

        public int PickNumber()
        {
            var cats = GameType.GetLegalCategories();

            if (NumbersShowing.Count == cats.Count * 15)
                return 0;

            int num;
            while (true)
            {
                Rng.GetBytes(_rngBuffer);
                var rngNum = BitConverter.ToInt32(_rngBuffer, 0);
                num = (rngNum % 75) + 1;

                if (Numbers.Contains(num))
                    continue;
                Numbers.Add(num);

                if (!cats.Contains(GetRowForNumber(num))) continue;

                NumbersShowing.Add(num);
                break;
            }

            CurrentNumber = num;

            return num;
        }

        public void ResetBoard()
        {
            Numbers.Clear();
            NumbersShowing.Clear();
            CurrentNumber = -1;
        }
    }
}
