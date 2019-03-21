using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iTweensTest : MonoBehaviour {
    private bool flag = false;
    private float para = 0.05f;
    private float interval = 0.05f;
    private float tmpTime1 = 0f;
    private float tmpTime2 = 0f;
    private int stackFlag = 0;
    [SerializeField] private float movingSpeed = 250f;
    [SerializeField] private float scale = 20;
    private float x, y, z;
    private GameObject Player;
    void Start () {
        Player = GameObject.Find ("chr_robot");
    }
    void Update () {

        if (flag) {
            // Player.transform.parent = transform;
            iTween.RotateBy (gameObject, iTween.Hash ("x", 0.25f, "time", 3));

            // iTween.MoveBy (this.gameObject, iTween.Hash ("x", 30f, "time", 60));
        }

    }
    private void OnTriggerStay (Collider other) {
        if (other.gameObject.name == "FootCollider") {
            tmpTime1 += Time.deltaTime;
            if (tmpTime1 >= interval) {
                if (stackFlag > 20) {
                    flag = true;
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
        Player.transform.parent = null;
        flag = false;
        stackFlag = 0;
    }
}