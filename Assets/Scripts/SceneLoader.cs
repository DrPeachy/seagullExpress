using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneName;
    public PlayerAction _playerAction;

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
        if(_playerAction.PlayerControl.Interact.IsPressed()){
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right);
            Debug.DrawRay(transform.position , Vector2.right, Color.red);
            if(hit.collider.CompareTag("Player")){
                if(SceneManager.GetActiveScene().name == "OpenWorld")       // set check point
                    PubVar.checkPoint = hit.collider.transform.position;
                SceneManager.LoadScene(sceneName);
                    
            }
        }
    }

}
