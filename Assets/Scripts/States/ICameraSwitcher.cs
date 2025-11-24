using Unity.Cinemachine;
using UnityEngine;

namespace Golf
{
    public interface ICameraSwitcher
    {        
        protected void SwitchCamera(CinemachineCamera from, CinemachineCamera to);
    }
}
