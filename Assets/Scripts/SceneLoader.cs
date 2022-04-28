using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    public AnimationClip tran_in;
    public string sceneName;
    public PlayerAction _playerAction;
    public float transitionTime = 1f;
    public LayerMask playerMask;

    private bool flag = true;

    private void Awake() {
        _playerAction = new PlayerAction();
    }

    private void OnEnable() {
        _playerAction.Enable();
    }

    private void OnDisable() {
        _playerAction.Disable();
    }


    private void FixedUpdate() {

        if(_playerAction.PlayerControl.Interact.IsPressed() && flag){

            if(SceneManager.GetActiveScene().name == "OpenWorld"){  // openWorld
                Collider2D hit;
                if(hit = Physics2D.OverlapCircle(transform.position, 3, playerMask)){
                    flag = false;
                    PubVar.checkPoint = hit.transform.position;
                    StartCoroutine(LoadSceneWithAni());
                }
            }
            else{                                                   // platformer
                // RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, playerMask);
                // Debug.DrawRay(transform.position , Vector2.right, Color.red);
                // StartCoroutine(LoadSceneWithAni());
                Collider2D hit;
                if(hit = Physics2D.OverlapBox(transform.position, new Vector2(2, 2) , 0f, playerMask)){
                    flag = false;
                    StartCoroutine(LoadSceneWithAni());
                }
            }
        }
    }


    public IEnumerator LoadSceneWithAni(){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }

    public void wrapper(){
        
        StartCoroutine(LoadSceneWithAni());
    }

}
