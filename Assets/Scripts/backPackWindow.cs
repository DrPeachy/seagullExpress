using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
            dropButtons[i].SetActive(false);
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


    private void FixedUpdate() {
      
    }

    public void SetBackpack(){
        //int counter = 0;
        for(int i = 0; i < 6; i++){
            if(PubVar.pkgNum <= i){
                slots.Find("slot" + i).gameObject.SetActive(false);
                continue;
            }
            if(PubVar.packages[i].state == 1 ||
                PubVar.packages[i].state == 4 ||
                PubVar.packages[i].state == 5){
                dropButtons[i].SetActive(true);
                pkgInfos[i] = slots.Find("slot" + i).Find("pkgInfo").GetComponent<TextMeshProUGUI>();
                pkgInfos[i].text = PubVar.packages[i].BackpackString();
            }
        }
    }

    public void Drop(int x){
        setWeightSpd(x);
        GameObject newPkg = Instantiate(pkgPrefab.gameObject, new Vector3(_player.transform.position.x,1,0), Quaternion.Euler(0,0,0));
        newPkg.name = PubVar.packages[x].id + "";
        pkgInfos[x].text = "";
        dropButtons[x].SetActive(false);
        // dont drop pkg in openworld!!!
        if(SceneManager.GetActiveScene().name == "OpenWorld")
            PubVar.packages[x].getHit(100);
        else if(PubVar.packages[x].UpdateState())
            PubVar.packages[x].state = 2;
    }

    public void setWeightSpd(int x){
        PubVar.playerWeight -= PubVar.packages[x].weight;
        PubVar.actualSpeed = PubVar.movSpeed * (1- (PubVar.playerWeight/(PubVar.pkgNum * 30f)) );   
    }
}
