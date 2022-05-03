using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    
    public void SetEasy(){
        PubVar.realTimeForMin = 0.8f;
        PubVar.damage = 5f;
        PubVar.movSpeed = 6f;
        PubVar.pkgBaseIncome = 700f;
        PubVar.hasObstacle = false;
    }
    public void SetNormal(){
        PubVar.realTimeForMin = 0.4f;
        PubVar.damage = 30f;
        PubVar.movSpeed = 5f;
        PubVar.pkgBaseIncome = 500f;    
    }
    public void SetHard(){
        PubVar.realTimeForMin = 0.18f;
        PubVar.damage = 30f;
        PubVar.movSpeed = 5f;
        PubVar.pkgBaseIncome = 500f;     
    }


}
