using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_objects : MonoBehaviour
{
    public GameObject objects_to_create;
    public float cool_down;
    public int nums_to_create_each_time;
    public bool keep_creating = true;
    Renderer _obj_rd;
    Camera maincam;
    Vector2 cam_center;
    int i = 0;
    float x;
    float y;
    private void Start() {
        _obj_rd = objects_to_create.GetComponent<Renderer>();
        maincam = Camera.main;
        StartCoroutine(create());
    }

    private void Update() {
        // can add conditions to stop creating by change keep_creating
    }

    IEnumerator create(){
        while(keep_creating){
            i = 0;
            create_objects_once();
            yield return new WaitForSeconds(cool_down);
        }
    }

    void create_objects_once(){
        while(i < nums_to_create_each_time){
            // 20 and 10 are the camera size, which are constant
            x = Random.Range(maincam.transform.position.x - 20, maincam.transform.position.x + 20);
            y = Random.Range(maincam.transform.position.y - 10, maincam.transform.position.y + 10);
            Vector2 pos = new Vector2(x,y);
            Vector2 temp = maincam.WorldToViewportPoint(pos);
            if(Physics2D.BoxCast(pos, _obj_rd.bounds.size*2, 0, Vector2.up, .01f) ||
                (temp.x>=-.2f && temp.x<=1.2f && temp.y>=-0.2f && temp.y<=1.2f)){
                continue;
            } else {
                Instantiate(objects_to_create, pos, Quaternion.identity);
                i++;
            }
        }
    }
}