using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public event Action Finished;

        [Header("Game logic")]
        [SerializeField] private int m_missedCount;
        [SerializeField, Min(0.1f)] private float m_spawnRate = 1f;
        [SerializeField] private StoneSpawner m_stoneSpawner;

        [Header("UI")]
        [SerializeField] private ScoreManager m_scoreManager;
        [SerializeField] private TMP_Text m_scoreText;

        public long Score { get; private set; } = 0;

        private float m_time;
        private int m_currentMissedCount;
        private List<Stone> m_stones;
        

        private void Awake()
        {
            m_currentMissedCount = m_missedCount;
            m_stones = new List<Stone>();
        }

        void Update()
        {
            m_time += Time.deltaTime;

            if (m_time >= m_spawnRate)
            {
                Stone stone = m_stoneSpawner.Spawn();                
                m_stones.Add(stone);

                stone.Hit += OnHitStone;
                stone.Missed += OnMissedStone;

                m_time = 0;
            }
        }

        private void OnMissedStone(Stone stone)
        {
            UnsubscribeStone(stone);

            m_currentMissedCount--;
            if (m_currentMissedCount <= 0)
            {
                Debug.Log("Game Over!");
                Finished?.Invoke();

                foreach (Stone item in m_stones)
                {
                    Destroy(item.gameObject);
                }
            }    
        }

        private void OnHitStone(Stone stone)
        {
            UnsubscribeStone(stone);
            m_scoreManager.Increase(stone.score);
        }

        private void UnsubscribeStone(Stone stone)
        {
            stone.Hit -= OnHitStone;
            stone.Missed -= OnMissedStone;
        }

    }
}
