using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public GameObject bulletPrefab;
    public float reload = 1f;
    public bool IsShoot = false;

    private Rigidbody2D rb;
    private Animator animator;
    private string tankTag;
    private float lastShotTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        tankTag = gameObject.tag; // Get the tag of the GameObject (Player1 or Player2)
        lastShotTime = -reload;
    }

    private void Update()
    {
        HandleMovement(); 
        HandleRotation();
        HandleShooting();
    }

    private void HandleMovement()
    {
        float horizontalMovement = 0;
        float verticalMovement = 0;

        // Get movement input based on tank tag
        if (tankTag == "Player1")
        {
            horizontalMovement = GetInputMovement(KeyCode.A, KeyCode.D);
            verticalMovement = GetInputMovement(KeyCode.S, KeyCode.W);
        }
        else if (tankTag == "Player2")
        {
            horizontalMovement = GetInputMovement(KeyCode.LeftArrow, KeyCode.RightArrow);
            verticalMovement = GetInputMovement(KeyCode.DownArrow, KeyCode.UpArrow);
        }

        // Prioritize one axis (vertical over horizontal)
        if (horizontalMovement != 0 && verticalMovement != 0)
        {
            horizontalMovement = 0;
        }

        // Set movement velocity
        rb.velocity = new Vector2(horizontalMovement, verticalMovement) * movementSpeed;

        // Update animation states
        if (horizontalMovement != 0 || verticalMovement != 0)
        {
            animator.Play(tankTag + "-Move");
        }
        else
        {
            animator.Play(tankTag + "-Idle");
        }
    }

    private float GetInputMovement(KeyCode negativeKey, KeyCode positiveKey)
    {
        float movement = 0;

        // Negative movement (e.g., Left/Down key)
        if (Input.GetKey(negativeKey))
        {
            movement = -1f;
        }
        // Positive movement (e.g., Right/Up key)
        else if (Input.GetKey(positiveKey))
        {
            movement = 1f;
        }

        return movement * Time.deltaTime; // Incorporate Time.deltaTime
    }

    private void HandleRotation()
    {
        if (tankTag == "Player1")
        {
            UpdateRotation(KeyCode.A, KeyCode.D, KeyCode.W, KeyCode.S);
        }
        else if (tankTag == "Player2")
        {
            UpdateRotation(KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.DownArrow);
        }
    }

    private void UpdateRotation(KeyCode leftKey, KeyCode rightKey, KeyCode upKey, KeyCode downKey)
    {
        if (Input.GetKey(leftKey)) transform.localRotation = Quaternion.Euler(0f, 0f, 90f); // Left
        if (Input.GetKey(rightKey)) transform.localRotation = Quaternion.Euler(0f, 0f, -90f); // Right
        if (Input.GetKey(upKey)) transform.localRotation = Quaternion.Euler(0f, 0f, 0f); // Up
        if (Input.GetKey(downKey)) transform.localRotation = Quaternion.Euler(0f, 0f, 180f); // Down
    }

    private void HandleShooting()
    {
        // Check for shooting input
        if (Time.time - lastShotTime >= reload && ((tankTag == "Player1" && Input.GetKeyDown(KeyCode.Space)) ||
            (tankTag == "Player2" && (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.Slash)))))
        {
            Vector3 bulletSpawnPosition = transform.position + transform.up; // Offset bullet in the forward direction
            Instantiate(bulletPrefab, bulletSpawnPosition, transform.rotation);
            lastShotTime = Time.time;
            IsShoot = true;
        }
        else
        {
            IsShoot = false;
        }
    }
}
