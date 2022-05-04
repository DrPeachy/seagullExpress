using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerController : MonoBehaviour
{

    private PlayerAction _playerAction;
    private Rigidbody2D _rig;
    public GameObject BagUI;
    private backPackWindow bagCode;
    private float obstacleCooldown = 1f;
    public Animator animator;
    public TextMeshProUGUI dmgText;

    // interact button toggle
    public LayerMask sceneloaderMask;
    public GameObject interactButton;

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
        if(dmgText) dmgText.text = "";
    }
    private void FixedUpdate() {
        // activate/deactive interact button
        if(interactButton != null){
            Collider2D hit = Physics2D.OverlapCircle(transform.position, 5f, sceneloaderMask);
            if(hit){
                interactButton.SetActive(true);
                //print("activate button");
            }
            else{
                interactButton.SetActive(false);
                //print("deactivate button");
            }
        }

        // open backpack
        if(_playerAction.PlayerControl.OpenBag.IsPressed()){
            if(!BagUI.activeSelf){
                BagUI.SetActive(true);
                bagCode.SetBackpack();
                soundManagerScript.playSound("openBag");   // NEED TO BE FIXED
            }
        }
    }


    void Update()
    {
        if(_playerAction.PlayerControl.Pause.IsPressed()){
            GameObject.FindGameObjectWithTag("pause_menu").GetComponent<pause_menu>().pause(); // NEED TO BE FIXED
        }
        Vector2 moveInput = _playerAction.PlayerControl.Move.ReadValue<Vector2>();
        if(_rig.gravityScale == 0){ // top down control
            // on controller, set velocity
            if(moveInput != Vector2.zero) _rig.velocity = moveInput * PubVar.actualSpeed;
            // afk, speed down
            if(moveInput == Vector2.zero) _rig.velocity = new Vector2(Mathf.Lerp(_rig.velocity.x,0,Time.deltaTime), Mathf.Lerp(_rig.velocity.y,0,Time.deltaTime));
            // smooth rotation
            float angle = Mathf.LerpAngle(_rig.rotation, Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg - 90f, Time.deltaTime * 8);
            // set rotation
            if(moveInput != Vector2.zero) _rig.rotation = angle;
        }else{ // platformer control
            _rig.velocity = new Vector2(moveInput.x, 0) * PubVar.actualSpeed;
            animator.SetFloat("speed", Mathf.Abs(moveInput.x * PubVar.actualSpeed));  //testing animator
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
        float damage;
        for(int i = 0; i < PubVar.pkgNum; i++){
            if(PubVar.packages[i] != null && PubVar.packages[i].state == 1){
                damage = (1 - (PubVar.packages[i].weight/35f)) * PubVar.damage;
                dmgText.text += PubVar.packages[i].getHit(damage);
                print(PubVar.packages[i].integrity+ "  " +(PubVar.packages[i].weight/500) * 10);
            }
        }
        yield return new WaitForSeconds(obstacleCooldown);
        _rig.velocity = Vector2.zero;
        _playerAction.Enable();
        yield return new WaitForSeconds(3f);
        dmgText.text = "";
    }



}
