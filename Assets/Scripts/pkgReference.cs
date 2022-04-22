using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pkgReference : MonoBehaviour
{
    private PlayerAction _playerAction;
    public string location;
    private int index = 0;
    public LayerMask detectLayer;

    
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
        if(Physics2D.OverlapCircle(transform.position, 2.5f, detectLayer)){
            PubVar.packages[index].state = 3;
            Debug.Log("deliveried");
            GetComponent<pkgReference>().enabled = false;
        }
        checkAllPkg();

    }
    private void Update() {
        if(_playerAction.PlayerControl.Interact.IsPressed()){
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, 0.5f);
            if(hit.collider != null && hit.collider.CompareTag("DeliveryPoint") && hit.collider.name == location){
                PubVar.packages[index].state = 3;
                GetComponent<pkgReference>().enabled = false;
                checkAllPkg();
            }
            if(hit.collider != null && hit.collider.CompareTag("Player")){
                PubVar.packages[index].state = 1;
                PubVar.playerWeight += PubVar.packages[index].weight;
                PubVar.actualSpeed = PubVar.movSpeed * (1- (PubVar.playerWeight/(PubVar.pkgNum * 400f)) );
                Destroy(gameObject);
            }
        }
    }


    void checkAllPkg(){
        int flag = 0;
        foreach(package i in PubVar.packages){
            Debug.Log(i.id + " state: " + i.state);
            if(i.state == 1 || i.state == 2) flag = -1;
        }
        switch(flag){
            case 0:
                SceneManager.LoadScene("DeliveryEnd");
                break;
            case -1:
                break;
        }
    }


    // private void OnTriggerEnter2D(Collider2D other) {
    //     if(other.CompareTag("DeliveryPoint")){
    //             PubVar.packages[index].state = 3;
    //             Debug.Log("deliveried");
    //             GetComponent<pkgReference>().enabled = false;
    //             checkAllPkg();
    //     }
    // }
}
