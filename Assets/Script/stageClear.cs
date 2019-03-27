using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stageClear : MonoBehaviour {
    public bool isClear { get; private set; } = false;
    private void OnTriggerEnter (Collider other) {
        if (other.gameObject.name == "chr_robot") {
            isClear = true;
        }
    }
}