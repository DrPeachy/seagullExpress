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
    public LayerMask playerLayer;

    
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

        if(true){
            Collider2D collideObj;
            if((collideObj = Physics2D.OverlapBox(transform.position, new Vector2(3, 10), 0f, detectLayer)) != null &&
                collideObj.GetComponent<DeliveryPoint>().code == location){
                // set state before deliver
                if(PubVar.packages[index].UpdateState())
                    PubVar.packages[index].state = 3;
                // disable pkg prefab
                GetComponent<pkgReference>().enabled = false;
                Debug.Log($"{PubVar.packages[index].id} is {PubVar.packages[index].GetState()}");
                checkAllPkg();
            }  
        }


    }
    private void Update() {
        if(_playerAction.PlayerControl.Interact.IsPressed()){                       // check if succeed to deliver

            Collider2D collideObj;
            if((collideObj = Physics2D.OverlapBox(transform.position, new Vector2(3, 10), 0f, detectLayer)) != null &&
                collideObj.GetComponent<DeliveryPoint>().code == location){
                // set state before deliver
                if(PubVar.packages[index].UpdateState())
                    PubVar.packages[index].state = 3;
                // disable pkg prefab
                GetComponent<pkgReference>().enabled = false;
                Debug.Log($"{PubVar.packages[index].id} is {PubVar.packages[index].GetState()}");
                checkAllPkg();
            }
            else if((collideObj = Physics2D.OverlapBox(transform.position, new Vector2(3, 10), 0f, playerLayer)) != null){           // pick up pkg
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
