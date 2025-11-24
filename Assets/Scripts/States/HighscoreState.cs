using System;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class HighscoreState : StateBase
    {
        [SerializeField] private GameObject m_highscoreRoot;
        [SerializeField] private Button m_returnButton;         

        [Header("Cinemachine Cameras")]
        [SerializeField] private CameraSwitcher m_cameraSwitcher;
        [SerializeField] private CinemachineCamera m_fromCamera;
        [SerializeField] private CinemachineCamera m_toCamera;

        private GameStateMachine m_gameStateMachine;

        public override void Enter()
        {
            m_highscoreRoot.SetActive(true);
            m_returnButton.onClick.AddListener(OnReturnClicked);            
        }        

        public override void Exit()
        {
            m_highscoreRoot.SetActive(false);
            m_returnButton.onClick.RemoveListener(OnReturnClicked);
        }

        public override void Init(GameStateMachine gameStateMachine)
        {
            m_gameStateMachine = gameStateMachine;
            m_highscoreRoot.SetActive(false);            
        }

        private void OnReturnClicked()
        {
            m_cameraSwitcher.SwitchCamera(m_fromCamera, m_toCamera);
            m_gameStateMachine.Enter<MainMenuState>();
        }
    }
}
