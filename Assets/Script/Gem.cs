using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour {
    private PlayerStatus PlayerStatus;
    private bool isMoveUp = false;
    [SerializeField] private float upTime;
    private float tmpTime;
    void Start () {
        PlayerStatus = GameObject.Find ("chr_robot").GetComponent<PlayerStatus> ();
        upTime = 1;
        tmpTime = upTime;
    }
    void Update () {
        transform.Rotate (new Vector3 (0, 2, 0));
        if (isMoveUp) {
            if (tmpTime > 0) {
                transform.position += new Vector3 (0, 0.01f, 0);
                transform.Rotate (new Vector3 (0, 20, 0));
                tmpTime -= Time.deltaTime;
            } else {
                tmpTime = upTime;
                isMoveUp = false;
                Destroy (gameObject);
            }
        }
    }
    private void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag ("Player") && !isMoveUp) {
            PlayerStatus.getScore (1000);
            isMoveUp = true;
        }
    }
}
