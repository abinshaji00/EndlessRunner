using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeaneMng : MonoBehaviour
{
    public TextMeshProUGUI Highscore;
    public void Start()
    {
        Highscore.text = "HighScore = " + ((int)PlayerPrefs.GetFloat("HighScore")).ToString();
    }
    public void newgame()
    {
        SceneManager.LoadScene("Game");
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void exit()
    {
        Application.Quit();
    }
}
