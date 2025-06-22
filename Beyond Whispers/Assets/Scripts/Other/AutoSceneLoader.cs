using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoSceneLoader : MonoBehaviour {
    public string sceneToLoad = "Menu";   // �������� �����
    public float delay = 5f;              // �������� � ��������

    void Start()
    {
        Invoke("LoadNextScene", delay);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
