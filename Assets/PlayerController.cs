 using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // moving speed
    public float jumpForce = 10f; 
    public LayerMask groundLayer; // check ground layer

    private Rigidbody2D rb;
    private bool isGrounded; // check if player is on the ground
    private Animator animator;

    private bool isJumping = false;
    private float jumpTimeCounter = 0.35f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // w is left, d is right    
        float moveInput = Input.GetAxis("Horizontal"); 
        //Debug.Log($"Horizontal Input: {moveInput}");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Update Animator parameters
        animator.SetBool("IsWalking", moveInput != 0); // If moving, set IsWalking to true
        //Debug.Log($"IsWalking: {animator.GetBool("IsWalking")}");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("IsJump", true);
            isJumping = true;
            Debug.Log("Jump Triggered");
        }

        if (isJumping)
        {
            jumpTimeCounter -= Time.deltaTime;
            
            if (jumpTimeCounter <= 0)
            {
                if (IsGrounded())
                {
                    animator.SetBool("IsJump", false);
                    isJumping = false;
                    jumpTimeCounter = 0.35f;  
                }
            }
        }
    }

     // on the ground
    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.015f, groundLayer);
        //Debug.DrawRay(transform.position, Vector2.down * 0.25f, Color.red); // Visualize raycast
        Debug.Log(hit.collider != null ? "Grounded" : "Not Grounded");
        return hit.collider != null; // if ground return true
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3.down * 0.015f));
    }
}
