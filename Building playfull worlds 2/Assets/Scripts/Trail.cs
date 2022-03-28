using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{

    [SerializeField] bool withColor;
    [SerializeField] bool withTrail;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            // Trial actief
            if(withTrail)
            {
                // Trail kleuren actief
                if (withColor)
                {
                    // Trail kleur is de kleur van de speler
                    GetComponent<SpriteRenderer>().color = other.GetComponent<SpriteRenderer>().color;
                }
                else if (!withColor)
                {
                    // Trail kleur is wit
                    GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
        else if(!withTrail)
            {
                // Niks
                return;
            }
        }
    }

}
