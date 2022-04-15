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
        
    }


    void Update()
    {
        Vector2 moveInput = _playerAction.Movement.Move.ReadValue<Vector2>();
        if(_rig.isKinematic){
            _rig.velocity = moveInput * movSpeed;
            float angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg - 90f;
            if(moveInput != Vector2.zero) _rig.rotation = angle;
        }else{
            _rig.velocity = new Vector2(moveInput.x, 0) * movSpeed;
            if(moveInput != Vector2.zero) transform.localScale = new Vector2((moveInput.x > 0) ? 1:-1, 1);
        }
        
    }
}
