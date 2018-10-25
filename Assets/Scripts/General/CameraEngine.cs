using UnityEngine;

public class CameraEngine : Singelton<CameraEngine>
{
    private Vector2 maxPosition = new Vector2(3, 6);
    private Vector2 minPosition = new Vector2(-3, -6);
    private readonly float smooth = 10f;

    public Vector2 MaxPosition
    {
        get { return maxPosition; }
        set { maxPosition = value; }
    }

    public Vector2 MinPosition
    {
        get { return minPosition; }
        set { maxPosition = value; }
    }

    private Transform currentTarget;

    public void SetTarget(Transform newTarget)
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
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            transform.position = Vector2.Lerp(currentPosition, targetPosition, smooth * Time.deltaTime);
        }
    }
}
