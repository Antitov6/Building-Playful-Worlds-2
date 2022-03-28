using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHitSound : MonoBehaviour
{

    [SerializeField] AudioSource audioSource;

    Color wallColor;

    private void OnCollisionEnter2D(Collision2D other)
    {
        Color playerColor = gameObject.GetComponent<SpriteRenderer>().color;
        if(other.gameObject.GetComponentInChildren<TrailRenderer>())
        {
            wallColor = other.gameObject.GetComponentInChildren<TrailRenderer>().startColor;
        }

        if (playerColor == wallColor || playerColor == Color.black)
        {
            PlayerHitWallSound();
        }
    }

    public void PlayerHitWallSound()
    {
        audioSource.Play();
    }
}
