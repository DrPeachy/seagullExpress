using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class pkgSelectWindow : MonoBehaviour
{
    private TextMeshProUGUI[] pkgInfos;
    //==============pkg generator=============
    public Vector3 firstPos;
    public GameObject pkgPrefab;
    public Behaviour pkgUI;

    private Transform slots;
    public AnimationClip tran_in;





    private void Start() {
        slots = transform.Find("slots");
        pkgInfos = new TextMeshProUGUI[8];

        if(PubVar.packages == null){    // set pkg number limit, randamize pkgs
            setPkgNum();
            PubVar.packages = PkgRandomize();
            displayPkgs(PubVar.packages, pkgInfos);
        }else{  // havent hit confirm butto
            int flag = 0;
            foreach(package i in PubVar.packages){
                if(i.state == 1 || i.state == 2) flag = 1;
            }
            if(flag == 1) pkgUI.enabled = false;
            else{
                displayPkgs(PubVar.packages, pkgInfos);
            }
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
        for(int i = 0; i < 8; i++){
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
        int flag = 0;
        //Transform slots = transform.Find("slots");
        for(int i = 0; i < PubVar.pkgNum; i++){
            if(PubVar.packages[i].state == 0 && slots.Find("slot" + i).Find("select").GetComponent<Toggle>().isOn){
                PubVar.packages[i].state = 2;
                flag = 1;
            }
        }
        if(flag == 0){

            SceneManager.LoadScene("DeliveryEnd");
        }
    }

    void setPkgNum(){   // set pkg number limit due to level
        switch(PubVar.playerLevel){
            case 1:
                PubVar.pkgNum = PubVar.pkglimit;
                break;
            case 2:
                PubVar.pkgNum = PubVar.pkglimit + 1;
                break;
            case 3:
                PubVar.pkgNum = PubVar.pkglimit + 2;
                break;
        }
        Debug.Log(PubVar.pkgNum);
    }

    public void generatePkg(){  // instantiate pkg prefab
        Vector3 dif = new Vector3(3, 0, 0);
        for(int i = 0; i < PubVar.pkgNum; i++){
            if(PubVar.packages[i].state == 2){
                // drop packages on the floor
                GameObject newPkg = Instantiate(pkgPrefab, firstPos + i * dif, Quaternion.Euler(0, 0, 0));
                newPkg.name = PubVar.packages[i].id + "";
            }
        }
    }
}
