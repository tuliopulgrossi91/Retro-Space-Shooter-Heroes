using UnityEngine;

public class BulletDeath : MonoBehaviour {

    public SpriteRenderer sprtRend; // SPRITE DO OBJETO
    float randC0, randC1, randC2; // VALORES ALEATORIO
    float speed = 5; // VELOCIDADE
    Rigidbody2D rb2d; // CORPO RIGIDO

    void Start()
    {
        // RECEBE COR RANDOMICA
        randC0 = Random.Range(0f, 1f);
        randC1 = Random.Range(0f, 1f);
        randC2 = Random.Range(0f, 1f);
        sprtRend.color = new Color(randC0, randC1, randC2, 1);

        rb2d = GetComponent<Rigidbody2D>(); // PEGANDO O CORPO RIGIDO
        rb2d.velocity = Vector2.down * speed; // TIRO PARA BAIXO
        transform.rotation = Quaternion.Euler(0, 0, 180);
    }

    void LateUpdate()
    {
        if (Death.life == 0) // SE MOVIMENTO DO JOGADOR É ATIVADO
        {
            Destroy(gameObject); // DESTROI OBJETO
        }
        if (Time.timeScale == 0)
        {
            gameObject.SetActive(false);
        }
    }

    // METODO DE COLISAO TRIGGER
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Bullet") // SE COLIDIR COM TIRO DO PLAYER
        {
            Destroy(gameObject); // DESTROI OBJETO
        }
        if (c.gameObject.tag == "Player") // SE COLIDIR COM PLAYER
        {
            if (Player.lifes == false)  // SE VIDAS DO PLAYER FOR 0
            {
                Destroy(gameObject); // DESTROI OBJETO
                Time.timeScale = 0; // O TEMPO PARA
                Player.loser = true; // O JOGADOR PERDE
            }
            if (Player.lifes == true)  // SE VIDAS DO PLAYER FOR 0
            {
                Destroy(gameObject); // DESTROI OBJETO
            }
        }
    }

    // METODO TORNAR-SE INVISIVEL - SAIR DA TELA
    void OnBecameInvisible()
    {
        Destroy(gameObject); // DESTROI OBJETO
    }
}
