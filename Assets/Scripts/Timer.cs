using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float timer;
    public int minCountToUpdate = 15;
    private int minCounter;
    public TextMeshProUGUI timerUI;
    public Image skybox;
    private CanvasGroup skyColor;

    private void Awake() {
        PubVar.initTime = new StaticTime(7, 0);
        timer = PubVar.realTimeForMin;
        minCounter = minCountToUpdate;
        skyColor = skybox.GetComponent<CanvasGroup>();
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
            timer = PubVar.realTimeForMin;
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

        if(PubVar.initTime.hr >= 17) skyColor.alpha += Time.deltaTime * (0.002f/PubVar.realTimeForMin);

    }

}
