using Unity.Cinemachine;
using UnityEngine;

public class LaunchIndicator : MonoBehaviour
{
    [SerializeField] private CinemachineCamera freeLookCamera;

    // Update is called once per frame
    void Update()
    {
        transform.up = freeLookCamera.transform.up;
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y,0);
    }
}
