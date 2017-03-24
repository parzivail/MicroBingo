namespace Bingo
{
    partial class FormBingoController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBingoController));
            this.gbGame = new System.Windows.Forms.GroupBox();
            this.lNumber = new Bingo.SmoothLabel();
            this.bPickNumber = new System.Windows.Forms.Button();
            this.bNewGame = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsDdbHelp = new System.Windows.Forms.ToolStripDropDownButton();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tutorialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbMinimap = new System.Windows.Forms.PictureBox();
            this.gbGame.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimap)).BeginInit();
            this.SuspendLayout();
            // 
            // gbGame
            // 
            this.gbGame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGame.Controls.Add(this.lNumber);
            this.gbGame.Controls.Add(this.bPickNumber);
            this.gbGame.Location = new System.Drawing.Point(12, 12);
            this.gbGame.Name = "gbGame";
            this.gbGame.Size = new System.Drawing.Size(480, 134);
            this.gbGame.TabIndex = 0;
            this.gbGame.TabStop = false;
            this.gbGame.Text = "Game";
            // 
            // lNumber
            // 
            this.lNumber.AutoSize = true;
            this.lNumber.Font = new System.Drawing.Font("Consolas", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNumber.Location = new System.Drawing.Point(162, 15);
            this.lNumber.Name = "lNumber";
            this.lNumber.Size = new System.Drawing.Size(100, 112);
            this.lNumber.TabIndex = 1;
            this.lNumber.Text = "0";
            this.lNumber.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lNumber.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            // 
            // bPickNumber
            // 
            this.bPickNumber.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPickNumber.Location = new System.Drawing.Point(6, 19);
            this.bPickNumber.Name = "bPickNumber";
            this.bPickNumber.Size = new System.Drawing.Size(150, 108);
            this.bPickNumber.TabIndex = 0;
            this.bPickNumber.Text = "Pick Number";
            this.bPickNumber.UseVisualStyleBackColor = true;
            this.bPickNumber.Click += new System.EventHandler(this.bPickNumber_Click);
            // 
            // bNewGame
            // 
            this.bNewGame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bNewGame.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bNewGame.Location = new System.Drawing.Point(12, 152);
            this.bNewGame.Name = "bNewGame";
            this.bNewGame.Size = new System.Drawing.Size(480, 44);
            this.bNewGame.TabIndex = 0;
            this.bNewGame.Text = "Reset Board";
            this.bNewGame.UseVisualStyleBackColor = true;
            this.bNewGame.Click += new System.EventHandler(this.bNewGame_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsDdbHelp});
            this.statusStrip1.Location = new System.Drawing.Point(0, 395);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(504, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsDdbHelp
            // 
            this.tsDdbHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsDdbHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tutorialToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.tsDdbHelp.Image = ((System.Drawing.Image)(resources.GetObject("tsDdbHelp.Image")));
            this.tsDdbHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDdbHelp.Name = "tsDdbHelp";
            this.tsDdbHelp.Size = new System.Drawing.Size(45, 20);
            this.tsDdbHelp.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tutorialToolStripMenuItem
            // 
            this.tutorialToolStripMenuItem.Name = "tutorialToolStripMenuItem";
            this.tutorialToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tutorialToolStripMenuItem.Text = "Tutorial";
            this.tutorialToolStripMenuItem.Click += new System.EventHandler(this.tutorialToolStripMenuItem_Click);
            // 
            // pbMinimap
            // 
            this.pbMinimap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMinimap.Location = new System.Drawing.Point(12, 202);
            this.pbMinimap.Name = "pbMinimap";
            this.pbMinimap.Size = new System.Drawing.Size(480, 183);
            this.pbMinimap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMinimap.TabIndex = 3;
            this.pbMinimap.TabStop = false;
            // 
            // FormBingoController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 417);
            this.Controls.Add(this.pbMinimap);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.bNewGame);
            this.Controls.Add(this.gbGame);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBingoController";
            this.Text = "Bingo Controller";
            this.gbGame.ResumeLayout(false);
            this.gbGame.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbGame;
        private System.Windows.Forms.Button bNewGame;
        private Bingo.SmoothLabel lNumber;
        private System.Windows.Forms.Button bPickNumber;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripDropDownButton tsDdbHelp;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tutorialToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbMinimap;
    }
}