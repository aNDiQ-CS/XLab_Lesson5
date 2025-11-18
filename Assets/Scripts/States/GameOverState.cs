using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class GameOverState : MonoBehaviour
    {
        [SerializeField] private GameObject m_gameOverPanel;
        [SerializeField] private TextMeshProUGUI m_scoreText;
        [SerializeField] private Button m_backButton;
        [SerializeField] private ScoreManager m_scoreManager;

        private GameStateMachine m_gameStateMachine;

        public void Init(GameStateMachine gameStateMachine)
        {
            m_gameStateMachine = gameStateMachine;
            m_gameOverPanel.gameObject.SetActive(false);
        }

        public void Enter()
        {
            m_scoreText.text = m_scoreManager.Score.ToString();
            m_backButton.onClick.AddListener(OnClicked);
            m_gameOverPanel.gameObject.SetActive(true);
        }

        public void Exit()
        {
            m_gameOverPanel.gameObject.SetActive(false);
            m_backButton?.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked()
        {
            Debug.Log("Clicik");
            m_gameStateMachine.Enter<MainMenuState>();
        }
    }
}
