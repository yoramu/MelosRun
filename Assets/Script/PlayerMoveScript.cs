using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour {
    public GameObject footCollider;
    public GameObject grabCollider;
    public GameObject Player;
    public const int MaxJumpCount = 2;
    public bool isJumping = false;
    public float Upspeed; //ジャンプのスピード
    public float direction = 0;

    private Rigidbody PlayerRigid;
    private bool directionFlag;
    // Start is called before the first frame update
    void Start () {
        PlayerRigid = Player.GetComponent<Rigidbody> ();
        footCollider = transform.GetChild (0).gameObject;
        grabCollider = transform.GetChild (1).gameObject;
        directionFlag = false;
    }

    // Update is called once per frame
    void Update () {
        JumpColliderScript j = footCollider.GetComponent<JumpColliderScript> ();
        GrabColliderScript g = grabCollider.GetComponent<GrabColliderScript> ();
        direction = Input.GetAxis ("Horizontal");
        PlayerRigid.position += new Vector3 (direction * Time.deltaTime * 5, 0.0f, 0.0f);
        //キャラの向き
        if (direction > 0 && directionFlag) {
            transform.Rotate (new Vector3 (0, 0, 180));
            directionFlag = false;
        }
        if (direction < 0 && !directionFlag) {
            transform.Rotate (new Vector3 (0, 0, -180));
            directionFlag = true;
        }
        //ジャンプフラグ
        if (j.jumpCount < MaxJumpCount && Input.GetKeyDown (KeyCode.Space)) {
            isJumping = true;
        }
        if (isJumping) {
            PlayerRigid.velocity = Vector3.zero;
            PlayerRigid.AddForce (0f, Upspeed, 0f);
            j.jumpCount++;
            isJumping = false;
        }
        //壁掴み
        if (g.isCanGrabWall && Input.GetKey (KeyCode.G)) {
            PlayerRigid.velocity = Vector3.zero;
            j.jumpCount = 0;
        }
    }
}
