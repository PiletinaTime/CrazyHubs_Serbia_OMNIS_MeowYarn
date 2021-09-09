using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Debug : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Ptxt;
    [SerializeField]
    private Slider Pslider;
    [SerializeField]
    private TextMeshProUGUI MaxHPtxt;
    [SerializeField]
    private Slider MaxHPslider;
    [SerializeField]
    private TextMeshProUGUI MinHPtxt;
    [SerializeField]
    private Slider MinHPslider;
    [SerializeField]
    private TextMeshProUGUI CVtxt;
    [SerializeField]
    private Slider CVslider;
    [SerializeField]
    private TextMeshProUGUI Ntxt;
    [SerializeField]
    private Slider Nslider;
    [SerializeField]
    private TextMeshProUGUI Btxt;
    [SerializeField]
    private Slider Bslider;
    [SerializeField]
    private TextMeshProUGUI COtxt;
    [SerializeField]
    private Slider COslider;
    [SerializeField]
    private TextMeshProUGUI FOVtxt;
    [SerializeField]
    private Slider FOVslider;
    void Start()
    {
        Pslider.value = Movement.speed;
        MaxHPslider.value = Health.maxHealth;
        MinHPslider.value = Health.minHealth;
        CVslider.value = Collision.collectibleValue;
        Nslider.value = Needles.speed;
        Bslider.value = Blades.speed;
        COslider.value = -CameraFollow.offset;
        FOVslider.value = Camera.main.fieldOfView;
    }
    public void UpdatePlayerSpeed()
    {
        Ptxt.text = "Player speed: " + Pslider.value;
        Movement.speed = Pslider.value;
    }
    public void UpdateMaxHP()
    {
        MaxHPtxt.text = "Max health: " + MaxHPslider.value;
        Health.maxHealth = MaxHPslider.value;
    }
    public void UpdateMinHP()
    {
        MinHPtxt.text = "Min health: " + MinHPslider.value;
        Health.minHealth = MinHPslider.value;
    }
    public void UpdateCV()
    {
        CVtxt.text = "Collectible value: " + CVslider.value;
        Collision.collectibleValue = CVslider.value;
    }
    public void UpdateNeedlesSpeed()
    {
        Ntxt.text = "Needles speed: " + Nslider.value;
        Needles.speed = Nslider.value + (Nslider.maxValue - Nslider.value * 2 + Nslider.minValue);
    }
    public void UpdateBladesSpeed()
    {
        Btxt.text = "Blades speed: " + Bslider.value;
        Blades.speed = Bslider.value + (Bslider.maxValue - Bslider.value * 2 + Bslider.minValue);
    }
    public void UpdateCameraOffset()
    {
        COtxt.text = "Camera offset: " + COslider.value;
        CameraFollow.offset = -COslider.value;
    }
    public void UpdateCameraFOV()
    {
        FOVtxt.text = "Camera field of view: " + FOVslider.value;
        Camera.main.fieldOfView = FOVslider.value;
    }
    public void RevertToDefault()
    {
        Pslider.value = 10;
        Movement.speed = Pslider.value;
        MaxHPslider.value = 200;
        Health.maxHealth = MaxHPslider.value;
        MinHPslider.value = 20;
        Health.minHealth = MinHPslider.value;
        CVslider.value = 30;
        Collision.collectibleValue = CVslider.value;
        Nslider.value = 5;
        Bslider.value = 5;
        COslider.value = 10;
        CameraFollow.offset = -COslider.value;
        FOVslider.value = 60;
        Camera.main.fieldOfView = FOVslider.value;
    }
}