using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToStage : MonoBehaviour {
    private void OnTriggerEnter (Collider other) {
        if (other.gameObject.name == "chr_robot") {
            SceneManager.LoadScene ("StageScene");
        }
    }
}