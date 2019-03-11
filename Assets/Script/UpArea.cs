using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpArea : MonoBehaviour {

    // private float y = 0.001f;
    // void Update () {
    //     transform.localPosition.y += new Vector3 (0f, y, 0f);
    //     Debug.Log (transform.localPosition.y);
    //     if (Mathf.Abs (transform.localPosition.y) > 0.1) {
    //         y *= -1;
    //     }
    // }
    private void OnTriggerStay (Collider other) {
        if (other.gameObject.CompareTag ("Player")) {
            other.attachedRigidbody.AddForce (new Vector3 (0f, 0.1f, 0f), ForceMode.Impulse);
        }
    }
}