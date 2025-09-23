using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -7);
    [SerializeField] private float followSpeed = 10f;
    [SerializeField] private float mouseSensitivity = 2f;

    private float yaw;

    private void FixedUpdate()
    {
        RotateAroundTarget();
        FollowTarget();
    }

    private void RotateAroundTarget()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
    }

    private void FollowTarget()
    {
        Quaternion rotation = Quaternion.Euler(0f, yaw, 0f);
        Vector3 desiredPosition = target.position + rotation * offset;

        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
