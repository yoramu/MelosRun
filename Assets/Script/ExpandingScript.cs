using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandingScript : MonoBehaviour {
    // Start is called before the first frame update

    private bool flag = true;
    private float para = 0.05f;
    private float interval = 0.05f;
    private float tmpTime1 = 0f;
    private float tmpTime2 = 0f;
    private int stackFlag = 0;
    private bool smallFlag = true;
    void Start () { }

    // Update is called once per frame
    void Update () {
        Debug.Log (stackFlag);
        if (smallFlag) {
            tmpTime2 += Time.deltaTime;
            if (tmpTime2 >= interval) {
                if (transform.localScale.y > 1.1) {
                    transform.localScale += new Vector3 (0f, -1f, 0f);
                }
                if (transform.localScale.y < 1.0) {
                    transform.localScale = new Vector3 (1, 1, 1);
                }
                tmpTime2 = 0;
            }
        }
    }

    private void OnTriggerStay (Collider other) {
        if (other.gameObject.name == "JumpCollider") {
            smallFlag = false;
            tmpTime1 += Time.deltaTime;
            if (tmpTime1 >= interval) {
                if (stackFlag > 40) {
                    transform.localScale += new Vector3 (0f, 0.5f, 0f);
                }
                transform.localScale += new Vector3 (para, para, para);
                para *= -1f;
                stackFlag += 1;
                tmpTime1 = 0;
            }
        }
    }

    private void OnTriggerExit (Collider other) {
        if (other.gameObject.name == "JumpCollider") {
            smallFlag = true;
            if (stackFlag > 41) {
                stackFlag = 0;
            }
        }
    }
}
