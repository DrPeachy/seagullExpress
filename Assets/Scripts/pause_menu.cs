using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause_menu : MonoBehaviour
{
    //public PlayerAction _pa;
    GameObject pause_panel;
    bool is_paused = false;
    bool is_disabled = false;

    private void Awake() {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("pause_menu");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    
    }

    private void Start() {
        pause_panel = transform.GetChild(0).gameObject;
    }
    private void Update() {
        if((SceneManager.GetActiveScene().name == "StartMenu")){
            is_disabled = true;
        } else {
            is_disabled = false;
        }
        //if(_pa.PlayerControl.Pause.IsPressed()){
            //pause();
        //}
    }

    public void pause(){
        if(!is_disabled){
            is_paused = true;
            Time.timeScale = 0;
            pause_panel.SetActive(true);
        }
        
    }

    public void Resume(){
        is_paused = false;
        Time.timeScale = 1;
        pause_panel.SetActive(false);
    }

    public void switch_sound_status(){
        PubVar.sound_on = !PubVar.sound_on;
    }

    public void quit(){
        Resume();
        SceneManager.LoadScene("StartMenu");
    }

}
