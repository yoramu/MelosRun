﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    private bool isDirectionRight = false;
    private bool isSquat = false;
    public bool isMove { get; private set; } = true;
    private bool isRotate = true;
    public float direction { get; private set; } = 0;
    [SerializeField] private float speed = 5;
    private Rigidbody PlayerRigid;
    private CapsuleCollider PlayerCollider;
    [SerializeField] private float adRotate = 500;
    private float maxRotate = 90; //回転角の最大値//
    private float tmpRotate = -90; //現在の回転角//
    private float startRotation; //最初のグローバルY座標//
    void Start () {
        PlayerRigid = GetComponent<Rigidbody> ();
        PlayerCollider = GetComponent<CapsuleCollider> ();
        startRotation = transform.rotation.eulerAngles.y;
    }
    void Update () {
        float y = transform.rotation.eulerAngles.y;
        //キーを入力するとプレイヤーが左右に移動する
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
        //プレイヤーが移動する方向へ半周回る
        if (isRotate) {
            if (direction < 0) {
                this.transform.Rotate (new Vector3 (0, 0, adRotate) * Time.deltaTime);
                tmpRotate += (adRotate * Time.deltaTime);
                if (tmpRotate >= maxRotate) {
                    this.transform.rotation = Quaternion.Euler (-90, 0, startRotation + 180);
                    tmpRotate = 90;
                }
            }
            if (direction > 0) {
                this.transform.Rotate (new Vector3 (0, 0, -adRotate) * Time.deltaTime);
                tmpRotate -= (adRotate * Time.deltaTime);
                if (tmpRotate <= maxRotate * -1) {
                    this.transform.rotation = Quaternion.Euler (-90, 0, startRotation);
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