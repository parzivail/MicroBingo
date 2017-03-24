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
        private FormBingoBoard _board;

        public bool IsClosing { get; set; }
        public BingoBoard BingoBoard { get; set; }

        private const int Version = 1;

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

            UpdateBoard();

            try
            {
                var client = new WebClient();
                var remoteVersionString =
                    client.DownloadString("https://raw.githubusercontent.com/parzivail/SjccBingo/master/VERSION.md");

                if (!int.TryParse(remoteVersionString, out int version)) return;
                if (version == Version)
                    return;

                if (MessageBox.Show(this,
                        string.Format(Resources.NewUpdateAvailable, Version, version),
                        Resources.Bingo, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    TryWebpage("https://github.com/parzivail/SjccBingo/releases/tag/1." + version);
            }
            catch (Exception)
            {
                MessageBox.Show(this,
                    Resources.NoInternet,
                    Resources.Bingo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
                    Resources.NoInternet,
                    Resources.Bingo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

            _board.ResetBoard();
            lNumber.Text = Resources.Ready;
        }

        private void UpdateBoard()
        {
            pbMinimap.Image = _board.UpdateBoard();
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
