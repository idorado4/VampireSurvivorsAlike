using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private CharacterStatsSO stats;
    
    private Rigidbody2D _rb;
    private Vector2 _movementInputValue;
    
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _movementInputValue = InputManager.Instance.GetMovement();
        _rb.velocity = _movementInputValue * (stats.speed * Time.fixedDeltaTime);
    }
}
