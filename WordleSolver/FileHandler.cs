using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleSolver
{
    class FileHandler
    {
        private string Path;
        private string RawPath;

        public FileHandler(string Path)
        {
            this.RawPath = Path;
            this.Path = Path;
            this.TryLoadFile();
        }

        public List<string> GetFileLines()
        {
            using (StreamReader reader = new StreamReader(this.Path))
            {
                List<string> lines = new List<string>();

                string line;
                while((line = reader.ReadLine()) != null) {
                    lines.Add(line.ToUpper());
                }

                reader.Close();

                return lines;
            }
        }

        private bool TryLoadFile()
        {
            try
            {
                using (StreamReader reader = new StreamReader(this.RawPath))
                {
                    string content = "";

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        content += line + "\n";
                    }

                    reader.Close();

                    return content != null;
                }
            }
            catch (Exception)
            {
                if (!File.Exists(this.RawPath))
                {
                    using(File.Create(this.RawPath)) { }
                    return GetFileContent() != null;
                }
                else
                {
                    return false;
                }
            }
        }

        private string GetFileContent()
        {
            try
            {
                using (StreamReader reader = new StreamReader(this.RawPath))
                {
                    string content = "";

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        content += line + "\n";
                    }

                    reader.Close();

                    return content;
                }
            } catch(Exception)
            {
                if(!File.Exists(this.RawPath))
                {
                    File.Create(this.RawPath);
                    return GetFileContent();
                } else
                {
                    return "";
                }
            }
        }

        public void AppendWord(string Word)
        {
            if(!GetFileLines().Contains(Word.ToUpper()))
            {
                using (StreamWriter writer = new StreamWriter(this.Path, true))
                {
                    writer.WriteLine(Word);
                    writer.Close();
                }
            }
        }
    }
}
