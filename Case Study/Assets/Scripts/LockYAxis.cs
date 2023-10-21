using UnityEngine;

public class LockYAxis : MonoBehaviour
{
    private bool lockYAxis = true;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (lockYAxis)
        {
            Vector3 newPosition = transform.position;
            newPosition.y = initialPosition.y;
            transform.position = newPosition;
        }
    }
}
