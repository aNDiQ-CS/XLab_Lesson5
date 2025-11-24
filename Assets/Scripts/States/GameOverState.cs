using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class GameOverState : StateBase
    {
        [SerializeField] private GameObject m_gameOverPanel;
        [SerializeField] private TextMeshProUGUI m_scoreText;
        [SerializeField] private Button m_backButton;
        [SerializeField] private ScoreManager m_scoreManager;
        [SerializeField] private LevelController m_levelController;
        [SerializeField] private PlayerController m_playerController;

        private GameStateMachine m_gameStateMachine;

        public override void Init(GameStateMachine gameStateMachine)
        {
            m_gameStateMachine = gameStateMachine;
            m_gameOverPanel.gameObject.SetActive(false);
        }

        public override void Enter()
        {
            m_scoreText.text = m_scoreManager.Score.ToString();            

            m_scoreManager.UpdateHighscore();

            m_backButton.onClick.AddListener(OnClicked);
            m_gameOverPanel.gameObject.SetActive(true);
        }

        public override void Exit()
        {
            m_playerController.Reset();

            m_levelController.ResetMissedCount();
            m_gameOverPanel.gameObject.SetActive(false);
            m_backButton?.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked()
        {            
            m_gameStateMachine.Enter<MainMenuState>();
        }
    }
}
