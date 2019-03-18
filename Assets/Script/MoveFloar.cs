using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloar : MonoBehaviour {
    private bool flag = false;
    private bool flag2 = true;
    private float para = 0.05f;
    private float interval = 0.05f;
    private float tmpTime1 = 0f;
    private int stackFlag = 0;
    private bool smallFlag = true;
    private GameObject Player;
    private Rigidbody rb;
    void Start () {
        rb = GetComponent<Rigidbody> ();
        Player = GameObject.Find ("chr_robot");
    }
    void Update () {
        if (flag && flag2) {
            // rb.velocity = new Vector3 (1f, 0, 0);
            Player.transform.parent = transform;
            iTween.MoveBy (this.gameObject, iTween.Hash ("x", 3.7333f - 0.9603f, "y", 0.58035f + 2.1164f, "z", -3.1429 + 3.1429f, "time", 5));
            flag2 = false;
            // Player.transform.parent = null;
        }
    }

    private void OnTriggerStay (Collider other) {
        if (other.gameObject.name == "FootCollider") {
            smallFlag = false;
            tmpTime1 += Time.deltaTime;
            if (tmpTime1 >= interval) {
                if (stackFlag > 19) {
                    flag = true;
                } else {
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
    }
}