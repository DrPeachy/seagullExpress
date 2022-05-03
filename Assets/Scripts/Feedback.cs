using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Feedback : MonoBehaviour
{
    public GameObject bubbleText;
    private TextMeshPro text;

    private bool alldelivered = false;


    private void Start() {
        text = bubbleText.transform.GetChild(0).GetComponent<TextMeshPro>();
        
        bubbleText.SetActive(false);
    }

    private void FixedUpdate() {
        if(!alldelivered){

            foreach(package i in PubVar.packages){
                if(i.address == SceneManager.GetActiveScene().name){
                    if(i.state >= 3){               // delivered
                        bubbleText.SetActive(true);
                        alldelivered = true;
                        switch(i.state){
                            case 3:
                                text.text = i.receiver.feedback[0];
                                continue;
                            case 5:
                                text.text = i.receiver.feedback[1];
                                continue;
                            case 4:
                                text.text = i.receiver.feedback[2];
                                continue;
                            case 6:
                                text.text = i.receiver.feedback[2];
                                continue;

                        }
                    }else if(i.state >= 1){
                        alldelivered = false;
                    }
                }
            }
        }
    }
}
