using UnityEngine;

namespace Golf
{
    public class GameStateMachine : MonoBehaviour
    {
        [SerializeField] private StateBase[] m_states;
        
        private StateBase m_currentState;

        private void Awake()
        {
            foreach (StateBase state in m_states)
            {
                state.Init(this);
            }            
        }

        private void Start()
        {
            Enter<BootstrapState>();
        }

        public void Enter<T>()
        {
            m_currentState?.Exit();

            foreach (StateBase state in m_states)
            {
                if (state.GetType() == typeof(T))
                {
                    m_currentState = state;
                    state.Enter();

                    break;
                }
            }

            //if (typeof(T) == typeof(BootstrapState))
            //{
            //    m_bootstrapState.Enter();
            //}
            //else if (typeof(T) == typeof(GameplayState))
            //{
            //    m_bootstrapState.Exit();
            //    m_mainMenuState.Exit();
            //    m_gameoverState.Exit();
            //    m_gameplayState.Enter();                
            //}
            //else if (typeof(T) == typeof(MainMenuState))
            //{
            //    m_gameplayState.Exit();
            //    m_mainMenuState.Enter();
            //    m_gameoverState.Exit();
            //}
            //else if (typeof(T) == typeof(GameOverState))
            //{
            //    m_gameplayState.Exit();
            //    m_gameoverState.Enter();
            //}
        }
    }
}
