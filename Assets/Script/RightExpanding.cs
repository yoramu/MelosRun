using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightExpanding : MonoBehaviour {
    private bool flag = true;
    private float para = 0.05f;
    private float interval = 0.05f;
    private float tmpTime1 = 0f;
    private float tmpTime2 = 0f;
    private int stackFlag = 0;
    private bool smallFlag = true;
    public float expandingSpeed = 1.0f;
    public float scale = 20;
    void Start () { }
    // Update is called once per frame
    void Update () {
        if (smallFlag) {
            tmpTime2 += Time.deltaTime;
            if (tmpTime2 >= interval) {
                if (transform.localScale.y > 1.1) {
                    transform.localScale += new Vector3 (0f, -1 * expandingSpeed / 2.0f, 0f);
                    transform.position += new Vector3 (-1 * expandingSpeed / 4.0f, 0f, 0f);
                }
                if (transform.localScale.y < 1.0) {
                    transform.localScale = new Vector3 (1, 1, 1);
                }
                tmpTime2 = 0;
            }
        }
    }
    private void OnTriggerStay (Collider other) {
        if (other.gameObject.name == "FootCollider") {
            smallFlag = false;
            tmpTime1 += Time.deltaTime;
            if (tmpTime1 >= interval) {
                if (stackFlag > 20) {
                    if (transform.localScale.y < scale) {
                        transform.localScale += new Vector3 (0f, expandingSpeed / 2.0f, 0f);
                        transform.position += new Vector3 (expandingSpeed / 4.0f, 0f, 0f);
                    }
                } else {
                    transform.localScale += new Vector3 (para, para, para);
                    para *= -1f;
                }
                stackFlag += 1;
                tmpTime1 = 0;
            }
        }
    }

    private void OnTriggerExit (Collider other) {
        if (other.gameObject.name == "FootCollider") {
            smallFlag = true;
            stackFlag = 0;
        }
    }
}