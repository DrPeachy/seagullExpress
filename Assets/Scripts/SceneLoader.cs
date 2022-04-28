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
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right);
            Debug.DrawRay(transform.position , Vector2.right, Color.red);
            if(hit.collider.CompareTag("Player")){
                if(SceneManager.GetActiveScene().name == "OpenWorld")       // set check point
                    PubVar.checkPoint = hit.collider.transform.position;
                flag = false;
                //StartCoroutine(LoadSceneWithAni());

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
