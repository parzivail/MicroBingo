﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using Bingo.Properties;

namespace Bingo
{
    public partial class FormBingoController : Form
    {
        private FormBingoDisplay _display;

        public bool IsClosing { get; set; }
        public BingoBoard BingoBoard { get; set; }

        public static IBingoGameType[] GameTypes =
        {
            BingoGameTypes.GameStandard, BingoGameTypes.GameLittlePictureFrame,
            BingoGameTypes.GameX, BingoGameTypes.GameFourCorners, BingoGameTypes.GameBlackout,
            BingoGameTypes.GamePostageStamp
        };

        public static string[] GameTypeNames = new string[GameTypes.Length];

        public FormBingoController()
        {
            InitializeComponent();

            Load += Form1_Load;
            Closing += Form1_Closing;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ver = Assembly.GetExecutingAssembly().GetName().Version;
            Text = Resources.BingoController + " v" + ver;
            lNumber.Text = Resources.Ready;

            BingoBoard = new BingoBoard();

            _display = new FormBingoDisplay(this);
            _display.Show();

            BingoBoard.GameType = GameTypes[0];

            for (var i = 0; i < GameTypes.Length; i++)
            {
                GameTypeNames[i] = GameTypes[i].GetName();
                cbGameSelector.Items.Add(GameTypeNames[i]);
            }
            cbGameSelector.SelectedIndex = 0;
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
            TryReset();
        }

        private bool TryReset()
        {
            if (BingoBoard.Numbers.Count > 0 && MessageBox.Show(this, Resources.BoardClearConfirmation, Resources.Bingo, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation) == DialogResult.No)
                return false;

            BingoBoard.ResetBoard();

            UpdateBoard();

            _display.ResetBoard();
            lNumber.Text = Resources.Ready;

            return true;
        }

        private void UpdateBoard()
        {
            pbMinimap.Image = _display.UpdateBoard();
            tsLNumSelected.Text = string.Format(Resources.NumbersSelected, BingoBoard.NumbersShowing.Count, BingoBoard.GameType.GetLegalCategories().Count * 15);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TryWebpage("https://github.com/parzivail/");
        }

        private void tutorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TryWebpage("https://github.com/parzivail/MicroBingo/blob/master/README.md#tutorial");
        }

        private void cbGameSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!TryReset())
                return;

            BingoBoard.GameType = GameTypes[cbGameSelector.SelectedIndex];

            UpdateBoard();
        }
    }
}
