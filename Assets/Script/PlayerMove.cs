using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public GameObject Player;
    public bool isDirectionRight = false;
    private bool isSquat = false;
    [SerializeField] private float direction = 0;
    private Rigidbody PlayerRigid;
    private CapsuleCollider PlayerCollider;
    void Start () {
        PlayerRigid = Player.GetComponent<Rigidbody> ();
        PlayerCollider = Player.GetComponent<CapsuleCollider> ();
    }
    void Update () {
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
        //しゃがむ
        if (Input.GetKey ("down")) {
            //gameObject.transform.localScale = new Vector3 (1, 1, 0.7f);
            PlayerCollider.height = 0.7f;
        }
        if (Input.GetKeyUp ("down")) {
            PlayerCollider.height = 1.2f;
        }
    }
}
