using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeliveryEnd : MonoBehaviour
{
    public TextMeshProUGUI resultsUI;
    string results = "";

    void Start()
    {
        foreach (package p in PubVar.packages) {
            if (p.GetState() == "Delivered" || p.GetState() == "Broken") {
                results += p.ResultString() + "\n";
            }
        }
    }

    void Update()
    {
        resultsUI.text = results;
    }
}
