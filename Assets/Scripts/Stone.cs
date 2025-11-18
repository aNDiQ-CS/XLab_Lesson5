using System;
using UnityEngine;

namespace Golf
{
    [RequireComponent(typeof(Rigidbody))]
    public class Stone : MonoBehaviour
    {
        public event Action<Stone> Hit;
        public event Action<Stone> Missed;

        [SerializeField] private LayerMask m_layerMask;

        private Rigidbody m_rigidbody;

        private void Awake()
        {
            m_rigidbody = GetComponent<Rigidbody>();
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

        private void LogHit(Collision collision)
        {
            var hitLayerMask = 1 << collision.gameObject.layer;
            if ((m_layerMask.value & hitLayerMask) != 0)
            {
                Debug.Log(gameObject.name + " hit " + collision.collider.name + ":" + collision.gameObject.layer);
            }
        }
    }
}
