using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private PlayerAction _playerAction;
    public float movSpeed;
    private Rigidbody2D _rig;
    public GameObject BagUI;

    private backPackWindow bagCode;

    private void Awake() {
        bagCode = BagUI.GetComponent<backPackWindow>();
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
        if(_playerAction.PlayerControl.OpenBag.IsPressed()){
            BagUI.SetActive(true);
            //bagCode.ClearBackPack();
            bagCode.SetBackpack();
        }
    }


    void Update()
    {
        Vector2 moveInput = _playerAction.PlayerControl.Move.ReadValue<Vector2>();
        if(_rig.gravityScale == 0){
            _rig.velocity = moveInput * movSpeed;
            float angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg - 90f;
            if(moveInput != Vector2.zero) _rig.rotation = angle;
        }else{
            _rig.velocity = new Vector2(moveInput.x, 0) * movSpeed;
            if(moveInput != Vector2.zero) transform.localScale = new Vector2((moveInput.x > 0) ? 1:-1, 1);
        }
        
    }
}
