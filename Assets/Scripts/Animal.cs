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
        package pkg = new package(wishlist[Random.Range(0, wishlist.Length)],Random.Range(0, 1000), 0, name,
                        address, Random.Range(60, 500), Random.Range(60, 500), Random.Range(60, 500));

        return pkg;
    }
}
