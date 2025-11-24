using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(Image))]
    public class MusicButton : MonoBehaviour
    {
        [SerializeField] private AudioSource m_music;
        [SerializeField] private Image m_image;

        private Button m_button;

        private void OnEnable()
        {
            m_button = GetComponent<Button>();
            m_image = GetComponent<Image>();
        }        

        public void ChangeMusicState()
        {
            m_music.mute = !m_music.mute;

            if (m_music.mute)
            {
                m_image.color = Color.darkGray;
            }
            else
            {
                m_image.color = Color.white;
            }
        }
    }
}
