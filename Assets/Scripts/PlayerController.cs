using System;
using UnityEngine;
using UnityEngine.EventSystems;
namespace Golf
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Club m_club;
        [SerializeField] private StoneSpawner m_stoneSpawner;

        [SerializeField] private EventTrigger m_hitButton;

        private bool m_isDown;

        private void Start()
        {
            EventTrigger.Entry entryDown = new EventTrigger.Entry();
            entryDown.eventID = EventTriggerType.PointerDown;

            EventTrigger.Entry entryUp = new EventTrigger.Entry();
            entryUp.eventID = EventTriggerType.PointerUp;

            entryDown.callback.AddListener(OnPointerDown);
            entryUp.callback.AddListener(OnPointerUp);

            m_hitButton.triggers.Add(entryDown);
            m_hitButton.triggers.Add(entryUp);
        }        

        private void Update()
        {
            if (m_isDown)
            {
                m_club.Down();
            }
            else
            {
                m_club.Up();
            }

            //if (Input.GetKey(KeyCode.RightArrow))
            //{
            //    m_club.Down();
            //}
            //else
            //{
            //    m_club.Up();
            //}
        }        

        private void Down()
        {
            m_isDown = true;
        }

        private void Up()
        {
            m_isDown = false;
        }

        private void OnPointerUp(BaseEventData arg0)
        {
            Up(); 
        }

        private void OnPointerDown(BaseEventData arg0)
        {
            Down();
        }   
    }
}
