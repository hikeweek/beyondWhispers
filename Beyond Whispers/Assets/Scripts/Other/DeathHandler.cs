using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathHandler : MonoBehaviour {
    public Image deathImage; // Сюда перетянешь UI-изображение
    public float fadeDuration = 2f;
    public float delayBeforeRestart = 5f;
    public string sceneToLoad = "Level1"; // Название сцены

    public void HandleDeath()
    {
        StartCoroutine(DeathSequence());
    }

    private IEnumerator DeathSequence()
    {
        float timer = 0f;
        Color color = deathImage.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(0, 1, timer / fadeDuration);
            deathImage.color = color;
            yield return null;
        }

        yield return new WaitForSeconds(delayBeforeRestart);
        SceneManager.LoadScene(sceneToLoad);
    }
}
