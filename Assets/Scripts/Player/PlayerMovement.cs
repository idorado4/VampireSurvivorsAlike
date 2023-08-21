using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerStatsSO stats;

    [SerializeField] private List<Weapon> weapons;
    private Rigidbody2D _rb;
    public Vector2 MovementDirection { get; private set; }
    public Vector2 LastMovementDirection { get; private set; }


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        foreach (var weapon in weapons)
        {
            weapon.Unlock(this);
        }

        LastMovementDirection = Vector2.right;
    }


    // Update is called once per frame
    void Update()
    {
        MovementDirection = InputManager.Instance.GetMovement();
        if (MovementDirection != Vector2.zero)
            LastMovementDirection = MovementDirection;
    }

    private void FixedUpdate()
    {
        _rb.velocity = MovementDirection * (stats.speed * Time.fixedDeltaTime);
    }
}