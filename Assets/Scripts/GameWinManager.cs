using UnityEngine;

public class GameWinManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject winPanel;
    public GameObject winnerTextPlayer1;
    public GameObject winnerTextPlayer2;

    [Header("Players")]
    public GameObject player1Object;
    public GameObject player2Object;

    private bool isPlayer1Eliminated = false;
    private bool isPlayer2Eliminated = false;

    private void Update()
    {
        CheckGameStatus();
    }

    private void CheckGameStatus()
    {
        // Check if Player 1 is eliminated
        if (!isPlayer1Eliminated && player1Object == null)
        {
            isPlayer1Eliminated = true;
            HandlePlayerElimination(isPlayer1: true);
        }

        // Check if Player 2 is eliminated
        if (!isPlayer2Eliminated && player2Object == null)
        {
            isPlayer2Eliminated = true;
            HandlePlayerElimination(isPlayer1: false);
        }
    }

    private void HandlePlayerElimination(bool isPlayer1)
    {
        winPanel.SetActive(true);

        if (isPlayer1)
        {
            winnerTextPlayer1.SetActive(false);
            winnerTextPlayer2.SetActive(true);
        }
        else
        {
            winnerTextPlayer1.SetActive(true);
            winnerTextPlayer2.SetActive(false);
        }
    }
}
