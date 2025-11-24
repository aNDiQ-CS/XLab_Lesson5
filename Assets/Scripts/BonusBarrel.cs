using UnityEngine;

namespace Golf
{
    public class BonusBarrel : MonoBehaviour
    {
        [SerializeField] private ParticleSystem m_particleSystem;

        public void PlayBonusParticle()
        {
            m_particleSystem.Play();
        }
    }
}
