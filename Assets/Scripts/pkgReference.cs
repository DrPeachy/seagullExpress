using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pkgReference : MonoBehaviour
{
    private PlayerAction _playerAction;
    private void Awake() {
        _playerAction = new PlayerAction();
    }

    private void OnEnable() {
        _playerAction.Enable();
    }


    private void OnDisable() {
        _playerAction.Disable();
    }
    private void Update() {
        if(_playerAction.PlayerControl.Interact.IsPressed()){
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, 0.5f);
            if(hit.collider != null && hit.collider.CompareTag("Player")){
                foreach(var i in PubVar.packages){
                    if((i.id + "") == transform.name){
                        i.state = 1;
                        Destroy(gameObject);
                    }
                }
            }
        }
    }



}
