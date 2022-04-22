using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private PlayerAction _playerAction;
    
    private Rigidbody2D _rig;
    public GameObject BagUI;

    private backPackWindow bagCode;

    private float obstacleCooldown = 1f;

    public Animator animator;

    private void Awake() {
        bagCode = BagUI.GetComponent<backPackWindow>();
        _playerAction = new PlayerAction();
        _rig = GetComponent<Rigidbody2D>();

    }


    private void OnEnable() {
        _playerAction.Enable();
    }

    private void OnDisable() {
        _playerAction.Disable();
    }
    
    private void Start() {
        if(SceneManager.GetActiveScene().name == "OpenWorld"){
            transform.position = PubVar.checkPoint;
        }
    }
    private void FixedUpdate() {
        if(_playerAction.PlayerControl.OpenBag.IsPressed()){
            BagUI.SetActive(true);
            //bagCode.ClearBackPack();
            bagCode.SetBackpack();
            //soundManagerScript.playSound("openBag");   // NEED TO BE FIXED
        }
    }


    void Update()
    {
        Vector2 moveInput = _playerAction.PlayerControl.Move.ReadValue<Vector2>();
        if(_rig.gravityScale == 0){ // top down control
            // on controller, set velocity
            if(moveInput != Vector2.zero) _rig.velocity = moveInput * PubVar.actualSpeed;
            // animator.SetFloat("Speed", Mathf.Abs(PubVar.actualSpeed));  testing animator
            // afk, speed down
            if(moveInput == Vector2.zero) _rig.velocity = new Vector2(Mathf.Lerp(_rig.velocity.x,0,Time.deltaTime), Mathf.Lerp(_rig.velocity.y,0,Time.deltaTime));
            // smooth rotation
            float angle = Mathf.LerpAngle(_rig.rotation, Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg - 90f, Time.deltaTime * 8);
            // set rotation
            if(moveInput != Vector2.zero) _rig.rotation = angle;
        }else{ // platformer control
            _rig.velocity = new Vector2(moveInput.x, 0) * PubVar.actualSpeed;
            if(moveInput != Vector2.zero) transform.localScale = new Vector2((moveInput.x > 0) ? 1:-1, 1);
        }
    }



    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Obstacle")){
            soundManagerScript.playSound("hitCloud");
            StartCoroutine(WaitTillRestore());
        }
    }


    IEnumerator WaitTillRestore(){  // lose integrity
        _playerAction.Disable();
        for(int i = 0; i < PubVar.pkgNum; i++){
            if(PubVar.packages[i] != null && PubVar.packages[i].state == 1){

                PubVar.packages[i].getHit( (1- (PubVar.packages[i].weight/500f)) * 10f);
                print(PubVar.packages[i].integrity+ "  " +(PubVar.packages[i].weight/500) * 10);
            }
        }
        yield return new WaitForSeconds(obstacleCooldown);
        _rig.velocity = Vector2.zero;
        _playerAction.Enable();
    }
}
