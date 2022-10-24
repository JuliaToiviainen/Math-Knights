using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] [Range(0.01f, 1f)] private float speed = 0.125f;

    private Vector3 velocity = Vector3.zero;
   // public Panel panel;

    private void LateUpdate()
    {
        //panel.
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, speed);
    }
}
