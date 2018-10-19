using UnityEngine;

public class CameraEngine : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private Vector3 offset = new Vector3(0, 0, -10);

    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
