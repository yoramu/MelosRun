﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    public PlayerStatus PlayerStatus;
    private bool isMoveUp = false;
    [SerializeField] private float upTime;
    private float tmpTime;
    // Start is called before the first frame update
    void Start () {
        PlayerStatus = GameObject.Find ("chr_robot").GetComponent<PlayerStatus> ();
        upTime = 1;
        tmpTime = upTime;
    }

    // Update is called once per frame
    void Update () {
        transform.Rotate (new Vector3 (0, 0, 5));
        if (isMoveUp) {
            if (tmpTime > 0) {
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
    public void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag ("Player") && !isMoveUp) {
            PlayerStatus.score += 100;
            isMoveUp = true;
        }
    }
}
