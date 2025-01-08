using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private PlayerInterface pi;
    private GameObject player1;
    private GameObject player2;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        pi = GetComponent<PlayerInterface>();

        player1 = GameObject.FindWithTag("Player1");
        player2 = GameObject.FindWithTag("Player2");

        if (animator == null)
        {
            Debug.LogError("Animator component is missing on " + gameObject.name);
        }

        if (pi == null)
        {
            Debug.LogError("PlayerInterface component is missing on " + gameObject.name);
        }
    }

    private void Update()
    {
        // Handle inputs separately for each player
        if (player1 != null && gameObject.CompareTag("Player1"))
        {
            HandlePlayer1Input();
        }

        if (player2 != null && gameObject.CompareTag("Player2"))
        {
            HandlePlayer2Input();
        }
    }

    private void HandlePlayer1Input()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayAnimation("Player1-Shoot");
            pi?.__Shoot__();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            PlayAnimation("Player1-Idle");
        }
    }

    private void HandlePlayer2Input()
    {
        if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.Slash))
        {
            PlayAnimation("Player2-Shoot");
            pi?.__Shoot__();
        }
        else if (Input.GetKeyUp(KeyCode.RightShift) || Input.GetKeyUp(KeyCode.Slash))
        {
            PlayAnimation("Player2-Idle");
        }
    }

    private void PlayAnimation(string animationName)
    {
        if (animator != null)
        {
            animator.Play(animationName);
        }
        else
        {
            Debug.LogWarning("Animator is not assigned.");
        }
    }
}
