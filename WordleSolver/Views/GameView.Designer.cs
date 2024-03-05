using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WordleSolver.Models;

namespace WordleSolver.Views
{
    partial class GameView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public SlotRow activeRow;
        public SlotRow slotRow2;
        public SlotRow slotRow3;
        public SlotRow slotRow4;
        public SlotRow slotRow5;
        public SlotRow slotRow1;
        public SlotRow slotRow6;

        private WordleValidator validator = new WordleValidator();
        private HistoryHandler handler = new HistoryHandler();
        public int currentAttempt = 1;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameView));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.slotRow4 = new WordleSolver.Models.SlotRow();
            this.slotRow3 = new WordleSolver.Models.SlotRow();
            this.slotRow2 = new WordleSolver.Models.SlotRow();
            this.slotRow1 = new WordleSolver.Models.SlotRow();
            this.slotRow5 = new WordleSolver.Models.SlotRow();
            this.slotRow6 = new WordleSolver.Models.SlotRow();
            this.activeRow = this.slotRow1;
            this.slotRow2.DisableRow();
            this.slotRow3.DisableRow();
            this.slotRow4.DisableRow();
            this.slotRow5.DisableRow();
            this.slotRow6.DisableRow();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(222, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(383, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Update below to look like your Wordle \r\ngame and click the green tick";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(96, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Btn_HomePage);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(719, 109);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Confirm_BtnClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(663, 109);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 40);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GenerateNewWord);
            // 
            // slotRow4
            // 
            this.slotRow4.BackColor = System.Drawing.Color.Transparent;
            this.slotRow4.Location = new System.Drawing.Point(182, 339);
            this.slotRow4.Name = "slotRow4";
            this.slotRow4.Size = new System.Drawing.Size(458, 77);
            this.slotRow4.TabIndex = 7;
            // 
            // slotRow3
            // 
            this.slotRow3.BackColor = System.Drawing.Color.Transparent;
            this.slotRow3.Location = new System.Drawing.Point(182, 256);
            this.slotRow3.Name = "slotRow3";
            this.slotRow3.Size = new System.Drawing.Size(458, 77);
            this.slotRow3.TabIndex = 6;
            // 
            // slotRow2
            // 
            this.slotRow2.BackColor = System.Drawing.Color.Transparent;
            this.slotRow2.Location = new System.Drawing.Point(182, 173);
            this.slotRow2.Name = "slotRow2";
            this.slotRow2.Size = new System.Drawing.Size(458, 77);
            this.slotRow2.TabIndex = 5;
            // 
            // slotRow1
            // 
            this.slotRow1.BackColor = System.Drawing.Color.Transparent;
            this.slotRow1.Location = new System.Drawing.Point(182, 90);
            this.slotRow1.Name = "slotRow1";
            this.slotRow1.Size = new System.Drawing.Size(458, 77);
            this.slotRow1.TabIndex = 2;
            // 
            // slotRow5
            // 
            this.slotRow5.BackColor = System.Drawing.Color.Transparent;
            this.slotRow5.Location = new System.Drawing.Point(182, 422);
            this.slotRow5.Name = "slotRow5";
            this.slotRow5.Size = new System.Drawing.Size(458, 77);
            this.slotRow5.TabIndex = 8;
            // 
            // slotRow6
            // 
            this.slotRow6.BackColor = System.Drawing.Color.Transparent;
            this.slotRow6.Location = new System.Drawing.Point(182, 505);
            this.slotRow6.Name = "slotRow6";
            this.slotRow6.Size = new System.Drawing.Size(458, 77);
            this.slotRow6.TabIndex = 9;
            // 
            // GameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 602);
            this.Controls.Add(this.slotRow6);
            this.Controls.Add(this.slotRow5);
            this.Controls.Add(this.slotRow4);
            this.Controls.Add(this.slotRow3);
            this.Controls.Add(this.slotRow2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.slotRow1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameView";
            this.Text = "Wordle Solver";
            this.Load += new System.EventHandler(this.GameView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
            
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;

        public void Confirm_BtnClick(object sender, MouseEventArgs args)
        {
            if(this.activeRow.getCompleteWord().Contains("%") || this.activeRow.AreSlotsUnselected())
            {
                return;
            }

            if(this.activeRow.IsWordCorrect())
            {
                this.EndGameLoop();
                return;
            }

            string[] correctLetters = this.activeRow.GetCorrectLetterPositions();
            for(int i = 0; i < correctLetters.Length; i++)
            {
                if (correctLetters[i] == "%") continue;

                validator.InsertCorrectLetter(correctLetters[i].ToCharArray()[0], i);
            }

            List<char> DuplicatedPossibilities = new List<char>();

            char[] rowPossibleLetters = new char[this.activeRow.GetPossibleLettersWithIndex().Keys.Count];
            this.activeRow.GetPossibleLettersWithIndex().Keys.CopyTo(rowPossibleLetters, 0);

            char[] charArr = new char[validator.GetPossibleLetters().Keys.Count];
            validator.GetPossibleLetters().Keys.CopyTo(charArr, 0);
            List<char> PossibleLetters = new List<char>(charArr);

            for (int i = 0; i < rowPossibleLetters.Length; i++)
            {
                int index = this.activeRow.GetPossibleLettersWithIndex()[rowPossibleLetters[i]];

                if (PossibleLetters.Contains(rowPossibleLetters[i]))
                {
                    // This statement is for if a letter has already been added to the PossibleLetters list
                    if(DuplicatedPossibilities.Contains(rowPossibleLetters[i]))
                    {
                        // This is run if there's 2 occurences of a letter
                        validator.InsertPossibleLetter(rowPossibleLetters[i], index);
                    } else
                    {
                        // This is run if there is 1 occurence of a letter
                        DuplicatedPossibilities.Add(rowPossibleLetters[i]);

                        // if the index of the letter, doesn't match what is stored in the PossibleLetters value list
                        // then add the index, else, break
                        List<int> indexes = validator.GetPossibleLetters()[rowPossibleLetters[i]];

                        if(!indexes.Contains(index))
                        {
                            validator.InsertPossibleLetter(rowPossibleLetters[i], index);
                        }
                    }
                } else
                {
                    validator.InsertPossibleLetter(rowPossibleLetters[i], index);
                }
            }


            List<char> DuplicatedExclusions = new List<char>();
            foreach (char c in this.activeRow.GetExcludedLetters())
            {
                if(validator.GetExcludedLetters().Contains(c))
                {
                    if(DuplicatedExclusions.Contains(c))
                    {
                        validator.InsertExcludedLetter(c);
                    } else
                    {
                        DuplicatedExclusions.Add(c);
                    }
                } else
                {
                    validator.InsertExcludedLetter(c);
                }
            }

            string suggestedWord = "";
            bool wordFound = true;

            try
            {
                suggestedWord = validator.SuggestNextWord();
                this.label1.Text = "Suggested word: " + suggestedWord;
            } catch(Exception e)
            {
                this.label1.Text = "No suggested word to match.";
                wordFound = false;
            }

            if(wordFound)
            {
                this.activeRow.DisableRow();

                switch (activeRow.Name)
                {
                    case "slotRow1":
                        this.activeRow = slotRow2;
                        currentAttempt = 2;
                        this.UpdateActionRowYLocation(189);
                        break;
                    case "slotRow2":
                        this.activeRow = slotRow3;
                        currentAttempt = 3;
                        this.UpdateActionRowYLocation(269);
                        break;
                    case "slotRow3":
                        this.activeRow = slotRow4;
                        currentAttempt = 4;
                        this.UpdateActionRowYLocation(349);
                        break;
                    case "slotRow4":
                        this.activeRow = slotRow5;
                        currentAttempt = 5;
                        this.UpdateActionRowYLocation(429);
                        break;
                    case "slotRow5":
                        this.activeRow = slotRow6;
                        currentAttempt = 6;
                        this.UpdateActionRowYLocation(509);
                        break;
                    case "slotRow6":
                        this.EndGameLoop();
                        return;
                }

                this.activeRow.EnableRow();

                this.activeRow.setWord(suggestedWord);
            } else
            {
                this.EndGameLoop();
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

            handler.AddToHistory(this.activeRow.getCompleteWord(), this.activeRow.IsWordCorrect(), currentAttempt);

            if (this.activeRow.IsWordCorrect())
            {
                Program.SwitchView(new Views.CorrectView());
            } else
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
    }
}