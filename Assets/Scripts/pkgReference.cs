using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pkgReference : MonoBehaviour
{
    private PlayerAction _playerAction;
    public string location;
    private int index = 0;
    private void Awake() {
        _playerAction = new PlayerAction();
    }

    private void OnEnable() {
        _playerAction.Enable();
    }


    private void OnDisable() {
        _playerAction.Disable();
    }

    private void Start() {
        foreach(var i in PubVar.packages){
            if(name == (i.id + "")){
                location = i.address;
                break;
            }
            index++;
        }
        if(true){
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, 0.5f);

        }
    }
    private void Update() {
        if(_playerAction.PlayerControl.Interact.IsPressed()){
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, 0.5f);
            if(hit.collider != null && hit.collider.CompareTag("DeliveryPoint") && hit.collider.name == location){
                print("a");
                PubVar.packages[index].state = 3;
                GetComponent<pkgReference>().enabled = false;
            }
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
