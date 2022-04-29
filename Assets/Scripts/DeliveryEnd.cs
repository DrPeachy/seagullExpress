using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeliveryEnd : MonoBehaviour
{
    public TextMeshProUGUI resultsUI;
    public float textSpeed = 0.05f;
    string results = "";
    float totalPay = 0;

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
        results += $" \nTotal Pay: ${totalPay:.}";
        PubVar.money += totalPay;

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
        PubVar.checkPoint = PubVar.originPoint;
        PubVar.flagShop = false;

        
        // set player level -> increase pkg limit
        if(PubVar.deliveredPkg >= 5 && PubVar.deliveredPkg < 12){
            PubVar.playerLevel = 2;
        }
        else if(PubVar.deliveredPkg >= 12){
            PubVar.playerLevel = 3;
        }
    }
}
