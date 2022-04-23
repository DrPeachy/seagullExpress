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
        foreach(var i in PubVar.packages){          // check self
            if(name == (i.id + "")){
                location = i.address;
                break;
            }
            index++;
        }
        PubVar.packages[index].dropPos = transform.position;

        checkAllPkg();

    }
    private void Update() {
        if(_playerAction.PlayerControl.Interact.IsPressed()){                       // check if succeed to deliver
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, 0.5f);
            if(Physics2D.OverlapCircle(transform.position, 5f, detectLayer)){
                if(!PubVar.packages[index].due.check(PubVar.initTime.hr, PubVar.initTime.min)) // if late
                    PubVar.packages[index].state = 5;
                else if(PubVar.packages[index].state != 4) PubVar.packages[index].state = 3;
                GetComponent<pkgReference>().enabled = false;
                checkAllPkg();
            }
            if(hit.collider != null && hit.collider.CompareTag("Player")){           // pick up pkg
                soundManagerScript.playSound("boxPick");
                PubVar.packages[index].state = 1;
                PubVar.playerWeight += PubVar.packages[index].weight;
                PubVar.actualSpeed = PubVar.movSpeed * (1- (PubVar.playerWeight/(PubVar.pkgNum * 30f)) );
                Destroy(gameObject);
            }
        }
    }


    void checkAllPkg(){     // check if all deliveries reach its end
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

}
