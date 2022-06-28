using UnityEngine;
using TMPro;

public class SnakeScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI finalScore;
    private int finalScoreAfterDie;
    private int score = 0;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        finalScore = GetComponent<TextMeshProUGUI>();

    }

    private void Start()
    {
        RefreshUI();
    }
    public void IncreaseScore(int increament)
    {
        score += increament;
        
        RefreshUI();
        finalScoreAfterDie = score;
        //FinalScoreWhenDie();

        PlayerPrefs.SetInt("Score : ", score);
    }

    public void RefreshUI()
    {
        scoreText.text = "Score : " + score;
        
    }

    public void FinalScoreWhenDie()
    {

        //finalScoreAfterDie = score;
        finalScore.text = PlayerPrefs.GetInt("Score", 0).ToString();
        Debug.Log("Final Score " + finalScoreAfterDie);
    }
}
