using UnityEngine;

public class Life : MonoBehaviour
{
    float x, y;
    public static bool d;
    Vector2 v2;

    void Start()
    {
        d = false;
        Called();
    }

    void Called()
    {
        x = Random.Range(-7.45f, 7.45f);
        y = Random.Range(-2.5f, 2.5f);
        v2 = new Vector2(x, y);
        transform.position = v2;
    }
}