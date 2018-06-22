using UnityEngine;

public class Death : MonoBehaviour {

    public SpriteRenderer sprtRend; // SPRITE DO OBJETO
    float randC0, randC1, randC2; // VALORES ALEATORIO
    public GameObject bulletDeath;
    float speed = 2;
    Rigidbody2D rb2d;
    public static int life = 10;
    int m;
    public GameObject[] deathLifes;

    void Start()
    {
        // RECEBE COR RANDOMICA
        randC0 = Random.Range(0f, 1f);
        randC1 = Random.Range(0f, 1f);
        randC2 = Random.Range(0f, 1f);
        sprtRend.color = new Color(randC0, randC1, randC2, 1);

        rb2d = GetComponent<Rigidbody2D>();
        transform.rotation = Quaternion.Euler(0, 0, 180);
        m = Random.Range(0, 2);
        InvokeRepeating("NextBulletDeath", 0, 2f);
        Moves();
    }

    void Moves()
    {
        if (m == 0)
        {
            Invoke("ChangeLeft", 1);
        }
        if (m == 1)
        {
            Invoke("ChangeDown", 1);
        }
    }

    void ChangeLeft()
    {
        rb2d.velocity = Vector2.left * speed;
        Invoke("ChangeRight", 1);
    }

    void ChangeRight()
    {
        rb2d.velocity = Vector2.right * speed;
        Invoke("ChangeLeft", 1);
    }

    void ChangeUp()
    {
        rb2d.velocity = Vector2.up * speed;
        Invoke("ChangeDown", 1);
    }

    void ChangeDown()
    {
        rb2d.velocity = Vector2.down * speed;
        Invoke("ChangeUp", 1);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Bullet")
        {
            life--;
            deathLifes[life].SetActive(false);

            if (life == 0)
            {
                Player.shot = false;
                Coin.d = false;
            }
        }
    }

    void NextBulletDeath()
    {
        Instantiate(bulletDeath, transform.position, Quaternion.identity);
    }
}
