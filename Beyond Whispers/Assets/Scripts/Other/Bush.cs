using UnityEngine;

public class Bush : MonoBehaviour {
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private int coinsToDrop = 3;

    public void DestroyBush()
    {
        SpawnCoins();
        Destroy(gameObject);
    }

    private void SpawnCoins()
    {
        for (int i = 0; i < coinsToDrop; i++)
        {
            Vector3 dropPosition = transform.position + (Vector3)Random.insideUnitCircle * 0.5f;
            Instantiate(coinPrefab, dropPosition, Quaternion.identity);
        }
    }
}
