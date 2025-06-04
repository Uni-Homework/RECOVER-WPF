using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using RECOVER.Engine.Models;

namespace RECOVER.Engine.Serialization
{
    public static class LeaderboardSerializer
    {
        private static readonly string LeaderboardPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "RECOVER",
            "leaderboard.json");

        public static event EventHandler LeaderboardUpdated;

        public static void SaveLeaderboard(List<LeaderboardEntry> entries)
        {
            try
            {
                // Ensure directory exists
                var directory = Path.GetDirectoryName(LeaderboardPath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var json = JsonSerializer.Serialize(entries, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                File.WriteAllText(LeaderboardPath, json);
                
                LeaderboardUpdated?.Invoke(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                // Log error or handle it appropriately
                Console.WriteLine($"Error saving leaderboard: {ex.Message}");
            }
        }

        public static List<LeaderboardEntry> LoadLeaderboard()
        {
            try
            {
                if (!File.Exists(LeaderboardPath))
                {
                    return new List<LeaderboardEntry>();
                }

                var json = File.ReadAllText(LeaderboardPath);
                return JsonSerializer.Deserialize<List<LeaderboardEntry>>(json) ?? new List<LeaderboardEntry>();
            }
            catch (Exception ex)
            {
                // Log error or handle it appropriately
                Console.WriteLine($"Error loading leaderboard: {ex.Message}");
                return new List<LeaderboardEntry>();
            }
        }

        public static void AddEntry(string playerName, int score) 
        {
            var entries = LoadLeaderboard();
            entries.Add(new LeaderboardEntry(playerName, score));
            SaveLeaderboard(entries);
        }
    }
} 