using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFrameRate : MonoBehaviour
{
    public int tfr;
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Application.targetFrameRate != tfr){
            Application.targetFrameRate = tfr;
        }
    }
}
