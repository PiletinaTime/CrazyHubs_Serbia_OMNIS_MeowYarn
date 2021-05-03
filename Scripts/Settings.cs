using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private GameObject settings;
    [SerializeField]
    private GameObject finish;
    [SerializeField]
    private GameObject gameover;
    [SerializeField]
    private GameObject PressAnywhere;
    private bool Paused;
    public static bool startGame;
    private void Start()
    {
        startGame = false;
    }
    private void Update()
    {
        if (PressAnywhere.activeInHierarchy)
        {
            if (Input.touchCount > 0)
            {
                PressAnywhere.SetActive(false);
                startGame = true;
                Health health = transform.GetChild(0).GetChild(1).GetComponent<Health>();
                health.reduceHP = StartCoroutine(health.ReduceHealthGradually(10));
            }
        }
    }
    public void PauseUnPause()
    {
        if (!finish.activeInHierarchy && !gameover.activeInHierarchy && !Collision.finish && !PressAnywhere.activeInHierarchy)
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
    public void Finish()
    {
        finish.SetActive(true);
        Time.timeScale = 0.0f;
    }
    public void GameOver()
    {
        Time.timeScale = 0.0f;
        gameover.SetActive(true);
    }
    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);

    }
}
