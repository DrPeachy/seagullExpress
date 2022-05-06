using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UpgradeWindow : MonoBehaviour
{
    private PlayerAction _playerAction;    
    private Transform slots;
    private TextMeshProUGUI[] upInfos;
    private GameObject[] purchaseButtons = new GameObject[6];
    public LayerMask playerMask;
    public TextMeshProUGUI upgradeText;
    public TextMeshProUGUI moneyText;


    private void Awake() {
        _playerAction = new PlayerAction();
    }


    private void OnEnable() {
        _playerAction.Enable();
    }

    private void OnDisable() {
        _playerAction.Disable();
        upgradeText.text = "";
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
        if(!PubVar.flagShop){
            Debug.Log("start initialize shop");
            InitializeShop();
            PubVar.flagShop = true;
        }else{
            DisplayShop();
        }
        gameObject.SetActive(false);
        
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

    void InitializeShop(){
        Debug.Log("start initialize shop");
        slots = transform.Find("slots");
        for(int i = 0; i < 5; i++){
            upInfos[i] = slots.Find("slot" + i).Find("upInfo").GetComponent<TextMeshProUGUI>();
            upInfos[i].text = PubVar.upgrades[i].ToString();
            PubVar.upgrades[i].info = PubVar.upgrades[i].ToString();
            Debug.Log(PubVar.upgrades[i].ToString());
            purchaseButtons[i].SetActive(true);
            purchaseButtons[i].GetComponent<Button>().interactable = true;
            if((PubVar.upgrades[i].limit+1) == PubVar.upgrades[i].level){
                purchaseButtons[i].GetComponent<Button>().interactable = false;
                purchaseButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "No upgrade available";
            }
        }
    }

    void DisplayShop(){
        slots = transform.Find("slots");
        for(int i = 0; i < 5; i++){
            upInfos[i] = slots.Find("slot" + i).Find("upInfo").GetComponent<TextMeshProUGUI>();
            upInfos[i].text = PubVar.upgrades[i].info;
            purchaseButtons[i].SetActive(true);
            purchaseButtons[i].GetComponent<Button>().interactable = true;
            if(PubVar.upgrades[i].isPurchased){
                purchaseButtons[i].GetComponent<Button>().interactable = false;
                purchaseButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "purchased";
            }
            if((PubVar.upgrades[i].limit+1) == PubVar.upgrades[i].level){
                purchaseButtons[i].GetComponent<Button>().interactable = false;
                purchaseButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "No upgrade available";
            }
        }
    }

    public void Purchase(int index){
        if(PubVar.upgrades[index].CostMoney()){
            if(PubVar.upgrades[index].NextBlock()){
                purchaseButtons[index].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "purchased";
                purchaseButtons[index].GetComponent<Button>().interactable = false;
                switch(index){
                    case 0:
                        upgradeText.text = PubVar.upgrades[index].Spdup();
                        break;
                    case 1:
                        upgradeText.text = PubVar.upgrades[index].Dmgdown();
                        break;
                    case 2:
                        upgradeText.text = PubVar.upgrades[index].SlowerTime();
                        break;
                    case 3:
                        upgradeText.text = PubVar.upgrades[index].RandomUpgrade();
                        break;
                    case 4:
                        upgradeText.text = PubVar.upgrades[index].PkgLimitUp();
                        break;
                }
                PubVar.upgrades[index].info = PubVar.upgrades[index].ToString();
                PubVar.upgrades[index].isPurchased = true;
                StartCoroutine(ClearText());
            }
            

        }else{
            PubVar.upgrades[index].info = PubVar.upgrades[index].ToString();
            PubVar.upgrades[index].isPurchased = false;
            upgradeText.text = "You don't have enough money!\n";
            StartCoroutine(ClearText());
        }
        moneyText.text = $"Money: {PubVar.money:.}";
    }
    

    IEnumerator ClearText(){
        yield return new WaitForSeconds(2f);
        upgradeText.text = "";
    }





}
