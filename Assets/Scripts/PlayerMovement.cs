using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerStatsSO stats;

    [SerializeField] private List<Weapon> weapons;
    private Rigidbody2D _rb;
    public Vector2 MovementDirection { get; private set; }
    public Vector2 LastMovementDirection { get; private set; }

    public int Health { get; set; }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        foreach (var weapon in weapons)
        {
            weapon.Unlock(this);
        }

        Health = stats.hp;
        LastMovementDirection = Vector2.right;
    }


    // Update is called once per frame
    void Update()
    {
        if (InputManager.Instance.Test())
        {
        }


        MovementDirection = InputManager.Instance.GetMovement();
        if (MovementDirection != Vector2.zero)
            LastMovementDirection = MovementDirection;
    }

    private void FixedUpdate()
    {
        _rb.velocity = MovementDirection * (stats.speed * Time.fixedDeltaTime);
    }


    public void Damage(int dmg)
    {
        Health -= dmg;
    }

    public void Die()
    {
        Debug.Log("Die");
    }
}