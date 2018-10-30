using UnityEngine;

public class CameraEngine : Singelton<CameraEngine>
{
    private readonly float smooth = 10f;

    private Transform currentTarget;

    private void Start()
    {
        SetTarget(GameObject.FindGameObjectWithTag("Player").transform);
    }

    private void SetTarget(Transform newTarget)
    {
        if(newTarget == null)
        {
            Debug.LogError("FOFOOFFOFOOO!");
        }

        currentTarget = newTarget;
    }

    private void LateUpdate()
    {
        if(currentTarget == null)
        {
            return;
        }

        if(transform.position != currentTarget.position)
        {
            Vector2 currentPosition = transform.position;
            Vector2 targetPosition = currentTarget.position;
            transform.position = Vector2.Lerp(currentPosition, targetPosition, smooth * Time.deltaTime);
        }
    }
}
