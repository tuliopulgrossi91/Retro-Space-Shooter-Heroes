using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject bulletNPC;
    float speed = 2;
    Rigidbody2D rb2d;
    public static bool i, lifes;
    public static int life;
    int m;
    public GameObject[] npcLifes;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        transform.rotation = Quaternion.Euler(0, 0, 180);
        m = Random.Range(0, 2);
        InvokeRepeating("NextBulletNPC", 0, 2f);
        Moves();
    }

    void Update()
    {
        if (lifes == false)
        {
            npcLifes[0].SetActive(false);
            npcLifes[1].SetActive(false);
            npcLifes[2].SetActive(false);
        }
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

    void NextBulletNPC()
    {
        Instantiate(bulletNPC, transform.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Bullet")
        {
            if (lifes == true)
            {
                life--;
                npcLifes[life].SetActive(false);

                if (life == 0)
                {
                    Destroy(gameObject);
                    GameScene.s = GameScene.s + 10;
                    GameScene.n = GameScene.n - 1;
                    GameScene3.s = GameScene3.s + 10;
                    GameScene3.n = GameScene3.n - 1;
                    NextNPC.d = true;
                }
            }
            if (lifes == false)
            {
                Destroy(gameObject);
                GameScene.s = GameScene.s + 10;
                GameScene.n = GameScene.n - 1;
                GameScene3.s = GameScene3.s + 10;
                GameScene3.n = GameScene3.n - 1;
                NextNPC.d = true;
            }
        }
    }

    void OnBecameInvisible()
    {
        if (GameScene.n > 0 || GameScene2.c > 0 || GameScene3.n > 0)
        {
            i = true;
            Destroy(gameObject);
        }
    }
}