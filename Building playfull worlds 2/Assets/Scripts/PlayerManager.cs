using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] int pushSpeed;
    public float currendSpeed;
    //public int playerHealth;
    //[SerializeField] SpriteRenderer currentHealthSprite;
    //[SerializeField] Sprite HealthSprite1;
    //[SerializeField] Sprite HealthSprite2;
    //[SerializeField] Sprite HealthSprite3;

    private List<Color> colors;
    private SpriteRenderer playerColor;

    int colorNumber;

    public LayerMask whatStopsMovement;

    [SerializeField] GameObject resetPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerColor = GetComponent<SpriteRenderer>();

        colors = GameObject.Find("Game Manager").GetComponent<DivideColors>().colors;

        colorNumber = Random.Range(0, colors.Count);
        playerColor.color = colors[colorNumber];

        //playerHealth = 3;
        //currentHealthSprite.sprite = HealthSprite1;

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        ChangeColor();
    }

    private void ChangeColor()
    {

        // Als de speler stil staat dan
        if (!IsMoving())
        {
            // Als de spatie wordt ingedrukt
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // kleur nummer verhogen met 1
                colorNumber += 1;

                // Als alle kleuren zijn geweest dan
                if (colorNumber == colors.Count)
                {
                    // Pak weer 1e kleur
                    colorNumber = 0;
                }

                // Verander de speler van kleur
                playerColor.color = colors[colorNumber];
            }
        }         
    }

    private void Movement()
    {
        // Als de speler stil staat dan
        if (!IsMoving())
        {
            // Als geen muur boven de speler staat dan
            if(!Physics2D.OverlapCircle(transform.position + new Vector3(0, 0.5f, 0), 0.1f, whatStopsMovement))
            {
                // Als de pijltjes toets omhoog wordt ingedrukt dan
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    // Duw de speler naar boven
                    rb.velocity = new Vector2(0, pushSpeed);
                }
            }
            else
            {
                CallBlockSound();
            }
            if (!Physics2D.OverlapCircle(transform.position + new Vector3(0, -0.5f, 0), 0.1f, whatStopsMovement))
            {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    rb.velocity = new Vector2(0, -pushSpeed);
                }
            }
            else
            {
                CallBlockSound();
            }
            if (!Physics2D.OverlapCircle(transform.position + new Vector3(-0.5f, 0, 0), 0.1f, whatStopsMovement))
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    rb.velocity = new Vector2(-pushSpeed, 0);
                }
            }
            else
            {
                CallBlockSound();
            }
            if (!Physics2D.OverlapCircle(transform.position + new Vector3(0.5f, 0, 0), 0.1f, whatStopsMovement))
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    rb.velocity = new Vector2(pushSpeed, 0);
                }
            }
            else
            {
                CallBlockSound();
            }
        }
    }

    private void CallBlockSound()
    {
        GetComponent<WallBlockSound>().PlayPlayerBlockSound();
    }

    private bool IsMoving()
    {
        // Berkend de huidige snelheid van de speler
        currendSpeed = rb.velocity.magnitude;

        // Als de speler stil staat dan
        if (currendSpeed <= 0.1f)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Wall")
        {
            // Berekend de x en y positie van de speler en vertaald dit naar het midden van een vakje
            float xPositieSpeler = Mathf.Round(transform.position.x + 0.5f) - 0.5f;
            float yPositieSpeler = Mathf.Round(transform.position.y + 0.5f) - 0.5f;

            // Reset positie geheugen wordt gevuld
            Vector3 resetPlayerPosition = new Vector3(xPositieSpeler, yPositieSpeler, 0);

            // Spelers positie wordt weer recht gezet, zodat hij niet langs de muur schuift
            transform.position = resetPlayerPosition;
        }
    }

    //public void TakeDamage()
    //{
    //    playerHealth -= 1;

    //    if(playerHealth == 2)
    //    {
    //        currentHealthSprite.sprite = HealthSprite2;
    //    }
    //    else if(playerHealth == 1)
    //    {
    //        currentHealthSprite.sprite = HealthSprite3;
    //    }

    //    if(playerHealth <= 0)
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}

    public void ResetPosition()
    {
        transform.position = resetPosition.transform.position;
    }

    public void ResetVelocity()
    {
        rb.velocity = new Vector2(0, 0);
    }
}
