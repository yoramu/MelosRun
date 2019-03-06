using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCollider : MonoBehaviour {
    public int jumpCount = 0;
    // Start is called before the first frame update
    public void OnTriggerEnter (Collider other) {
        jumpCount = 0;
    }
}
