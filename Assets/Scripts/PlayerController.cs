using UnityEngine;
namespace Golf
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Club m_club;
        [SerializeField] private StoneSpawner m_stoneSpawner;

        private void Update()
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                m_club.Down();                
            }
            else
            {
                m_club.Up();
            }
        }
    }
}
