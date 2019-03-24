using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCollider : MonoBehaviour {
    private bool isCanGrabWall = false;
    private bool isGrab = false;
    private GameObject player;
    private Rigidbody playerRigid;
    private FootCollider foot;
    public GameObject grabtext;
    private PlayerMove PlayerMove;
    void Start () {
        player = transform.root.gameObject;
        playerRigid = player.GetComponent<Rigidbody> ();
        PlayerMove = player.GetComponent<PlayerMove> ();
        foot = GameObject.Find ("FootCollider").GetComponent<FootCollider> ();
        grabtext = GameObject.Find ("grabwalltext");
    }
    void Update () {
        //壁掴み
        if (isCanGrabWall && (Input.GetKey (KeyCode.G) || Input.GetKey (KeyCode.W))) {
            grabtext.SetActive (false);
            isGrab = true;
        }
        if (isGrab) {
            playerRigid.velocity = Vector3.zero;
            foot.JumpCountReset ();
        }
    }
    private void OnTriggerStay (Collider other) {
        if (other.gameObject.CompareTag ("floor")) {
            PlayerMove.IsMoveFalse ();
        }
        if (other.gameObject.CompareTag ("GrabWall")) {
            PlayerMove.IsMoveFalse ();
            isCanGrabWall = true;
        }
    }
    private void OnTriggerExit (Collider other) {
        PlayerMove.IsMoveTrue ();
        if (other.gameObject.CompareTag ("GrabWall")) {
            isCanGrabWall = false;
            isGrab = false;
        }
    }
    public void IsGrabFalse () {
        isGrab = false;
    }
}
