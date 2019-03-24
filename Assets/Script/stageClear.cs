using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stageClear : MonoBehaviour {
    public bool isClear { get; private set; } = false;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
    private void OnTriggerEnter (Collider other) {
        if (other.gameObject.name == "chr_robot") {
            isClear = true;
            //SceneManager.LoadScene ("StageScene");
        }
    }
}
