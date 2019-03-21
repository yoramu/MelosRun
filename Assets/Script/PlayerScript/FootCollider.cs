using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootCollider : MonoBehaviour {
    private int jumpCount = 0;
    [SerializeField] private int MaxJumpCount = 2;
    private bool isJumping = false;
    private bool isExitCollider = false;
    [SerializeField] private float Upspeed = 70;
    private GameObject player;
    private Rigidbody playerRigid;
    private GrabCollider GrabCollider;
    [SerializeField] private AudioClip jumpSound;
    private AudioSource audioSource;
    void Start () {
        player = transform.root.gameObject;
        GrabCollider = GameObject.Find ("GrabCollider").GetComponent<GrabCollider> ();
        playerRigid = player.GetComponent<Rigidbody> ();
        audioSource = GetComponent<AudioSource> ();
    }
    void Update () {
        //ジャンプフラグ
        if (jumpCount < MaxJumpCount && Input.GetKeyDown (KeyCode.Space)) {
            playerRigid.velocity = Vector3.zero;
            playerRigid.AddForce (0f, Upspeed, 0f);
            isJumping = true;
            GrabCollider.IsGrabFalse ();
            if (isExitCollider) {
                jumpCount++;
            }
            audioSource.PlayOneShot (jumpSound);
        }
    }
    private void OnTriggerStay (Collider other) {
        if (other.gameObject.CompareTag ("floor") && isExitCollider) {
            isExitCollider = false;
            isJumping = false;
            if (playerRigid.velocity.y <= 0.1f) {
                jumpCount = 0;
            }
        }
    }
    private void OnTriggerExit (Collider other) {
        if (other.gameObject.CompareTag ("floor") && !isExitCollider) {
            isExitCollider = true;
            if (isJumping) {
                jumpCount++;
            }
        }
    }
    public void JumpCountReset () {
        jumpCount = 0;
    }
}
