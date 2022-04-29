using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILoader : MonoBehaviour
{
    public PlayerAction _playerAction;
    public GameObject newUI;
    public GameObject oldUI;
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

        if(_playerAction.PlayerControl.Interact.IsPressed()){
            if(Physics2D.OverlapBox(transform.position, new Vector2(3, 10), 0f, playerMask)){
                soundManagerScript.playSound("clickUI");    
                oldUI.SetActive(false);
                newUI.SetActive(true);         
            }
        }
    }


}
