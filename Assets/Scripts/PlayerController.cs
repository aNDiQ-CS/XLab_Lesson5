using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FreeCamera m_camera; //m - member
    [SerializeField] private GameObject m_UI_Panel;
    [SerializeField] private CloudController m_CloudController;

    private void Update()
    {
        if (m_UI_Panel.activeSelf)
        {
            return;
        }

        m_camera.Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_CloudController.MoveNext();
        }
    }
}
