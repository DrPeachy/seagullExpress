using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deliveryman : MonoBehaviour
{   
    
    public float speed_const = 20;
    public float speed_limit = 5;
    public LayerMask obstacles;
    public LayerMask my_layer;
    Vector2 direction;
    Rigidbody2D _rb;
    Collider2D _coll;
    Vector3 cam_pos;
    bool been_in_sight = false;
    bool ready_to_destory = false;
    RaycastHit2D _hit;
    float start_time;
    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
        _coll = GetComponent<Collider2D>();
        cam_pos = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);
        transform.up = (cam_pos - transform.position).Rotate(Random.Range(-15f, 15f));
    }

    private void Update() {
        Vector3 offset = transform.up.normalized * (_coll.bounds.size.y + .3f);
        _hit = Physics2D.BoxCast(transform.position + offset, _coll.bounds.size, 0, transform.up, 5f);
        if(_hit){
            // print(_hit.transform.position);
            _rb.velocity = _rb.velocity * 0.5f;
            transform.up = transform.up.Rotate(2f);
        } else {
            // need to be impreved
            //if( !_rb.velocity.normalized.equals_in_2d(transform.up.normalized)){
                //_rb.velocity = _rb.velocity.projection(transform.up) * _rb.velocity.normalized;
            //}
            if(_rb.velocity.magnitude < speed_limit){
                _rb.AddForce(transform.up * speed_const);
            }
            //_rb.angularVelocity = _rb.angularVelocity / 2;
            //if(_rb.angularVelocity < 1f) _rb.angularVelocity = 0;
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
