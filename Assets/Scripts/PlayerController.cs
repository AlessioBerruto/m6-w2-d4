using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private Transform cameraTransform;  
    private Rigidbody rb;
    private Vector2 input;
    private GroundCheck groundCheck;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        groundCheck = GetComponent<GroundCheck>();
        animator = GetComponent<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && groundCheck.IsGrounded)
        {
            Jump();
        }

        UpdateAnimatorParameters();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 camForward = cameraTransform.forward;
        camForward.y = 0f;
        camForward.Normalize();

        Vector3 camRight = cameraTransform.right;
        camRight.y = 0f;
        camRight.Normalize();

        Vector3 direction = camForward * input.y + camRight * input.x;

        if (direction.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }

        Vector3 velocity = direction.normalized * moveSpeed;
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        animator.SetTrigger("Jump");
    }

    private void UpdateAnimatorParameters()
    {
        Vector3 horizontalVelocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        float speed = horizontalVelocity.magnitude;
        animator.SetFloat("Speed", speed);
    }

    public void TriggerHit()
    {
        animator.SetTrigger("Hit");
    }
}
