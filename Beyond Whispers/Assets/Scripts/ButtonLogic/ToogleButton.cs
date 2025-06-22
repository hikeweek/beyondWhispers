using UnityEngine;
using UnityEngine.UI;

public class ScreenSettings : MonoBehaviour {
    public Toggle fullscreenToggle;

    void Start()
    {
        if (fullscreenToggle == null)
        {
            Debug.LogError("Toggle не назначен в инспекторе!");
            return;
        }

        // Включаем полноэкранный режим при старте игры
        Screen.fullScreen = true;

        // Устанавливаем состояние Toggle в соответствии с текущим режимом
        fullscreenToggle.isOn = Screen.fullScreen;

        // Подписываемся на событие переключения Toggle
        fullscreenToggle.onValueChanged.AddListener(SetFullscreen);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log("Fullscreen mode set to: " + isFullscreen);
    }
}
