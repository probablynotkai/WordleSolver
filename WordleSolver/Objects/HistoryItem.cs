using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleSolver.Objects
{
    public class HistoryItem
    {
        private string word;
        private bool guessed;
        private int attempts;
        private DateTime dateTime;

        public HistoryItem(string word, bool guessed, int attempts, DateTime dateTime)
        {
            this.word = word;
            this.guessed = guessed;
            this.attempts = attempts;
            this.dateTime = dateTime;
        }

        public string GetWord()
        {
            return word;
        }

        public bool IsGuessed()
        {
            return guessed;
        }

        public int GetAttempts()
        {
            return attempts;
        }

        public DateTime GetDateTime()
        {
            return dateTime;
        }
    }
}
