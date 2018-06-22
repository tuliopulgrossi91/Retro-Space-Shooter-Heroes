using UnityEngine;
using UnityEngine.UI;

public class Select : MonoBehaviour
{
    public Button bt_Ok;
    public SpriteRenderer sp;
    public Sprite[] select;

    void Start()
    {
        Time.timeScale = 1;
    }

    public void SelectHeroes(int s)
    {
        PlayerPrefs.SetInt("Selected", s);
        sp.sprite = select[s];
        bt_Ok.interactable = true;
    }

    public void ConfirmOk()
    {
        Player.moved = true;
    }
}
