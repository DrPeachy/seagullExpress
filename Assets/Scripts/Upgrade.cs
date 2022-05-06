using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade
{
    public string upName {get;set;}
    public float price {get;set;}
    public int limit {get;set;}
    public string detail {get;set;}

    public int level {get;set;}

    public string info{get;set;}
    public bool isPurchased{get;set;}


    public Upgrade(string upName, float price, int limit, string detail){
        this.upName = upName;
        this.price = price;
        this.limit = limit;
        this.level = 1;
        this.detail = detail;
        isPurchased = false;
    }

    public string Spdup() { 
        PubVar.movSpeed *= 1.2f;
        return "Speed Up!\n";
    }
    public string Dmgdown() { 
        PubVar.damage *= 0.8f;
        return "Damage down!\n";
    }
    public string SlowerTime() {
        PubVar.realTimeForMin += 0.2f;
        return "Slower Time!\n";
    }

    public string RandomUpgrade() {
        int i = Random.Range(0, 4);
        switch(i){
            case 0:
                PubVar.movSpeed *= 1.1f;
                return "Speed Up!\n";
            case 1:
                PubVar.damage *= 0.9f;
                return "Damage down!\n";
            case 2:
                PubVar.realTimeForMin += 0.1f;
                return "Slower Time!\n";
            case 3:
                return "Your essay due is one hour earlier!\n";
            default: return "";
        }
    }

    public string PkgLimitUp(){
        PubVar.pkglimit = 5;
        return "You can have one more package to select now!\n";
    }

    public bool NextBlock(){
        switch(limit){
            case 3:
                if(level <= limit){
                    PubVar.money -= price;
                    price *= 2;
                    price += (level * 100);
                    level++;
                    return true;
                }
                return false;
            case 50:
                if(level <= limit){
                    PubVar.money -= price;
                    price *= 1.2f;
                    price += (level * 40);
                    level++;
                    return true;
                }
                return false;
            case 1:
                if(level <= limit){
                    PubVar.money -= price;
                    level++;
                    return true;
                }
                return false;
            default: return false;
        }
    }

    public bool CostMoney(){
        if(price <= PubVar.money){
            //PubVar.money -= price;
            return true;
        }else{
            return false;
        }
    }


    public override string ToString()
    {
        return $"Upgrade Name: {upName}" 
            + $"\nUpgradePrice: {price:.}" 
            + $"\nCurrent Upgrade Level: {level}"
            + $"\nPurchase Limit: {limit}"
            + $"\n\n{detail}\n";
    }
}
