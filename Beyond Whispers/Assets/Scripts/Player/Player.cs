using System;
using System.Collections;
using UnityEngine;

[SelectionBase]
public class Player : MonoBehaviour {
    public static Player Instance { get; private set; }
    public event EventHandler OnPlayerDeath;
    public DeathHandler deathHandler; // dobavil

    [Header("UI")]
    public HealthBar healthBar;

    [Header("Player Stats")]
    [SerializeField] private float _movingSpeed = 5f;
    [SerializeField] private float _maxHealth = 5f;
    [SerializeField] private float _damageRecoveryTime = 0.5f;

    private float _currentHealth;
    private bool _canTakeDamage;
    private bool _isAlive;

    private Vector2 inputVector;
    private Rigidbody2D _rb;
    private KnockBack _knockBack;

    private float _minMovingSpeed = 0.1f;
    private bool _isRunning = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        Instance = this;
        _knockBack = GetComponent<KnockBack>();
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
        _canTakeDamage = true;
        _isAlive = true;

        if (GameInput.Instance != null)
            GameInput.Instance._OnPlayerAttack += GameInput_OnPlayerAttack;

        if (healthBar != null)
            healthBar.SetHealth(_currentHealth);
    }

    private void Update()
    {
        inputVector = GameInput.Instance.GetMovementVector();
    }

    private void FixedUpdate()
    {
        if (_knockBack.IsGettingKnockedBack)
            return;

        HandleMovement();
    }

    public bool IsAlive()
    {
        return _isAlive;
    }

    public void TakeDamage(Transform damageSource, float damage)
    {
        if (_canTakeDamage && _isAlive)
        {
            _canTakeDamage = false;
            _currentHealth = Mathf.Max(0, _currentHealth - damage);
            Debug.Log("Current Health: " + _currentHealth);

            if (healthBar != null)
                healthBar.SetHealth(_currentHealth);

            StartCoroutine(DamageRecoveryRoutine());
        }

        DetectDeath();
    }

    private void DetectDeath()
    {
        if (_currentHealth <= 0 && _isAlive)
        {
            _isAlive = false;
            _knockBack.StopKnockBackMovement();
            GameInput.Instance.DisableMovement();

            OnPlayerDeath?.Invoke(this, EventArgs.Empty);
            deathHandler.HandleDeath(); // dobavil
        }

    }

    private IEnumerator DamageRecoveryRoutine()
    {
        yield return new WaitForSeconds(_damageRecoveryTime);
        _canTakeDamage = true;
    }

    private void HandleMovement()
    {
        _rb.MovePosition(_rb.position + inputVector * (_movingSpeed * Time.fixedDeltaTime));
        _isRunning = (Mathf.Abs(inputVector.x) > _minMovingSpeed || Mathf.Abs(inputVector.y) > _minMovingSpeed);
    }

    public bool IsRunning()
    {
        return _isRunning;
    }

    private void GameInput_OnPlayerAttack(object sender, EventArgs e)
    {
        if (ActiveWeapon.Instance != null && ActiveWeapon.Instance.GetActiveWeapon() != null)
        {
            ActiveWeapon.Instance.GetActiveWeapon().Attack();
        }
    }

    public Vector3 GetPlayerScreenPosition()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnDisable()
    {
        if (GameInput.Instance != null)
            GameInput.Instance._OnPlayerAttack -= GameInput_OnPlayerAttack;
    }
}