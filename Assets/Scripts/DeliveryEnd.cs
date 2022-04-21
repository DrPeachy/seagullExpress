using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeliveryEnd : MonoBehaviour
{
    public TextMeshProUGUI resultsUI;
    string results = "";
    int totalPay = 0;

    void Start()
    {   
        int pkgPickedUp = 0;
        foreach (package p in PubVar.packages) {
            if (p.GetState() == "Delivered" || p.GetState() == "Broken") {
                pkgPickedUp += 1;
                totalPay += p.Results(ref results);
                results += "\n";
            }
            results += "\n";
        }
        if (pkgPickedUp == 0) {
            results = "No Packages Picked Up\n";
        }
        results += " \nTotal Pay: $" + totalPay;
    }

    void Update()
    {
        resultsUI.text = results;
    }
}
