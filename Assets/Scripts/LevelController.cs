using TMPro;
using UnityEngine;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        [Header("Game logic")]
        [SerializeField] private int m_missedCount;
        [SerializeField, Min(0.1f)] private float m_spawnRate = 1f;
        [SerializeField] private StoneSpawner m_stoneSpawner;

        [Header("UI")]
        [SerializeField] private TMP_Text m_scoreText;

        public long Score { get; private set; } = 0;

        private float m_time;
        private int m_currentMissedCount;
        

        private void Awake()
        {
            m_currentMissedCount = m_missedCount;
        }

        void Update()
        {
            m_time += Time.deltaTime;

            if (m_time >= m_spawnRate)
            {
                Stone stone = m_stoneSpawner.Spawn();
                
                stone.Hit += OnHitStone;
                stone.Missed += OnMissedStone;

                m_time = 0;
            }
        }

        private void OnMissedStone(Stone stone)
        {
            stone.Hit -= OnHitStone;
            stone.Missed -= OnMissedStone;

            m_currentMissedCount--;
            if (m_currentMissedCount <= 0)
            {
                Debug.Log("Game Over!");
            }    
        }

        private void OnHitStone(Stone stone)
        { 
            stone.Hit -= OnHitStone;
            stone.Missed -= OnMissedStone;

            Score++;

            m_scoreText.text = "Score: " + Score;
            Debug.Log("Score: " + Score);
        }
    }
}
