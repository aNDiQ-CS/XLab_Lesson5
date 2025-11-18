using UnityEngine;

namespace Golf
{
    public class GameStateMachine : MonoBehaviour
    {
        [SerializeField] private MainMenuState m_mainMenuState;
        [SerializeField] private GameplayState m_gameplayState;
        [SerializeField] private BootstrapState m_bootstrapState;
        [SerializeField] private GameOverState m_gameoverState;

        private void Awake()
        {
            m_mainMenuState.Init(this);
            m_gameplayState.Init(this);
            m_bootstrapState.Init(this);
            m_gameoverState.Init(this);
        }

        private void Start()
        {
            Enter<BootstrapState>();
        }

        public void Enter<T>()
        {
            if (typeof(T) == typeof(BootstrapState))
            {
                m_bootstrapState.Enter();
            }
            else if (typeof(T) == typeof(GameplayState))
            {
                m_bootstrapState.Exit();
                m_mainMenuState.Exit();
                m_gameoverState.Exit();
                m_gameplayState.Enter();                
            }
            else if (typeof(T) == typeof(MainMenuState))
            {
                m_gameplayState.Exit();
                m_mainMenuState.Enter();
                m_gameoverState.Exit();
            }
            else if (typeof(T) == typeof(GameOverState))
            {
                m_gameplayState.Exit();
                m_gameoverState.Enter();
            }
        }
    }
}
