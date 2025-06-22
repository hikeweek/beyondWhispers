using UnityEngine;

public class PortalActivator : MonoBehaviour {
    public GameObject portal;

    void Start()
    {
        portal.SetActive(false);
    }

    void Update()
    {
        int skeletonCount = GameObject.FindGameObjectsWithTag("Skeleton").Length;
        Debug.Log("Скелетов осталось: " + skeletonCount);

        if (skeletonCount == 0)
        {
            Debug.Log("Все скелеты уничтожены! Активируем портал.");
            portal.SetActive(true);
            enabled = false;
        }
    }
}
