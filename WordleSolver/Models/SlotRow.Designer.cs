using System;
using System.Collections.Generic;

namespace WordleSolver.Models
{
    partial class SlotRow
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private List<SequenceSlot> slots = new List<SequenceSlot>();

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SlotRow));
            this.sequenceSlot1 = new WordleSolver.Models.SequenceSlot();
            this.sequenceSlot2 = new WordleSolver.Models.SequenceSlot();
            this.sequenceSlot3 = new WordleSolver.Models.SequenceSlot();
            this.sequenceSlot4 = new WordleSolver.Models.SequenceSlot();
            this.sequenceSlot5 = new WordleSolver.Models.SequenceSlot();
            this.slots.Add(this.sequenceSlot1);
            this.slots.Add(this.sequenceSlot2);
            this.slots.Add(this.sequenceSlot3);
            this.slots.Add(this.sequenceSlot4);
            this.slots.Add(this.sequenceSlot5);
            this.SuspendLayout();
            // 
            // sequenceSlot1
            // 
            this.sequenceSlot1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sequenceSlot1.BackgroundImage")));
            this.sequenceSlot1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sequenceSlot1.Location = new System.Drawing.Point(4, 3);
            this.sequenceSlot1.Name = "sequenceSlot1";
            this.sequenceSlot1.Size = new System.Drawing.Size(70, 70);
            this.sequenceSlot1.TabIndex = 0;
            // 
            // sequenceSlot2
            // 
            this.sequenceSlot2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sequenceSlot2.BackgroundImage")));
            this.sequenceSlot2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sequenceSlot2.Location = new System.Drawing.Point(102, 3);
            this.sequenceSlot2.Name = "sequenceSlot2";
            this.sequenceSlot2.Size = new System.Drawing.Size(70, 70);
            this.sequenceSlot2.TabIndex = 1;
            // 
            // sequenceSlot3
            // 
            this.sequenceSlot3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sequenceSlot3.BackgroundImage")));
            this.sequenceSlot3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sequenceSlot3.Location = new System.Drawing.Point(196, 3);
            this.sequenceSlot3.Name = "sequenceSlot3";
            this.sequenceSlot3.Size = new System.Drawing.Size(70, 70);
            this.sequenceSlot3.TabIndex = 2;
            // 
            // sequenceSlot4
            // 
            this.sequenceSlot4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sequenceSlot4.BackgroundImage")));
            this.sequenceSlot4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sequenceSlot4.Location = new System.Drawing.Point(291, 3);
            this.sequenceSlot4.Name = "sequenceSlot4";
            this.sequenceSlot4.Size = new System.Drawing.Size(70, 70);
            this.sequenceSlot4.TabIndex = 3;
            // 
            // sequenceSlot5
            // 
            this.sequenceSlot5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sequenceSlot5.BackgroundImage")));
            this.sequenceSlot5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sequenceSlot5.Location = new System.Drawing.Point(384, 3);
            this.sequenceSlot5.Name = "sequenceSlot5";
            this.sequenceSlot5.Size = new System.Drawing.Size(70, 70);
            this.sequenceSlot5.TabIndex = 4;
            // 
            // SlotRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.sequenceSlot5);
            this.Controls.Add(this.sequenceSlot4);
            this.Controls.Add(this.sequenceSlot3);
            this.Controls.Add(this.sequenceSlot2);
            this.Controls.Add(this.sequenceSlot1);
            this.Name = "SlotRow";
            this.Size = new System.Drawing.Size(458, 77);
            this.Load += new System.EventHandler(this.SlotRow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SequenceSlot sequenceSlot1;
        private SequenceSlot sequenceSlot2;
        private SequenceSlot sequenceSlot3;
        private SequenceSlot sequenceSlot4;
        private SequenceSlot sequenceSlot5;

        public string getCompleteWord()
        {
            string word = "";

            word += this.sequenceSlot1.getValue();
            word += this.sequenceSlot2.getValue();
            word += this.sequenceSlot3.getValue();
            word += this.sequenceSlot4.getValue();
            word += this.sequenceSlot5.getValue();

            return word;
        }

        public Dictionary<char, int> GetPossibleLettersWithIndex()
        {
            // duplicate possible letters will break this, use EXCEL with both Es as CLWP
            Dictionary<char, int> pairs = new Dictionary<char, int>();
            SequenceSlot[] slotArr = this.slots.ToArray();

            for(int i = 0; i < slotArr.Length; i++)
            {
                if(slotArr[i].getStateEnum().Equals(SlotState.CLWP))
                {
                    pairs.Add(slotArr[i].getValue().ToCharArray()[0], i);
                }
            }

            return pairs;
        }

        public bool AreSlotsUnselected()
        {
            return this.sequenceSlot1.getStateEnum().Equals(SlotState.DEFAULT) || this.sequenceSlot2.getStateEnum().Equals(SlotState.DEFAULT) || this.sequenceSlot3.getStateEnum().Equals(SlotState.DEFAULT) || this.sequenceSlot4.getStateEnum().Equals(SlotState.DEFAULT) || this.sequenceSlot5.getStateEnum().Equals(SlotState.DEFAULT);
        }

        public bool IsWordCorrect()
        {
            return this.sequenceSlot1.getStateEnum().Equals(SlotState.CLCP) && this.sequenceSlot2.getStateEnum().Equals(SlotState.CLCP) && this.sequenceSlot3.getStateEnum().Equals(SlotState.CLCP) && this.sequenceSlot4.getStateEnum().Equals(SlotState.CLCP) && this.sequenceSlot5.getStateEnum().Equals(SlotState.CLCP);
        }

        public string[] GetCorrectLetterPositions()
        {
            string[] letters = new string[5] { "%", "%", "%", "%", "%" };

            if (this.sequenceSlot1.getStateEnum().Equals(SlotState.CLCP)) letters[0] = this.sequenceSlot1.getValue();
            if (this.sequenceSlot2.getStateEnum().Equals(SlotState.CLCP)) letters[1] = this.sequenceSlot2.getValue();
            if (this.sequenceSlot3.getStateEnum().Equals(SlotState.CLCP)) letters[2] = this.sequenceSlot3.getValue();
            if (this.sequenceSlot4.getStateEnum().Equals(SlotState.CLCP)) letters[3] = this.sequenceSlot4.getValue();
            if (this.sequenceSlot5.getStateEnum().Equals(SlotState.CLCP)) letters[4] = this.sequenceSlot5.getValue();

            return letters;
        }

        public void CopyRowState(SlotRow row)
        {
            for(int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 0:
                        // shit wont copy accross
                        ApplyChanges(row.sequenceSlot1, sequenceSlot1);
                        break;
                    case 1:
                        ApplyChanges(row.sequenceSlot2, sequenceSlot2);
                        break;
                    case 2:
                        ApplyChanges(row.sequenceSlot3, sequenceSlot3);
                        break;
                    case 3:
                        ApplyChanges(row.sequenceSlot4, sequenceSlot4);
                        break;
                    case 4:
                        ApplyChanges(row.sequenceSlot5, sequenceSlot5);
                        break;
                }
            }
        }

        private void ApplyChanges(SequenceSlot s, SequenceSlot s2)
        {
            if(s.getValue() != "%")
            {
                s2.setValue(s.getValue());
                s2.setState(s.getStateEnum());
                s2.disableStateRepresentation();
            } else
            {
                s2.disableStateRepresentation();
            }
        }

        public List<char> GetPossibleLetters()
        {
            List<char> letters = new List<char>();

            foreach (SequenceSlot slot in this.slots)
            {
                if (slot.getStateEnum().Equals(SlotState.CLWP))
                {
                    letters.Add(slot.getValue().ToCharArray()[0]);
                }
            }

            return letters;
        }

        public List<char> GetExcludedLetters()
        {
            List<char> letters = new List<char>();

            foreach (SequenceSlot slot in this.slots)
            {
                if(slot.getStateEnum().Equals(SlotState.WLWP))
                {
                    letters.Add(slot.getValue().ToCharArray()[0]);
                }
            }

            return letters;
        }

        public void DisableRow()
        {
            foreach (SequenceSlot slot in this.slots)
            {
                slot.disableStateRepresentation();
            }
        }

        public void EnableRow()
        {
            foreach(SequenceSlot slot in this.slots)
            {
                slot.updateStateRepresentation();
                slot.EnableTyping();
            }
        }

        public void EnableState()
        {
            foreach(SequenceSlot slot in this.slots)
            {
                slot.updateStateRepresentation();
            }
        }

        public void setWord(string word)
        {
            if(word.Length != 5)
            {
                throw new System.Exception("Word length is not equal to 5.");
            }

            char[] letters = word.ToCharArray();

            this.sequenceSlot1.setValue(letters[0].ToString());
            this.sequenceSlot2.setValue(letters[1].ToString());
            this.sequenceSlot3.setValue(letters[2].ToString());
            this.sequenceSlot4.setValue(letters[3].ToString());
            this.sequenceSlot5.setValue(letters[4].ToString());
        }

        public void DisableTyping()
        {
            this.sequenceSlot1.DisableTyping();
            this.sequenceSlot2.DisableTyping();
            this.sequenceSlot3.DisableTyping();
            this.sequenceSlot4.DisableTyping();
            this.sequenceSlot5.DisableTyping();
        }
    }
}
