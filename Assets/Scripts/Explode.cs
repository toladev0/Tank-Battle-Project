using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public GameObject ExplodePreface;

    private bool hasExplodedPlayer1 = false;
    private bool hasExplodedPlayer2 = false;

    private Vector3 player1LastPosition;
    private Quaternion player1LastRotation;

    private Vector3 player2LastPosition;
    private Quaternion player2LastRotation;

    private void Update()
    {
        // Save the last known position and rotation of Player1 if it exists
        if (Player1 != null)
        {
            player1LastPosition = Player1.transform.position;
            player1LastRotation = Player1.transform.rotation;
        }
        else if (!hasExplodedPlayer1)
        {
            // Spawn explosion at Player1's last known position and rotation
            Instantiate(ExplodePreface, player1LastPosition, player1LastRotation);
            hasExplodedPlayer1 = true; // Mark Player1 as exploded
        }

        // Save the last known position and rotation of Player2 if it exists
        if (Player2 != null)
        {
            player2LastPosition = Player2.transform.position;
            player2LastRotation = Player2.transform.rotation;
        }
        else if (!hasExplodedPlayer2)
        {
            // Spawn explosion at Player2's last known position and rotation
            Instantiate(ExplodePreface, player2LastPosition, player2LastRotation);
            hasExplodedPlayer2 = true; // Mark Player2 as exploded
        }
    }
}
