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
            Debug.Log(Physics2D.OverlapCircle(transform.position, 5f, detectLayer));
            Collider2D deliveryPoint = Physics2D.OverlapCircle(transform.position, 1f, detectLayer);
            if(deliveryPoint != null &&
                deliveryPoint.GetComponent<DeliveryPoint>().code == SceneManager.GetActiveScene().name){
                // set state before deliver
                if(PubVar.packages[index].UpdateState())
                    PubVar.packages[index].state = 3;
                // disable pkg prefab
                GetComponent<pkgReference>().enabled = false;
                Debug.Log($"{PubVar.packages[index].id} is {PubVar.packages[index].GetState()}");
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
