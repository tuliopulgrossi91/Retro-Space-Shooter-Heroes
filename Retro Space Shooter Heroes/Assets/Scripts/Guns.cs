using UnityEngine;

public class Guns : MonoBehaviour
{
    public GameObject bullet;

    void Start()
    {
        InvokeRepeating("NextBullet", 0, 0.5f);
    }

    void Update()
    {
        if (Death.life == 0)
        {
            Player.shot2 = false;
            GameObject.FindGameObjectWithTag("Guns").SetActive(false);
        }
    }

    void NextBullet()
    {
        if (Player.shot2 == true)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}