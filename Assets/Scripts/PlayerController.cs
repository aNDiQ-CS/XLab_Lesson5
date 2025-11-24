using System;
using UnityEngine;
using UnityEngine.EventSystems;
namespace Golf
{
    public class PlayerController : MonoBehaviour
    {
        public event Action Punish;

        [SerializeField] private Club m_club;
        [SerializeField] private StoneSpawner m_stoneSpawner;
        [SerializeField] private int m_maxTimePunishment = 5;

        [SerializeField] private EventTrigger m_hitButton;

        private float m_timePunishment;
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

        public void Reset()
        {
            Up();
            m_club.ResetPosition();
            m_timePunishment = 0;
        }

        private void Update()
        {
            if (m_isDown)
            {
                m_timePunishment += Time.deltaTime;
                if (m_timePunishment > m_maxTimePunishment)
                {
                    Punish?.Invoke();
                    Reset();
                }
                m_club.Down();
            }
            else
            {
                m_timePunishment = 0;
                m_club.Up();
            }
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
