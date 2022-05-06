using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_obs_generator : MonoBehaviour
{
    public int num_limit = 10;
    public GameObject moving_object;
    public static int current_num_of_mo;
    GameObject _player;
    Rigidbody2D _player_rb;
    Vector3 _rd_size;
    Camera _main;
    float temp_x;
    float temp_y;
    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
        current_num_of_mo = 0;
        _player_rb = _player.GetComponent<Rigidbody2D>();
        _rd_size = moving_object.GetComponent<Renderer>().bounds.size;
        print(new Vector2(10, -20).in_camera());
        _main = Camera.main;
    }

    private void Update() {
        Vector2 predict_pos = _player.transform.position.cast_to_2d() + 3 * _player_rb.velocity.magnitude * _player.transform.up.normalized.cast_to_2d();
        float x = predict_pos.x;
        float y = predict_pos.y;
        int insurance = 0;
        print(predict_pos);
        //print(x);
        while(current_num_of_mo < num_limit && insurance < 511){
            insurance++;
            temp_x = Random.Range(_main.transform.position.x - 35 , _main.transform.position.x+ 35);
            temp_y = Random.Range(_main.transform.position.y - 20, _main.transform.position.y + 20);
            Vector2 create_pos = new Vector2(temp_x,temp_y);
            //print(create_pos);
            if(create_pos.in_camera(Camera.main) || Physics2D.OverlapBox(create_pos, _rd_size, 0f)){
                continue;
            }
            current_num_of_mo++;
            //print(create_pos);
            Instantiate(moving_object, create_pos, Quaternion.identity);
        }
    }


}
