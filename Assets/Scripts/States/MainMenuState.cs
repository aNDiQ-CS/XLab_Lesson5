using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class MainMenuState : StateBase
    {        
        [SerializeField] private GameObject m_mainMenuRoot;
        [SerializeField] private Button m_playButton;
        [SerializeField] private Button m_highscoreButton;

        [Header("Cinemachine Cameras")]
        [SerializeField] private CameraSwitcher m_cameraSwitcher;
        [SerializeField] private CinemachineCamera m_fromCamera;
        [SerializeField] private CinemachineCamera m_toCamera;

        private GameStateMachine m_gameStateMachine;        

        public override void Init(GameStateMachine gameStateMachine)
        {
            m_mainMenuRoot.SetActive(false);
            m_gameStateMachine = gameStateMachine;
        }

        public override void Enter()
        {
            m_mainMenuRoot.SetActive(true);
            m_playButton.onClick.AddListener(OnPlayButtonClicked);
            m_highscoreButton.onClick.AddListener(OnHighscoreButtonClicked);
        }       

        public override void Exit()
        {
            m_mainMenuRoot.SetActive(false);
            m_playButton.onClick.RemoveListener(OnPlayButtonClicked);
            m_highscoreButton.onClick.RemoveListener(OnHighscoreButtonClicked);
        }

        private void OnPlayButtonClicked()
        {            
            m_gameStateMachine.Enter<GameplayState>();
        }

        private void OnHighscoreButtonClicked()
        {
            // Я бы это переделал на более универсальное решение, но времени неть
            m_cameraSwitcher.SwitchCamera(m_fromCamera, m_toCamera);
            m_gameStateMachine.Enter<HighscoreState>();
        }
    }
}
