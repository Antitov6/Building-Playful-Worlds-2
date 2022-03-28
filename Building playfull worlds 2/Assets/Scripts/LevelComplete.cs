using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{

    private List<GameObject> walls;
    private Component[] sprites;

    private void Start()
    {
        walls = GameObject.Find("Game Manager").GetComponent<DivideColors>().walls;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            foreach (GameObject wall in walls)
            {
                //sprites = wall.GetComponentsInChildren<TrailRenderer>();

                //// Voor elk kind van muur
                //foreach (TrailRenderer sprite in sprites)
                //{
                //    // Verander de kleur
                //    sprite.startColor = Color.black;
                //    sprite.endColor = Color.black;
                //}

                wall.GetComponent<Animator>().SetTrigger("Hit");

                StartCoroutine(NextLevel());
            }
        }
    }

    private IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(3.5f);
        FindObjectOfType<SceneMana>().LoadNextScene();
    }

}
