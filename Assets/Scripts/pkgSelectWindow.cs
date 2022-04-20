using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class pkgSelectWindow : MonoBehaviour
{
    private TextMeshProUGUI[] pkgInfos;
    //==============pkg generator=============
    public Vector3 firstPos;
    public GameObject pkgPrefab;
    public Behaviour pkgUI;

    private Transform slots;


    private void Start() {
        slots = transform.Find("slots");
        pkgInfos = new TextMeshProUGUI[6];
        if(PubVar.packages == null){
            setPkgNum();
            PubVar.packages = PkgRandomize();
            displayPkgs(PubVar.packages, pkgInfos);
        }else{
            GetComponent<pkgSelectWindow>().enabled = false;
            pkgUI.enabled = false;
        }
        gameObject.SetActive(false);
    }
    private void OnEnable() {
             
    }
 
    private void OnDisable() {
        
    }
 
    package[] PkgRandomize(){
        package[] packages = new package[PubVar.pkgNum];
        int i;
        // available package
        for(i = 0; i < PubVar.pkgNum; i++){
            packages[i] = PubVar.animals[Random.Range(0, PubVar.animals.Length)].orderPkg();
        }
        return packages;
    }

    void displayPkgs(package[] pkgs, TextMeshProUGUI[] texts){
        //Transform slots = transform.Find("slots");
        for(int i = 0; i < 6; i++){
            if(PubVar.pkgNum <= i){
                slots.Find("slot" + i).gameObject.SetActive(false);
                continue;
            }
            texts[i] = slots.Find("slot" + i).Find("pkgInfo").GetComponent<TextMeshProUGUI>();
            //display pkgs' info
            texts[i].text = pkgs[i].ToString();

            if(!pkgs[i].checkAvailable()) slots.Find("slot" + i).Find("select").GetComponent<Toggle>().interactable = false;
        }
    }

    public void checkSelected(){
        //Transform slots = transform.Find("slots");
        for(int i = 0; i < PubVar.pkgNum; i++){
            if(PubVar.packages[i].state == 0 && slots.Find("slot" + i).Find("select").GetComponent<Toggle>().isOn){
                PubVar.packages[i].state = 1;
            }
        }
    }

    void setPkgNum(){
        switch(PubVar.playerLevel){
            case 1:
                PubVar.pkgNum = 4;
                break;
            case 2:
                PubVar.pkgNum = 5;
                break;
            case 3:
                PubVar.pkgNum = 6;
                break;
        }
    }

    public void generatePkg(){
        Vector3 dif = new Vector3(3, 0, 0);
        for(int i = 0; i < PubVar.pkgNum; i++){
            if(PubVar.packages[i].state == 1){
                GameObject newPkg = Instantiate(pkgPrefab, firstPos + i * dif, Quaternion.Euler(0, 0, 0));
                newPkg.name = PubVar.packages[i].id + "";
                // drop packages on the floor
                PubVar.packages[i].state = 2;
                
            }
        }
    }
}
