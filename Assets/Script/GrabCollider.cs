using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCollider : MonoBehaviour {
    public bool isCanGrabWall = false;
    public void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag ("GrabWall")) {
            isCanGrabWall = true;
        }
    }
    public void OnTriggerExit (Collider other) {
        if (other.gameObject.CompareTag ("GrabWall")) {
            isCanGrabWall = false;
        }
    }
}
