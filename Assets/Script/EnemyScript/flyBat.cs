using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyBat : MonoBehaviour {
    private int para;
    [SerializeField] private float y;
    void Update () {
        transform.Rotate (0, 3, 0);
        transform.localPosition = new Vector3 (transform.localPosition.x, Mathf.PingPong (Time.time * 10, 1) + y, transform.localPosition.z);
    }
}