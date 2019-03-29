using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    private bool isDirectionRight = false;
    private bool isSquat = false;
    public bool isMove { get; private set; } = true;
    private bool isRotate = true;
    public float direction { get; private set; } = 0;
    [SerializeField] private float speed = 5;
    private CapsuleCollider PlayerCollider;
    [SerializeField] private float adRotate = 500;
    private float maxRotate = 90; //回転角の最大値//
    private float tmpRotate = -90; //現在の回転角//
    private float startRotation; //最初のグローバルY座標//
    private float cameraRotationY;
    private float deltaTime;
    private GameObject Camera;
    void Start () {
        PlayerCollider = GetComponent<CapsuleCollider> ();
        startRotation = transform.rotation.eulerAngles.y;
        Camera = GameObject.Find ("MultipurposeCameraRig");

    }
    void FixedUpdate () {
        float y = transform.rotation.eulerAngles.y;
        //キーを入力するとプレイヤーが左右に移動する
        direction = Input.GetAxis ("Horizontal");
        deltaTime = Time.deltaTime;
        cameraRotationY = Camera.transform.eulerAngles.y;

        if (isMove) {
            transform.position += new Vector3 (
                direction * speed * Mathf.Cos (-1 * cameraRotationY * Mathf.Deg2Rad) * deltaTime,
                0.0f,
                direction * speed * Mathf.Sin (-1 * cameraRotationY * Mathf.Deg2Rad) * deltaTime);
        }
        //キャラの向き
        if (direction > 0 && isDirectionRight) {
            isDirectionRight = false;
        }
        if (direction < 0 && !isDirectionRight) {
            isDirectionRight = true;
        }
        //プレイヤーが移動する方向へ半周回る
        if (isRotate) {
            if (direction < 0) {
                this.transform.Rotate (new Vector3 (0, 0, adRotate) * deltaTime);
                tmpRotate += (adRotate * deltaTime);
                if (tmpRotate >= maxRotate) {
                    this.transform.rotation = Quaternion.Euler (-90, 0, cameraRotationY + startRotation + 180);
                    tmpRotate = 90;
                }
            }
            if (direction > 0) {
                this.transform.Rotate (new Vector3 (0, 0, -adRotate) * deltaTime);
                tmpRotate -= (adRotate * deltaTime);
                if (tmpRotate <= maxRotate * -1) {
                    this.transform.rotation = Quaternion.Euler (-90, 0, cameraRotationY + startRotation);
                    tmpRotate = -90;
                }
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
    public void IsRotateTrue () {
        this.isRotate = true;
    }
    public void IsRotateFalse () {
        this.isRotate = false;
    }
    public void IsDirectionRightFalse () {
        this.isDirectionRight = false;
    }
}
