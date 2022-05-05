using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    
    public void SetEasy(){
        PubVar.realTimeForMin = 0.6f;
        PubVar.damage = 5f;
        PubVar.movSpeed = 6f;
        PubVar.pkgBaseIncome = 600f;
        PubVar.hasObstacle = false;
    }
    public void SetNormal(){
        PubVar.realTimeForMin = 0.35f;
        PubVar.damage = 30f;
        PubVar.movSpeed = 5f;
        PubVar.pkgBaseIncome = 400f;    
    }
    public void SetHard(){
        PubVar.realTimeForMin = 0.2f;
        PubVar.damage = 40f;
        PubVar.movSpeed = 4f;
        PubVar.pkgBaseIncome = 300f;     
    }


}
