using System;
using TMPro;
using UnityEngine;

namespace Golf
{
    public class GameplayState : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_scoreText;
        [SerializeField] private ScoreManager m_scoreManager;
        [SerializeField] private PlayerController m_playerController;
        [SerializeField] private LevelController m_levelController;

        private GameStateMachine m_gameStateMachine;

        public void Init(GameStateMachine gameStateMachine)
        {
            m_scoreText.gameObject.SetActive(false);
            m_gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            m_scoreManager.Reset();
            m_scoreManager.ScoreChanged += OnScoreChanged;

            m_scoreText.gameObject.SetActive(true);
            OnScoreChanged(m_scoreManager.Score);

            m_levelController.enabled = true;
            m_playerController.enabled = true;

            m_levelController.Finished += OnFinished;
        }      

        public void Exit()
        {
            m_levelController.enabled = false;
            m_playerController.enabled = false;
        }
        private void OnScoreChanged(int score)
        {
            m_scoreText.text = score.ToString();
        }

        private void OnFinished()
        {
            m_scoreManager.ScoreChanged -= OnScoreChanged;
            m_gameStateMachine.Enter<GameOverState>();
        }
    }
}
