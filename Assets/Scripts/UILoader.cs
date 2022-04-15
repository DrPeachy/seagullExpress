using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILoader : MonoBehaviour
{
    private PlayerAction _playerAction;
    public GameObject newUI;
    public GameObject oldUI;
    private void Start() {
        _playerAction = new PlayerAction();
    }
    private void OnTriggerEnter(Collider other) {
        if(_playerAction.PlayerControl.Click.ReadValue<float>() == 1 && other.CompareTag("Player")){
            if(oldUI&&newUI){
                oldUI.SetActive(false);
                newUI.SetActive(true);
            }
        }
    }
}
