using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootCollider : MonoBehaviour {
    public int jumpCount = 0;
    [SerializeField] private int MaxJumpCount = 2;
    public bool isJumping = false;
    public bool isExitCollider = false;
    [SerializeField] private float Upspeed = 5000;
    public GameObject player;
    private Rigidbody playerRigid;
    // Start is called before the first frame update
    void Start () {
        player = transform.root.gameObject;
        playerRigid = player.GetComponent<Rigidbody> ();
    }
    void Update () {
        //ジャンプフラグ
        if (jumpCount < MaxJumpCount && Input.GetKeyDown (KeyCode.Space)) {
            playerRigid.velocity = Vector3.zero;
            playerRigid.AddForce (0f, Upspeed, 0f);
            isJumping = true;
            if (isExitCollider) {
                jumpCount++;
            }
        }
    }
    public void OnTriggerStay (Collider other) {
        if (other.gameObject.CompareTag ("floor") && isExitCollider) {
            isExitCollider = false;
            isJumping = false;
            if (playerRigid.velocity.y <= 0.1f) {
                jumpCount = 0;
            }
        }
    }
    public void OnTriggerExit (Collider other) {
        if (other.gameObject.CompareTag ("floor") && !isExitCollider) {
            isExitCollider = true;
            if (isJumping) {
                jumpCount++;
            }
        }
    }
}
