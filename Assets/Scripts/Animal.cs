using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal
{
    public string name {get;set;}
    public string address {get;set;}

    public string[] wishlist {get;set;}
    public string[] feedback {get;set;}
    public package[] pkgs;


    public Animal(string name, string address, string[] wishlist, string[] feedback = null){
        this.name = name;
        this.address = address;
        this.wishlist = wishlist;
        if(this.feedback == null){
            this.feedback = new string[]{"That's good and fast!", "Not bad, not bad~", "It's a waste of money!"};
        }else{
            this.feedback = feedback;
        }
    }
    
    public package orderPkg(){
        StaticTime dueTime = new StaticTime(Random.Range(9,24), Random.Range(0,61));
        int weightVal = Random.Range(1, 31);
        int income = (int)(PubVar.pkgBaseIncome * (weightVal / 30f) * (14f / dueTime.hr));
        package pkg = new package(wishlist[Random.Range(0, wishlist.Length)],   //name
                                    Random.Range(1000,10000),                   //id
                                    -1,                                         //state
                                    this,                                       //receiver
                                    address, 
                                    dueTime,                                    //due
                                    income,                                     //income($)
                                    weightVal);                                 //weight(kilogram)

        return pkg;
    }
}
