using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deliveryman : MonoBehaviour
{
    public GameObject destination;
    public float speed_const = 20;
    public float speed_limit = 20;
    Vector2 direction;
    Rigidbody2D _rb;
    bool arrived = false;
    RaycastHit2D _hit;
    private void Start() {
        _rb=GetComponent<Rigidbody2D>();
    }

    private void Update() {
        // get direction towards the destination
        direction = (destination.transform.position - transform.position).normalized;
        transform.up = direction;


        // detect upcoming obstacle
        _hit = Physics2D.Raycast(transform.position, )


        if(Vector2.Distance(destination.transform.position, transform.position) < .5f){
            arrived = true;
        }
        
        if(!arrived){
            if(_rb.velocity.magnitude < speed_limit) _rb.AddForce(direction * speed_const);
        }
        else{
            _rb.velocity = Vector2.zero;
        }
        
    }
}
