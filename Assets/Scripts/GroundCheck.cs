using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float sphereRadius = 0.2f;
    [SerializeField] private float checkDistance = 0.3f;
    [SerializeField] private Transform checkOrigin;

    public bool IsGrounded { get; private set; }

    private void Update()
    {
        CheckGround();        
    }

    private void CheckGround()
    {
        Ray ray = new Ray(checkOrigin.position, Vector3.down);
        IsGrounded = Physics.SphereCast(ray, sphereRadius, out RaycastHit hit, checkDistance, groundLayer);

        Debug.DrawRay(checkOrigin.position, Vector3.down * checkDistance, IsGrounded ? Color.green : Color.red);
    }


    private void OnDrawGizmosSelected()
    {
        if (checkOrigin == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(checkOrigin.position + Vector3.down * checkDistance, sphereRadius);
    }
}
