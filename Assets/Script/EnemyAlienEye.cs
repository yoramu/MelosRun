using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlienEye : MonoBehaviour {
    private bool isDirectionRight = false;
    private bool isSquat = false;
    private bool isMove = true;
    private bool isRotate = true;
    public float direction { get; private set; } = 0;
    [SerializeField] private float speed = 5;
    private Rigidbody PlayerRigid;
    [SerializeField] private float adRotate = 500;
    private float maxRotate = 90; //回転角の最大値//
    private float tmpRotate = -90; //現在の回転角//
    private float startRotation; //最初のグローバルY座標//
    void Start () {
        PlayerRigid = GetComponent<Rigidbody> ();
        startRotation = transform.rotation.eulerAngles.y;
    }
    void Update () {
        float y = transform.rotation.eulerAngles.y;
        direction = -0.1f;
        if (isMove) {
            PlayerRigid.transform.localPosition += new Vector3 (direction * Time.deltaTime * speed, 0.0f, 0.0f);
        }
        /**
        //キャラの向き
        if (direction > 0 && isDirectionRight) {
            isDirectionRight = false;
        }
        if (direction < 0 && !isDirectionRight) {
            isDirectionRight = true;
        }
        if (isRotate) {
            if (direction < 0) {
                this.transform.Rotate (new Vector3 (0, 0, adRotate) * Time.deltaTime);
                tmpRotate += (adRotate * Time.deltaTime);
                if (tmpRotate >= maxRotate) {
                    this.transform.rotation = Quaternion.Euler (180, startRotation + 180, 0);
                    tmpRotate = 90;
                }
            }
            if (direction > 0) {
                this.transform.Rotate (new Vector3 (0, 0, -adRotate) * Time.deltaTime);
                tmpRotate -= (adRotate * Time.deltaTime);
                if (tmpRotate <= maxRotate * -1) {
                    this.transform.rotation = Quaternion.Euler (180, startRotation - 0, 0);
                    tmpRotate = -90;
                }
            }
        }
        */
    }
}
