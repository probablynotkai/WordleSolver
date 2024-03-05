using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WordleSolver.Objects;

namespace WordleSolver.Models
{
    public partial class HistoryRow : UserControl
    {
        /*
         * Now that history is loaded from history.txt:
            - Create model for history row (464 x 53)
            - Pass HistoryItem data to row
            - Add row to Controls
            - Try to figure an effective pagination system
            (212 x 464)
            4 per page
         */
        public HistoryItem assignedItem;

        public HistoryRow()
        {
            InitializeComponent();
        }

        public HistoryRow(HistoryItem item)
        {
            InitializeComponent();
            this.assignedItem = item;
            this.RenderItem();
        }

        private void RenderItem()
        {
            this.label1.Text = this.assignedItem.GetWord() + " - " + this.assignedItem.GetAttempts();
            this.label2.Text = this.assignedItem.GetDateTime().ToString();
            this.UpdateSuccessIcon();
        }

        private void UpdateSuccessIcon()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativeDirectory = Path.Combine(currentDirectory, "..\\..\\Assets\\");

            Image stateRepresentation;

            if(this.assignedItem.IsGuessed())
            {
                stateRepresentation = new Bitmap(@Path.GetFullPath(relativeDirectory + "CONFIRM_BTN.png"));
            } else
            {
                stateRepresentation = new Bitmap(@Path.GetFullPath(relativeDirectory + "NEGATIVE_BTN.png"));
            }

            this.pictureBox1.BackgroundImage = stateRepresentation;
        }

        private void HistoryRow_Load(object sender, EventArgs e)
        {

        }
    }
}
