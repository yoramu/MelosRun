using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour {
    public GameObject Player;
    private Rigidbody PlayerRigid;

    private bool isJumping = true;
    public float Upspeed; //ジャンプのスピード
    // Start is called before the first frame update
    void Start () {
        PlayerRigid = Player.GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update () {
        PlayerRigid.position += new Vector3 (Input.GetAxis ("Horizontal") * Time.deltaTime * 3, 0.0f, 0.0f);
        if (Input.GetKeyDown (KeyCode.Space) && isJumping) {
            PlayerRigid.AddForce (0f, Upspeed, 0f);
        }
        Debug.Log (isJumping);
    }
    private void OnCollisionExit (Collision collision) {
        isJumping = false;
    }
    private void OnCollisionEnter (Collision collision) {
        isJumping = true;
    }
}
