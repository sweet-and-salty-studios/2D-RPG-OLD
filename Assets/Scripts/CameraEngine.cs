using UnityEngine;

public class CameraEngine : MonoBehaviour
{
    private Transform target;
    private Vector3 offset = new Vector3(0, 0, -10);

    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
