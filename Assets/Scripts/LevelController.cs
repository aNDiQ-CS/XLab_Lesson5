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
        [SerializeField] private BonusBarrel m_barrel;
        [SerializeField] private int m_bonusMultiplier = 5;
        [SerializeField] private PlayerController m_playerController;

        [Header("UI, ART and SOUND")]
        [SerializeField] private ScoreManager m_scoreManager;
        [SerializeField] private TMP_Text m_scoreText;
        [SerializeField] private ParticleSystem m_particleSystem;
        [SerializeField] private AudioSource m_missAudio;
        [SerializeField] private AudioSource m_gameOverAudio;
        [SerializeField] private AudioSource m_bonusAudio;

        public long Score { get; private set; } = 0;

        private float m_time;
        private int m_currentMissedCount;
        private List<Stone> m_stones;
        

        private void Awake()
        {
            m_currentMissedCount = m_missedCount;
            m_playerController.Punish += PunishPlayer;
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
                stone.HitBonus += OnHitBonus;

                m_time = 0;
            }
        }        

        private void OnMissedStone(Stone stone)
        {
            UnsubscribeStone(stone);
            PunishPlayer();
        }

        private void PunishPlayer()
        {
            m_particleSystem.Play();
            m_currentMissedCount--;
            if (m_currentMissedCount <= 0)
            {                
                m_gameOverAudio.Play();

                Debug.Log("Game Over!");
                Finished?.Invoke();

                foreach (Stone item in m_stones)
                {
                    if (item != null)
                    {
                        UnsubscribeStone(item);
                        Destroy(item.gameObject);
                    }
                }
                m_stones = new List<Stone>();
            }
            else
            {
                m_missAudio.Play();
            }
        }

        private void OnHitStone(Stone stone)
        {
            UnsubscribeStone(stone);
            m_scoreManager.Increase(stone.score);
        }

        private void OnHitBonus(Stone stone)
        {
            UnsubscribeStone(stone);
            m_bonusAudio.Play();
            stone.HitBonus -= OnHitBonus;
            m_scoreManager.Increase(stone.score * m_bonusMultiplier);
            m_barrel.PlayBonusParticle();
        }

        private void UnsubscribeStone(Stone stone)
        {
            stone.Hit -= OnHitStone;
            stone.Missed -= OnMissedStone;
        }

        internal void ResetMissedCount()
        {
            m_currentMissedCount = m_missedCount;
        }
    }
}
