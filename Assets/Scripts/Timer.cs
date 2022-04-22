using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public StaticTime initTime = new StaticTime(7, 0);
    public float realTimeForMin = 0.2f;
    private float timer;
    public int minCountToUpdate = 15;
    private int minCounter;
    public TextMeshProUGUI timerUI;


    private void Awake() {
        timer = realTimeForMin;
        minCounter = minCountToUpdate;
        
    }

    private void Start() {
        timerUI.text = initTime.ToString();
        DontDestroyOnLoad(gameObject);
    }
    private void Update() {
        timer-= Time.deltaTime;

        if(timer < 0){
            initTime.IncMin();
            minCounter--;
            timer = realTimeForMin;
        }
        if(minCounter == 0){
            timerUI.text = initTime.ToString();
            minCounter = minCountToUpdate;
        }
        if(initTime.hr == 24){
            SceneManager.LoadScene("DeliveryEnd");
            Destroy(gameObject);
        }
        if(SceneManager.GetActiveScene().name == "DeliveryEnd"){
            Destroy(gameObject);
        }
    }

}
