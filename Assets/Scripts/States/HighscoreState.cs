using System;
using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class HighscoreState : StateBase
    {
        [SerializeField] private GameObject m_highscoreRoot;
        [SerializeField] private Button m_returnButton;

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
        }

        private void OnReturnClicked()
        {
            m_gameStateMachine.Enter<MainMenuState>();
        }
    }
}
