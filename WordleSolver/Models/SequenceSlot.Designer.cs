using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using WordleSolver;

namespace WordleSolver.Models
{
    partial class SequenceSlot
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private SlotState currentState = SlotState.DEFAULT;
        private SlotInput slotInput;
        private bool updateable = true;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected void Dispose(bool disposing)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SequenceSlot));
            this.slotInput = new WordleSolver.Models.SlotInput();
            this.SuspendLayout();
            // 
            // slotInput
            // 
            this.slotInput.BackColor = System.Drawing.Color.Transparent;
            this.slotInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.slotInput.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.slotInput.Font = new System.Drawing.Font("Arial", 32F, System.Drawing.FontStyle.Bold);
            this.slotInput.ForeColor = System.Drawing.Color.Transparent;
            this.slotInput.Location = new System.Drawing.Point(13, 3);
            this.slotInput.MaxLength = 1;
            this.slotInput.Name = "slotInput";
            this.slotInput.Size = new System.Drawing.Size(70, 50);
            this.slotInput.TabIndex = 0;
            this.slotInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SequenceSlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.slotInput);
            this.DoubleBuffered = true;
            this.Name = "SequenceSlot";
            this.Size = new System.Drawing.Size(70, 70);
            this.Load += new System.EventHandler(this.SequenceSlot_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SequenceSlot_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();
            
        }

        private void SequenceSlot_MouseClick(Object sender, MouseEventArgs e)
        {
            if(updateable)
            {
                callStateSwitch();
                updateStateRepresentation();
            }
        }

        #endregion
    }
}
