using System;
using UnityEngine;

namespace Golf
{
    [RequireComponent(typeof(Rigidbody))]
    public class Stone : MonoBehaviour
    {
        public event Action<Stone> Hit;
        public event Action<Stone> Missed;
        public event Action<Stone> HitBonus;

        [SerializeField] private StoneData[] m_data;
        [SerializeField] private LayerMask m_layerMask;
        [SerializeField] private TrailRenderer m_lineRenderer;        

        private Rigidbody m_rigidbody;
        private StoneData m_currentData;
        private bool m_particlePlayed = false;
        private bool m_hitGround = false;

        public int score
        {
            get;
            private set;
        }

        private void OnEnable()
        {
            m_lineRenderer = GetComponent<TrailRenderer>();            
        }

        private void Awake()
        {
            m_rigidbody = GetComponent<Rigidbody>();
            m_lineRenderer.enabled = false;
            m_currentData = m_data[UnityEngine.Random.Range(0, m_data.Length)];
            score = m_currentData.score;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<Club>())
            {
                m_lineRenderer.enabled = true;                
                Hit?.Invoke(this);
            }
            else if (collision.gameObject.GetComponent<BonusBarrel>())
            {
                if (!m_hitGround)
                    HitBonus?.Invoke(this);                
            }
            else
            {
                m_hitGround = true;                
                Missed?.Invoke(this);
            }
        }

        public void AddForce(Vector3 force) => m_rigidbody.AddForce(force, ForceMode.Force);        

        
    }
}
