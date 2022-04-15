using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILoader : MonoBehaviour
{
    public PlayerAction _playerAction;
    public GameObject newUI;
    public GameObject oldUI;
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

    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag("Player") && _playerAction.PlayerControl.Interact.IsPressed()){
            if(oldUI&&newUI){
                oldUI.SetActive(false);
                newUI.SetActive(true);
            }
        }
    }
}
