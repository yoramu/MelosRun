using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCollider : MonoBehaviour {
    public bool isCanGrabWall = false;
    public GameObject player;
    private Rigidbody playerRigid;
    private FootCollider foot;
    void Start () {
        player = transform.root.gameObject;
        playerRigid = player.GetComponent<Rigidbody> ();
        foot = GameObject.Find ("FootCollider").GetComponent<FootCollider> ();
    }
    void Update () {
        //壁掴み
        if (isCanGrabWall && Input.GetKey (KeyCode.G)) {
            playerRigid.velocity = Vector3.zero;
            foot.jumpCount = 0;
        }
    }
    public void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag ("GrabWall")) {
            isCanGrabWall = true;
        }
    }
    public void OnTriggerExit (Collider other) {
        if (other.gameObject.CompareTag ("GrabWall")) {
            isCanGrabWall = false;
        }
    }
}
