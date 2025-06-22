using UnityEngine;
using UnityEngine.UI;

public class ScreenSettings : MonoBehaviour {
    public Toggle fullscreenToggle;

    void Start()
    {
        if (fullscreenToggle == null)
        {
            Debug.LogError("Toggle �� �������� � ����������!");
            return;
        }

        // �������� ������������� ����� ��� ������ ����
        Screen.fullScreen = true;

        // ������������� ��������� Toggle � ������������ � ������� �������
        fullscreenToggle.isOn = Screen.fullScreen;

        // ������������� �� ������� ������������ Toggle
        fullscreenToggle.onValueChanged.AddListener(SetFullscreen);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log("Fullscreen mode set to: " + isFullscreen);
    }
}
