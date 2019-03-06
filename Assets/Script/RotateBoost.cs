using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBoost : MonoBehaviour {
    // Start is called before the first frame update

    private float interval = 0.05f;
    private float tempTime1 = 0.0f;
    private float z = 30f;
    private bool stoppingRotateFlag = false;

    private GameObject player;

    void Start () { }

    // Update is called once per frame
    void Update () {
        transform.Rotate (0f, 50f, 0f);
        if (stoppingRotateFlag) {
            if (z <= 10f) {
                player.transform.Rotate (new Vector3 (0f, 0f, z));
                //Debug.Log(player.transform.rotation.eulerAngles.y);
                float ptrz = player.transform.rotation.eulerAngles.y;
                if (265 < ptrz && ptrz < 275) {
                    stoppingRotateFlag = false;
                    z = 30f;
                    player.transform.rotation = Quaternion.Euler (-90, 0, 270);
                    player.GetComponent<PlayerMove> ().directionFlag = false;
                }
            } else {
                tempTime1 += Time.deltaTime;
                player.transform.Rotate (new Vector3 (0f, 0f, z));
                if (tempTime1 >= interval) {
                    z -= 1.0f;
                    tempTime1 = 0;
                }
            }
        }

    }

    private void OnTriggerStay (Collider other) {
        player = other.transform.root.gameObject;
        if (other.gameObject.name == "JumpCollider") {
            stoppingRotateFlag = false;
            z = 30f;
            player.transform.Rotate (new Vector3 (0f, 0f, 30f));
        }
    }

    private void OnTriggerExit (Collider other) {
        stoppingRotateFlag = true;
    }
}
