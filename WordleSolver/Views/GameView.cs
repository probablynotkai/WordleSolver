using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordleSolver.Models;

namespace WordleSolver.Views
{
    public partial class GameView : Form
    {
        public GameView()
        {
            InitializeComponent();
        }

        public GameView(SlotRow[] rows)
        {
            InitializeComponent();

            if(rows.Length > 6)
            {
                throw new Exception("You can't pass more than 6 rows due to the concept of the game.");
            }

            for(int i = 0; i < 6; i++)
            {
                try
                {
                    switch (i)
                    {
                        case 0:
                            this.slotRow1.CopyRowState(rows[i]);

                            if (this.slotRow1.getCompleteWord().Contains("%"))
                            {
                                DoCopy(ref this.slotRow1);
                                return;
                            } else
                            {
                                AddToValidator(ref this.slotRow1);
                            }
                            break;
                        case 1:
                            this.slotRow2.CopyRowState(rows[i]);

                            if (this.slotRow2.getCompleteWord().Contains("%"))
                            {
                                DoCopy(ref this.slotRow2);
                                return;
                            } else if(!this.slotRow2.getCompleteWord().Contains("%") && this.slotRow2.AreSlotsUnselected())
                            {
                                activeRow.EnableState();
                                return;
                            } else
                            {
                                AddToValidator(ref this.slotRow2);
                            }
                            break;
                        case 2:
                            this.slotRow3.CopyRowState(rows[i]);

                            if (this.slotRow3.getCompleteWord().Contains("%"))
                            {
                                DoCopy(ref this.slotRow3);
                                return;
                            }
                            else if (!this.slotRow3.getCompleteWord().Contains("%") && this.slotRow3.AreSlotsUnselected())
                            {
                                // Doesn't let you type or anything
                                activeRow.EnableState();
                                return;
                            }
                            else
                            {
                                AddToValidator(ref this.slotRow3);
                            }
                            break;
                        case 3:
                            this.slotRow4.CopyRowState(rows[i]);

                            if (this.slotRow4.getCompleteWord().Contains("%"))
                            {
                                DoCopy(ref this.slotRow4);
                                return;
                            }
                            else if (!this.slotRow4.getCompleteWord().Contains("%") && this.slotRow4.AreSlotsUnselected())
                            {
                                activeRow.EnableState();
                                return;
                            }
                            else
                            {
                                AddToValidator(ref this.slotRow4);
                            }
                            break;
                        case 4:
                            this.slotRow5.CopyRowState(rows[i]);

                            if (this.slotRow5.getCompleteWord().Contains("%"))
                            {
                                DoCopy(ref this.slotRow5);
                                return;
                            }
                            else if (!this.slotRow5.getCompleteWord().Contains("%") && this.slotRow5.AreSlotsUnselected())
                            {
                                activeRow.EnableState();
                                return;
                            }
                            else
                            {
                                AddToValidator(ref this.slotRow5);
                            }
                            break;
                        case 5:
                            this.slotRow6.CopyRowState(rows[i]);

                            if (this.slotRow6.getCompleteWord().Contains("%"))
                            {
                                DoCopy(ref this.slotRow6);
                                return;
                            }
                            else if (!this.slotRow6.getCompleteWord().Contains("%") && this.slotRow6.AreSlotsUnselected())
                            {
                                activeRow.EnableState();
                                return;
                            }
                            else
                            {
                                AddToValidator(ref this.slotRow6);
                            }
                            break;
                    }
                } catch(Exception ignored) { }

            }
        }

        private void AddToValidator(ref SlotRow row)
        {
            this.activeRow = row;

            if (row.getCompleteWord().Contains("%") || row.AreSlotsUnselected())
            {
                return;
            }

            if (row.IsWordCorrect())
            {
                this.EndGameLoop();
                return;
            }

            string[] correctLetters = row.GetCorrectLetterPositions();
            for (int i = 0; i < correctLetters.Length; i++)
            {
                if (correctLetters[i] == "%") continue;

                validator.InsertCorrectLetter(correctLetters[i].ToCharArray()[0], i);
            }

            List<char> DuplicatedPossibilities = new List<char>();

            char[] rowPossibleLetters = new char[row.GetPossibleLettersWithIndex().Keys.Count];
            row.GetPossibleLettersWithIndex().Keys.CopyTo(rowPossibleLetters, 0);

            char[] charArr = new char[validator.GetPossibleLetters().Keys.Count];
            validator.GetPossibleLetters().Keys.CopyTo(charArr, 0);
            List<char> PossibleLetters = new List<char>(charArr);

            for (int i = 0; i < rowPossibleLetters.Length; i++)
            {
                int index = row.GetPossibleLettersWithIndex()[rowPossibleLetters[i]];

                if (PossibleLetters.Contains(rowPossibleLetters[i]))
                {
                    // This statement is for if a letter has already been added to the PossibleLetters list
                    if (DuplicatedPossibilities.Contains(rowPossibleLetters[i]))
                    {
                        // This is run if there's 2 occurences of a letter
                        validator.InsertPossibleLetter(rowPossibleLetters[i], index);
                    }
                    else
                    {
                        // This is run if there is 1 occurence of a letter
                        DuplicatedPossibilities.Add(rowPossibleLetters[i]);

                        // if the index of the letter, doesn't match what is stored in the PossibleLetters value list
                        // then add the index, else, break
                        List<int> indexes = validator.GetPossibleLetters()[rowPossibleLetters[i]];

                        if (!indexes.Contains(index))
                        {
                            validator.InsertPossibleLetter(rowPossibleLetters[i], index);
                        }
                    }
                }
                else
                {
                    validator.InsertPossibleLetter(rowPossibleLetters[i], index);
                }
            }


            List<char> DuplicatedExclusions = new List<char>();
            foreach (char c in row.GetExcludedLetters())
            {
                if (validator.GetExcludedLetters().Contains(c))
                {
                    if (DuplicatedExclusions.Contains(c))
                    {
                        validator.InsertExcludedLetter(c);
                    }
                    else
                    {
                        DuplicatedExclusions.Add(c);
                    }
                }
                else
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
            }
            catch (Exception)
            {
                this.label1.Text = "No suggested word to match.";
                wordFound = false;
            }

            if (wordFound)
            {
                row.DisableRow();

                switch (activeRow.Name)
                {
                    case "slotRow1":
                        this.activeRow = slotRow2;
                        this.UpdateActionRowYLocation(189);
                        break;
                    case "slotRow2":
                        this.activeRow = slotRow3;
                        this.UpdateActionRowYLocation(269);
                        break;
                    case "slotRow3":
                        this.activeRow = slotRow4;
                        this.UpdateActionRowYLocation(349);
                        break;
                    case "slotRow4":
                        this.activeRow = slotRow5;
                        this.UpdateActionRowYLocation(429);
                        break;
                    case "slotRow5":
                        this.activeRow = slotRow6;
                        this.UpdateActionRowYLocation(509);
                        break;
                    case "slotRow6":
                        this.EndGameLoop();
                        return;
                }


                activeRow.setWord(suggestedWord);
            }
            else
            {
                this.EndGameLoop();
            }
        }

        private void DoCopy(ref SlotRow row)
        {
            this.activeRow = row;
            row.EnableRow();
            ApplyChanges();
        }

        public void ApplyChanges()
        {
            switch (activeRow.Name)
            {
                case "slotRow2":
                    this.UpdateActionRowYLocation(189);
                    break;
                case "slotRow3":
                    this.UpdateActionRowYLocation(269);
                    break;
                case "slotRow4":
                    this.UpdateActionRowYLocation(349);
                    break;
                case "slotRow5":
                    this.UpdateActionRowYLocation(429);
                    break;
                case "slotRow6":
                    this.UpdateActionRowYLocation(509);
                    return;
            }
        }

        private void GameView_Load(object sender, EventArgs e)
        {

        }
    }
}
