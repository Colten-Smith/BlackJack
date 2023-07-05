using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace BlackJack_1._0.Classes
{
    public class HighScoreManager
    {
        private string CurrentDirectory { get; set; }
        private string FileToRead { get; set; }
        private string FilePath { get; set; }
        public List<string> Names { get; private set; } = new List<string>();
        public List<int> Scores { get; private set; } = new List<int>();
        public int LeaderboardSize { get; private set; }
        public HighScoreManager(string fileToRead)
        {
            CurrentDirectory = Directory.GetCurrentDirectory();
            FileToRead = fileToRead;
            FilePath = Path.Combine(CurrentDirectory, FileToRead);
            try
            {
                using (StreamReader sr = new StreamReader(FilePath))
                {
                    while (!sr.EndOfStream)
                    {
                        Names.Add(sr.ReadLine());
                        try
                        {
                            Scores.Add(int.Parse(sr.ReadLine()));
                        }
                        catch
                        {
                            break;
                        }
                    }
                }
            }
            catch
            {

            }
            LeaderboardSize = Names.Count();
        }
        public void AddScore(string name, int score)
        {
            if (name.Length > 20)
            {
                name = name.Substring(0, 20);
            }
            foreach (int item in Scores)
            {
                if (score > item)
                {
                    int index = Scores.IndexOf(item);
                    Scores.Insert(index, score);
                    Names.Insert(index, name);
                    Names.RemoveAt(Names.Count - 1);
                    Scores.RemoveAt(Scores.Count - 1);
                    break;
                }
            }
        }
        public void UpdateLeaderboard()
        {
            try
            {
                using (StreamWriter sr = new StreamWriter(FilePath))
                {
                    for (int i = 0; i < Names.Count; i++)
                    {
                        sr.WriteLine(Names[i]);
                        sr.WriteLine(Scores[i]);
                    }
                }
            }

            catch (Exception)
            {

                throw;
            }
        }
    }
}
