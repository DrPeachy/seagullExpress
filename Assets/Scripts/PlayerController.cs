using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private PlayerAction _playerAction;
    public float movSpeed;
    private Rigidbody2D _rig;

    private void Awake() {
        _playerAction = new PlayerAction();
        _rig = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
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
        float angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg - 90f;
        _rig.rotation = angle;
    }
    void Update()
    {
        
    }
}
