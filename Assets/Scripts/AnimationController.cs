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
    }

    private void Update()
    {
        if (player1 != null)
        {
            HandlePlayer1Input();
        }

        if (player2 != null)
        {
            HandlePlayer2Input();
        }
    }

    private void HandlePlayer1Input()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("Player1-Shoot");
            pi.__Shoot__();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.Play("Player1-Idle");
        }
    }

    private void HandlePlayer2Input()
    {
        if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.Slash))
        {
            animator.Play("Player2-Shoot");
            pi.__Shoot__();
        }
        else if (Input.GetKeyUp(KeyCode.RightShift) || Input.GetKeyUp(KeyCode.Slash))
        {
            animator.Play("Player2-Idle");
        }
    }
}
