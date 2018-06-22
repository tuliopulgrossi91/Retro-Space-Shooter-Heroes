using UnityEngine;

public class NextNPC : MonoBehaviour
{
    public GameObject go; // OBJETO NPC
    public SpriteRenderer sprtRend; // SPRITE DO OBJETO
    float x, y, randC0, randC1, randC2; // VALORES ALEATORIOS
    Vector2 obj; // VETOR 2 DE POSICAO
    public static bool d; //VERIFICAR DESTRUICAO

    void Start()
    {
        d = false; // OBJETO ATIVO
        Next(); // CHAMAR NOVO OBJETO
    }

    void Update()
    {
        if (d == true) // SE DESTRUIDO
        {
            d = !d; // RECEBE FALSO
            Next(); // CHAMAR NOVO OBJETO 
        }
        if (NPC.i == true) // FICOU FORA DA TELA
        {
            NPC.i = !NPC.i; // NÃO FICOU FORA DA TELA
            Next(); // CHAMAR NOVO OBJETO
        }
        if (Time.timeScale == 0)
        {
            gameObject.SetActive(false);
        }
    }

    void Next()
    {
        if (d == false || NPC.i == true) // SE NÃO DESTRUIDO OU FICOU FORA DA TELA
        {
            // RECEBE COR RANDOMICA
            randC0 = Random.Range(0f, 1f);
            randC1 = Random.Range(0f, 1f);
            randC2 = Random.Range(0f, 1f);
            sprtRend.color = new Color(randC0, randC1, randC2, 1);

            // RECEBE NOVA POSICÃO RANDOMICA
            x = Random.Range(-7.45f, 7.45f);
            y = Random.Range(-2.5f, 2.5f);
            obj = new Vector2(x, y);

            // É INSTANCIADO
            Instantiate(go, obj, Quaternion.identity);

            // SE TIVER VIDAS RECEBE 3
            if (NPC.lifes == true)
            {
                NPC.life = 3;
            }
            // SENAO RECEBE 0
            else
            {
                NPC.life = 0;
            }
        }
    }
}