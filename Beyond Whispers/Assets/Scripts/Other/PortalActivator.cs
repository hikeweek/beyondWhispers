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
        Debug.Log("�������� ��������: " + skeletonCount);

        if (skeletonCount == 0)
        {
            Debug.Log("��� ������� ����������! ���������� ������.");
            portal.SetActive(true);
            enabled = false;
        }
    }
}
