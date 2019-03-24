using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashArea : MonoBehaviour {

    private void OnTriggerStay (Collider other) {
        if (other.gameObject.CompareTag ("Player")) {
            other.attachedRigidbody.AddForce (new Vector3 (0.25f, 0f, 0f), ForceMode.Impulse);
        }
    }
}