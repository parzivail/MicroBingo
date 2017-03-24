using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bingo.Properties;

namespace Bingo
{
    public partial class FormBingoController : Form
    {
        private FormBingoBoard _board;

        public bool IsClosing { get; set; }
        public BingoBoard BingoBoard { get; set; }

        public FormBingoController()
        {
            InitializeComponent();

            Load += Form1_Load;
            Closing += Form1_Closing;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = Resources.BingoController;
            lNumber.Text = Resources.Ready;

            BingoBoard = new BingoBoard();

            _board = new FormBingoBoard(this);
            _board.Show();
        }

        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            if (_board.IsClosing)
                return;

            if (MessageBox.Show(this, Resources.CloseConfirmation, Resources.Bingo, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation) == DialogResult.No)
                e.Cancel = true;
            else
            {
                IsClosing = true;
                _board.Close();
            }
        }

        private void bPickNumber_Click(object sender, EventArgs e)
        {
            var num = BingoBoard.PickNumber();

            if (num == 0)
                lNumber.Text = Resources.Full;
            else
                lNumber.Text = BingoBoard.LetterForNumber(num) + @"-" + num;

            _board.UpdateBoard();
        }

        private void bNewGame_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show(this, Resources.BoardClearConfirmation, Resources.Bingo, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation) == DialogResult.No)
                return;

            BingoBoard.ResetBoard();

            _board.ResetBoard();
            lNumber.Text = Resources.Ready;
        }

        private void bReopenBoard_Click(object sender, EventArgs e)
        {
            IsClosing = true;
            _board?.Close();
            IsClosing = false;

            _board = new FormBingoBoard(this);
            _board.Show();
            _board.UpdateBoard();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("");
        }

        private void tutorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("");
        }
    }
}
