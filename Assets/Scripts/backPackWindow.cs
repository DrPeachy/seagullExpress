using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class backPackWindow : MonoBehaviour
{
    private Transform slots;
    private TextMeshProUGUI[] pkgInfos;
    public Transform pkgPrefab;
    private GameObject _player;
    private GameObject[] dropButtons = new GameObject[8];

    public TextMeshProUGUI moneyText;


    //private PlayerAction _playerAction;

    private void Awake() {
        //_playerAction = new PlayerAction();
    }
    void Start()
    {
        moneyText.text = $"Money: {PubVar.money:.}";
        slots = transform.Find("slots");
        for(int i = 0; i < 8; i++){
            dropButtons[i] = slots.Find("slot" + i).Find("drop").gameObject;
            dropButtons[i].SetActive(false);
        }
        _player = GameObject.FindGameObjectWithTag("Player");
        pkgInfos = new TextMeshProUGUI[8];
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
        for(int i = 0; i < 8; i++){
            if(PubVar.pkgNum <= i){
                slots.Find("slot" + i).gameObject.SetActive(false);
                continue;
            }
            if(PubVar.packages[i].state == 1){
                if(SceneManager.GetActiveScene().name == "OpenWorld") dropButtons[i].SetActive(false);
                else dropButtons[i].SetActive(true);
                slots.Find("slot" + i).GetComponent<Image>().color = PubVar.packages[i].color;
                pkgInfos[i] = slots.Find("slot" + i).Find("pkgInfo").GetComponent<TextMeshProUGUI>();
                pkgInfos[i].text = PubVar.packages[i].BackpackString();
            }
        }
    }

    public void Drop(int x){
        setWeightSpd(x);

        // update backpack page
        slots.Find("slot" + x).GetComponent<Image>().color = Color.white;
        pkgInfos[x].text = "";
        dropButtons[x].SetActive(false);
        // dont drop pkg in openworld!!!
        if(SceneManager.GetActiveScene().name == "OpenWorld"){
            PubVar.packages[x].getHit(100);
            PubVar.packages[x].state = 2;
        }
        else{
            PubVar.packages[x].state = 2;
            // create new pkg prefab
            GameObject newPkg = Instantiate(pkgPrefab.gameObject, new Vector3(_player.transform.position.x, _player.transform.position.y - 1.5f,0), Quaternion.Euler(0,0,0));
            newPkg.name = PubVar.packages[x].id + "";
            newPkg.transform.GetChild(0).GetComponent<SpriteRenderer>().color = PubVar.packages[x].color;
        }
    }

    public void setWeightSpd(int x){
        PubVar.playerWeight -= PubVar.packages[x].weight;
        PubVar.actualSpeed = PubVar.movSpeed * (1- (PubVar.playerWeight/(PubVar.pkgNum * 30f)) );   
    }
}
