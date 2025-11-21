using System;
using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class MainMenuState : StateBase
    {        
        [SerializeField] private GameObject m_mainMenuRoot;
        [SerializeField] private Button m_playButton;

        private GameStateMachine m_gameStateMachine;

        public override void Init(GameStateMachine gameStateMachine)
        {
            m_mainMenuRoot.SetActive(false);
            m_gameStateMachine = gameStateMachine;
        }

        public override void Enter()
        {
            m_mainMenuRoot.SetActive(true);
            m_playButton.onClick.AddListener(OnClicked);
        }        

        public override void Exit()
        {
            m_mainMenuRoot.SetActive(false);
            m_playButton.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked()
        {
            // To Gameplay;
            m_gameStateMachine.Enter<GameplayState>();
        }
    }
}
