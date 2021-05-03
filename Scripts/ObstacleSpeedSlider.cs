using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ObstacleSpeedSlider : MonoBehaviour
{
    private TextMeshProUGUI txt;
    [SerializeField]
    private Slider slider;
    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
        slider.value = Needles.speed;
    }
    public void UpdateObstacleSpeed()
    {
        txt.text = "Obstacle speed: " + slider.value;
        Needles.speed = Blades.speed = slider.value + ((slider.maxValue - slider.value * 2) + slider.minValue); //please ignore this awful calculation
    }
}



