using System;
using System.Collections;
using System.Collections.Generic;
using WordleSolver.Models;
using WordleSolver.Views;
using System.Windows.Forms;

namespace WordleSolver.Views
{
    partial class PartialGameView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public SlotRow activeRow;
        private WordleValidator validator = new WordleValidator();
        private int currentAttempts = 1;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PartialGameView));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.slotRow1 = new WordleSolver.Models.SlotRow();
            this.slotRow2 = new WordleSolver.Models.SlotRow();
            this.slotRow3 = new WordleSolver.Models.SlotRow();
            this.slotRow4 = new WordleSolver.Models.SlotRow();
            this.slotRow5 = new WordleSolver.Models.SlotRow();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.slotRow6 = new WordleSolver.Models.SlotRow();

            this.slotRow1.EnableRow();
            this.activeRow = slotRow1;
            this.slotRow2.DisableRow();
            this.slotRow3.DisableRow();
            this.slotRow4.DisableRow();
            this.slotRow5.DisableRow();
            this.slotRow6.DisableRow();

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(146, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(501, 78);
            this.label1.TabIndex = 0;
            this.label1.Text = "Replicate the Wordle screen by clicking the orange\r\n button to continue, click th" +
    "e tick once completed \r\nto suggest the next word.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Back";
            this.button1.MouseClick += new MouseEventHandler(Btn_HomePage);
            this.button1.UseVisualStyleBackColor = true;
            // 
            // slotRow1
            // 
            this.slotRow1.BackColor = System.Drawing.Color.Transparent;
            this.slotRow1.Location = new System.Drawing.Point(168, 98);
            this.slotRow1.Name = "slotRow1";
            this.slotRow1.Size = new System.Drawing.Size(458, 77);
            this.slotRow1.TabIndex = 2;
            // 
            // slotRow2
            // 
            this.slotRow2.BackColor = System.Drawing.Color.Transparent;
            this.slotRow2.Location = new System.Drawing.Point(168, 181);
            this.slotRow2.Name = "slotRow2";
            this.slotRow2.Size = new System.Drawing.Size(458, 77);
            this.slotRow2.TabIndex = 3;
            // 
            // slotRow3
            // 
            this.slotRow3.BackColor = System.Drawing.Color.Transparent;
            this.slotRow3.Location = new System.Drawing.Point(168, 264);
            this.slotRow3.Name = "slotRow3";
            this.slotRow3.Size = new System.Drawing.Size(458, 77);
            this.slotRow3.TabIndex = 4;
            // 
            // slotRow4
            // 
            this.slotRow4.BackColor = System.Drawing.Color.Transparent;
            this.slotRow4.Location = new System.Drawing.Point(168, 347);
            this.slotRow4.Name = "slotRow4";
            this.slotRow4.Size = new System.Drawing.Size(458, 77);
            this.slotRow4.TabIndex = 5;
            // 
            // slotRow5
            // 
            this.slotRow5.BackColor = System.Drawing.Color.Transparent;
            this.slotRow5.Location = new System.Drawing.Point(168, 430);
            this.slotRow5.Name = "slotRow5";
            this.slotRow5.Size = new System.Drawing.Size(458, 77);
            this.slotRow5.TabIndex = 6;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(650, 117);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 40);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseClick += new MouseEventHandler(this.Continue_BtnClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(706, 117);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new MouseEventHandler(this.Confirm_BtnClick);
            // 
            // slotRow6
            // 
            this.slotRow6.BackColor = System.Drawing.Color.Transparent;
            this.slotRow6.Location = new System.Drawing.Point(168, 513);
            this.slotRow6.Name = "slotRow6";
            this.slotRow6.Size = new System.Drawing.Size(458, 77);
            this.slotRow6.TabIndex = 9;
            // 
            // PartialGameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 602);
            this.Controls.Add(this.slotRow6);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.slotRow5);
            this.Controls.Add(this.slotRow4);
            this.Controls.Add(this.slotRow3);
            this.Controls.Add(this.slotRow2);
            this.Controls.Add(this.slotRow1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PartialGameView";
            this.Text = "Wordle Solver";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public void Continue_BtnClick(object sender, MouseEventArgs args)
        {
            if (this.activeRow.getCompleteWord().Contains("%") || this.activeRow.AreSlotsUnselected()) return;

            this.activeRow.DisableRow();

            switch (activeRow.Name)
            {
                case "slotRow1":
                    this.activeRow = slotRow2;
                    this.currentAttempts = 2;
                    this.UpdateActionRowYLocation(189);
                    break;
                case "slotRow2":
                    this.activeRow = slotRow3;
                    this.currentAttempts = 3;
                    this.UpdateActionRowYLocation(269);
                    break;
                case "slotRow3":
                    this.activeRow = slotRow4;
                    this.currentAttempts = 4;
                    this.UpdateActionRowYLocation(349);
                    break;
                case "slotRow4":
                    this.activeRow = slotRow5;
                    this.currentAttempts = 5;
                    this.UpdateActionRowYLocation(429);
                    break;
                case "slotRow5":
                    this.activeRow = slotRow6;
                    this.currentAttempts = 6;
                    this.UpdateActionRowYLocation(509);
                    break;
                case "slotRow6":
                    this.EndGameLoop();
                    return;
            }

            this.activeRow.EnableRow();
        }

        public void Confirm_BtnClick(object sender, MouseEventArgs args)
        {
            if(!this.activeRow.getCompleteWord().Contains("%"))
            {
                SlotRow[] rows = new SlotRow[6] { this.slotRow1, this.slotRow2, this.slotRow3, this.slotRow4, this.slotRow5, this.slotRow6 };

                foreach(SlotRow row in rows)
                {
                    if(!row.getCompleteWord().Contains("%"))
                    {
                        if(row.AreSlotsUnselected())
                        {
                            return;
                        }
                    }
                }

                GameView view = new GameView(rows);
                view.currentAttempt = this.currentAttempts;

                // Weird behaviours when confirming

                Program.SwitchView(view);
            }
        }

        public void GenerateNewWord(object sender, EventArgs args)
        {
            string suggestedWord = "";
            bool wordFound = true;

            try
            {
                suggestedWord = validator.SuggestRandomWord();
                this.label1.Text = "Suggested word: " + suggestedWord;
                this.activeRow.setWord(suggestedWord);
            }
            catch (Exception e)
            {
                this.label1.Text = "No suggested word to match.";
                wordFound = false;
            }
        }

        private void EndGameLoop()
        {
            this.activeRow.DisableRow();
            this.HideActionRow();

            if (this.activeRow.IsWordCorrect())
            {
                Program.SwitchView(new Views.CorrectView());
            }
            else
            {
                Program.SwitchView(new Views.FailureView());
            }
        }

        private void Btn_HomePage(object sender, EventArgs args)
        {
            Program.SwitchView(new views.Menu());
        }

        private void UpdateActionRowYLocation(int y)
        {
            this.pictureBox1.Bounds = new System.Drawing.Rectangle(pictureBox1.Bounds.X, y, pictureBox1.Width, pictureBox1.Height);
            this.pictureBox2.Bounds = new System.Drawing.Rectangle(pictureBox2.Bounds.X, y, pictureBox2.Width, pictureBox2.Height);
        }

        private void HideActionRow()
        {
            this.pictureBox1.Hide();
            this.pictureBox2.Hide();
        }

        public void SetRowValues(string word)
        {
            this.slotRow1.setWord(word);
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private Models.SlotRow slotRow1;
        private Models.SlotRow slotRow2;
        private Models.SlotRow slotRow3;
        private Models.SlotRow slotRow4;
        private Models.SlotRow slotRow5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private SlotRow slotRow6;
    }
}