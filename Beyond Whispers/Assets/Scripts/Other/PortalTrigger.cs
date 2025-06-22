using UnityEngine;

public class PortalTrigger2D : MonoBehaviour {
    public GameObject portalButton;

    private void Start()
    {
        if (portalButton != null)
            portalButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("2D ���� � ����: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("��� �����! ���������� ������.");
            portalButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && portalButton != null)
        {
            portalButton.SetActive(false);
        }
    }

}
