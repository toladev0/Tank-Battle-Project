using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float movementSpeed;
    public GameObject bulletPrefab;

    private Rigidbody2D rb;
    private string tankTag;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        tankTag = gameObject.tag; // Get the tag of the GameObject (Player1 or Player2)
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

        // Movement logic for Player1 (WASD)
        if (tankTag == "Player1")
        {
            horizontalMovement = GetInputMovement(KeyCode.A, KeyCode.D);  // Left and Right Movement
            verticalMovement = GetInputMovement(KeyCode.S, KeyCode.W);  // Down and Up Movement (Reversed order)
        }
        // Movement logic for Player2 (Arrow Keys)
        else if (tankTag == "Player2")
        {
            horizontalMovement = GetInputMovement(KeyCode.LeftArrow, KeyCode.RightArrow);  // Left and Right Movement
            verticalMovement = GetInputMovement(KeyCode.DownArrow, KeyCode.UpArrow);  // Down and Up Movement (Reversed order)
        }

        rb.velocity = new Vector2(horizontalMovement, verticalMovement);
    }

    private float GetInputMovement(KeyCode negativeKey, KeyCode positiveKey)
    {
        float movement = 0;

        // Negative movement (Left/Down key)
        if (Input.GetKey(negativeKey))
        {
            movement = -movementSpeed * Time.deltaTime;
        }
        // Positive movement (Right/Up key)
        if (Input.GetKey(positiveKey))
        {
            movement = movementSpeed * Time.deltaTime;
        }

        return movement;
    }

    private void HandleRotation()
    {
        // Rotation based on movement input
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
        // Shooting bullets (for Player1 or Player2)
        if ((tankTag == "Player1" && Input.GetKeyDown(KeyCode.Space)) ||
            (tankTag == "Player2" && (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.Slash))))
        {
            Vector3 bulletSpawnPosition = transform.position + transform.up; // Offset bullet in the forward direction
            Instantiate(bulletPrefab, bulletSpawnPosition, transform.rotation);
        }
    }
}
