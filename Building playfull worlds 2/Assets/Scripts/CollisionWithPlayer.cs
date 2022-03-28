using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithPlayer : MonoBehaviour
{ 

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            Color playerColor = other.collider.GetComponent<SpriteRenderer>().color;
            Color wallColor = GetComponentInChildren<TrailRenderer>().startColor;

            if(playerColor == wallColor)
            {
                Debug.Log("Same Color!");
            }
            else
            {
                Debug.Log("Wrong Color!");
                other.collider.GetComponent<PlayerManager>().ResetPosition();         
            }

            GameObject.FindObjectOfType<DivideColors>().FindObjectWithSameColor(wallColor);
        }      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Color playerColor = other.GetComponent<SpriteRenderer>().color;
            Color wallColor = GetComponentInChildren<TrailRenderer>().startColor;

            if (playerColor == wallColor)
            {
                Debug.Log("Same Color!");
            }
            else
            {
                Debug.Log("Wrong Color!");
                other.GetComponent<PlayerManager>().ResetVelocity();
                other.GetComponent<PlayerManager>().ResetPosition();
            }

            GameObject.FindObjectOfType<DivideColors>().FindObjectWithSameColor(wallColor);
        }
    }
}
