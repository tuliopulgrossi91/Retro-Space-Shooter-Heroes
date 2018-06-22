using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Vector3 d;
    float x, y;
    public static bool loser;
    float speed = 10;
    Rigidbody2D rb2d;
    public static bool moved, shot, shot2, lifes;
    public GameObject bullet;
    public static int life;
    SpriteRenderer sp;
    public Sprite[] select;
    public GameObject[] playerLifes;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        sp.sprite = select[PlayerPrefs.GetInt("Selected")];
        loser = false;
        moved = false;
        shot = false;
        shot2 = false;
        rb2d = GetComponent<Rigidbody2D>();
        InvokeRepeating("NextBullet", 0, 0.5f);
    }

    void Update()
    {
        if (lifes == false)
        {
            playerLifes[0].SetActive(false);
            playerLifes[1].SetActive(false);
            playerLifes[2].SetActive(false);
        }

        if (moved == true)
        {
            rb2d.velocity = Vector2.up * speed;
        }
        if (GameScene.t < 0)
        {
            gameObject.SetActive(false);
        }
        if (Time.timeScale == 0)
        {
            gameObject.SetActive(false);
        }
    }

    void NextBullet()
    {
        if (shot == true)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }

    void OnMouseDown()
    {
        if (moved == false)
        {
            d = Camera.main.WorldToScreenPoint(transform.position);
            x = Input.mousePosition.x - d.x;
            y = Input.mousePosition.y - d.y;
        }
    }

    void OnMouseDrag()
    {
        if (moved == false)
        {
            Vector2 l = new Vector2(Input.mousePosition.x - x, Input.mousePosition.y - y);
            Vector2 w = Camera.main.ScreenToWorldPoint(l);
            transform.position = w;
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "NPC" || c.gameObject.tag == "Death")
        {
            if (lifes == true)
            {
                life--;
                playerLifes[life].SetActive(false);

                if (life == 0)
                {
                    gameObject.SetActive(false);
                    loser = true;
                }
            }
            if (lifes == false)
            {
                gameObject.SetActive(false);
                loser = true;
            }
        }
        if (c.gameObject.tag == "BulletNPC" || c.gameObject.tag == "BulletDeath")
        {
            if (lifes == true)
            {
                life--;
                playerLifes[life].SetActive(false);

                if (life == 0)
                {
                    gameObject.SetActive(false);
                    Time.timeScale = 0;
                    loser = true;
                }
            }
            if (lifes == false)
            {
                gameObject.SetActive(false);
                Time.timeScale = 0;
                loser = true;
            }

        }
        if (c.gameObject.tag == "Coin")
        {
            if (lifes == false)
            {
                moved = true;
                Coin.d = true;
            }
            if (lifes == true)
            {
                if (GameScene2.c > 0)
                {
                    GameScene2.c--;
                    Coin.d = true;
                }
                if (GameScene2.c == 0)
                {
                    moved = true;
                }
                if (Death.life == 0)
                {
                    moved = true;
                    Coin.d = true;
                }
            }
        }
        if (c.gameObject.tag == "PowerUp")
        {
            PowerUp.d = true;
            shot2 = true;
        }
        if (c.gameObject.tag == "Life")
        {
            if (life < 3)
            {
                life++;
                playerLifes[life].SetActive(true);
            }
            Life.d = true;
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.tag == "Select")
        {
            SceneManager.LoadScene(2);
        }
    }

    void OnTriggerStay2D(Collider2D c)
    {
        if (c.gameObject.tag == "Borders")
        {
            if (moved == false)
            {
                loser = true;
                gameObject.SetActive(false);
            }
            else
            {
                loser = false;
                gameObject.SetActive(true);
            }
            Time.timeScale = 0;
        }
    }
}