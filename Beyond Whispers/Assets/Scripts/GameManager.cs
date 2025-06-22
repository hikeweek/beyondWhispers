using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }

    public bool IsGamePaused { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        IsGamePaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        IsGamePaused = false;
    }
}
