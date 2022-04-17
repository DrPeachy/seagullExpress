using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class pkgSelectWindow : MonoBehaviour
{
    private TextMeshProUGUI[] pkgInfos= new TextMeshProUGUI[6];
    //==============pkg generator=============
    public Vector3 firstPos;
    public GameObject pkgPrefab;

    private void Start() {
        PubVar.pkgNum = PubVar.playerLevel + 3;
        setPkgNum();
        PubVar.packages = pkgRandomize();
        displayPkgs(PubVar.packages, pkgInfos);
    }
    private void OnEnable() {
             
    }
 
    private void OnDisable() {
        
    }
 
    package[] pkgRandomize(){
        package[] packages = new package[PubVar.pkgNum];
        int i;
        // available package
        for(i = 0; i < PubVar.pkgNum; i++){
            packages[i] = PubVar.animals[Random.Range(0, PubVar.animals.Length)].orderPkg();
        }
        return packages;
    }

    void displayPkgs(package[] pkgs, TextMeshProUGUI[] texts){
        Transform slots = transform.Find("slots");
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
            Instantiate(pkgPrefab, firstPos + i * dif, Quaternion.Euler(0, 0, 0));
        }
    }
}
