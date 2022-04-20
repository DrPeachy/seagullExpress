using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryPoint : MonoBehaviour
{

    public string code;
    private void Awake() {
        this.name = code;
    }


}
