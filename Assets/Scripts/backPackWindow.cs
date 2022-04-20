using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class backPackWindow : MonoBehaviour
{
    private Transform slots;
    private TextMeshProUGUI[] pkgInfos;
    public Transform pkgPrefab;
    private GameObject _player;
    private GameObject[] dropButtons = new GameObject[6];

    //private PlayerAction _playerAction;

    private void Awake() {
        //_playerAction = new PlayerAction();
    }
    void Start()
    {
        slots = transform.Find("slots");
        for(int i = 0; i < 6; i++){
            dropButtons[i] = slots.Find("slot" + i).Find("drop").gameObject;
        }
        _player = GameObject.FindGameObjectWithTag("Player");
        pkgInfos = new TextMeshProUGUI[6];
        gameObject.SetActive(false);
        
    }

    private void OnEnable() {
        //_playerAction.Enable();
    }

    private void OnDisable() {
        //_playerAction.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
      
    }

    public void SetBackpack(){
        //int counter = 0;
        for(int i = 0; i < 6; i++){
            if(PubVar.pkgNum <= i){
                slots.Find("slot" + i).gameObject.SetActive(false);
                continue;
            }
            if(PubVar.packages[i].state == 1){
                pkgInfos[i] = slots.Find("slot" + i).Find("pkgInfo").GetComponent<TextMeshProUGUI>();
                pkgInfos[i].text = PubVar.packages[i].ToString();
                //counter ++;
            }
        }
    }

    public void Drop(int x){
        PubVar.packages[x].state = 2;
        GameObject newPkg = Instantiate(pkgPrefab.gameObject, _player.transform.position, Quaternion.Euler(0,0,0));
        newPkg.name = PubVar.packages[x].id + "";
        pkgInfos[x].text = "";
        slots.Find("slot" + x).Find("drop").gameObject.SetActive(false);
    }

    public void ClearBackPack(){
    
    }
}
