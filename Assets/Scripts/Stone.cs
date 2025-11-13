using UnityEngine;

namespace Golf
{
    public class Stone : MonoBehaviour
    {
        [SerializeField] private LayerMask m_layerMask;

        private void OnCollisionEnter(Collision collision)
        {
            var hitLayerMask = 1 << collision.gameObject.layer;
            if ((m_layerMask.value & hitLayerMask) != 0)
            {
                Debug.Log(gameObject.name + " hit " + collision.collider.name + ":" + collision.gameObject.layer);
            }
        }
    }
}
