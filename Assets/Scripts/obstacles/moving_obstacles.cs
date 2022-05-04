using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_obstacles : MonoBehaviour
{
    public float offset_const = 5f;
    public float speed = 10f;
    GameObject _player;
    Rigidbody2D _rb;
    Collider2D _coll;
    Vector2 direction;
    RaycastHit2D _hit;
    float start_time;

    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody2D>();
        _coll = GetComponent<Collider2D>();
        direction = get_direction();
        transform.up = direction;
        start_time = Time.time;
    }
    private void Update() {
        Vector3 offset = transform.up.normalized * (_coll.bounds.size.y + .3f);
        _hit = Physics2D.BoxCast(transform.position + offset, _coll.bounds.size, 0, transform.up, 5f);
        if(_hit){
            _rb.velocity = Vector2.zero;
            transform.up = transform.up.Rotate(2f);
        } else {
            _rb.velocity = transform.up * speed;
        }
        print(transform.up);
        if((Time.time - start_time < 60) && (Time.time - start_time > 5)){
            if(!transform.position.in_camera(Camera.main)){
                moving_obs_generator.current_num_of_mo--;
                Destroy(gameObject);
            }
        } 
        if(Time.time - start_time >= 60){
            if(!transform.position.in_camera(Camera.main)){
                moving_obs_generator.current_num_of_mo--;
                Destroy(gameObject);
            }
        }
    }

    Vector2 get_direction(){
        Vector2 temp = _player.transform.position;
        temp += (Time.deltaTime* offset_const * _player.GetComponent<Rigidbody2D>().velocity);
        return (temp - transform.position.cast_to_2d()).normalized;
    }

    IEnumerator wait(){
        yield return new WaitForSeconds(5f);
    }
}
