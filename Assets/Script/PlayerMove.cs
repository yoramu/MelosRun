using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public GameObject footCollider;
    public GameObject grabCollider;
    public GameObject Player;
    public const int MaxJumpCount = 2;
    public bool isJumping = false;
    public float Upspeed; //ジャンプのスピード
    public float direction = 0;

    private Rigidbody PlayerRigid;
    public bool isDirectionRight = false;
    // Start is called before the first frame update
    void Start () {
        PlayerRigid = Player.GetComponent<Rigidbody> ();
        footCollider = transform.GetChild (0).gameObject;
        grabCollider = transform.GetChild (1).gameObject;
    }

    // Update is called once per frame
    void Update () {
        JumpCollider j = footCollider.GetComponent<JumpCollider> ();
        GrabCollider g = grabCollider.GetComponent<GrabCollider> ();
        direction = Input.GetAxis ("Horizontal");
        PlayerRigid.position += new Vector3 (direction * Time.deltaTime * 5, 0.0f, 0.0f);
        //キャラの向き
        if (direction > 0 && isDirectionRight) {
            transform.rotation = Quaternion.Euler (-90, 0, 270);
            isDirectionRight = false;
        }
        if (direction < 0 && !isDirectionRight) {
            transform.rotation = Quaternion.Euler (-90, 0, 90);
            isDirectionRight = true;
        }
        //ジャンプフラグ
        Debug.Log (j.jumpCount);
        //Debug.Log ("E" + j.isExitCollider);
        //Debug.Log (isJumping);
        if (j.jumpCount < MaxJumpCount && Input.GetKeyDown (KeyCode.Space)) {
            PlayerRigid.velocity = Vector3.zero;
            PlayerRigid.AddForce (0f, Upspeed, 0f);
            isJumping = true;
            if (j.isExitCollider) {
                j.jumpCount++;
            }
        }
        //壁掴み
        if (g.isCanGrabWall && Input.GetKey (KeyCode.G)) {
            PlayerRigid.velocity = Vector3.zero;
            j.jumpCount = 0;
        }
    }
}
