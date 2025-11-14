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

        private Vector3 m_lastPointPosition;
        private Vector3 m_direction;

        void FixedUpdate()
        {
            Vector3 angles = transform.localEulerAngles;

            if (Input.GetKey(KeyCode.RightArrow))
            {
                angles.z= Rotate(angles.z, m_minAngleZ);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                angles.z = Rotate(angles.z, m_maxAngleZ);
            }

            transform.localEulerAngles = angles;
            m_direction = (m_point.position - m_lastPointPosition).normalized;
            m_lastPointPosition = angles;
        }

        private float Rotate(float angleZ, float target)
        {
            return Mathf.MoveTowardsAngle(angleZ, target, m_speed * Time.fixedDeltaTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            //LogHit(collision);
             

            if (collision.gameObject.TryGetComponent<Stone>(out Stone stone))
            {
                stone.GetComponent<Rigidbody>().AddForce(m_direction * m_power, ForceMode.Force);
                // collision.impulse;
            }            
        }
    }
}
