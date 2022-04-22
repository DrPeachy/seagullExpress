using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openworld_gamemanager : MonoBehaviour
{
    public GameObject obstacle;
    public int obstacle_num = 100;
    Renderer _rd;
    private void Awake() {
        _rd = GetComponent<Renderer>();

        // ramdomly create obstacle_num of obstacles
        create_obstacles();

    }

    void create_obstacles(){
        Vector2 obs_size = obstacle.GetComponent<Renderer>().bounds.size;
        float x;
        float y;
        int i = 0;
        while(i < 100){
            x = 0.5f * Random.Range(-_rd.bounds.size.x, _rd.bounds.size.x);
            y = 0.5f * Random.Range(-_rd.bounds.size.y, _rd.bounds.size.y);
            Vector2 pos = new Vector2(x,y);
            if(Physics2D.BoxCast(pos, obs_size*2, 0, Vector2.up, .1f)){
                continue;
            } else {
                Instantiate(obstacle, pos, Quaternion.identity);
                i++;
            }
        }
    }
}
