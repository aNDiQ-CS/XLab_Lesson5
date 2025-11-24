using System;
using TMPro;
using UnityEngine;

namespace Golf
{
    [RequireComponent(typeof(TMP_Text))]
    public class HighscoreText : MonoBehaviour
    {
        [SerializeField] private TMP_Text m_text;
        [SerializeField] private ScoreManager m_scoreManager;
        //[SerializeField] private string m_format;

        // При инициализации скрипта, при изменении значений
        private void OnValidate()
        {
            if (!m_text)
            {
                m_text = GetComponent<TMP_Text>();
            }
        }

        private void Awake()
        {
            m_text.text = "Highscore:\n" + m_scoreManager.HighScore;
        }

        private void OnEnable()
        {
            m_scoreManager.HighscoreChanged += OnRecordChanged;
        }        

        private void OnDisable()
        {
            m_scoreManager.HighscoreChanged -= OnRecordChanged;
        }

        private void OnRecordChanged(int value)
        {
            //m_format ??= string.Empty;
            m_text.text = "Highscore:\n" + m_scoreManager.HighScore + "\nLast Score:\n" + value;
            //m_text.text = string.Format(m_format, value.ToString());             
        }
    }
}
