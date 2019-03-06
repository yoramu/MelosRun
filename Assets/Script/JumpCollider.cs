using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCollider : MonoBehaviour {
    public int jumpCount = 0;
    public bool isExitCollider = false;
    public GameObject player;
    // Start is called before the first frame update
    void Start () {
        player = transform.root.gameObject;
    }
    public void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag ("floor")) {
            jumpCount = 0;
            isExitCollider = false;
            player.GetComponent<PlayerMove> ().isJumping = false;
        }
    }
    public void OnTriggerExit (Collider other) {
        if (other.gameObject.CompareTag ("floor")) {
            isExitCollider = true;
            if (player.GetComponent<PlayerMove> ().isJumping) {
                jumpCount++;
            }
        }
    }
}
