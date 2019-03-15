using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageRotationAxis : MonoBehaviour {
    // Start is called before the first frame update
    void Start () {
        GameObject.Find ("StageGroup").transform.parent = transform;
    }

    // Update is called once per frame
    void Update () {
        GameObject.Find ("StageGroup").transform.parent = transform;
        GameObject.Find ("StageGroup").transform.parent = null;
    }
}
