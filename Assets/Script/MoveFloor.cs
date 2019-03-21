using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour {
    private bool flag = false;
    private bool flag2 = true;
    private float para = 0.05f;
    private float interval = 0.05f;
    private float tmpTime1 = 0f;
    private int stackFlag = 0;
    private bool smallFlag = true;
    private GameObject Player;
    private Rigidbody rb;
    [SerializeField] private float x = 0, y = 0, z = 0, moveTime = 0;
    private Vector3 localScale;
    private Vector3 Lposition;
    void Start () {
        rb = GetComponent<Rigidbody> ();
        Player = GameObject.Find ("chr_robot");
        localScale = transform.localScale;
        Lposition = transform.localPosition;
        x -= Lposition.x;
        y -= Lposition.y;
        z -= Lposition.z;
    }
    void Update () {
        Debug.Log (Lposition);
        if (flag && flag2) {
            Player.transform.parent = transform;
            iTween.MoveBy (this.gameObject, iTween.Hash ("x", x, "y", y, "z", z, "time", moveTime));
            transform.localScale = localScale;
            flag2 = false;
            x *= -1;
            y *= -1;
            z *= -1;
        }
    }
    private void OnTriggerStay (Collider other) {
        if (other.gameObject.name == "FootCollider") {
            smallFlag = false;
            tmpTime1 += Time.deltaTime;
            if (tmpTime1 >= interval) {
                if (stackFlag > 20) {
                    flag = true;
                } else if (stackFlag > 4) {
                    if (flag2) {
                        transform.localScale += new Vector3 (para, para, para);
                        para *= -1f;
                    }
                }
                stackFlag += 1;
                tmpTime1 = 0;
            }
        }
    }
    private void OnTriggerExit (Collider other) {
        Player.transform.parent = null;
        flag = false;
        stackFlag = 0;
        flag2 = true;
    }
}