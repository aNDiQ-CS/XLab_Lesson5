using System;
using TMPro;
using UnityEngine;

namespace Golf
{
    public class GameplayState : StateBase
    {
        [SerializeField] private TextMeshProUGUI m_scoreText;
        [SerializeField] private ScoreManager m_scoreManager;
        [SerializeField] private PlayerController m_playerController;
        [SerializeField] private LevelController m_levelController;
        [SerializeField] private GameObject m_gameplayPanel;

        private GameStateMachine m_gameStateMachine;

        public override void Init(GameStateMachine gameStateMachine)
        {   
            m_scoreText.gameObject.SetActive(false);
            m_gameplayPanel.gameObject.SetActive(false);
            m_gameStateMachine = gameStateMachine;
        }

        public override void Enter()
        {
            m_scoreManager.Reset();
            m_scoreManager.ScoreChanged += OnScoreChanged;

            m_scoreText.gameObject.SetActive(true);
            m_gameplayPanel.SetActive(true);
            OnScoreChanged(m_scoreManager.Score);

            m_levelController.enabled = true;
            m_playerController.enabled = true;

            m_levelController.Finished += OnFinished;
        }      

        public override void Exit()
        {
            m_levelController.enabled = false;
            m_playerController.enabled = false;
            m_gameplayPanel.SetActive(false);
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
