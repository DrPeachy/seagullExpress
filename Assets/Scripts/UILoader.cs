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
        if(true){
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right);
            Debug.DrawRay(transform.position , Vector2.right, Color.red);
            if(hit.collider.CompareTag("Player") && _playerAction.PlayerControl.Interact.IsPressed()){
                soundManagerScript.playSound("clickUI");
                if(oldUI&&newUI){
                    oldUI.SetActive(false);
                    newUI.SetActive(true);
                    
                }         
            }
        }
    }


}
