using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordleSolver.Models
{
    class SlotInput : TextBox
    {
        public Label val;

        public SlotInput()
        {
            InitializeComponent();
            LoadLabel();
        }

        private void LoadLabel()
        {
            val.Font = new System.Drawing.Font("Helvetica", 28.0f, System.Drawing.FontStyle.Bold);
            val.ForeColor = System.Drawing.Color.Black;
            val.SetBounds(0, 0, 44, 40);
            val.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            val.BackColor = System.Drawing.Color.Transparent;
            val.ForeColor = System.Drawing.Color.Black;
            val.Visible = false;

            val.Click += new EventHandler(Label_HandleClick);
        }

        private void InitializeComponent()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor |
                            ControlStyles.OptimizedDoubleBuffer |
                            ControlStyles.UserPaint, true);
            this.BackColor = System.Drawing.Color.Transparent;
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Font = new System.Drawing.Font("Helvetica", 32.0f, System.Drawing.FontStyle.Bold);
            this.CharacterCasing = CharacterCasing.Upper;
            this.TextAlign = HorizontalAlignment.Center;
            this.MaxLength = 1;
            this.Width = 40;
            this.Height = 40;
            this.BorderStyle = BorderStyle.None;
            this.SetBounds(16, 6, 70, 70);

            this.val = new Label();
            this.Controls.Add(val);

            this.MouseLeave += new EventHandler(SlotInput_MouseLeave);
            this.TextChanged += new EventHandler(SlotInput_MouseLeave);
        }

        public string getLabelValue()
        {
            return val.Text;
        }

        public void HideInput()
        {
            this.ReadOnly = true;
            val.Visible = true;
            val.ForeColor = System.Drawing.Color.Black;
        }

        public void ShowInput()
        {
            this.ReadOnly = false;
            val.Visible = false;
            val.ForeColor = System.Drawing.Color.Transparent;
        }

        public void setLabelValue(string value)
        {
            val.Text = value;
            val.Visible = true;
            val.ForeColor = System.Drawing.Color.Black;
        }

        public void Label_HandleClick(object sender, EventArgs e)
        {
            if(!this.ReadOnly)
            {
                val.Text = "";
                this.Focus();
            }
        }


        public void SlotInput_MouseLeave(object sender, EventArgs e)
        {
            if(Text.Length > 0)
            {
                this.SetStyle(ControlStyles.UserPaint, false);

                this.BackColor = System.Drawing.Color.Transparent;
                this.ForeColor = System.Drawing.Color.Transparent;

                val.Visible = true;
                val.Text = this.Text;
                val.ForeColor = System.Drawing.Color.Black;

                this.Text = "";

            } else
            {
                this.SetStyle(ControlStyles.SupportsTransparentBackColor |
                    ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.ResizeRedraw |
                    ControlStyles.UserPaint, true);

                this.BackColor = System.Drawing.Color.Transparent;
                this.ForeColor = System.Drawing.Color.Transparent;
            }
        }
    }
}
