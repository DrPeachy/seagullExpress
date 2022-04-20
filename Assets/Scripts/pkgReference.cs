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
        PubVar.packages[index].dropPos = transform.position;
        if(true){
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, 0.5f);

        }
    }
    private void Update() {
        if(_playerAction.PlayerControl.Interact.IsPressed()){
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, 0.5f);
            if(hit.collider != null && hit.collider.CompareTag("DeliveryPoint") && hit.collider.name == location){
                PubVar.packages[index].state = 3;
                GetComponent<pkgReference>().enabled = false;
            }
            if(hit.collider != null && hit.collider.CompareTag("Player")){
                PubVar.packages[index].state = 1;
                PubVar.playerWeight += PubVar.packages[index].weight;
                PubVar.actualSpeed = PubVar.movSpeed * (1- (PubVar.playerWeight/(PubVar.pkgNum * 400f)) );
                Destroy(gameObject);
                
            }
        }
    }



}
