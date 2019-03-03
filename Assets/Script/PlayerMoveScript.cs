using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour {
    public GameObject footCollider;
    public GameObject Player;
    public const int MaxJumpCount = 2;
    public bool isJumping = false;
    public float Upspeed; //ジャンプのスピード
    public float speed = 0;

    private Rigidbody PlayerRigid;
    // Start is called before the first frame update
    void Start () {
        PlayerRigid = Player.GetComponent<Rigidbody> ();
        footCollider = transform.GetChild (0).gameObject;
    }

    // Update is called once per frame
    void Update () {
        JumpColliderScript j = footCollider.GetComponent<JumpColliderScript> ();
        speed = Input.GetAxis ("Horizontal");
        Debug.Log (speed);
        if (speed < 0) {
            transform.rotation = Quaternion.Euler (-90f, -90f, 180f);
        } else {
            transform.rotation = Quaternion.Euler (-90f, -90f, -180f);
        }
        PlayerRigid.position += new Vector3 (speed * Time.deltaTime * 5, 0.0f, 0.0f);

        if (j.jumpCount < MaxJumpCount && Input.GetKeyDown (KeyCode.Space)) {
            isJumping = true;
        }
        if (isJumping) {
            PlayerRigid.velocity = Vector3.zero;
            PlayerRigid.AddForce (0f, Upspeed, 0f);
            j.jumpCount++;
            isJumping = false;
        }
    }
}
