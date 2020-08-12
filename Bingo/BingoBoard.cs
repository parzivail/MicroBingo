using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bingo
{
    public class BingoBoard
    {
        private static readonly string[] _bingo = { "B", "I", "N", "G", "O" };

        public const int BoardNumberWidth = 120;
        public const int BoardNumberHeight = 110;

        public List<int> Numbers { get; } = new List<int>();
        public List<int> NumbersShowing { get; } = new List<int>();
        public int CurrentNumber { get; set; } = -1;
        public IBingoGameType GameType;

        private readonly byte[] _rngBuffer = new byte[4];
        public RNGCryptoServiceProvider Rng { get; } = new RNGCryptoServiceProvider();

        public static string LetterForNumber(int num)
        {
            return _bingo[GetRowForNumber(num)];
        }

        public static int GetRowForNumber(int num)
        {
            return (int)Math.Floor((num - 1) / 15f);
        }

        public int GetColumnForNumber(int num)
        {
            return (num - 1) % 15;
        }

        public Point GetPositionForNumber(int num)
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
                num = RngNext(75) + 1;

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

        private int RngNext(int max)
        {
            Rng.GetBytes(_rngBuffer);
            var randInt = BitConverter.ToUInt32(_rngBuffer, 0);

            var scalar = randInt / (double)uint.MaxValue;
            return (int)(scalar * max);
        }

        public void ResetBoard()
        {
            Numbers.Clear();
            NumbersShowing.Clear();
            CurrentNumber = -1;
        }
    }
}
