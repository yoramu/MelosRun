using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {
    public bool MoveUp = false;
    public float tmp = 0;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        transform.Rotate (new Vector3 (0, 0, 5));
        if (MoveUp) {
            if (tmp < 50) {
                transform.position += new Vector3 (0, 0.01f, 0);
                transform.Rotate (new Vector3 (0, 0, 100));
                tmp++;
            } else {
                tmp = 0;
                MoveUp = false;
                Destroy (gameObject);
            }
            //MoveUp = false;
        }
    }
    public void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag ("Player")) {
            MoveUp = true;
        }
    }
}
