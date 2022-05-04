using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    public Transform pkgPrefab;

    private struct Pos{
        int id;
        Transform lastPos;
    }
    private Pos[] allPos;
    private void Start() {
        foreach(var i in PubVar.packages ?? new package[0]){
            if(SceneManager.GetActiveScene().name != "OpenWorld" && i.dropPos != Vector3.zero && i.dropScene == SceneManager.GetActiveScene().name && i.state == 2){
                GameObject newPkg = Instantiate(pkgPrefab.gameObject, i.dropPos, Quaternion.Euler(0,0,0));             
                newPkg.name = i.id + "";
                newPkg.transform.GetChild(0).GetComponent<SpriteRenderer>().color = i.color;
                i.dropPos = Vector3.zero;
                i.dropScene = null;
            }
        }
    }
    private void OnDestroy() {
        foreach(var i in PubVar.packages ?? new package[0]){
            if(i.state == 2 && i.dropScene == null){
                i.dropScene = SceneManager.GetActiveScene().name;
            }
        }
    }
}
