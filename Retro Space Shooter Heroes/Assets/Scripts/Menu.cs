using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject panelMenu, panelCredits, panelExit, panelReadMe;
    public bool check;

    public void Buttons(int b)
    {
        // start game
        if (b == 0)
        {
            SceneManager.LoadScene(1);
        }
        // credits
        if (b == 1)
        {
            panelMenu.SetActive(check);
            panelCredits.SetActive(!check);
        }
        // exit
        if (b == 2)
        {
            panelMenu.SetActive(check);
            panelExit.SetActive(!check);
        }
        // back
        if (b == 3)
        {
            GameObject.FindGameObjectWithTag("back").SetActive(check);
            panelMenu.SetActive(!check);
        }
        // confirm exit
        if (b == 4)
        {
            Application.Quit();
        }
        // read me
        if (b == 5)
        {
            GameObject.FindGameObjectWithTag("back").SetActive(check);
            panelReadMe.SetActive(!check);
        }
    }
}