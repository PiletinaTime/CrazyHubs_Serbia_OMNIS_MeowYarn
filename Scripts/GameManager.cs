using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameObject settings;
    public static GameObject Controls;
    public static Animation anim;
    private static GameObject canvas;
    private static GameObject gameover;
    private static GameObject finish;
    private static TextMeshProUGUI finishText;
    private bool Paused;
    public static bool startGame;
    private static bool created = false;
    private void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this);
            created = true;
        }
        startGame = false;
        canvas = GameObject.Find("Canvas");
        gameover = canvas.transform.Find("GameOver").gameObject;
        finish = canvas.transform.Find("Finish").gameObject;
        finishText = finish.GetComponentInChildren<TextMeshProUGUI>();
        settings = canvas.transform.Find("Debug").gameObject;
        Controls = canvas.transform.Find("Controls").gameObject;
        anim = FindObjectOfType<Animation>();
    }
    private void Update()
    {
        if (Controls.activeSelf)
        {
            if (Input.touchCount > 0)
            {
                Controls.SetActive(false);
                startGame = true;
                anim.Play();
            }
        }
    }
    public void PauseUnPause()
    {
        if (!finish.activeInHierarchy && !gameover.activeInHierarchy && !Collision.finish)
        {
            if (Paused)
            {
                settings.SetActive(false);
                Time.timeScale = 1.0f;
                Paused = false;
            }
            else
            {
                Paused = true;
                settings.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
    }
    public static void Finish()
    {
        Time.timeScale = 0.0f;
        finishText.text = "You finished level: " + GenerateMap.level;
        finish.SetActive(true);
    }
    public static void GameOver()
    {
        Time.timeScale = 0.0f;
        Collision.collectibleValue = 30;
        gameover.SetActive(true);
    }
    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
    public void NextLevel()
    {
        GenerateMap.level++;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
}