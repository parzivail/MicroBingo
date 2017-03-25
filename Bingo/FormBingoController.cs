using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bingo.Properties;

namespace Bingo
{
    public partial class FormBingoController : Form
    {
        private FormBingoDisplay _display;

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

            _display = new FormBingoDisplay(this);
            _display.Show();

            UpdateBoard();
        }

        private void TryWebpage(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch (Exception)
            {
                MessageBox.Show(this,
                    Resources.CantOpenLink,
                    Resources.Bingo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            if (_display.IsClosing)
                return;

            if (MessageBox.Show(this, Resources.CloseConfirmation, Resources.Bingo, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation) == DialogResult.No)
                e.Cancel = true;
            else
            {
                IsClosing = true;
                _display.Close();
            }
        }

        private void bPickNumber_Click(object sender, EventArgs e)
        {
            var num = BingoBoard.PickNumber();

            if (num == 0)
                lNumber.Text = Resources.Full;
            else
                lNumber.Text = BingoBoard.LetterForNumber(num) + @"-" + num;

            UpdateBoard();
        }

        private void bNewGame_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show(this, Resources.BoardClearConfirmation, Resources.Bingo, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation) == DialogResult.No)
                return;

            BingoBoard.ResetBoard();

            UpdateBoard();

            _display.ResetBoard();
            lNumber.Text = Resources.Ready;
        }

        private void UpdateBoard()
        {
            pbMinimap.Image = _display.UpdateBoard();
            tsLNumSelected.Text = string.Format(Resources.NumbersSelected, BingoBoard.Numbers.Count);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TryWebpage("https://github.com/parzivail/");
        }

        private void tutorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TryWebpage("https://github.com/parzivail/SjccBingo/blob/master/README.md#tutorial");
        }
    }
}
