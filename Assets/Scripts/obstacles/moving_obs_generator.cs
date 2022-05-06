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
    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
        current_num_of_mo = 0;
        _player_rb = _player.GetComponent<Rigidbody2D>();
        _rd_size = moving_object.GetComponent<Renderer>().bounds.size;
    }

    private void Update() {
        Vector2 predict_pos = _player.transform.position.cast_to_2d() + 3 * _player_rb.velocity;
        float x = predict_pos.x;
        float y = predict_pos.y;
        int insurance = 0;
        while(current_num_of_mo < num_limit && insurance < 65535){
            insurance++;
            x = Random.Range(x - 20 , x + 20);
            y = Random.Range(y - 20, y + 20);
            Vector2 create_pos = new Vector2(x,y);
            if(create_pos.in_camera(Camera.main) || (Physics2D.BoxCast(create_pos, _rd_size*2, 0, Vector2.up, .01f))){
                continue;
            }
            current_num_of_mo++;
            Instantiate(moving_object, create_pos, Quaternion.identity);
        }
    }


}
