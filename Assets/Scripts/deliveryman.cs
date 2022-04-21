using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deliveryman : MonoBehaviour
{   
    /*
    public GameObject destination;
    public float speed_const = 20;
    public float speed_limit = 20;
    public LayerMask obstacles;
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
        _hit = Physics2D.Raycast(transform.position, direction, 10, obstacles);
        if(_hit.collider != null){

        }


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

    void avoiding_obstacles(GameObject the_obstacle){
        Bounds temp_bounds = 
    }
    */
}
