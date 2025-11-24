using Unity.Cinemachine;
using UnityEngine;

namespace Golf
{
    public class CameraSwitcher : MonoBehaviour
    {
        public void SwitchCamera(CinemachineCamera from, CinemachineCamera to)
        {
            from.gameObject.SetActive(false);
            to.gameObject.SetActive(true);
        }
    }
}
