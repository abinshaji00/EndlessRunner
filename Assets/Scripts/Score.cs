using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float score = 0f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI Gems;
    public int Difficultylevel = 1;
    private int MaxDifficulty = 10;
    private int ScoreToNextLevel = 10;
    private bool isdead=false;
    public EndGame endGame;
    public float Gem = 0;

    public void Update()
    {
        if (isdead) return;
        

        if(score>=ScoreToNextLevel)
        {
            levelUp();
        }
        score += Time.deltaTime*Difficultylevel;
        scoreText.text = "Distence : " +((int)score).ToString();
     
    }
    public void levelUp()
    {
        if (Difficultylevel == MaxDifficulty)
            return;
        ScoreToNextLevel *= 2;
        Difficultylevel++;
        GetComponent<Playermovement>().setSpeed(Difficultylevel);
    }
    public void OnTriggerEnter(Collider other)
    {
        other.gameObject.CompareTag("Gems");
        Gem++;
        Gems.text = "Gems : " + ((int)Gem).ToString();
    }
    public void onDeth()
    {
        isdead = true;
        
        endGame.toggleEndScore(score,Gem);
    }

}
