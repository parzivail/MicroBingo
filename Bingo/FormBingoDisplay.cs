using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using Bingo.Properties;

namespace Bingo
{
    public partial class FormBingoDisplay : Form
    {
        private readonly FormBingoController _parent;

        private static readonly Font Arial = new Font(new FontFamily("Arial"), 100, FontStyle.Bold);
        private static readonly Font ArialSmall = new Font(new FontFamily("Arial"), 48, FontStyle.Bold);

        public bool IsClosing { get; set; }

        public FormBingoDisplay(FormBingoController parent)
        {
            _parent = parent;
            InitializeComponent();
            Load += FormBingoBoard_Load;
            Closing += FormBingoBoard_Closing;
        }

        private void FormBingoBoard_Closing(object sender, CancelEventArgs e)
        {
            if (_parent.IsClosing)
                return;

            if (MessageBox.Show(this, Resources.CloseConfirmation, Resources.Bingo, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation) == DialogResult.No)
                e.Cancel = true;
            else
            {
                IsClosing = true;
                _parent.Close();
            }
        }

        private void FormBingoBoard_Load(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(12, 12, 12);
        }

        public Image UpdateBoard()
        {
            var boardOffOrig = (Image) Images.bingo_off.Clone();
            var boardOff = Graphics.FromImage(boardOffOrig);
            var boardOn = (Image)Images.bingo_on.Clone();

            foreach (var number in _parent.BingoBoard.NumbersShowing)
            {
                var pos = _parent.BingoBoard.GetPositionForNumber(number);

                boardOff.DrawImage(boardOn, new Rectangle(pos.X, pos.Y, BingoBoard.BoardNumberWidth - 10, BingoBoard.BoardNumberHeight), new Rectangle(pos.X, pos.Y, BingoBoard.BoardNumberWidth - 10, BingoBoard.BoardNumberHeight), GraphicsUnit.Pixel);
            }

            if (_parent.BingoBoard.NumbersShowing.Count > 0)
            {
                boardOff.TextRenderingHint = TextRenderingHint.AntiAlias;

                var left = _parent.BingoBoard.NumbersShowing.Count + "/" +
                           _parent.BingoBoard.GameType.GetLegalCategories().Count * 15;
                boardOff.DrawString(left, ArialSmall, Brushes.White, 30, 678);

                var num = _parent.BingoBoard.CurrentNumber;
                var curNumStr = BingoBoard.LetterForNumber(num) + @"-" + num;
                boardOff.DrawString(curNumStr, Arial, Brushes.White,
                    boardOffOrig.Width / 2f - boardOff.MeasureString(curNumStr, Arial).Width / 2f, 642);

                var name = _parent.BingoBoard.GameType.GetName();
                boardOff.DrawString(name, ArialSmall, Brushes.White, boardOffOrig.Width - 30 - boardOff.MeasureString(name, ArialSmall).Width, 678);
            }

            pictureBox1.Image = boardOffOrig;

            return boardOffOrig;
        }

        public void ResetBoard()
        {
            var boardOffOrig = (Image)Images.bingo_off.Clone();
            pictureBox1.Image = boardOffOrig;
        }
    }
}
