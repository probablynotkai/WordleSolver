using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordleSolver.Objects;

namespace WordleSolver.Models
{
    public partial class HistoryPaginator : UserControl
    {
        public List<HistoryItem> historyItems = new List<HistoryItem>();
        public List<Control> currentItems = new List<Control>();
        public int pageSize = 5;
        public int pageIndex = 0; 

        public HistoryPaginator()
        {
            InitializeComponent();
        }

        public HistoryPaginator(List<HistoryItem> items)
        {
            SetHistoryItems(items);
        }

        public void SetHistoryItems(List<HistoryItem> items)
        {
            this.historyItems = items;
            this.historyItems.Sort((a, b) =>
            {
                return a.GetDateTime().CompareTo(b.GetDateTime()) < 0 ? 1 : 0;
            });

            this.RenderRows();
        }

        private void RenderRows()
        {
            int startIndex = (pageIndex == 0 ? 0 : pageIndex * pageSize);
            int itemCount = 0;

            foreach(Control c in currentItems)
            {
                Controls.Remove(c);
            }

            for(int i = startIndex; i < startIndex + pageSize; i++)
            {
                if (i < historyItems.Count)
                {
                    itemCount++;

                    HistoryRow row = new HistoryRow(historyItems[i]);
                    UpdateComponentRowYLocation(ref row, (itemCount-1)*53);

                    Controls.Add(row);
                    currentItems.Add(row);
                } else
                {
                    break;
                }
            }

            this.UpdatePageCounter();
        }

        private void UpdatePageCounter()
        {
            decimal max = Math.Ceiling((decimal)this.historyItems.Count / this.pageSize);
            this.pageCounter.Text = (this.pageIndex + 1) + "/" + (max > 0 ? max : 1);
        }

        private void UpdateComponentRowYLocation(ref HistoryRow component, int y)
        {
            component.Bounds = new Rectangle(component.Bounds.X, y, component.Width, component.Height);
            component.Bounds = new Rectangle(component.Bounds.X, y, component.Width, component.Height);
        }

        private void HistoryPaginator_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            decimal maxSize = Math.Ceiling((decimal)this.historyItems.Count / this.pageSize);

            if(pageIndex + 1 < maxSize)
            {
                this.pageIndex++;
                this.RenderRows();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pageIndex - 1 > -1)
            {
                this.pageIndex--;
                this.RenderRows();
            }
        }
    }
}
