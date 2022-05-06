using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach(var i in PubVar.packages){
            if(i.state == 1 || i.state == 2) Destroy(gameObject); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
