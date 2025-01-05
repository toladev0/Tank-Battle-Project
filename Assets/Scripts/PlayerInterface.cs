using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterface : MonoBehaviour
{
    public AudioClip shoot;
    public AudioClip playerMove;

    public AudioSource shootAs;
    public AudioSource playerMoveAs;

    public void __Shoot__()
    {
        shootAs.clip = shoot;
        shootAs.Play();
    }
    public void __PlayerMove__(bool IsPlay)
    {
        playerMoveAs.clip = playerMove;
        playerMoveAs.loop = true;
        if (IsPlay )
        {
            playerMoveAs.Play();
        }
        else
        {
            playerMoveAs.Pause();
        }
    }
}
