using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpArea : MonoBehaviour {

    private void OnTriggerStay (Collider other) {
        if (other.gameObject.CompareTag ("Player")) {
            other.attachedRigidbody.AddForce (new Vector3 (0f, 0.1f, 0f), ForceMode.Impulse);
        }
    }
}