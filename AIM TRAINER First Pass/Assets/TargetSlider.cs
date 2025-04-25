using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TargetSlider : MonoBehaviour
{
    Slider slider;
    public TMP_Text sliderText;
    void Start()
    {
        slider = GetComponent<Slider>();
        if (GameManager.numberOfTargets == 0)
        {
            UpdateValue();
        } else
        {
            slider.value = GameManager.numberOfTargets;
            UpdateValue();
        }
    }

    public void UpdateValue()
    {
        sliderText.text = "Number of Targets\n" + (int)slider.value;
        GameManager.numberOfTargets = (int) slider.value;
    }
}
