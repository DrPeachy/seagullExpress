using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public string upName {get;set;}
    public float price {get;set;}
    public int limit {get;set;}

    private int level;

    public Upgrade(string upName, float price, int limit){
        this.upName = upName;
        this.price = price;
        this.limit = limit;
        this.level = 1;
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

    public void NextBlock(){
        switch(limit){
            case 3:
                if(level < limit){
                    price *= 2;
                    price += (level * 100);
                    level++;
                }
                break;
            case 50:
                if(level < limit){
                    price *= 1.2f;
                    price += (level * 40);
                    level++;
                }
                break;
        }
    }

    public bool CostMoney(){
        if(price <= PubVar.money){
            PubVar.money -= price;
            return true;
        }else{
            return false;
        }
    }
}
