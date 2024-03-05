using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleSolver
{
    class WordleValidator
    {
        private List<string> PossibleWords;
        private char[] Sequence;
        private Dictionary<char, List<int>> PossibleLetters;
        //private char[] PossibleLetters;
        private List<char> ExcludedLetters;

        public WordleValidator()
        {
            Sequence = new char[5] { '%', '%', '%', '%', '%' };
            //PossibleLetters = new char[5] { '%', '%', '%', '%', '%' };
            //PossibleLetters = new List<char>();
            PossibleLetters = new Dictionary<char, List<int>>();
            ExcludedLetters = new List<char>();

            FileHandler handler = new FileHandler("words.txt");
            this.PossibleWords = handler.GetFileLines();
        }

        public char[] GetSequence()
        {
            return this.Sequence;
        }

        public KeyValuePair<string, float>[] SuggestNextWordList()
        {
            SortedDictionary<string, float> CalculatedPossibilities = new SortedDictionary<string, float>();
            List<string> WordsToRemove = new List<string>();

            foreach (string PossibleWord in this.PossibleWords)
            {
                string Word = PossibleWord.ToUpper();
                float Weight = 0.0f;
                bool Exclude = false;

                char[] SplitWord = Word.ToCharArray();
                char[] TestWord = new char[5];
                Sequence.CopyTo(TestWord, 0);

                for (int i = 0; i < TestWord.Length; i++)
                {
                    if (TestWord[i] == '%') continue;

                    if (SplitWord[i] == TestWord[i])
                    {
                        Weight += 0.2f;

                        SplitWord[i] = '%';
                        TestWord[i] = '%';
                    }
                    else
                    {
                        Exclude = true;
                    }
                }

                foreach (char PossibleLetter in this.PossibleLetters.Keys)
                {
                    bool WrongPlace = true;
                    List<int> indexes = this.PossibleLetters[PossibleLetter];

                    if(SplitWord.Contains(PossibleLetter))
                    {
                        WrongPlace = false;

                        // For the word on the right, it suggested Growl after R1 is excluded
                        foreach (int i in indexes)
                        {
                            if (SplitWord[i] == '%' || SplitWord[i] == '@') continue;

                            if (SplitWord[i] == PossibleLetter)
                            {
                                //if (PossibleWord == "GROWL") Console.WriteLine(PossibleLetter + " not at " + i);
                                WrongPlace = true;
                            }
                        }

                        for (int j = 0; j < SplitWord.Length; j++)
                        {
                            if (SplitWord[j] == PossibleLetter)
                            {
                                //if (PossibleWord == "GROWL") Console.WriteLine(PossibleLetter + " substituted at " + j + " " + SplitWord[j]);
                                SplitWord[j] = '%';
                                break;
                            }
                        }
                    }

                    if(WrongPlace)
                    {
                        //if(PossibleWord == "GROWL") Console.WriteLine(PossibleWord + " excluded");
                        Exclude = true;
                    }
                }

                foreach (char ExcludedLetter in this.ExcludedLetters)
                {
                    for(int i = 0; i < SplitWord.Length; i++)
                    {
                        if (SplitWord[i] == '%' || SplitWord[i] == '@') continue;

                        if(SplitWord[i] == ExcludedLetter)
                        {
                            SplitWord[i] = '@';
                            Exclude = true;
                            //if (PossibleWord == "GROWL") Console.WriteLine(PossibleWord + " excluded for letter " + ExcludedLetter);
                        }
                    }
                }

                if(Exclude)
                {
                    WordsToRemove.Add(PossibleWord);
                } else
                {
                    CalculatedPossibilities.Add(Word, Weight);
                }
            }

            foreach(string s in WordsToRemove)
            {
                this.PossibleWords.Remove(s);
            }

            List<KeyValuePair<string, float>> list = new List<KeyValuePair<string, float>>(CalculatedPossibilities);
            //list.Sort((x, y) => x.Value.CompareTo(y.Value));

            // Words with duplicated letters rank lower, should prove faster when trying to find woprds faster
            list.Sort((x, y) =>
            {
                bool xd = false;
                bool yd = false;
                string xw = x.Key;
                string yw = y.Key;

                for (int i = 0; i < xw.Length; i++)
                {
                    if (xw.Length > 1)
                    {
                        for (int j = 1; j < xw.Length - 1; j++)
                        {
                            if (xw[i].Equals(xw[j]))
                            {
                                xd = true;
                            }
                        }
                    }
                }

                for (int i = 0; i < yw.Length; i++)
                {
                    if (yw.Length > 1)
                    {
                        for (int j = 1; j < yw.Length - 1; j++)
                        {
                            if (yw[i].Equals(yw[j]))
                            {
                                yd = true;
                            }
                        }
                    }
                }

                if (x.Value == y.Value)
                {
                    return xd && !yd ? 1 : (xd && yd ? 0 : -1);
                } else
                {
                    return x.Value.CompareTo(y.Value);
                }
            });

            return list.ToArray();
        }

        public string SuggestNextWord()
        {
            return SuggestNextWordList()[0].Key;
        }

        public string SuggestRandomWord()
        {
            KeyValuePair<string, float>[] words = SuggestNextWordList();

            Random r = new Random();

            return words[r.Next(0, words.Length - 1)].Key;
        }

        public void AddMissingWord(string Word)
        {
            FileHandler handler = new FileHandler("words.txt");
            handler.AppendWord(Word);
        }

        public void InsertPossibleLetter(char Character, int index)
        {
            if(this.PossibleLetters.ContainsKey(Character))
            {
                //if (Character == 'R') Console.WriteLine("Adding R" + index);
                List<int> indexes = this.PossibleLetters.First((x) => x.Key == Character).Value;

                if(!indexes.Contains(index))
                {
                    indexes.Add(index);
                }

                this.PossibleLetters[Character] = indexes;
            } else
            {
                //if (Character == 'R') Console.WriteLine("Setting R" + index);
                List<int> indexes = new List<int>();

                indexes.Add(index);

                this.PossibleLetters.Add(Character, indexes);
            }
        }

        public void InsertCorrectLetter(char Character, int index)
        {
            if(index > this.Sequence.Length)
            {
                throw new Exception("Index exceeds sequence length.");
            }

            List<char> ToRemove = new List<char>();
            foreach(char c in this.PossibleLetters.Keys)
            {
                if(c == Character)
                {
                    ToRemove.Add(c);
                }
            }

            foreach (char c in ToRemove) this.PossibleLetters.Remove(c);

            this.Sequence[index] = Character;
        }

        public Dictionary<char, List<int>> GetPossibleLetters()
        {
            return this.PossibleLetters;
        }

        public void InsertExcludedLetter(char Character)
        {
            this.ExcludedLetters.Add(Character);
        }

        public List<char> GetExcludedLetters()
        {
            return this.ExcludedLetters;
        }

        public void InsertSequence(char Letter, int Index)
        {
            if(Index > this.Sequence.Length)
            {
                throw new IndexOutOfRangeException("Selected index exceeds Wordle Array length.");
            }

            this.Sequence[Index] = Letter;

            if(this.PossibleLetters.ContainsKey(Letter))
            {
                this.PossibleLetters.Remove(Letter);
            }
        }

        public void PopSequence(int Index)
        {
            if (Index > this.Sequence.Length)
            {
                throw new IndexOutOfRangeException("Selected index exceeds Wordle Array length.");
            }

            this.Sequence[Index] = '%';
        }
    }
}
