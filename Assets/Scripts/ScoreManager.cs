using System;
using UnityEngine;

namespace Golf
{
    public class ScoreManager : MonoBehaviour
    {
        public event Action<int> ScoreChanged;
        public event Action<int> HighscoreChanged;

        private int m_score;

        public int Score { get => m_score; private set
            {
                m_score = value;
                ScoreChanged?.Invoke(Score);
                Debug.Log("Score: " + Score);
            }}

        public int HighScore
        {
            get => PlayerPrefs.GetInt(GlobalConstants.Highscore, 0);
            private set
            {
                int highscore = Mathf.Max(PlayerPrefs.GetInt(GlobalConstants.Highscore, 0), Score);
                PlayerPrefs.SetInt(GlobalConstants.Highscore, highscore);
                HighscoreChanged?.Invoke(value);
            }
        }

        public void Increase()
        {
            Score++;            
        }

        public void Increase(int score)
        {
            Score += score;
        }

        public void UpdateHighscore()
        {
            HighScore = Score;
        }

        public void Reset()
        {
            Score = 0;
        }
    }
}
