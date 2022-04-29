using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeWindow : MonoBehaviour
{
    private PlayerAction _playerAction;    
    private Transform slots;
    private TextMeshProUGUI[] upInfos;
    private GameObject[] purchaseButtons = new GameObject[6];
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

    void Start()
    {
        slots = transform.Find("slots");
        for(int i = 0; i < 5; i++){
            purchaseButtons[i] = slots.Find("slot" + i).Find("purchase").gameObject;
            purchaseButtons[i].SetActive(false);
        }
        //_player = GameObject.FindGameObjectWithTag("Player");
        upInfos = new TextMeshProUGUI[5];
        transform.Find("UpgradeUI").gameObject.SetActive(false);
        
    }
    private void FixedUpdate() {

        // upgrade
        if(_playerAction.PlayerControl.Interact.IsPressed()){
            Collider2D hit;
            if(hit = Physics2D.OverlapBox(transform.position, new Vector2(2,2), 0f, playerMask)){
                transform.Find("UpgradeUI").gameObject.SetActive(true);
            }
        }
    }

    void SetShop(){

    }
    




}
