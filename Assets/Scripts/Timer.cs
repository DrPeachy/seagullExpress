using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    
    public float realTimeForMin = 0.3f;
    private float timer;
    public int minCountToUpdate = 15;
    private int minCounter;
    public TextMeshProUGUI timerUI;


    private void Awake() {
        PubVar.initTime = new StaticTime(7, 0);
        timer = realTimeForMin;
        minCounter = minCountToUpdate;
        
    }

    private void Start() {
        timerUI.text = PubVar.initTime.ToString();
        DontDestroyOnLoad(gameObject);
    }
    private void Update() {
        timer-= Time.deltaTime;

        if(timer < 0){  // increment for in-game minutes
            PubVar.initTime.IncMin();
            minCounter--;
            timer = realTimeForMin;
        }
        if(minCounter == 0){    // update text every x in-game minutes
            timerUI.text = PubVar.initTime.ToString();
            minCounter = minCountToUpdate;
        }
        if(PubVar.initTime.hr == 24){   // if timer reach 24, game ends
            SceneManager.LoadScene("DeliveryEnd");
            Destroy(gameObject);
        }
        if(SceneManager.GetActiveScene().name == "DeliveryEnd"){    // if finish task in time, load end scene
            Destroy(gameObject);
        }
    }

}
