using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public GameObject Player;
    public bool isDirectionRight = false;
    public float direction = 0;
    private Rigidbody PlayerRigid;
    void Start () {
        PlayerRigid = Player.GetComponent<Rigidbody> ();
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
    }
}