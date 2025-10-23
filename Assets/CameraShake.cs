using Unity.Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;
    public CinemachineImpulseSource ImpulseSource;

    private void Awake()
    {
        Instance = this;
        ImpulseSource = GetComponent<CinemachineImpulseSource>();
    }


    public void Shake(float force)
    {
        ImpulseSource.GenerateImpulse(force);
    }
}
