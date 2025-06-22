using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinCounter : MonoBehaviour {
    public static CoinCounter Instance { get; private set; }

    private Text coinText;    // Ссылка на текст UI монет
    private int coinCount = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.Log("Duplicate CoinCounter destroyed");
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Корневой объект сохраняется при смене сцен
        SceneManager.sceneLoaded += OnSceneLoaded;

        Debug.Log("CoinCounter initialized");
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        Debug.Log("CoinCounter unsubscribed from sceneLoaded event");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Ищем объект CoinUI на сцене (там должен быть CoinUI.cs)
        CoinUI coinUI = FindObjectOfType<CoinUI>();
        if (coinUI != null)
        {
            coinText = coinUI.GetComponentInChildren<Text>();
            Debug.Log($"Scene loaded: {scene.name}. CoinUI found → Text updated.");
        }
        else
        {
            coinText = null;
            Debug.LogWarning($"Scene loaded: {scene.name}. CoinUI NOT found!");
        }

        UpdateUI(); // После нахождения текста сразу обновляем UI
    }

    public void AddCoins(int amount)
    {
        coinCount += amount;
        Debug.Log($"Coins added: {amount}, total coins: {coinCount}");
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coinCount;
        }
        else
        {
            Debug.LogWarning("coinText is null, UI not updated.");
        }
    }
}