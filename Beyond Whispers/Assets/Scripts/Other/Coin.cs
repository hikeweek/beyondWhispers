using UnityEngine;

public class Coin : MonoBehaviour {
    [SerializeField] private float attractDistance = 3f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private int coinValue = 1;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player")?.transform;
    }

    private void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);
        if (distance < attractDistance)
        {
            // плавное движение к игроку
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (CoinCounter.Instance != null)
            {
                CoinCounter.Instance.AddCoins(coinValue);
            }
            else
            {
                Debug.LogError("CoinCounter.Instance is null!");
            }
            Destroy(gameObject);
        }
    }
}
