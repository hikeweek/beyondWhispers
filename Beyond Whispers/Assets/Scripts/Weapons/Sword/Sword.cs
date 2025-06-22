using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    [SerializeField] private int _damageAmount = 2;

    public event EventHandler OnSwordSwing;

    private PolygonCollider2D _polygonCollider2D;

    private void Awake()
    {
        _polygonCollider2D = GetComponent<PolygonCollider2D>();
    }

    private void Start()
    {
        AttackColiderTurnOff();
    }
    public void Attack()
    {
        // if (GameManager.Instance.IsGamePaused) return; // dobavil dlya pausi 1 fix osh1bki menu

        if (_polygonCollider2D == null) return;

        AttackColliderTurnOffOn();

        OnSwordSwing?.Invoke(this, EventArgs.Empty);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bush bush))
        {
            bush.DestroyBush();
            return;
        }

        if (collision.transform.TryGetComponent(out EnemyEntity enemyEntity))
        {
            enemyEntity.TakeDamage(_damageAmount);
        }
    }

    public void AttackColiderTurnOff()
    {
       //if (_polygonCollider2D == null) return;
        _polygonCollider2D.enabled = false;
    }

    private void AttackColiderTurnOn()
    {
        _polygonCollider2D.enabled = true;
    }

    private void AttackColliderTurnOffOn()
    {
        AttackColiderTurnOff();
        AttackColiderTurnOn();
    }

}