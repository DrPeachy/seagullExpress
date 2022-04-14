using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private PlayerAction _playerAction;
    public float movSpeed;
    private Rigidbody2D _rig;
    public Vector2 velo;
    void Start()
    {
        _playerAction = new PlayerAction();
        _rig = GetComponent<Rigidbody2D>();
        
        
    }

    private void OnEnable() {
        _playerAction.Enable();
    }

    private void OnDisable() {
        _playerAction.Disable();
    }
    

    private void FixedUpdate() {
        Vector2 moveInput = _playerAction.Movement.Move.ReadValue<Vector2>();
        _rig.velocity = moveInput * movSpeed;
        velo = _rig.velocity;
    }
    void Update()
    {
        
    }
}
