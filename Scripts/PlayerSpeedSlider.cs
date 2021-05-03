using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerSpeedSlider : MonoBehaviour
{
    private TextMeshProUGUI txt;
    [SerializeField]
    private Slider slider;
    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
        slider.value = Movement.speed;
    }
    public void UpdateSpeed()
    {
        txt.text = "Player speed: " + slider.value;
        Movement.speed = slider.value;
    }
}
