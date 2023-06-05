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
        //todo Complete HighScoreManager class
        private string CurrentDirectory { get; set; }
        private string FileToRead { get; set; }
        private string FilePath { get; set; }
        public Dictionary<string, int> Leaderboard { get; private set; }
        public int LeaderboardSize { get; private set; }
        public HighScoreManager(string fileToRead)
        {
            CurrentDirectory = Directory.GetCurrentDirectory();
            FileToRead = fileToRead;
            FilePath = Path.Combine(CurrentDirectory, FileToRead);
            Leaderboard = new Dictionary<string, int>();
            try
            {
                StreamReader sr = new StreamReader(FilePath);
                using (sr)
                {
                    while (!sr.EndOfStream)
                    {
                        string key = sr.ReadLine();
                        try
                        {
                            int value = int.Parse(sr.ReadLine());
                            Leaderboard[key] = value;
                        }
                        catch { }
                    }
                }
            }
            catch
            {

            }
            LeaderboardSize = Leaderboard.Count();
        }
    }
}
