using UnityEngine;

namespace Golf
{
    public class BootstrapState : MonoBehaviour
    {
        [SerializeField] private PlayerController m_playerController;
        [SerializeField] private LevelController m_levelController;        

        private GameStateMachine m_gameStateMachine;

        public void Init(GameStateMachine gameStateMachine)
        {
            m_playerController.enabled = false;
            m_levelController.enabled = false;
            m_gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            m_gameStateMachine.Enter<MainMenuState>();
        }

        public void Exit()
        {

        }
    }
}
