using System.Collections;
using UnityEngine;

public class PortalFadeOut : MonoBehaviour {
    [SerializeField] private float delayBeforeFade = 2f;
    [SerializeField] private float fadeDuration = 1.5f;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(delayBeforeFade);

        float elapsed = 0f;
        Color startColor = spriteRenderer.color;

        while (elapsed < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // В конце убедимся, что полностью исчез
        spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
    }
}
