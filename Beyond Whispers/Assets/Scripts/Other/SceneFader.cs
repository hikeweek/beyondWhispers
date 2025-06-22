using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneFader : MonoBehaviour {
    public Image fadeImage;
    public float fadeDuration = 1.5f;

    void Start()
    {
        // Сразу делаем плавное появление
        StartCoroutine(FadeIn());
    }

    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    IEnumerator FadeIn()
    {
        float t = fadeDuration;
        while (t > 0)
        {
            t -= Time.deltaTime;
            float alpha = t / fadeDuration;
            SetAlpha(alpha);
            yield return null;
        }
        SetAlpha(0);
    }

    IEnumerator FadeOut(string sceneName)
    {
        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = t / fadeDuration;
            SetAlpha(alpha);
            yield return null;
        }

        SetAlpha(1);
        SceneManager.LoadScene(sceneName);
    }

    void SetAlpha(float a)
    {
        if (fadeImage != null)
        {
            Color c = fadeImage.color;
            c.a = Mathf.Clamp01(a);
            fadeImage.color = c;
        }
    }
}
