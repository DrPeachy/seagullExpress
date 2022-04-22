using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deliveryman : MonoBehaviour
{   
    
    public float speed_const = 20;
    public float speed_limit = 5;
    public LayerMask obstacles;
    Vector2 direction;
    Rigidbody2D _rb;
    Collider2D _coll;
    Camera _cam;
    bool been_in_sight = false;
    bool ready_to_destory = false;
    RaycastHit2D _hit;
    float start_time;
    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
        _coll = GetComponent<Collider2D>();
        _cam = Camera.main;
    }

    private void Update() {
        _hit = Physics2D.BoxCast(transform.position, _coll.bounds.size, 0, transform.up, 5f, obstacles);
        print(_hit);
        if(_hit){
            _rb.velocity = _rb.velocity * 0.5f;
            transform.up = transform.up.Rotate(2f);
        } else {
            if(_rb.velocity.magnitude < speed_limit){
                _rb.AddForce(transform.up * speed_const);
            }
        }
        if(ready_to_destory){
            if(Time.time - start_time >5f){
                Destroy(gameObject);
            }
        }
    }

    private void OnBecameVisible() {
        been_in_sight = true;
        ready_to_destory = false;
    }

    private void OnBecameInvisible() {
        start_time = Time.time;
        ready_to_destory = been_in_sight;
    }    
}
