using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windzone : MonoBehaviour
{
    public float wind_strength = 60;
    Vector2 direction;
    GameObject obj_in_zone = null;
    bool is_in = false;
    private void Start() {
        direction = (transform.position - transform.GetChild(0).transform.position).normalized;
    }
    void Update()
    {
        if(is_in && obj_in_zone!=null){
            obj_in_zone.GetComponent<Rigidbody2D>().AddForce(direction * wind_strength);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            is_in = true;
            obj_in_zone = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            is_in = false;
            obj_in_zone = null;
        }
    }
}
