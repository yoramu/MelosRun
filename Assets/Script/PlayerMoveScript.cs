using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour {
    public GameObject footCollider;
    public GameObject Player;
    public const int MaxJumpCount = 2;
    public bool isJumping = false;
    public float Upspeed; //ジャンプのスピード
    public float direction = 0;

    private Rigidbody PlayerRigid;
    // Start is called before the first frame update
    public bool directionFlag;
    void Start () {
        PlayerRigid = Player.GetComponent<Rigidbody> ();
        footCollider = transform.GetChild (0).gameObject;
        directionFlag = false;
    }

    // Update is called once per frame
    void Update () {
        JumpColliderScript j = footCollider.GetComponent<JumpColliderScript> ();
        direction = Input.GetAxis ("Horizontal");
        PlayerRigid.position += new Vector3 (direction * Time.deltaTime * 5, 0.0f, 0.0f);

        if (direction >= 0 && directionFlag) {
            transform.Rotate (new Vector3 (0, 0, 180));
            directionFlag = false;
        }
        if (direction < 0 && !directionFlag) {
            transform.Rotate (new Vector3 (0, 0, -180));
            directionFlag = true;
        }

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
