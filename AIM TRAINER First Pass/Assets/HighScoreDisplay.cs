using TMPro;
using UnityEngine;

public class HighScoreDisplay : MonoBehaviour
{
    public TMP_Text lastScoreText;
    public TMP_Text highScoreText;
    void Start()
    {
        lastScoreText.text = "You broke " + GameManager.numberOfTargets + " targets in " + GameManager.lastScore + " seconds";

        float highScore = Mathf.Min(GameManager.lastScore, GameManager.highScores[GameManager.numberOfTargets - 1]);
        if (highScore == 0)
        {
            highScore = GameManager.lastScore;
        }
        GameManager.highScores[GameManager.numberOfTargets - 1] = highScore;

        highScoreText.text = "High score for " + GameManager.numberOfTargets + " targets is " + highScore;
        if (highScore == GameManager.lastScore)
        {
            highScoreText.text += "\nNEW HIGH SCORE";
        }
    }
}
