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
using WordleSolver.Objects;

namespace WordleSolver.Views
{
    public partial class HistoryView : Form
    {
        private HistoryHandler historyHandler;

        public HistoryView()
        {
            InitializeComponent();
            historyHandler = new HistoryHandler();

            List<HistoryItem> items = new List<HistoryItem>();
            historyHandler.GetHistory().ForEach((historyItem) =>
            {
                items.Add(historyItem);
            });
            this.historyPaginator1.SetHistoryItems(items);
        }

        private void HistoryView_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.SwitchView(new views.Menu());
        }
    }
}
