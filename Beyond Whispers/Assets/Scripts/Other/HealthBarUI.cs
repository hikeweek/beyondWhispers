using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    [Header("От 0 до 5 HP с шагом 0.5 (всего 11 спрайтов)")]
    public Sprite[] healthSprites;

    public Image healthImage;
    private float maxHealth = 5f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(float amount)
    {
        SetHealth(currentHealth - amount);
    }

    public void Heal(float amount)
    {
        SetHealth(currentHealth + amount);
    }

    // 🔧 Добавлен метод SetHealth для совместимости с Player.cs
    public void SetHealth(float newHealth)
    {
        currentHealth = Mathf.Clamp(newHealth, 0f, maxHealth);
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        int spriteIndex = Mathf.RoundToInt(currentHealth * 2f); // шаг 0.5 => 0–10
        spriteIndex = Mathf.Clamp(spriteIndex, 0, healthSprites.Length - 1);
        healthImage.sprite = healthSprites[spriteIndex];
    }
}