using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpArea : MonoBehaviour {
    [SerializeField] private float y;
    void Update () {
        // transform.localPosition = new Vector3 (transform.position.x, Mathf.PingPong (Time.time, 0.5f) + transform.position.y, transform.position.z);
    }
    private void OnTriggerStay (Collider other) {
        if (other.gameObject.CompareTag ("Player")) {
            other.attachedRigidbody.AddForce (new Vector3 (0f, y, 0f), ForceMode.Impulse);
        }
    }
}