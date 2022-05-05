using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_objects : MonoBehaviour
{
    public GameObject objects_to_create;
    public GameObject objects_to_create2;
    public float cool_down;
    public int nums_to_create_each_time;
    public bool keep_creating = true;
    Renderer _obj_rd;
    Camera maincam;
    Vector2 cam_center;
    int i = 0;
    int j = 0;
    float x;
    float y;
    public int objLimit = 11;
    private void Start() {
        // turn off generator in easy mode
        if(!PubVar.hasObstacle) gameObject.GetComponent<create_objects>().enabled = false;
        //
        _obj_rd = objects_to_create.GetComponent<Renderer>();
        maincam = Camera.main;
        StartCoroutine(create());

    }

    private void Update() {
        // can add conditions to stop creating by change keep_creating
        // while(j < objLimit){
        //     create_objects_once();
        //     j++;
        // }
        
    }

    IEnumerator create(){
        while(keep_creating){
            i = 0;
            if(j < objLimit) create_objects_once();
            print("create");
            yield return new WaitForSeconds(cool_down);
        }
    }

    void create_objects_once(){
        while(i < nums_to_create_each_time){
            // 20 and 10 are the camera size, which are constant
            x = Random.Range(maincam.transform.position.x - 30, maincam.transform.position.x + 30);
            y = Random.Range(maincam.transform.position.y - 20, maincam.transform.position.y + 20);
            Vector2 pos = new Vector2(x,y);
            Vector2 temp = maincam.WorldToViewportPoint(pos);
            if(temp.x>=-.2f && temp.x<=1.2f && temp.y>=-0.2f && temp.y<=1.2f){
                print("cannot instantiate");
                continue;
            } else {
                GameObject newObj = Instantiate(objects_to_create, pos, Quaternion.identity);
                print($"obj: {i}");
                i++;
                j++;
                StartCoroutine(deleteAfter(newObj));
            }
        }
    }


    IEnumerator deleteAfter(GameObject obj){
        bool flag = true;
        while(flag){
            yield return new WaitForSeconds(cool_down);
            if(Vector2.Distance(maincam.transform.position, obj.transform.position) > 20){
                    Destroy(obj);
                    j--;
                    flag = false;
            }
        }
    }
}
