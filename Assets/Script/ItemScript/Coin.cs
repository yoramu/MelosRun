using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    private PlayerStatus PlayerStatus;
    private bool isMoveUp = false;
    [SerializeField] private float upTime;
    private float tmpTime;
    [SerializeField] private AudioClip coinSound;
    private AudioSource audioSource;
    private bool flag = true;
    void Start () {
        PlayerStatus = GameObject.Find ("chr_robot").GetComponent<PlayerStatus> ();
        upTime = 1;
        tmpTime = upTime;
        audioSource = GetComponent<AudioSource> ();
    }
    void Update () {
        transform.Rotate (new Vector3 (0, 0, 5));
        if (isMoveUp) {
            if (tmpTime > 0) {
                if (flag) {
                    audioSource.PlayOneShot (coinSound);
                    flag = false;
                }
                transform.position += new Vector3 (0, 0.01f, 0);
                transform.Rotate (new Vector3 (0, 0, 100));
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
            PlayerStatus.getScore (100);
            isMoveUp = true;
        }
    }
}