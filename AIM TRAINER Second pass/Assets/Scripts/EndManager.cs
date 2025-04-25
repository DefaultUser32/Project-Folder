using TMPro;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    public TMP_Text timeText;
    public TMP_Text highScoreText;
    private void Start()
    {
        string formattedTime = GameManager.lastTime.ToString("F2");
        timeText.text = "You destroyed " + GameManager.numberOfTargets + " targets in " + formattedTime + " seconds";

        if (GameManager.highScores[GameManager.numberOfTargets] == GameManager.lastTime)
        {
            highScoreText.text = "NEW HIGH SCORE";
        } else
        {
            highScoreText.text = "High Score: " + GameManager.highScores[GameManager.numberOfTargets].ToString("F2");
        }
    }
}
