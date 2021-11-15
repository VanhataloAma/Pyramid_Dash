using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using GA.Pyramid_dash;

namespace GA.Pyramid_dash {

    public class Score {

        [System.Serializable]
        public struct Entry {

            public string Name;
            public int Score;
        }

        [System.Serializable]
        public struct ScoreArray {

            public class EntryComparer : IComparer<Entry> {
                public int Compare(Entry x, Entry y) {
                    return y.Score - x.Score;
                }
            }
            public Entry[] scores;

            public ScoreArray(int length) {
                scores = new Entry[length];
            }

            public void Sort() {
                Array.Sort(scores, new EntryComparer());
            }

            public Entry GetEntry(int index) {
                if (index < 0 || index > scores.Length) {
                    throw new System.ArgumentOutOfRangeException();
                }

                return scores[index];
            }

            public bool Add(string name, int score) {
                Entry newEntry = new Entry() {
                    Name = name,
                    Score = score
                };

                bool isAdded = false;

                for (int i = scores.Length - 1; i >= 0; i--) {
                    if (scores[i].Score >= newEntry.Score) {
                        break;
                    }

                    if (!isAdded) {
                        scores[i] = newEntry;
                        isAdded = true;
                    } else {
                        Swap(i, i + 1);
                    }
                }

                return isAdded;
            }
        
            private void Swap(int current, int next) {
                Entry tmp = scores[current];
                scores[current] = scores[next];
                scores[next] = tmp;
            }
        }

        [SerializeField]
        private ScoreArray scores;

        private string scoreFile;

        public Score(string path) {
            scoreFile = path;
            if (!Load()) {
                scores = new ScoreArray(GameConfig.ScoreEntryCount);
            }
        }

        public Entry GetEntry(int index) {
            return scores.GetEntry(index);
        }

        public bool Add(string name, int score) {
            return scores.Add(name, score);
        }

        public bool Load() {
            if (!File.Exists(scoreFile)) {
                return false;
            }

            string json = File.ReadAllText(scoreFile, System.Text.Encoding.UTF8);
            scores = JsonUtility.FromJson<ScoreArray>(json);

            return true;
        }

        public void Save() {
            if (!Directory.Exists(GameConfig.GetGameDataPath())) {
                Directory.CreateDirectory(GameConfig.GetGameDataPath());
            }
            string json = JsonUtility.ToJson(scores);
            File.WriteAllText(scoreFile, json, System.Text.Encoding.UTF8);
        }
    }
}