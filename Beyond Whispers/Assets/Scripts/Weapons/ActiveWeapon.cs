using UnityEngine;

public class ActiveWeapon : MonoBehaviour {
    public static ActiveWeapon Instance { get; private set; }

    [SerializeField] private Sword sword;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Player.Instance != null && Player.Instance.IsAlive()) // 21.06 fix
            FollowMousePosition();
    }

    public Sword GetActiveWeapon()
    {
        return sword;
    }

    private void FollowMousePosition()
    {
        if (GameInput.Instance == null || Player.Instance == null) return; // 21.06 fix

        Vector3 mousePos = GameInput.Instance.GetMousePositon();
        Vector3 playerPosition = Player.Instance.GetPlayerScreenPosition();

        if (mousePos.x < playerPosition.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

}
