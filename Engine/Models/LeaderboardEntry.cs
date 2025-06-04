using System;

namespace RECOVER.Engine.Models
{
    public class LeaderboardEntry
    {
        public string PlayerName { get; set; }
        public string Score { get; set; } // Can be "Win" or a number
        public DateTime Date { get; set; }
        
        // Parameterless constructor for JSON deserialization
        public LeaderboardEntry()
        {
            Date = DateTime.Now;
        }
        
        public LeaderboardEntry(string playerName, int score)
        {
            PlayerName = playerName;
            Score = score.ToString();
            Date = DateTime.Now;
        }
    }
} 