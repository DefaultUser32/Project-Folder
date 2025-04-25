using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TargetSlider : MonoBehaviour
{
    public TMP_Text sliderText;
    public TMP_Text highScoreText;
    Slider slider;
    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = GameManager.numberOfTargets;
        sliderText.text = slider.value.ToString();
    }
    public void UpdateSlider()
    {
        GameManager.numberOfTargets = (int) slider.value;
        sliderText.text = slider.value.ToString();
        if (GameManager.highScores.TryGetValue(GameManager.numberOfTargets, out float highScore))
        {
            highScoreText.text = "High Score:\n" + highScore.ToString("F2") + " Seconds";
        } else
        {
            highScoreText.text = "NO SCORE SET";
        }
    }
}
