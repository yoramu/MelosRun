using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public GameObject Player;
    public bool isDirectionRight = false;
    private bool isSquat = false;
    public bool isMove = true;
    public float direction = 0;
    [SerializeField] private float speed = 5;
    private Rigidbody PlayerRigid;
    private CapsuleCollider PlayerCollider;
    public float adRotate = 500;
    float maxRotate = 90; //回転角の最大値//
    float tmpRotate = -90; //現在の回転角//
    float startRotation; //最初のグローバルY座標//
    void Start () {
        PlayerRigid = Player.GetComponent<Rigidbody> ();
        PlayerCollider = Player.GetComponent<CapsuleCollider> ();
        startRotation = transform.rotation.eulerAngles.y;
    }
    void Update () {
        float y = transform.rotation.eulerAngles.y;
        direction = Input.GetAxis ("Horizontal");
        if (isMove) {
            PlayerRigid.position += new Vector3 (direction * Time.deltaTime * speed, 0.0f, 0.0f);
        }
        //キャラの向き
        if (direction > 0 && isDirectionRight) {
            isDirectionRight = false;
        }
        if (direction < 0 && !isDirectionRight) {
            isDirectionRight = true;
        }
        if (direction < 0) {
            this.transform.Rotate (new Vector3 (0, 0, adRotate * 5) * Time.deltaTime);
            tmpRotate += (adRotate * Time.deltaTime * 5);
            if (tmpRotate >= maxRotate) {
                this.transform.rotation = Quaternion.Euler (-90, 0, startRotation + 180);
                tmpRotate = 90;
            }
        }
        if (direction > 0) {
            this.transform.Rotate (new Vector3 (0, 0, -adRotate * 5) * Time.deltaTime);
            tmpRotate -= (adRotate * Time.deltaTime * 5);
            if (tmpRotate <= maxRotate * -1) {
                this.transform.rotation = Quaternion.Euler (-90, 0, startRotation);
                tmpRotate = -90;
            }
        }

        //しゃがむ
        if (Input.GetKey ("down")) {
            //gameObject.transform.localScale = new Vector3 (1, 1, 0.7f);
            PlayerCollider.height = 0.7f;
            speed = 2;
        }
        if (Input.GetKeyUp ("down")) {
            PlayerCollider.height = 1.2f;
            speed = 5;
        }
    }
    public void IsMoveTrue () {
        this.isMove = true;
    }
    public void IsMoveFalse () {
        this.isMove = false;
    }
}