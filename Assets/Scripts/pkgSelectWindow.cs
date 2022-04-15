using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pkgSelectWindow : MonoBehaviour
{
    private TextMeshProUGUI[] pkgInfos= new TextMeshProUGUI[6];
    
    private void OnEnable() {
        setPkgNum();
        PubVar.packages = pkgRandomize();
        displayPkgs(PubVar.packages, pkgInfos);        
    }
 
 
 
 
    package[] pkgRandomize(){
        package[] packages = new package[7];
        int i;
        // available package
        for(i = 0; i < 6; i++){
            packages[i] = new package(i, (PubVar.pkgNum > i)? 0:-1, "a", "a", 90f, 100, 100);
        }
        // not available package
        // for(int j = 4; j < 6; j++){
        //     packages[i] = new package(i, -1, "b", "b", 90f, 100, 100);
        // }
        return packages;
    }

    void displayPkgs(package[] pkgs, TextMeshProUGUI[] texts){
        Transform slots = transform.Find("slots");
        for(int i = 0; i < 6; i++){
            texts[i] = slots.Find("slot" + i).Find("pkgInfo").GetComponent<TextMeshProUGUI>();

            texts[i].text = "package id: " + pkgs[i].id
                        + "\nweight: " + pkgs[i].weight
                        + "\n\nto: " + pkgs[i].to
                        + "\naddress: " + pkgs[i].address
                        + "\n\nship before: " + pkgs[i].due
                        + "\nincome: " + pkgs[i].income;
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
}
