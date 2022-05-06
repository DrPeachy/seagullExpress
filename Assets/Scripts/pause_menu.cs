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

        //DontDestroyOnLoad(this.gameObject);
    
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
        if(PubVar.sound_on == true){
            AudioListener.volume = 1;
        }
        else{
            AudioListener.volume = 0;
        }
    }

    public void quit(){
        Resume();
        SceneManager.LoadScene("StartMenu");
        PubVar.packages = null;
        PubVar.money = 0;
        PubVar.hasObstacle = true;
        PubVar.pkglimit = 4;
        PubVar.initTime = new StaticTime(7, 0);
        Destroy(GameObject.FindGameObjectWithTag("Timer"));
        PubVar.playerLevel = 1;
        PubVar.deliveredPkg = 0;
        PubVar.flagShop = false;
        PubVar.money = 10;
        PubVar.playerWeight = 0;


        Vector3 checkPoint = new Vector3(35, -20, 0);
        Vector3 originPoint = new Vector3(35, -20, 0);


        PubVar.upgrades = null;
        
        PubVar.upgrades = new Upgrade[]{
            new Upgrade("SpeedUp", 300, 3, "You will be granted with a permanent speed up with this turbo charger, and be careful during your flight."),
            new Upgrade("DmgDown", 300, 3, "With the Wno reverse card, the damage recevied by your package will be reduced."),
            new Upgrade("SlowerTime", 300, 3, "Except from the red and blue pill, you can choose this green pill. It makes you feel time flows slower."),
            new Upgrade("RandomUpgrade", 200, 50, "No one knows what is inside this gashapon machine."),
            new Upgrade("PackageLimit + 1", 1000, 1, "Your boss will grant you one more choice(You can do more delivery now!)")
        };
    }

}
