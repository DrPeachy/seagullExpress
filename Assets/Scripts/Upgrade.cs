using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    private PlayerAction _playerAction;    

    public LayerMask playerMask;
    private void Awake() {
        _playerAction = new PlayerAction();
    }


    private void OnEnable() {
        _playerAction.Enable();
    }

    private void OnDisable() {
        _playerAction.Disable();
    }

    private void FixedUpdate() {

        // upgrade
        if(_playerAction.PlayerControl.Interact.IsPressed()){
            Collider2D hit;
            if(hit = Physics2D.OverlapBox(transform.position, new Vector2(2,2), 0f, playerMask)){
                

            }
        }
    }


    
}
