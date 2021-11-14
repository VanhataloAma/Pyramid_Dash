using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using GA.Pyramid_dash;

namespace GA.Pyramid_dash {
    public static class GameConfig {

        public const int ScoreEntryCount = 5;

        public const string HighScoreFile = "score.json";
        
        public const string GameDataFolder = "Pyramid_dash";


        public static string GetGameDataPath() {
            string documents = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return Path.Combine(documents, GameDataFolder);
        }

        public static string GetHighScorePath() {
            return Path.Combine(GetGameDataPath(), HighScoreFile);
        }
    }
}