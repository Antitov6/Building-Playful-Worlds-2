using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DivideColors : MonoBehaviour
{

    // Lijst van kleuren aanmaken
    public List<Color> colors;
    public List<GameObject> walls;
    private Component[] sprites;

    private float startWallCount;
    private int colorCounter;

    private System.Random random = new System.Random();

    void Start()
    {
        // lijst met mogelijke kleuren
        //colors = new List<Color>();
        //colors.Add(new Color(1, 0, 0)); // red
        //colors.Add(new Color(0, 1, 0)); // green
        //colors.Add(new Color(0, 0, 1)); // blue
        //colors.Add(new Color(1, 1, 0)); // yellow
        //colors.Add(new Color(1, 1, 1)); // White

        // Aantal objecten / door aantal beschikbare kleuren (elke kleur krijgt hierdoor x aantal objecten). Afgerond naar int.
        //startWallCount = Mathf.RoundToInt(walls.Count / colors.Count);
        // welke kleur als eerst wordt gepakt. Zodat niet telkens 1 dezelfde kleur en extra object heeft
        colorCounter = Random.Range(0, colors.Count);
        // Shufelt de bestaande lijst. Zodat de kleuren over random objecten worden verdeeld
        walls = walls.OrderBy(item => random.Next()).ToList();
        DivideColorsOnObjects();

    }

    private void DivideColorsOnObjects()
    {
        // Voor elke muur in de lijst muren
        foreach (GameObject wall in walls)
        {
            //// Als 1 kleur evenredig is verdeelt over objecten dan
            //if (counter >= startWallCount)
            //{
            //    colorCounter += 1;
            //    counter = 0;                
            //}

            //counter += 1;

            //// Als de laaste kleur in de lijst is geweest dan
            //if (colorCounter >= colors.Count)
            //{
            //    // Begin weer vooraf aan in de kleur lijst
            //    colorCounter = 0;
            //}

            sprites = wall.GetComponentsInChildren<TrailRenderer>();

            // Voor elk kind van muur
            foreach (TrailRenderer sprite in sprites)
            {
                // Verander de kleur
                sprite.startColor = colors[colorCounter];
                sprite.endColor = colors[colorCounter];
            }

            colorCounter += 1;

            if (colorCounter >= colors.Count)
            {
                colorCounter = 0;
            }
        }/*

                // random nummer genereren
                int randomColor = Random.Range(0, 4);
                // Array wordt gevuld met kinderen van muur
                sprites = wall.GetComponentsInChildren<SpriteRenderer>();

                // Voor elk kind van muur
                foreach (SpriteRenderer sprite in sprites)
                {
                    // Verander de kleur
                    sprite.color = colors[randomColor];
                }
            }*/
    }

    public void FindObjectWithSameColor(Color objectColor)
    {
        foreach (GameObject wall in walls)
        {

            TrailRenderer trail = wall.GetComponentInChildren<TrailRenderer>();

            if(trail)
            {
                Color wallColor = wall.GetComponentInChildren<TrailRenderer>().startColor;

                if (wallColor == objectColor)
                {
                    wall.GetComponent<Animator>().SetTrigger("Hit");
                }
                else
                {
                    // Nothing
                }
            }
            else
            {
                // Nothing
            }
        }
    }
}
