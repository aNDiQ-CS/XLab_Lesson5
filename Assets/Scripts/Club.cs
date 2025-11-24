using UnityEngine;

namespace Golf
{
    public class Club : MonoBehaviour
    {
        [SerializeField, Min(1)] private float m_power = 250f;
        [SerializeField] private Transform m_point;
        [SerializeField] private float m_minAngleZ = -30;
        [SerializeField] private float m_maxAngleZ = 30;
        [SerializeField, Min(0)] private float m_speed;
        [SerializeField] private AudioSource m_audioSource;

        private bool m_isDown;
        private Vector3 m_lastPointPosition;
        private Vector3 m_direction;

        void FixedUpdate()
        {
            Vector3 angles = transform.localEulerAngles;

            if (m_isDown)
            {
                angles.z = Rotate(angles.z, m_minAngleZ);
            }
            else
            {
                angles.z = Rotate(angles.z, m_maxAngleZ);
            }

            transform.localEulerAngles = angles;
            m_direction = (m_point.position - m_lastPointPosition).normalized;    
            m_lastPointPosition = m_point.position;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Stone>(out Stone stone))
            {
                stone.AddForce(m_power * m_direction);
                m_audioSource.Play();
            }
        }

        public void Down() => m_isDown = true;
        public void Up() => m_isDown = false;

        public void ResetPosition()
        {
            Vector3 angle = new Vector3(0, 0, m_maxAngleZ);
            transform.localEulerAngles = angle;
            Up();
        }

        private float Rotate(float angleZ, float target)
        {
            return Mathf.MoveTowardsAngle(angleZ, target, m_speed * Time.fixedDeltaTime);
        }                
    }
}
