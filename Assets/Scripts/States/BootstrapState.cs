using UnityEngine;

namespace Golf
{
    public class BootstrapState : StateBase
    {
        [SerializeField] private PlayerController m_playerController;
        [SerializeField] private LevelController m_levelController;        

        private GameStateMachine m_gameStateMachine;

        public override void Init(GameStateMachine gameStateMachine)
        {
            m_playerController.enabled = false;
            m_levelController.enabled = false;
            m_gameStateMachine = gameStateMachine;
        }

        public override void Enter()
        {
            m_gameStateMachine.Enter<MainMenuState>();
        }

        public override void Exit()
        {

        }
    }
}
