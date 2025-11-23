using System;
using UnityEngine;

namespace Golf
{
    [RequireComponent(typeof(Rigidbody))]
    public class Stone : MonoBehaviour
    {
        public event Action<Stone> Hit;
        public event Action<Stone> Missed;

        [SerializeField] private StoneData[] m_data;
        [SerializeField] private LayerMask m_layerMask;

        private Rigidbody m_rigidbody;
        private StoneData m_currentData;

        public int score
        {
            get;
            private set;
        }

        private void Awake()
        {
            m_rigidbody = GetComponent<Rigidbody>();
            m_currentData = m_data[UnityEngine.Random.Range(0, m_data.Length)];
            score = m_currentData.score;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<Club>())
            {
                Hit?.Invoke(this);
            }
            else
            {
                Missed?.Invoke(this);
            }
        }

        public void AddForce(Vector3 force) => m_rigidbody.AddForce(force, ForceMode.Force);        
    }
}
