using Cinemachine;

using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    private float sensivity = 0.5f;

    private CinemachineComposer composer;


    // Start is called before the first frame update
    void Start()
    {
        composer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineComposer>();

    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Mouse Y") * sensivity;
        composer.m_TrackedObjectOffset.y += vertical;
        composer.m_TrackedObjectOffset.y = Mathf.Clamp(composer.m_TrackedObjectOffset.y, 0, 10);
    }
}
