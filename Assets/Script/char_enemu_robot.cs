using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class char_enemu_robot : MonoBehaviour {
    // Start is called before the first frame update
    private GameObject child;
    private float y;
    void Start () {
        child = transform.FindChild ("control prop").gameObject;
    }

    // Update is called once per frame
    void Update () {

        child.transform.Rotate (new Vector3 (0f, 50f, 0f));

    }
}