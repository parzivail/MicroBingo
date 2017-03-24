using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bingo.Properties;

namespace Bingo
{
    public partial class FormBingoBoard : Form
    {
        private readonly FormBingoController _parent;

        public bool IsClosing { get; set; }

        public FormBingoBoard(FormBingoController parent)
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
            BackColor = Color.FromArgb(10, 10, 10);
        }

        public Image UpdateBoard()
        {
            var boardOffOrig = (Image) Images.bingo_off.Clone();
            var boardOff = Graphics.FromImage(boardOffOrig);
            var boardOn = (Image)Images.bingo_on.Clone();

            foreach (var number in _parent.BingoBoard.Numbers)
            {
                var pos = _parent.BingoBoard.GetPositionForNumber(number);

                boardOff.DrawImage(boardOn, new Rectangle(pos.X, pos.Y, BingoBoard.BoardNumberWidth - 10, BingoBoard.BoardNumberHeight), new Rectangle(pos.X, pos.Y, BingoBoard.BoardNumberWidth - 10, BingoBoard.BoardNumberHeight), GraphicsUnit.Pixel);
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
