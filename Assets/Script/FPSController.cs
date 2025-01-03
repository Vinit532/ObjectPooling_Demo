using UnityEngine;

public class FPSController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;   // Speed of movement
    public float sprintMultiplier = 1.5f; // Sprinting speed multiplier
    public float jumpForce = 5f;  // Force of jumping

    [Header("Mouse Settings")]
    public float mouseSensitivity = 2f; // Sensitivity for mouse movement
    public bool lockCursor = true; // Whether to lock the cursor to the center of the screen

    private float xRotation = 0f;
    private Rigidbody rb;

    void Start()
    {
        // Lock the cursor
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.freezeRotation = true; // Prevent the Rigidbody from rotating
        }
    }

    void Update()
    {
        // Handle mouse movement
        MouseLook();

        // Handle player movement
        MovePlayer();

        // Handle jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void MouseLook()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the camera around the Y-axis
        transform.Rotate(Vector3.up * mouseX);

        // Clamp the up and down rotation
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply the rotation to the camera
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    void MovePlayer()
    {
        // Get input for movement
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow keys
        float vertical = Input.GetAxis("Vertical");     // W/S or Up/Down arrow keys

        // Calculate movement direction
        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;

        // Apply movement
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);
    }

    void Jump()
    {
        if (IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        // Check if the player is grounded using a raycast
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
