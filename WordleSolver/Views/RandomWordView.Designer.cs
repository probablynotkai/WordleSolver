using System;
using System.Windows.Forms;
using System.Collections.Generic;
using WordleSolver;

namespace WordleSolver.Views
{
    partial class RandomWordView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RandomWordView));
            this.label1 = new System.Windows.Forms.Label();
            this.slotRow1 = new WordleSolver.Models.SlotRow();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(270, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 78);
            this.label1.TabIndex = 0;
            this.label1.Text = "Click regenerate until you\r\nfind a word that you want to\r\nstart with, then click " +
    "confirm.\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // slotRow1
            // 
            this.slotRow1.BackColor = System.Drawing.Color.Transparent;
            this.slotRow1.Location = new System.Drawing.Point(184, 217);
            this.slotRow1.Name = "slotRow1";
            this.slotRow1.Size = new System.Drawing.Size(459, 78);
            this.slotRow1.TabIndex = 1;
            Regenerate(true);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(275, 327);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Regenerate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Regenerate_BtnClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(456, 327);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 35);
            this.button2.TabIndex = 3;
            this.button2.Text = "Confirm";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(95, 63);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 35);
            this.button3.TabIndex = 4;
            this.button3.Text = "Back";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Back_BtnClick);
            // 
            // RandomWordView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 602);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.slotRow1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RandomWordView";
            this.Text = "Wordle Solver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Models.SlotRow slotRow1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;

        public void Back_BtnClick(object sender, MouseEventArgs args)
        {
            Program.SwitchView(new views.Menu());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Views.GameView view = new Views.GameView();
            view.SetRowValues(this.slotRow1.getCompleteWord());

            Program.SwitchView(view);
        }

        public void Regenerate_BtnClick(object sender, MouseEventArgs args)
        {
            Regenerate(false);
        }

        public void Regenerate(bool disable)
        {
            FileHandler reader = new FileHandler("words.txt");

            List<string> wordFile = reader.GetFileLines();

            Random random = new Random();
            int pos = random.Next(wordFile.Count);

            string randomWord = wordFile[pos];

            this.slotRow1.setWord(randomWord);

            if (disable)
            {
                this.slotRow1.DisableTyping();
                this.slotRow1.DisableRow();
            }
        }

        private Button button3;
    }
}