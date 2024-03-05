using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordleSolver.Objects;

namespace WordleSolver
{
    class HistoryHandler
    {
        private List<HistoryItem> history = new List<HistoryItem>();

        public HistoryHandler()
        {
            LoadHistory();
        }

        private void LoadHistory()
        {
            List<string> lines = Program.historyFile.GetFileLines();

            foreach(string line in lines)
            {
                string[] args = line.Split(';');

                if(args.Length == 4)
                {
                    string word = args[0];
                    bool guessed = Boolean.Parse(args[1]);
                    int attempts = Int32.Parse(args[2]);
                    DateTime dateTime = DateTime.Parse(args[3]);

                    history.Add(new HistoryItem(word, guessed, attempts, dateTime));
                }
            }
        }

        public List<HistoryItem> GetHistory()
        {
            return this.history;
        }

        public void AddToHistory(string word, bool guessed, int attempts)
        {
            Program.historyFile.AppendWord(word + ";" + guessed + ";" + attempts + ";" + DateTime.Now.ToString());
        }
    }
}
