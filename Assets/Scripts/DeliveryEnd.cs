using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeliveryEnd : MonoBehaviour
{
    public TextMeshProUGUI resultsUI;
    public float textSpeed = 0.05f;
    string results = "";
    int totalPay = 0;

    void Start()
    {   
        int pkgPickedUp = 0;
        foreach (package p in PubVar.packages) {
            if (p.GetState() != "Not Available" && p.GetState() != "Available") {
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

        // StartCoroutine(printText(results));
    }

    void Update()
    {
        resultsUI.text = results;
    }

    IEnumerator printText (string text) {
        foreach (char c in text) {
            resultsUI.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void OnDestroy() {
        PubVar.packages = null;
    }
}
