using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public TextMeshProUGUI ScoreTxt;
    public float Finalscore;
    
    void Start()
    {
        gameObject.SetActive(false);
    }
    public void toggleEndScore(float score,float gems)
    {
        gameObject.SetActive(true);
        Finalscore = score + (gems * 10);
        ScoreTxt.text = "FinalScore : "+((int)Finalscore).ToString();
        PlayerPrefs.SetFloat("HighScore", Finalscore);
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
